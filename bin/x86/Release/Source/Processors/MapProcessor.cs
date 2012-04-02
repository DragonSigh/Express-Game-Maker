//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using EGMGame.Extensions;
using FarseerPhysics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision;
using FarseerPhysics.Factories;
using System.Xml.Serialization;
using FarseerPhysics.Controllers;
using FarseerPhysics.Common;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Common.PolygonManipulation;
namespace EGMGame.Processors
{
    /// <summary>
    /// Updates and draws a map.
    /// </summary>

    public class MapProcessor
    {
        [XmlIgnore, DoNotSerialize]
        public MapData Data
        {
            get
            {
                if (Global.Project.MapsInfo.Count == 0) return null;
                return (data == null ? data = Marshal.LoadData<MapData>(Global.Project.MapsInfo[ID].Name + ".egmmap") : data);
            }
            set { data = value; }
        } MapData data;
        public int ID;

        #region Field: Processors, Map Fixtures, Tile Frame Sync
        /// <summary>
        /// A drawable component class based on layer
        /// </summary>
        public List<List<Drawable>> Processors = new List<List<Drawable>>();
        // Physics Storage
        [XmlIgnore, DoNotSerialize]
        public List<Body> MapBodies = new List<Body>();
        /// <summary>
        /// Tile Frame Sync
        /// </summary>
        List<int> TileFrameSync = new List<int>();
        /// <summary>
        /// Shader Process
        /// </summary>
        public ShaderProcessor ShaderProcess = new ShaderProcessor();

        Dictionary<int, Texture2D> Textures = new Dictionary<int, Texture2D>();
        /// <summary>
        /// Gravity
        /// </summary>
        public Vector2 Gravity;
        public GravityPoint[] GravityPoints = new GravityPoint[101];
        PointGravityController[] GravityControllers = new PointGravityController[101];
        // Garbage
        private Vector2 TileSize = new Vector2();
        #endregion

        #region Constructor and Setup
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapData"></param>
        public MapProcessor()
        {
        }
        /// <summary>
        /// Initialize Map
        /// </summary>
        /// <param name="mapData"></param>
        public MapProcessor(MapData mapData)
        {
            data = mapData;
            Setup();
        }
        /// <summary>
        /// Setup Map
        /// </summary>
        public void Setup()
        {
            try
            {
#if DEBUG
                Global.Log("Setting up map...");
#endif
                Textures.Clear();
                // Make sure map data exists
                if (data != null)
                {
                    if (Global.Instance.Player.Count > 0)
                        Global.Instance.ActiveCamera.TrackingObject = Global.Instance.Player[0];
                    ID = data.ID;
                    Global.Instance.CurrentMap = this;
                    // Autorun 
                    Global.Instance.AutorunID = -1;
                    // Clean Up
                    CleanUpPrevious();
                    // Set Gravity
                    if (data.CustomGravity)
                        Global.World.Gravity = Gravity = data.Gravity;
                    else
                        Global.World.Gravity = Gravity = Global.Project.Gravity;
                    // Setup Collision Detection
                    Body body;
                    int realIndex;
                    TilesetData tileset = null;
                    TileData tile;
                    Vertices clone, rotatedClone;
                    List<TileData> fusedTiles = new List<TileData>();

                    for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
                    {
                        // Tiles
                        for (int tileIndex = 0; tileIndex < data.Layers[layerIndex].Tiles.Count; tileIndex++)
                        {
                            tile = data.Layers[layerIndex].Tiles[tileIndex];
                            if (tileset == null || tileset.ID != tile.TilesetID)
                                tileset = GameData.Tilesets.GetData(tile.TilesetID);
                            if (tileset != null)
                            {
                                if (!Textures.ContainsKey(tileset.ID))
                                    Textures[tileset.ID] = Content.Texture2D(tileset.MaterialId);
                                int row = (int)Textures[tileset.ID].Height / (int)tileset.Grid.Y;
                                realIndex = (int)(tile.DisplayRect.X / tileset.Grid.X) * row + (int)(tile.DisplayRect.Y / tileset.Grid.Y);
                                body = null;
                                // Only add if there is a body
                                if (tileset.Tiles[realIndex].Body.Count > 0)
                                {
                                    // Create Body
                                    clone = new Vertices(tileset.Tiles[realIndex].Body);

                                    if (clone.Count < 3)
                                    {
                                        // > EGM WARNING
                                        Global.Log("Warning > All tile collision nodes must be more than 2. \n        > Tileset: " + tileset.Name + "\n        > Index : " + realIndex.ToString());

                                        Vector2 n = clone[0];
                                        n.X += 2;
                                        n.Y += 2;
                                        clone.Add(n);
                                        if (clone.Count < 3)
                                        {
                                            n = clone[2];
                                            n.X += 2;
                                            n.Y += 2;
                                            clone.Add(n);
                                        }
                                    }

                                    clone = Vertices.Simplify(clone);
                                    Vector2 size = new Vector2(tile.Width, tile.Height);
                                    clone.Scale(ref tile.Scale);
                                    Vector2 v = -(tile.Scale - new Vector2(1, 1)) * size / 2;
                                    clone.Translate(ref v);

                                    // Create Body
                                    rotatedClone = new Vertices(clone);

                                    rotatedClone.Rotate(MathHelper.ToRadians(tile.Rotation), size / 2);

                                    Vector2 centroid = -clone.GetCentroid();
                                    clone.Translate(ref centroid);

                                    tile.origin = -rotatedClone.GetCentroid();

                                    List<Vertices> vertices = BayazitDecomposer.ConvexPartition(clone);

                                    //scale the vertices from graphics space to sim space
                                    Vector2 vertScale = new Vector2(ConvertUnits.ToSimUnits(1)) * 1f;
                                    foreach (Vertices v1 in vertices)
                                    {
                                        v1.Scale(ref vertScale);
                                    }
                                    if (vertices.Count > 1)
                                        body = BodyFactory.CreateCompoundPolygon(Global.World, vertices, (tileset.Tiles[realIndex].Mass > 0 ? tileset.Tiles[realIndex].Mass : 1));
                                    else
                                        body = BodyFactory.CreatePolygon(Global.World, vertices[0], (tileset.Tiles[realIndex].Mass > 0 ? tileset.Tiles[realIndex].Mass : 1));

                                    // Physic Settings
                                    body.UserData = tileset.Tiles[realIndex];
                                    body.IsStatic = tileset.Tiles[realIndex].IsStatic;
                                    body.IgnoreGravity = tileset.Tiles[realIndex].IgnoreGravity;
                                    body.LayerIndex = layerIndex;
                                    body.Friction = tileset.Tiles[realIndex].Friction;
                                    body.LinearDamping = tileset.Tiles[realIndex].LinearDrag;
                                    body.AngularDamping = tileset.Tiles[realIndex].RotationalDrag;
                                    body.Restitution = tileset.Tiles[realIndex].Bounce;
                                    body.CollisionCategories = Category.All;
                                    body.CollidesWith = Category.All;
                                    body.Mass = (tileset.Tiles[realIndex].Mass > 0 ? tileset.Tiles[realIndex].Mass : 1);
                                    // Get Offset
                                    tile.offset = -(size / 2 + tile.origin);
                                    body.SetTransform(ConvertUnits.ToSimUnits(tile.origin), MathHelper.ToRadians(tile.Rotation));
                                    body.Position = ConvertUnits.ToSimUnits(tile.Position - (size / 2 + tile.origin));
                                    tile.body = body;

                                    // Store Body
                                    MapBodies.Add(body);

                                }
                            }
                        }
                        // Add Events
                        EventProcessor eProcessor;
                        foreach (KeyValuePair<int, EventData> eventPair in data.Layers[layerIndex].Events)
                        {
                            eProcessor = new EventProcessor(eventPair.Value, data.ID);
                            eProcessor.DrawOrderChanged += new EventHandler(OnDrawOrderChanged);
                            eProcessor.LayerIndex = layerIndex;
                            Processors[layerIndex].Add(eProcessor);
                            eProcessor.UniqueID = (eProcessor.IsPlayer ? -1 : Global.Instance.EventUniqueIDCount++);
                        }
                        // Add Collision Overlay
                        for (int c = 0; c < data.Layers[layerIndex].CollisionData.Count; c++)
                        {
                            // Create Body
                            clone = new Vertices(data.Layers[layerIndex].CollisionData[c]);

                            if (clone.Count < 3)
                            {
                                // > EGM WARNING
                                Global.Log("Warning > All tile collision nodes must be more than 2.\n");

                                Vector2 n = clone[0];
                                n.X += 2;
                                n.Y += 2;
                                clone.Add(n);
                                if (clone.Count < 3)
                                {
                                    n = clone[2];
                                    n.X += 2;
                                    n.Y += 2;
                                    clone.Add(n);
                                }
                            }

                            clone = Vertices.Simplify(clone);

                            List<Vertices> vertices = BayazitDecomposer.ConvexPartition(clone);

                            //scale the vertices from graphics space to sim space
                            Vector2 vertScale = new Vector2(ConvertUnits.ToSimUnits(1)) * 1f;
                            foreach (Vertices v1 in vertices)
                            {
                                v1.Scale(ref vertScale);
                            }
                            if (vertices.Count > 1)
                                body = BodyFactory.CreateCompoundPolygon(Global.World, vertices, (data.Layers[layerIndex].CollisionData[c].Mass > 0 ? data.Layers[layerIndex].CollisionData[c].Mass : 1));
                            else
                                body = BodyFactory.CreatePolygon(Global.World, vertices[0], (data.Layers[layerIndex].CollisionData[c].Mass > 0 ? data.Layers[layerIndex].CollisionData[c].Mass : 1));

                            // Physic Settings
                            body.LayerIndex = layerIndex;
                            body.Friction = data.Layers[layerIndex].CollisionData[c].Friction;
                            body.Restitution = data.Layers[layerIndex].CollisionData[c].Bounce;
                            body.CollisionCategories = Category.All;
                            body.CollidesWith = Category.All;
                            body.Mass = (data.Layers[layerIndex].CollisionData[c].Mass > 0 ? data.Layers[layerIndex].CollisionData[c].Mass : 1);

                            body.UserData = data.Layers[layerIndex].CollisionData[c];
                            // Store Body
                            MapBodies.Add(body);
                        }
                    }
                    // Add Player
                    if (Global.Instance.Player.Count > 0)
                    {
                        if (GameData.Player.MapID == data.ID || Global.Instance.Player[0].MapID == data.ID)
                        {
                            for (int i = 0; i < Global.Instance.Player.Count; i++)
                            {
                                Global.Instance.Player[i].MapID = data.ID;
                                Global.Instance.Player[i].LayerIndex = GameData.Player.LayerIndex;
                                Global.Instance.Player[i].DrawOrderChanged += new EventHandler(OnDrawOrderChanged);
                                if (Global.TransferPlayer) Global.Instance.Player[i].SetupCollisionBody();
                                // Add Player
                                AddProcessor(Global.Instance.Player[i]);
                            }
                        }
                        else
                            Global.Instance.Player[0] = null;
                    }
                }
                // Map Effects
                if (data.EnableBGM && data.BGM != null)
                {
                    AudioSettings settings;
                    settings = new AudioSettings((int)data.BGM.Value[2], (int)data.BGM.Value[3], (bool)data.BGM.Value[4], (float)data.BGM.Value[5], (float)data.BGM.Value[6], (float)data.BGM.Value[7], (bool)data.BGM.Value[8]);
                    if (!Global.Instance.AudioManager.Contains((int)data.BGM.Value[1], (int)data.BGM.Value[0]))
                        Global.Instance.AudioManager.Play((int)data.BGM.Value[0], (int)data.BGM.Value[1], settings);
                }
                if (data.EnableBGS && data.BGS != null)
                {
                    AudioSettings settings;
                    settings = new AudioSettings((int)data.BGS.Value[2], (int)data.BGS.Value[3], (bool)data.BGS.Value[4], (float)data.BGS.Value[5], (float)data.BGS.Value[6], (float)data.BGS.Value[7], (bool)data.BGS.Value[8]);
                    if (!Global.Instance.AudioManager.Contains((int)data.BGS.Value[1], (int)data.BGS.Value[0]))
                        Global.Instance.AudioManager.Play((int)data.BGS.Value[0], (int)data.BGS.Value[1], settings);
                }
                if (data.EnableFog && data.Fog != null)
                {
                    Global.Instance.FogMaterialID = (int)data.Fog.Value[0];
                    Global.Instance.FogColor = (Color)data.Fog.Value[1];
                    Global.Instance.FogSpeed = (int)data.Fog.Value[2];
                }
                if (data.EnableTint && data.Tint != null)
                {
                    GameScreen.ResetFade((Color)data.Tint.Value[0]);
                    if (!(bool)data.Tint.Value[3])
                        Global.TintEffect(EffectType.Tint, ScreenType.Gameplay, (Color)data.Tint.Value[0], (int)data.Tint.Value[1]);
                    else
                        Global.TintEffect(EffectType.Tint, ScreenType.Global, (Color)data.Tint.Value[0], (int)data.Tint.Value[1]);
                }
                // Initialize all processors
                bool newLayers = (Global.Instance.LayerBackroundOffset == null);
                if (newLayers) Global.Instance.LayerBackroundOffset = new Vector2[data.Layers.Count];
                for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
                {
                    //for (int drawIndex = 0; drawIndex < Processors[layerIndex].Count; drawIndex++)
                    //{
                    //    Processors[layerIndex][drawIndex].Update(ScreenManager.GameTime);
                    //}
                    // Background Layer
                    if (newLayers) Global.Instance.LayerBackroundOffset[layerIndex] = new Vector2();
                }

                Update(null);
#if DEBUG
                Global.Log("Map setup...");
#endif
            }
            catch (Exception ex)
            {
                Error.Do(ex);
            }
        }
        List<Vertices> drawPlease = new List<Vertices>();
        /// <summary>
        /// Clean up previous objects.
        /// </summary>
        private void CleanUpPrevious()
        {
            Global.Instance.LayerBackroundOffset = null;
            // Event Unique ID Count
            Global.Instance.EventUniqueIDCount = 0;
            for (int layerIndex = 0; layerIndex < Processors.Count; layerIndex++)
            {
                for (int eventIndex = 0; eventIndex < Processors[layerIndex].Count; eventIndex++)
                {
                    if (Processors[layerIndex][eventIndex] is EventProcessor && !((EventProcessor)Processors[layerIndex][eventIndex]).IsPlayer)
                        Processors[layerIndex][eventIndex].Dispose();
                    else if (!(Processors[layerIndex][eventIndex] is EventProcessor))
                        Processors[layerIndex][eventIndex].Dispose();
                }
            }
            // Clear Drawable Components
            Processors.Clear();

            for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
            {
                // DrawableComponent
                Processors.Add(new List<Drawable>());
            }
            // Clear Physics
            Global.World.Clear();

            MapBodies.Clear();
            // Clear Cache
            Content.Clear();
            // Force Collect Garbase while transitioning
            GC.Collect();
            // Setup Player
            for (int i = 0; i < Global.Instance.Player.Count; i++)
            {
                Global.Instance.Player[i].ClearBodies();
                Global.Instance.Player[i].SetupCollisionBody();
            }
        }
        /// <summary>
        /// Reload Map
        /// </summary>
        public void Reload()
        {
            Setup();
        }
        #endregion

        #region Events: On Draw Order changed.
        /// <summary>
        /// Called when a draw order has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnDrawOrderChanged(object sender, EventArgs args)
        {
            Drawable component = (Drawable)sender;
            this.Processors[component.LayerIndex].Remove(component);
            int index = Processors[component.LayerIndex].BinarySearch(component, DrawableComponentOrderComparer.Default);
            if (index < 0)
            {
                index = ~index;
                while ((index < this.Processors[component.LayerIndex].Count) && (this.Processors[component.LayerIndex][index].DrawOrder == component.DrawOrder))
                {
                    index++;
                }
                Processors[component.LayerIndex].Insert(index, component);
            }
        }
        #endregion

        #region Update: Map > Processes
        /// <summary>
        /// Update the map.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (data != null)
            {
                // Update Timers
                foreach (Timer timer in Global.Instance.Timers.Values)
                {
                    timer.Update(gameTime);
                }
                // Erased processors
                int processorCount;
                // Update Components  
                for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
                {
                    if (!data.Layers[layerIndex].IsVisible)
                        continue;
                    if (layerIndex < Processors.Count)
                    {
                        processorCount = Processors[layerIndex].Count;
                        for (int drawIndex = 0; drawIndex < processorCount; drawIndex++)
                        {
                            if (Processors[layerIndex].Count > drawIndex)
                            {
                                if (Processors[layerIndex][drawIndex].Erase)
                                {
                                    Processors[layerIndex][drawIndex].Dispose();
                                    Processors[layerIndex].RemoveAt(drawIndex);
                                    drawIndex--; processorCount--;
                                }
                                else
                                    Processors[layerIndex][drawIndex].Update(gameTime);
                            }
                        }
                    }
                }
            }
            // Reload Map
            if (Global.ReloadMap)
            {
                Global.ReloadMap = false;
                // Reset Player
                Global.Instance.Player[0].ResetPlayer();
                Reload();
            }
        }
        #endregion

        #region Draw: Map Tiles, Background, Processors
        /// <summary>
        /// Draw the map.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime)
        {
            // Draw Map
            if (data != null) DrawMap(gameTime);
            //// Draw Menus
            //for (int menuIndex = 0; menuIndex < Global.Menus.Count; menuIndex++)
            //{
            //    Global.Menus[menuIndex].Draw(gameTime);
            //}

            for (int j = 0; j < drawPlease.Count; j++)
            {
                int verticeCount = drawPlease[j].Count;
                for (int i = 0; i < verticeCount; i++)
                {
                    if (i < verticeCount - 1)
                    {
                        GraphicsHelper.DrawLine(drawPlease[j][i + 1], drawPlease[j][i], Color.Yellow, 1, GraphicsHelper.Texture);
                    }
                    else
                    {
                        GraphicsHelper.DrawLine(drawPlease[j][i], drawPlease[j][0], Color.Yellow, 1, GraphicsHelper.Texture);

                    }
                }
            }
        }
        /// <summary>
        /// Draw Map
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        private void DrawMap(GameTime gameTime)
        {
            TileFrameSync.Clear();

            Rectangle streamArea = new Rectangle(Global.Instance.ActiveCamera.DrawRectangle.X, Global.Instance.ActiveCamera.DrawRectangle.Y, Global.Instance.ActiveCamera.DrawRectangle.Width, Global.Instance.ActiveCamera.DrawRectangle.Height);

            for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
            {
                if (!data.Layers[layerIndex].IsVisible)
                    continue;
                // Draw the layer's background
                DrawLayerBackground(data.Layers[layerIndex], layerIndex);
                // Get Tiles
                // Draw Tiles
                for (int tileIndex = 0; tileIndex < data.Layers[layerIndex].Tiles.Count; tileIndex++)
                {
                    if ((((data.Layers[layerIndex].Tiles[tileIndex].Position.X < (streamArea.X + streamArea.Width)) && (streamArea.X < (data.Layers[layerIndex].Tiles[tileIndex].Position.X + data.Layers[layerIndex].Tiles[tileIndex].Width))) && (data.Layers[layerIndex].Tiles[tileIndex].Position.Y < (streamArea.Y + streamArea.Height))) && (streamArea.Y < (data.Layers[layerIndex].Tiles[tileIndex].Position.Y + data.Layers[layerIndex].Tiles[tileIndex].Height)))
                        DrawTile(data.Layers[layerIndex].Tiles[tileIndex], layerIndex);
                }
                // Draw the layer's events
                if (layerIndex < Processors.Count)
                {
                    for (int drawIndex = 0; drawIndex < Processors[layerIndex].Count; drawIndex++)
                    {
                        Processors[layerIndex][drawIndex].Draw(gameTime);

                        if (Global.BlendMode != BlendState.NonPremultiplied)
                        {
                            // End Map/Menu Draw
                            Global.SpriteBatch.End();
                            // Begin Particle Draw
                            Global.BeginMapSpriteBatch();
                            // Set BlendMode
                            Global.BlendMode = BlendState.NonPremultiplied;
                        }
                    }
                }

                // Draw Pictures
                for (int i = 0; i < Global.Instance.Pictures.Length; i++)
                {
                    if (Global.Instance.Pictures[i] != null)
                    {
                        if (Global.Instance.Pictures[i].Layer == layerIndex && (Global.Instance.Pictures[i].ScreenType == ScreenType.Global ||
                            (Global.Instance.Pictures[i].ScreenType == ScreenType.Gameplay)))
                        {
                            Global.Instance.Pictures[i].Draw(gameTime);
                        }
                    }
                }
            }
            try
            {
            }
            catch
            {
                //Error.Do(ex);
            }
        }
        /// <summary>
        /// Draw layer background
        /// </summary>
        /// <param name="layer">The layer that holds the background</param>
        /// <param name="spriteBatch"></param>
        private void DrawLayerBackground(LayerData layer, int layerIndex)
        {
            LayerBackground background;
            Vector2 cameraOffset = (layer.MoveSpeed * Global.Instance.ActiveCamera.RealPosition);

            Color color = Color.White;
            Vector2 ScreenPos = Vector2.Zero;

            if (layer.ScrollType == 0)
            {
                ScreenPos = Global.Instance.ActiveCamera.RealPosition;
            }
            if (layer.ScrollType == 1)
            {
                Global.Instance.LayerBackroundOffset[layerIndex].X = cameraOffset.X % data.Size.X;
                Global.Instance.LayerBackroundOffset[layerIndex].Y = cameraOffset.Y % data.Size.Y;
            }
            else if (layer.ScrollType == 2)
            {
                if (Math.Abs(Global.Instance.LayerBackroundOffset[layerIndex].X) >= data.Size.X)
                    Global.Instance.LayerBackroundOffset[layerIndex].X = 0;
                if (Math.Abs(Global.Instance.LayerBackroundOffset[layerIndex].Y) >= data.Size.Y)
                    Global.Instance.LayerBackroundOffset[layerIndex].Y = 0;

                Global.Instance.LayerBackroundOffset[layerIndex].X += layer.MoveSpeed.X;
                Global.Instance.LayerBackroundOffset[layerIndex].Y += layer.MoveSpeed.Y;
            }

            Rectangle rect = new Rectangle();


            for (int i = 0; i < layer.Backgrounds.Count; i++)
            {
                background = layer.Backgrounds[i];
                Texture2D tex = Content.Texture2D(background.MaterialId);
                // Draw tile texture
                if (tex != null)
                {
                    rect.X = (int)Global.Instance.LayerBackroundOffset[layerIndex].X + (int)ScreenPos.X + (int)background.Position.X;
                    rect.Y = (int)Global.Instance.LayerBackroundOffset[layerIndex].Y + (int)ScreenPos.Y + (int)background.Position.Y;
                    rect.Width = (int)background.Size.X;
                    rect.Height = (int)background.Size.Y;

                    Global.SpriteBatch.Draw(tex, rect, new Rectangle(0, 0, (int)tex.Width, (int)tex.Height), color, background.Rotation, new Vector2(tex.Width * 0.5f, tex.Height * 0.5f), SpriteEffects.None, 0);

                    if (layer.MoveSpeed.X != 0 || layer.MoveSpeed.Y != 0)
                    {
                        rect.X = (layer.MoveSpeed.X > 0 ? (int)Global.Instance.LayerBackroundOffset[layerIndex].X - (int)data.Size.X : layer.MoveSpeed.X < 0 ? (int)Global.Instance.LayerBackroundOffset[layerIndex].X + (int)data.Size.X : 0) + (int)background.Position.X + (int)ScreenPos.X;
                        rect.Y = (layer.MoveSpeed.Y > 0 ? (int)Global.Instance.LayerBackroundOffset[layerIndex].Y - (int)data.Size.Y : layer.MoveSpeed.Y < 0 ? (int)Global.Instance.LayerBackroundOffset[layerIndex].Y + (int)data.Size.Y : 0) + (int)background.Position.Y + (int)ScreenPos.Y;
                        rect.Width = (int)background.Size.X;
                        rect.Height = (int)background.Size.Y;

                        Global.SpriteBatch.Draw(tex, rect, new Rectangle(0, 0, (int)tex.Width, (int)tex.Height), color, background.Rotation, new Vector2(tex.Width * 0.5f, tex.Height * 0.5f), SpriteEffects.None, 0);

                    }
                }

            }
        }
        /// <summary>
        /// Draw Tile
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="spriteBatch"></param>
        private void DrawTile(TileData tile, int layerIndex)
        {
            // Draw tile texture
            if (Textures.TryGetValue(tile.TilesetID, out GraphicsHelper.LastTexture))
            {
                Rectangle rect = new Rectangle();
                Color color = Color.White;
                color.A = tile.Opacity;
                TileSize.X = tile.Width;
                TileSize.Y = tile.Height;
                if (Global.Instance.Player.Count > 0 && Global.Instance.Player[0].MapID == data.ID && Global.Instance.Player[0].LayerIndex < layerIndex)
                {
                    rect = new Rectangle((int)tile.Position.X, (int)tile.Position.Y, (int)TileSize.X, (int)TileSize.Y);
                    Rectangle playerRect = new Rectangle((int)Global.Instance.Player[0].Position.X - (int)Global.Project.TTAP_Radius.X, (int)Global.Instance.Player[0].Position.Y - (int)Global.Project.TTAP_Radius.Y - (int)Global.Instance.Player[0].CurrentAction.CanvasSize.Y, (int)Global.Instance.Player[0].CurrentAction.CanvasSize.X + (int)Global.Project.TTAP_Radius.X, (int)Global.Instance.Player[0].CurrentAction.CanvasSize.Y + (int)Global.Project.TTAP_Radius.Y);

                    if (Global.Project.TTAP_Enabled && rect.Intersects(playerRect))
                        color.A = (byte)Global.Project.TTAP_Transparency;
                }
                rect.X = (int)tile.DisplayRect.X; rect.Y = (int)tile.DisplayRect.Y; rect.Width = (int)TileSize.X; rect.Height = (int)TileSize.Y;
                int row = (int)GraphicsHelper.LastTexture.Height / (int)GameData.Tilesets[tile.TilesetID].Grid.Y;
                int realIndex = (int)(tile.DisplayRect.X / GameData.Tilesets[tile.TilesetID].Grid.X) * row + (int)(tile.DisplayRect.Y / GameData.Tilesets[tile.TilesetID].Grid.Y);
                TileData realTile = GameData.Tilesets[tile.TilesetID].Tiles[realIndex];

                if (realTile.AnimationFrames <= 0 && realTile.Animation.Count > 0)
                {
                    realTile.AnimationIndex++;
                    if (realTile.AnimationIndex < realTile.Animation.Count)
                    {
                        realTile.AnimationFrames = realTile.Animation[realTile.AnimationIndex][0];
                    }
                    else // Reset Animation Index to 0
                    {
                        realTile.AnimationIndex = 0;
                        realTile.AnimationFrames = realTile.Animation[realTile.AnimationIndex][0];
                    }
                    rect.X = (int)GameData.Tilesets[tile.TilesetID].Tiles[realTile.Animation[realTile.AnimationIndex][1]].DisplayRect.X;
                    rect.Y = (int)GameData.Tilesets[tile.TilesetID].Tiles[realTile.Animation[realTile.AnimationIndex][1]].DisplayRect.Y;

                    rect.Width = (int)GameData.Tilesets[tile.TilesetID].Tiles[realTile.Animation[realTile.AnimationIndex][1]].Width;
                    rect.Height = (int)GameData.Tilesets[tile.TilesetID].Tiles[realTile.Animation[realTile.AnimationIndex][1]].Height;
                }
                else if (realTile.AnimationFrames > 0)
                {
                    if (!TileFrameSync.Contains(tile.TilesetID))
                    {
                        TileFrameSync.Add(tile.TilesetID);
                        realTile.AnimationFrames--;
                    }
                    rect.X = (int)GameData.Tilesets[tile.TilesetID].Tiles[realTile.Animation[realTile.AnimationIndex][1]].DisplayRect.X;
                    rect.Y = (int)GameData.Tilesets[tile.TilesetID].Tiles[realTile.Animation[realTile.AnimationIndex][1]].DisplayRect.Y;
                    rect.Width = (int)GameData.Tilesets[tile.TilesetID].Tiles[realTile.Animation[realTile.AnimationIndex][1]].Width;
                    rect.Height = (int)GameData.Tilesets[tile.TilesetID].Tiles[realTile.Animation[realTile.AnimationIndex][1]].Height;
                }
#if !SILVERLIGHT
                if (!ShaderProcess.IsNull)
                {
                    ShaderProcess.Process();
                    foreach (EffectPass pass in ShaderProcess.Effect.CurrentTechnique.Passes)
                    {
                        pass.Apply();
                        Global.SpriteBatch.Draw(GraphicsHelper.LastTexture,
                          tile.GetPosition(),// + (data.Layers[layerIndex].MoveSpeed * Global.Instance.ActiveCamera.RealPosition),
                          rect,
                          color, tile.GetRotation(), TileSize * 0.5f, tile.Scale, (tile.VerticalFlip == true ? SpriteEffects.FlipVertically : tile.HorizontalFlip == true ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0);
                    }
                }
                else
                {
#endif
                    Global.SpriteBatch.Draw(GraphicsHelper.LastTexture,
                        tile.GetPosition(),// + (data.Layers[layerIndex].MoveSpeed * Global.Instance.ActiveCamera.RealPosition),
                        rect,
                        color, tile.GetRotation(), TileSize * 0.5f, tile.Scale, (tile.VerticalFlip == true ? SpriteEffects.FlipVertically : tile.HorizontalFlip == true ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0);

#if !SILVERLIGHT
                }
#endif
            }
        }
        #endregion

        #region Method: Remove Event, IsEvent Active, Get Event, Add/Remove Processor, TileTag, Layer Visibility
        /// <summary>
        /// Get Event ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsEventActive(int id)
        {
            EventProcessor ev = GetEvent(id);

            if (ev != null)
                return ev.isProgramActive;
            return false;
        }
        /// <summary>
        /// Get Event
        /// Does not include clones.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal EventProcessor GetEvent(int id)
        {
            for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
            {
                for (int j = 0; j < Processors[layerIndex].Count; j++)
                {
                    if (Processors[layerIndex][j] is EventProcessor && Processors[layerIndex][j].ID == id && !((EventProcessor)Processors[layerIndex][j]).IsClone)
                        return (EventProcessor)Processors[layerIndex][j];
                }
            }
            return null;
        }
        /// <summary>
        /// Gets an event from unique ID
        /// Includes clones
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal EventProcessor GetEventFromUniqueID(int id)
        {
            if (id == -1) return Global.Instance.Player[0];
            for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
            {
                for (int j = 0; j < Processors[layerIndex].Count; j++)
                {
                    if (Processors[layerIndex][j] is EventProcessor && Processors[layerIndex][j].UniqueID == id)
                        return (EventProcessor)Processors[layerIndex][j];
                }
            }
            return null;
        }
        /// <summary>
        /// Show Animation On Event
        /// </summary>
        /// <param name="animationID"></param>
        /// <param name="actionID"></param>
        /// <param name="directionIndex"></param>
        /// <param name="eventID"></param>
        public void ShowAnimationOnEvent(int animationID, int actionID, int directionIndex, int eventID)
        {
            Global.ShowAnimationOnEvent(animationID, actionID, directionIndex, GetEvent(eventID));
        }
        /// <summary>
        /// Add a new processor
        /// </summary>
        /// <param name="DrawableComponent"></param>
        public void AddProcessor(Drawable processor)
        {
            if (processor != null && Processors.Count > processor.LayerIndex)
            {
                Processors[processor.LayerIndex].Add(processor);
                processor.DrawOrderChanged += new EventHandler(OnDrawOrderChanged);
                OnDrawOrderChanged(processor, EventArgs.Empty);

                if (processor is EventProcessor && processor.UniqueID == -10)
                    processor.UniqueID = (((EventProcessor)processor).IsPlayer ? -1 : Global.Instance.EventUniqueIDCount++);
            }
        }
        /// <summary>
        /// Remove given processor
        /// </summary>
        /// <param name="DrawableComponent"></param>
        internal void RemoveProcessor(Drawable processor)
        {
            if (processor != null)
                processor.Erase = true;
        }
        /// <summary>
        /// Add Event
        /// </summary>
        /// <param name="data"></param>
        /// <param name="position"></param>
        public EventProcessor AddEvent(EventData edata, Vector2 position, int layerIndex)
        {
            EventProcessor eProcessor;
            edata.Position = position;
            eProcessor = new EventProcessor(edata, data.ID);
            eProcessor.DrawOrderChanged += new EventHandler(OnDrawOrderChanged);
            eProcessor.LayerIndex = layerIndex;
            Processors[layerIndex].Add(eProcessor);
            eProcessor.UniqueID = (eProcessor.IsPlayer ? -1 : Global.Instance.EventUniqueIDCount++);
            eProcessor.Data.TemplateID = data.ID;
            return eProcessor;
        }
        /// <summary>
        /// Tile Tags
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public List<int> TileTags(int x, int y)
        {
            List<int> list = new List<int>();
            TileData tile;
            TilesetData tileset;
            int realIndex;

            Vector2 drawArea = new Vector2((float)x, (float)y);
            for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
            {
                // Get Tiles
                // Draw Tiles
                for (int tileIndex = 0; tileIndex < data.Layers[layerIndex].Tiles.Count; tileIndex++)
                {
                    if (data.Layers[layerIndex].Tiles[tileIndex].Position == drawArea)
                    {
                        tile = data.Layers[layerIndex].Tiles[tileIndex];
                        tileset = GameData.Tilesets.GetData(tile.TilesetID);
                        if (tileset != null)
                        {
                            realIndex = (int)(tile.DisplayRect.X / tileset.Grid.X) * tileset.Rows + (int)(tile.DisplayRect.Y / tileset.Grid.Y);
                            list.Add(tileset.Tiles[realIndex].Tag);
                        }
                    }
                }
            }

            return list;
        }
        public List<int> TileTags(Vector2 pos)
        {
            return TileTags((int)pos.X, (int)pos.Y);
        }
        /// <summary>
        /// Is Layer Visible
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsLayerVisible(int index)
        {
            if (index > -1 && index < data.Layers.Count)
                return (data.Layers[index].IsVisible);
            return false;
        }
        /// <summary>
        /// Change Map Gravity
        /// </summary>
        /// <param name="gravity"></param>
        public void ChangeGravity(Vector2 gravity)
        {
            Gravity = gravity;
            Global.World.Gravity = gravity;
        }
        /// <summary>
        /// Add Gravity Point
        /// </summary>
        /// <param name="index"></param>
        /// <param name="str"></param>
        /// <param name="r"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        internal void AddGravityPoint(int index, float str, float r, float x, float y)
        {
            r = ConvertUnits.ToSimUnits(r);
            if (GravityPoints[index] != null)
                RemoveGravityPoint(index);
            GravityPoints[index] = new GravityPoint() { Position = new Vector2(x, y), Radius = r, Strength = str };
            GravityControllers[index] = new PointGravityController(Global.World, new Vector2(x, y), str, r);
        }
        /// <summary>
        /// Remove Gravity Point
        /// </summary>
        /// <param name="p"></param>
        internal void RemoveGravityPoint(int index)
        {
            GravityPoints[index] = null;
            if (GravityControllers[index] != null)
                Global.World.RemoveController(GravityControllers[index]);
        }
        #endregion

        #region Method: Load
        internal void Load()
        {
            if (Global.World == null)
            {
                Global.World = new World(Vector2.Zero);
            }
            else
            {
                Global.World.Clear();
            }
            // Set Gravity
            Global.World.Gravity = Gravity;

            MapBodies.Clear();

            Body body;
            int realIndex;
            TilesetData tileset = null;
            TileData tile;
            Vertices clone, rotatedClone;

            for (int layerIndex = 0; layerIndex < Data.Layers.Count; layerIndex++)
            {
                // DrawableComponent
                Processors.Add(new List<Drawable>());
                // Tiles
                for (int tileIndex = 0; tileIndex < data.Layers[layerIndex].Tiles.Count; tileIndex++)
                {
                    tile = data.Layers[layerIndex].Tiles[tileIndex];
                    if (tileset == null || tileset.ID != tile.TilesetID)
                        tileset = GameData.Tilesets.GetData(tile.TilesetID);
                    if (tileset != null)
                    {
                        if (!Textures.ContainsKey(tileset.ID))
                            Textures[tileset.ID] = Content.Texture2D(tileset.MaterialId);
                        int row = (int)Textures[tileset.ID].Height / (int)tileset.Grid.Y;
                        realIndex = (int)(tile.DisplayRect.X / tileset.Grid.X) * row + (int)(tile.DisplayRect.Y / tileset.Grid.Y);
                        body = null;
                        // Only add if there is a body
                        if (tileset.Tiles[realIndex].Body.Count > 0)
                        {
                            // Create Body
                            clone = new Vertices(tileset.Tiles[realIndex].Body);

                            if (clone.Count < 3)
                            {
                                // > EGM WARNING
                                Global.Log("Warning > All tile collision nodes must be more than 2. \n        > Tileset: " + tileset.Name + "\n        > Index : " + realIndex.ToString());

                                Vector2 n = clone[0];
                                n.X += 2;
                                n.Y += 2;
                                clone.Add(n);
                                if (clone.Count < 3)
                                {
                                    n = clone[2];
                                    n.X += 2;
                                    n.Y += 2;
                                    clone.Add(n);
                                }
                            }

                            clone = Vertices.Simplify(clone);
                            Vector2 size = new Vector2(tile.Width, tile.Height);
                            clone.Scale(ref tile.Scale);
                            Vector2 v = -(tile.Scale - new Vector2(1, 1)) * size / 2;
                            clone.Translate(ref v);

                            // Create Body
                            rotatedClone = new Vertices(clone);

                            rotatedClone.Rotate(MathHelper.ToRadians(tile.Rotation), size / 2);

                            Vector2 centroid = -clone.GetCentroid();
                            clone.Translate(ref centroid);

                            tile.origin = -rotatedClone.GetCentroid();

                            List<Vertices> vertices = BayazitDecomposer.ConvexPartition(clone);

                            //scale the vertices from graphics space to sim space
                            Vector2 vertScale = new Vector2(ConvertUnits.ToSimUnits(1)) * 1f;
                            foreach (Vertices v1 in vertices)
                            {
                                v1.Scale(ref vertScale);
                            }
                            if (vertices.Count > 1)
                                body = BodyFactory.CreateCompoundPolygon(Global.World, vertices, (tileset.Tiles[realIndex].Mass > 0 ? tileset.Tiles[realIndex].Mass : 1));
                            else
                                body = BodyFactory.CreatePolygon(Global.World, vertices[0], (tileset.Tiles[realIndex].Mass > 0 ? tileset.Tiles[realIndex].Mass : 1));

                            // Physic Settings
                            body.UserData = tileset.Tiles[realIndex];
                            body.IsStatic = tileset.Tiles[realIndex].IsStatic;
                            body.IgnoreGravity = tileset.Tiles[realIndex].IgnoreGravity;
                            body.LayerIndex = layerIndex;
                            body.Friction = tileset.Tiles[realIndex].Friction;
                            body.LinearDamping = tileset.Tiles[realIndex].LinearDrag;
                            body.AngularDamping = tileset.Tiles[realIndex].RotationalDrag;
                            body.Restitution = tileset.Tiles[realIndex].Bounce;
                            body.CollisionCategories = Category.All;
                            body.CollidesWith = Category.All;
                            body.Mass = (tileset.Tiles[realIndex].Mass > 0 ? tileset.Tiles[realIndex].Mass : 1);

                            // Get Offset
                            tile.offset = -(size / 2 + tile.origin);
                            body.SetTransform(ConvertUnits.ToSimUnits(tile.origin), MathHelper.ToRadians(tile.Rotation));
                            body.Position = ConvertUnits.ToSimUnits(tile.Position - (size / 2 + tile.origin));
                            tile.body = body;

                            // Store Body
                            MapBodies.Add(body);
                        }
                    }
                }
            }


            for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
            {
                for (int drawIndex = 0; drawIndex < Processors[layerIndex].Count; drawIndex++)
                {
                    Processors[layerIndex][drawIndex].Load();
                }
            }

            for (int i = 0; i < GravityPoints.Length; i++)
            {
                if (GravityPoints[i] != null)
                {
                    GravityControllers[i] = new PointGravityController(Global.World, GravityPoints[i].Position, GravityPoints[i].Strength, GravityPoints[i].Radius);
                }
            }
        }
        /// <summary>
        /// Remove Players
        /// </summary>
        internal void RemovePlayers()
        {
            // Erased processors
            List<Drawable> removed = new List<Drawable>();
            // Remove
            for (int layerIndex = 0; layerIndex < data.Layers.Count; layerIndex++)
            {
                for (int drawIndex = 0; drawIndex < Processors[layerIndex].Count; drawIndex++)
                {
                    if (Processors[layerIndex][drawIndex] is EventProcessor)
                    {
                        if (((EventProcessor)Processors[layerIndex][drawIndex]).IsPlayer)
                        {
                            removed.Add(Processors[layerIndex][drawIndex]);
                        }
                    }
                }
                foreach (Drawable remove in removed)
                {
                    Processors[layerIndex].Remove(remove);
                    remove.Dispose();
                }
                removed.Clear();
            }
        }
        #endregion

        internal void ChangeLayer(EventProcessor ev2, int layerIndex)
        {
            Processors[ev2.layerIndex].Remove(ev2);
            ev2.LayerIndex = layerIndex;
            Processors[ev2.layerIndex].Add(ev2);
        }
    }


    public class GravityPoint
    {
        public Vector2 Position;
        public float Strength;
        public float Radius;
    }
}

