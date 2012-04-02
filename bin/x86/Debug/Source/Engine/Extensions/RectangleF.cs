//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace EGMGame
{
    
    public struct RectangleF
    {
        // Values
        float x, y, width, height;
        /// <summary>
        /// The X value of the rectangle
        /// </summary>
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        /// <summary>
        /// The Y value of the rectangle
        /// </summary>
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        /// <summary>
        /// The Width of the rectangle
        /// </summary>
        public float Width
        {
            get { return width; }
            set { width = value; }
        }
        /// <summary>
        /// The Height of the rectangle
        /// </summary>
        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        public Vector2 Position
        {
            get { return new Vector2(x, y); }
            set { x = value.X; y = value.Y; }
        }
        public Vector2 Size
        {
            get { return new Vector2(width, height); }
            set { width = value.X; height = value.Y; }
        }
        public bool Contains(float _x, float _y)
        {
            return ((((this.X <= _x) && (_x < (this.X + this.Width))) && (this.Y <= _y)) && (_y < (this.Y + this.Height)));
        }
        public bool Contains(Vector2 vector)
        {
            return this.Contains(vector.X, vector.Y);
        }
        public bool Contains(Vector2 vector, Vector2 size, float increment)
        {
            for (float i = 0; i < size.X; i += increment)
            {
                for (float z = 0; z < size.Y; z += increment)
                {
                    if (this.Contains(i, x))
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_width"></param>
        /// <param name="_height"></param>
        public RectangleF(float _x, float _y, float _width, float _height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }
        public RectangleF(Vector2 position, Vector2 size)
        {
            x = position.X;
            y = position.Y;
            width = size.X;
            height = size.Y;
        }
    }
}
