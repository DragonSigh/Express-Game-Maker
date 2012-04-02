using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using EGMGame.Processors;
using EGMGame.Library;

namespace EGMGame.Components
{
    
    public class Drawable
    {
        public virtual int ID
        {
            get { return id; }
            set { id = value; }
        }
        internal int id = -1;

        public virtual Microsoft.Xna.Framework.Vector2 Position { get; set; }
        /// <summary>
        /// Unique ID is given for each event processor and is only reset
        /// when the map is changed
        /// </summary>
        public int UniqueID = -10;
        /// <summary>
        /// Draw Order Changed Event
        /// </summary>
        public event EventHandler DrawOrderChanged;
        /// <summary>
        /// The draw order of the component
        /// </summary>
        public int DrawOrder
        {
            get { return drawOrder; }
            set
            {
                drawOrder = value;
                OnDrawOrderChanged(this, EventArgs.Empty);
            }
        }
        int drawOrder;
        /// <summary>
        /// The layer index of the component
        /// </summary>
        [XmlIgnore, DoNotSerialize]
        public virtual int LayerIndex
        {
            get { return layerIndex; }
            set { layerIndex = value; }
        }
        public int layerIndex;
        /// <summary>
        /// Erase
        /// </summary>
        public bool Erase
        {
            get { return erase; }
            set { erase = value; }
        }
        bool erase;
        /// <summary>
        /// Called when the draw order changes
        /// </summary>
        private void OnDrawOrderChanged(object sender, EventArgs args)
        {
            if (this.DrawOrderChanged != null)
            {
                this.DrawOrderChanged(this, args);
            }

        }
        /// <summary>
        /// Called when the component needs to draw.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {

        }
        /// <summary>
        /// Called when the component needs to update.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
        }

        public virtual void Clear()
        {
        }

        public virtual void Dispose()
        {
        }

        public virtual void Load()
        {

        }
    }
    /// <summary>
    /// Draw Component Order Comparer
    /// </summary>
    internal class DrawableComponentOrderComparer : IComparer<Drawable>
    {
        // Fields
        public static readonly DrawableComponentOrderComparer Default = new DrawableComponentOrderComparer();

        // Methods
        public int Compare(Drawable x, Drawable y)
        {
            if ((x == null) && (y == null))
            {
                return 0;
            }
            if (x != null)
            {
                if (y == null)
                {
                    return -1;
                }
                if (x.Equals(y))
                {
                    return 0;
                }
                if (x.DrawOrder < y.DrawOrder)
                {
                    return -1;
                }
            }
            return 1;
        }
    }
}
