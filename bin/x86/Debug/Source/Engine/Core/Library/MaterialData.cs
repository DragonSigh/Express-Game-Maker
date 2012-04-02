//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the material data.
    /// Includes file path and data type.
    /// </summary>
    
    public class MaterialData : IGameData
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
        int category = 0;
        /// <summary>
        /// The file name of the material.
        /// </summary>
        public string FileName;

        /// <summary>
        /// The type of the material. Image, Audio, or Video.
        /// </summary>
        public MaterialDataType DataType;
    }

    
    public enum MaterialDataType
    {
        All,
        Image,
        Sound,
        Event,
        Text,
        Video,
        Effect_File,
        Plugin_File,
        Bitmap_Font
    }
}
