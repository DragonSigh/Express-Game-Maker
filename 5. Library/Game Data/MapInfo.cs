﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EGMGame.Library
{
    [Serializable]
    public class MapInfo : IGameData
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
        /// Path
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        string path;
    }
}
