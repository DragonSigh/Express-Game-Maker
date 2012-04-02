//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EGMGame
{
    
    public struct ColorRGBA
    {
        /// <summary>
        /// Red
        /// </summary>
        public byte Red
        {
            get { return red; }
            set { red = value; }
        }
        byte red;
        /// <summary>
        /// Green
        /// </summary>
        public byte Green
        {
            get { return green; }
            set { green = value; }
        }
        byte green;
        /// <summary>
        /// Blue
        /// </summary>
        public byte Blue
        {
            get { return blue; }
            set { blue = value; }
        }
        byte blue;
        /// <summary>
        /// Alpha
        /// </summary>
        public byte Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }
        byte alpha;
        /// <summary>
        /// Constructor from given color.
        /// </summary>
        /// <param name="color"></param>
        public ColorRGBA(Color color)
        {
            red = color.R;
            green = color.G;
            blue = color.B;
            alpha = color.A;
        }
        /// <summary>
        /// Construct from given red, green, blue, and alpha.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        public ColorRGBA(byte r, byte g, byte b, byte a)
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }
        /// <summary>
        /// Construct from given red, green, blue, and alpha.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        public ColorRGBA(decimal r, decimal g, decimal b, decimal a)
        {
            red = (byte)r;
            green = (byte)g;
            blue = (byte)b;
            alpha = (byte)a;
        }
        /// <summary>
        /// Construct from given red, green, blue, and alpha.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        public ColorRGBA(int r, int g, int b, int a)
        {
            red = (byte)r;
            green = (byte)g;
            blue = (byte)b;
            alpha = (byte)a;
        }
        /// <summary>
        /// Construct from given red, green, blue, and alpha.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        public ColorRGBA(float r, float g, float b, float a)
        {
            red = (byte)r;
            green = (byte)g;
            blue = (byte)b;
            alpha = (byte)a;
        }
        /// <summary>
        /// Returns the XNA Color format of the object.
        /// </summary>
        /// <returns></returns>
        public Color ToColor()
        {
            return new Color(red, green, blue, alpha);
        }
        /// <summary>
        /// Sets the properties of this object from a given color's.
        /// </summary>
        /// <param name="color"></param>
        public void FromColor(Color color)
        {
            red = color.R;
            green = color.G;
            blue = color.B;
            alpha = color.A;
        }
    }
}
