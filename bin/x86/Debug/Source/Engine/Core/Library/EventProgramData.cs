//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the event's program data.
    /// </summary>
    
    public class EventProgramData : IEventProgram
    {
        /// <summary>
        /// Name of the program. Often represents its display in program list.
        /// </summary>
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id of the program.
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
        /// Determines whether if the program is a branch.
        /// </summary>
        public bool Branch
        {
            get { return branch; }
            set { branch = value; }
        }
        bool branch = false;
        /// <summary>
        /// Determines whether if the program is a else.
        /// </summary>
        public bool Else
        {
            get { return _else; }
            set { _else = value; }
        }
        bool _else = false;
        /// <summary>
        /// The child programs of the program.
        /// </summary>
        public List<EventProgramData> ElsePrograms
        {
            get { return elseActions; }
            set { elseActions = value; }
        }
        List<EventProgramData> elseActions = new List<EventProgramData>();
        /// <summary>
        /// Determines if the program is expanded (if its branch).
        /// </summary>
        public bool Expand
        {
            get { return expand; }
            set { expand = value; }
        }
        bool expand = true;

        public object[] Value;
    }
    [XmlInclude(typeof(EventProgramData))]
    [XmlInclude(typeof(EventPageData))]
    public abstract class IEventProgram : IGameData
    {      
        /// <summary>
        /// Programs
        /// </summary>
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; }
        }
        List<EventProgramData> programs = new List<EventProgramData>();
        /// <summary>
        /// The category of the program.
        /// </summary>
        public ProgramCategory ProgramCategory
        {
            get { return acategory; }
            set { acategory = value; }
        }
        ProgramCategory acategory;
        /// <summary>
        /// Determines if its enabled or not.
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        bool enabled = true;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }
        int code;

        [ContentSerializerIgnore, DoNotSerialize]
        public int UniqueID = -1;
    }

    public enum ProgramCategory
    {
        Movement,
        Settings,
        Display,
        Conditions,
        Loops,
        Audio,
        Data,
        Event,
        Map,
        Screen,
        Graphics,
        Guide,
        Other,
        Party,
        Hero,
        Menu,
        Battle
    }
}
