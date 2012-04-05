//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
    [Serializable]
    public class MaterialData : IGameData
    {
        /// <summary>
        /// Name
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id
        /// </summary>
        [Browsable(false)]
        public override int ID
        {
            get { return id; }
            set { id = value; }
        }
        int id;
        /// <summary>
        /// The category the data is in. Usage is optional.
        /// </summary>
        [Browsable(false)]
        public override int Category
        {
            get { return category; }
            set { category = value; }
        }
        int category = 0;
        /// <summary>
        /// The file name of the material.
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        string fileName;

        /// <summary>
        /// The type of the material. Image, Audio, or Video.
        /// </summary>
        public MaterialDataType DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        MaterialDataType dataType;

        /// <summary>
        /// to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }

    [Serializable]
    public enum MaterialDataType
    {
        Image,
        Sound,
        Event,
        Text,
        Video,
        Effect_File,
        Plugin_File,
        Bitmap_Font,
        All
    }
}
