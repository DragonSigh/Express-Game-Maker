//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using Microsoft.Xna.Framework.Content;

namespace EGMGame
{
    
    public class PlayerData : EventData
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PlayerData()
        {
        }
        /// <summary>
        /// Gets or sets the player's page.
        /// Player has only one page.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        public EventPageData Page
        {
            get { return this.Pages[0]; }
        }
        /// <summary>
        /// Gets or sets the layer the player is on.
        /// </summary>
        public int LayerIndex;
        /// <summary>
        /// Movement Type
        /// </summary>
        public List<int> MovementType;
        /// <summary>
        /// Contains the party members.
        /// </summary>
        public List<int> PartyList;
        /// <summary>
        /// Max Party Size
        /// </summary>
        public int MaxPartySize;
        /// <summary>
        /// Contains the mapped keys.
        /// </summary>
        public Dictionary<string, int> Keys;
        /// <summary>
        /// Contains the mapped buttons.
        /// </summary>
        public Dictionary<string, int> Buttons;
        public List<Hotkey> MagicKeys;

        public List<Hotkey> SkillKeys;

        public List<Hotkey> ItemKeys;

        public int StartDirection;

        public int AttackPress;
    }

    public class Hotkey : IGameData
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
        /// The id
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

        public int Key1 = -1;

        public int Key2 = -1;

        public int Button1 = -1;

        public int Button2 = -1;

        public int DefaultID;
    }
}
