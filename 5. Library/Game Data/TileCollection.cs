//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Xna.Framework;
//using EGMGame.Library;
//using System.Xml.Serialization;

//namespace EGMGame
//{
//    [Serializable]
//    public class TileCollection : IXmlSerializable
//    {
//        public TileCollection()
//        {
//        }
//        public TileCollection(Vector2 _mapSize, Vector2 _displayRect)
//        {
//            mapSize = _mapSize;
//            displayRect = _displayRect / 2;
//            CreateCollection();
//        }
//        /// <summary>
//        /// Create collection
//        /// If a collection already exists, it will be appendeded to new collection.
//        /// </summary>
//        /// <param name="_mapSize">The size of the map</param>
//        /// <param name="_displayRect">The rectangle of the display area. Usually the screen.</param>
//        public void CreateCollection(Vector2 _mapSize, Vector2 _displayRect)
//        {
//            mapSize = _mapSize;
//            displayRect = _displayRect / 2;
//            CreateCollection();
//        }
//        /// <summary>
//        /// Create Collection
//        /// </summary>
//        public void CreateCollection()
//        {
//            try
//            {
//                // Calculate number of display rectangles
//                // Multiply by four to divide the screen to 4 parts
//                Vector2 numOfRects = Vector2.Zero;
//                numOfRects.X = (float)Math.Floor((double)(mapSize.X / displayRect.X));
//                numOfRects.Y = (float)Math.Floor((double)(mapSize.Y / displayRect.Y));
//                // Copy collection
//                List<List<List<TileData>>> clone = new List<List<List<TileData>>>();
//                // Copy
//                for (int x = 0; x < sections.Count; x++)
//                {
//                    clone.Add(new List<List<TileData>>());
//                    for (int y = 0; y < sections[x].Count; y++)
//                    {
//                        clone[x].Add(new List<TileData>(sections[x][y]));
//                    }
//                }
//                // Clear collection
//                sections.Clear();
//                // Setup sections
//                for (int x = 0; x <= numOfRects.X; x++)
//                {
//                    sections.Add(new List<List<TileData>>());
//                    for (int y = 0; y <= numOfRects.Y; y++)
//                    {
//                        sections[x].Add(new List<TileData>());
//                    }
//                }
//                // Add values of old collection
//                for (int i = 0; i < clone.Count; i++)
//                {
//                    for (int k = 0; k < clone[i].Count; k++)
//                    {
//                        foreach (TileData tile in clone[i][k])
//                        {
//                            if (tile.X < mapSize.X && tile.Y < mapSize.Y)
//                                Add(tile);
//                        }
//                    }
//                }
//                // Clear Collection
//                clone.Clear();
//            }
//            catch (Exception ex)
//            {
//                Error.ShowLogError(ex, "51x001");
//            }
//        }
//        /// <summary>
//        /// Move a tile
//        /// </summary>
//        /// <param name="tile"></param>
//        public void Move(TileData tile, Vector2 newPos, Vector2 oldPos)
//        {
//            Rectangle rect = new Rectangle(0, 0, (int)mapSize.X, (int)mapSize.Y);
//            if (rect.Contains((int)newPos.X, (int)newPos.Y))
//            {
//                Remove(tile);
//                Remove(newPos);
//                tile.Position = newPos;
//                Add(tile);
//            }
//            else
//            {
//                Remove(tile);
//            }
//        }
//        /// <summary>
//        /// Add a tile to collection.
//        /// </summary>
//        /// <param name="vector2"></param>
//        /// <param name="tileData"></param>
//        public void Add(TileData tile)
//        {
//            //Remove(tile.Position);
//            if (tile.Position.X < 0)
//                tile.Position = tile.Position;
//            Rectangle rect = new Rectangle((int)-tile.Width * 2, (int)-tile.Height * 2, (int)mapSize.X + (int)tile.Width * 4, (int)mapSize.Y + (int)tile.Height * 4);
//            // if (rect.Contains((int)tile.Position.X, (int)tile.Position.Y))
//            // {
//            Vector2 index = GetIndex(tile.Position);
//            if (GetSection(index) != null)
//            {
//                GetSection(index).Add(tile);
//            }
//            else
//                return;
//            // }
//            // else
//            //   return;
//        }
//        /// <summary>
//        /// Insert
//        /// </summary>
//        /// <param name="p"></param>
//        /// <param name="tile"></param>
//        public void Insert(int p, TileData tile)
//        {
//            Vector2 index = GetIndex(tile.Position);
//            if (GetSection(index) != null)
//            {
//                GetSection(index).Insert(p, tile);
//            }
//        }
//        /// <summary>
//        /// Remove a tile from given position.
//        /// </summary>
//        /// <param name="position"></param>
//        public void Remove(TileData tile)
//        {
//            Vector2 index = GetIndex(tile.Position);
//            List<TileData> section = GetSection(index);
//            if (section != null)
//            {
//                section.Remove(tile);
//            }
//        }
//        /// <summary>
//        /// Remove tiles at position
//        /// </summary>
//        /// <param name="pos"></param>
//        public List<TileData> Remove(Vector2 position)
//        {
//            List<TileData> toRemove = new List<TileData>();
//            Vector2 index = GetIndex(position);
//            List<TileData> section = GetSection(index);
//            if (section != null)
//            {
//                for (int i = 0; i < section.Count; i++)
//                {
//                    if (section[i].Position == position)
//                        toRemove.Add(section[i]);
//                }
//            }
//            foreach (TileData tr in toRemove)
//            {
//                section.Remove(tr);
//            }
//            return toRemove;
//        }
//        /// <summary>
//        /// Gets a section from the given index.
//        /// </summary>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        public List<TileData> GetSection(Vector2 index)
//        {
//            if (index.X > -1 && index.Y > -1 && index.X < sections.Count && index.Y < sections[(int)index.X].Count)
//                return sections[(int)index.X][(int)index.Y];
//            else
//                return null;
//        }
//        /// <summary>
//        /// Returns all sections surrounding the given index.
//        /// </summary>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        public List<List<TileData>> GetSections(Vector2 index, int range)
//        {
//            List<List<TileData>> _sections = new List<List<TileData>>();

//            for (int x = (int)index.X - range; x < index.X + range; x++)
//            {
//                if (x > -1 && x < sections.Count)
//                {
//                    for (int y = (int)index.Y - range; y < index.Y + range; y++)
//                    {
//                        if (y > -1 && y < sections[x].Count)
//                        {
//                            _sections.Add(sections[x][y]);
//                        }
//                    }
//                }
//            }
//            return _sections;
//        }
//        /// <summary>
//        /// Gets the index of a section from sections by the given position.
//        /// </summary>
//        /// <param name="position"></param>
//        /// <returns></returns>
//        public Vector2 GetIndex(Vector2 position)
//        {
//            // Section
//            Vector2 index = Vector2.Zero;
//            index.X = (float)Math.Floor((double)(position.X / displayRect.X));
//            index.Y = (float)Math.Floor((double)(position.Y / displayRect.Y));
//            if (index.X < 0)
//                index.X = 0;
//            if (index.Y < 0)
//                index.Y = 0;
//            return index;
//        }
//        /// <summary>
//        /// Gets or sets the map size of the collection.
//        /// This is mainly for serialization.
//        /// </summary>
//        public Vector2 MapSize
//        {
//            get { return mapSize; }
//            set { mapSize = value; }
//        }
//        Vector2 mapSize;
//        /// <summary>
//        /// Gets or sets the display rectangle of the collection.
//        /// This is mainly for serialization.
//        /// </summary>
//        public Vector2 DisplayRect
//        {
//            get { return displayRect; }
//            set { displayRect = value; }
//        }
//        Vector2 displayRect;
//        /// <summary>
//        /// Get the tile from given index
//        /// </summary>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        public TileData this[Vector2 key]
//        {
//            get
//            {
//                return GetTile(key); ;
//            }
//            set
//            {
//                Add(value);
//            }
//        }
//        /// <summary>
//        /// Gets a tile from given position
//        /// </summary>
//        /// <param name="key"></param>
//        /// <returns></returns>
//        private TileData GetTile(Vector2 position)
//        {
//            Vector2 index = GetIndex(position);
//            List<TileData> section = GetSection(index);
//            if (section != null)
//            {
//                for (int i = 0; i < section.Count; i++)
//                {
//                    if (section[i].Position == position)
//                        return section[i];
//                }
//            }
//            return null;
//        }
//        /// <summary>
//        /// Get the reversed tiles.
//        /// </summary>
//        /// <returns></returns>
//        public List<List<TileData>> Reverse(Vector2 position, int range)
//        {
//            List<List<TileData>> _sections = new List<List<TileData>>();
//            Vector2 index = GetIndex(position);
//            List<TileData> section;
//            for (int x = (int)index.X - range; x < index.X + range; x++)
//            {
//                if (x > -1 && x < sections.Count)
//                {
//                    for (int y = (int)index.Y - range; y < index.Y + range; y++)
//                    {
//                        if (y > -1 && y < sections[x].Count)
//                        {
//                            section = new List<TileData>(sections[x][y]);
//                            section.Reverse();
//                            _sections.Add(section);
//                        }
//                    }
//                }
//            }
//            return _sections;
//        }
//        /// <summary>
//        /// Gets the sections in the collection.
//        /// </summary>
//        public List<List<List<TileData>>> Sections
//        {
//            get { return sections; }
//            set { sections = value; }
//        }
//        List<List<List<TileData>>> sections = new List<List<List<TileData>>>();
//        /// <summary>
//        /// Clear the collection
//        /// </summary>
//        public void Clear()
//        {
//            for (int x = 0; x < sections.Count; x++)
//            {
//                for (int y = 0; y < sections[y].Count; y++)
//                {
//                    sections[x][y].Clear();
//                }
//            }
//        }
//        /// <summary>
//        /// Get section in between
//        /// </summary>
//        /// <param name="originalMouse"></param>
//        /// <param name="point"></param>
//        /// <returns></returns>
//        internal IEnumerable<List<TileData>> GetSectionsBetween(Vector2 p1, Vector2 p2)
//        {
//            Vector2 index1 = GetIndex(p1);
//            Vector2 index2 = GetIndex(p2);
//            float x1 = (index1.X <= index2.X ? index1.X : index2.X);
//            float x2 = (index1.X <= index2.X ? index2.X : index1.X);
//            float y1 = (index1.Y <= index2.Y ? index1.Y : index2.Y);
//            float y2 = (index1.Y <= index2.Y ? index2.Y : index1.Y);

//            List<List<TileData>> _sections = new List<List<TileData>>();

//            for (int x = (int)x1; x <= x2; x++)
//            {
//                if (x > -1 && x < sections.Count)
//                {
//                    for (int y = (int)y1; y <= y2; y++)
//                    {
//                        if (y > -1 && y < sections[x].Count)
//                        {
//                            _sections.Add(sections[x][y]);
//                        }
//                    }
//                }
//            }
//            return _sections;
//        }

//        #region IXmlSerializable Members

//        public System.Xml.Schema.XmlSchema GetSchema()
//        {
//            return null;
//        }

//        public void ReadXml(System.Xml.XmlReader reader)
//        {
//            XmlSerializer dataSerializer;
//            XmlSerializer sectionsSerializer;
//            dataSerializer = Marshal.CheckCache(typeof(Vector2));
//            sectionsSerializer = Marshal.CheckCache(sections.GetType());

//            bool wasEmpty = reader.IsEmptyElement;

//            reader.Read();

//            if (wasEmpty)

//                return;

//            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
//            {
//                reader.ReadStartElement("item");

//                reader.ReadStartElement("mapSize");

//                mapSize = (Vector2)dataSerializer.Deserialize(reader);

//                reader.ReadEndElement();

//                reader.ReadStartElement("displayRect");

//                displayRect = (Vector2)dataSerializer.Deserialize(reader);

//                reader.ReadEndElement();

//                reader.ReadStartElement("sections");

//                sections = (List<List<List<TileData>>>)sectionsSerializer.Deserialize(reader);

//                reader.ReadEndElement();

//                reader.ReadEndElement();

//                reader.MoveToContent();

//            }

//            reader.ReadEndElement();
//        }

//        public void WriteXml(System.Xml.XmlWriter writer)
//        {
//            XmlSerializer dataSerializer;
//            XmlSerializer sectionsSerializer;
//            dataSerializer = Marshal.CheckCache(typeof(Vector2));
//            sectionsSerializer = Marshal.CheckCache(sections.GetType());

//            writer.WriteStartElement("item");

//            writer.WriteStartElement("mapSize");

//            dataSerializer.Serialize(writer, mapSize);

//            writer.WriteEndElement();

//            writer.WriteStartElement("displayRect");

//            dataSerializer.Serialize(writer, displayRect);

//            writer.WriteEndElement();

//            writer.WriteStartElement("sections");

//            sectionsSerializer.Serialize(writer, sections);

//            writer.WriteEndElement();

//            writer.WriteEndElement();
//        }

//        #endregion

//    }
//}
