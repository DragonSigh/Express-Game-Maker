//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EGMGame.Library
{
    public interface IEvent
    {
        string Name { get; set; }

        int MapID
        {
            get;
            set;
        }

        List<EventPageData> Pages
        {
            get;
            set;
        }
        /// <summary>
        /// Variables
        /// </summary>
        Dictionary<int, VariableData> Variables
        {
            get;
            set;
        }
        /// <summary>
        /// Switches
        /// </summary>
        Dictionary<int, SwitchData> Switches
        {
            get;
            set;
        }
        int SelectedPage { get; set; }

        int ID { get; set; }

    }

    [XmlInclude(typeof(EventPageData))]
    [XmlInclude(typeof(EventProgramData))]
    [Serializable]
    public abstract class IEventProgram : IGameData
    {
        public virtual List<EventProgramData> Programs { get; set; }

        public virtual ProgramCategory ProgramCategory { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual int Code { get; set; }
    }
}
