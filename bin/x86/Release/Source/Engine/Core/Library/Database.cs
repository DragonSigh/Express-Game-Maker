//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the database data.
    /// </summary>
    
    public class Data : IGameData
    {
        /// <summary>
        /// Name of the data
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
        /// The datasets the database contains.
        /// </summary>        
        public List<DataProperty> Properties;
        /// <summary>
        /// The datas the template database contains.
        /// </summary>        
        public Dictionary<int, Data> Datas;

        /// <summary>
        /// Returns the name of the object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }

    
    public class DataProperty : IGameData
    {
        /// <summary>
        /// Name of the data
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
        /// The value of the dataset.
        /// </summary>
        public object Value;
        /// <summary>
        /// Value Type
        /// Text (string)
        /// Number (decimal)
        /// Link (int)
        /// Animation (int)
        /// </summary>
        public DataType ValueType;
        /// <summary>
        /// Stores the link index if the type is link.
        /// </summary>
        public int LinkIndex;
        /// <summary>
        /// Returns the name of the object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
        /// <summary>
        /// Clone this property
        /// </summary>
        /// <returns></returns>
        internal DataProperty Clone()
        {
            DataProperty prop = new DataProperty();
            prop.Category = Category;
            prop.ID = ID;
            prop.Name = Name;
            prop.LinkIndex = LinkIndex;
            if (ValueType != DataType.List)
                prop.Value = Value;
            else if (Value != null)
                prop.Value = new List<int>((List<int>)(Value));
            else
                prop.Value = new List<int>();
            prop.ValueType = ValueType;
            return prop;
        }
    }

    
    public enum DataType
    {
        Text,
        Number,
        Link,
        List
    }
}
