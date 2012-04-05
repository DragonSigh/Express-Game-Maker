//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the list data.
    /// Includes integer values. Useful for storing items(ID) and ect.
    /// </summary>
    [Serializable]
    public class ListData : IGameData
    {
        /// <summary>
        /// Name of the list
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
        /// Values
        /// </summary>
        public List<int> Values
        {
            get { return list; }
            set { list = value; }
        }
        List<int> list = new List<int>();

        public override string ToString()
        {
            return name;
        }
    }
}
