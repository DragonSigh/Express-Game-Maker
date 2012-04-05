//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EGMGame.Library.Interface
{
    public interface IMovable
    {
        /// <summary>
        /// The rectangle holding the position(x, y) and size(width, height) of the object.
        /// </summary>
        Rectangle Bounds { get; }
        /// <summary>
        /// Gets or sets the position of the object.
        /// </summary>
        Vector2 Position { get; set; }
        /// <summary>
        /// Gets or sets the size of the object.
        /// </summary>
        Vector2 Size { get; set; }
        /// <summary>
        /// Gets or sets the displayed portion of the object.
        /// </summary>
        //Rectangle DisplayRect { get; set; }
        /// <summary>
        /// Gets or sets the width of the object.
        /// </summary>
        float Width { get; set; }
        /// <summary>
        /// Gets or sets the height of the object.
        /// </summary>
        float Height { get; set; }
        /// <summary>
        /// Gets or sets the X position of the object.
        /// </summary>
        float X { get; set; }
        /// <summary>
        /// Gets or sets the Y position of the object.
        /// </summary>
        float Y { get; set; }
    }
}
