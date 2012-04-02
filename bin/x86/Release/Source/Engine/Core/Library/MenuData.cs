//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the menu data.
    /// </summary>
    
    public class MenuData : IGameData
    {
        /// <summary>
        /// Name
        /// </summary>
        
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id
        /// </summary>
        
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
        /// <summary>
        /// The category the data is in. Usage is optional.
        /// </summary>

        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category;
        /// <summary>
        /// Contains the menu parts of the menu.
        /// </summary>

        public List<IMenuParts> MenuParts;
        /// <summary>
        /// Gets or sets the skin id of the object.
        /// </summary>
        public int SkinID;
        /// <summary>
        /// Gets or sets the size of the canvas.
        /// </summary>
        public Vector2 CanvasSize;
        /// <summary>
        /// Background Image
        /// </summary>
        public int Background;
        /// <summary>
        /// Background Color
        /// </summary>
        public Color BackgroundColor;
        /// <summary>
        /// On Shown
        /// </summary>
        public List<EventProgramData> OnShown;
        /// <summary>
        /// Is Message
        /// </summary>
        public bool IsMessage;
    }
}
