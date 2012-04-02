//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EGMGame.Library
{
    public interface IEvent
    {
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
    }
}
