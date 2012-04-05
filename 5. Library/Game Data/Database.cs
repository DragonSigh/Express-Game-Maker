//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
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
    [Serializable]
    public class Data : IGameData
    {
        /// <summary>
        /// Name of the data
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
        /// The datasets the database contains.
        /// </summary>
        [Browsable(false)]
        public List<DataProperty> Properties
        {
            get { return properties; }
            set { properties = value; }
        }
        List<DataProperty> properties = new List<DataProperty>();
        /// <summary>
        /// The datas the template database contains.
        /// </summary>
        [Browsable(false)]
        public Dictionary<int, Data> Datas
        {
            get { return data; }
            set { data = value; }
        }
        Dictionary<int, Data> data = new Dictionary<int, Data>();

        /// <summary>
        /// Returns the name of the object.
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return name;
        }
    }

    [Serializable]
    public class DataProperty : IGameData
    {
        /// <summary>
        /// Name of the data
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
        /// The value of the dataset.
        /// </summary>
        public object Value
        {
            get
            {
                if (val != null)
                    return val;
                else
                {
                    switch (valueType)
                    {
                        case DataType.Text:
                            return "";
                        case DataType.Number:
                            return (int)0;
                        case DataType.Link:
                            return -1;
                        case DataType.List:
                            return new List<int>();
                    }
                }
                return null;
            }
            set { val = value; }
        }
        object val;
        /// <summary>
        /// Value Type
        /// Text (string)
        /// Number (decimal)
        /// Link (int)
        /// Animation (int)
        /// </summary>
        public DataType ValueType
        {
            get { return valueType; }
            set { valueType = value; }
        }
        DataType valueType = DataType.Text;
        /// <summary>
        /// Stores the link index if the type is link.
        /// </summary>
        public int LinkIndex
        {
            get { return linkIndex; }
            set { linkIndex = value; }
        }
        int linkIndex;
        /// <summary>
        /// Returns the name of the object.
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return name;
        }
    }

    [Serializable]
    public enum DataType
    {
        Text,
        Number,
        Link,
        List
    }
}
