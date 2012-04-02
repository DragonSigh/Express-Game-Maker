using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using Microsoft.Xna.Framework.Content;
using System.Xml.Serialization;

namespace EGMGame
{
    [Serializable]
    public class PlayerData : EventData
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PlayerData(bool n)
        {
            this.Name = "Player";
            this.ID = -1;
            this.Pages.Add(new EventPageData());
            Page.Name = "Player";
            Page.Enabled = true;
            Page.TriggerConditions = TriggerConditions.BackgroundProcess;
        }
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
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public EventPageData Page
        {
            get
            {
                if (this.Pages.Count == 0)
                {
                    this.Name = "Player";
                    this.ID = -1;
                    this.Pages.Add(new EventPageData());
                    Page.Name = "Player";
                    Page.Enabled = true;
                    Page.TriggerConditions = TriggerConditions.BackgroundProcess;
                }
                return this.Pages[0]; 
            }
        }
        /// <summary>
        /// Gets or sets the layer the player is on.
        /// </summary>
        public int LayerIndex
        {
            get { return layerIndex; }
            set { layerIndex = value; }
        }
        int layerIndex = 0;
        /// <summary>
        /// Movement Type
        /// </summary>
        public List<int> MovementType
        {
            get { return movementType; }
            set { movementType = value; Page.BattleDirections = value; }
        }
        List<int> movementType = new List<int>() { 0, 1, 2, 3 };
        /// <summary>
        /// Contains the party members.
        /// </summary>
        public List<int> PartyList
        {
            get { return partyList; }
            set { partyList = value; }
        }
        List<int> partyList = new List<int>();
        /// <summary>
        /// Max Party Size
        /// </summary>
        public int MaxPartySize
        {
            get { return maxPartySize; }
            set { maxPartySize = value; }
        }
        int maxPartySize = 4;
        /// <summary>
        /// Contains the mapped keys.
        /// </summary>
        public Dictionary<string, int> Keys
        {
            get { return keys; }
            set { keys = value; }
        }
        Dictionary<string, int> keys = new Dictionary<string, int>()
        {
                {"Action", 8},
                {"Cancel", 49},
                {"Attack", 27},
                {"Defend", 45},
                {"Movement",0}
        };
        /// <summary>
        /// Contains the mapped buttons.
        /// </summary>
        public Dictionary<string, int> Buttons
        {
            get { return buttons; }
            set { buttons = value; }
        }
        Dictionary<string, int> buttons = new Dictionary<string, int>()
        {
                {"Action", 7},
                {"Cancel", 8},
                {"Attack", 7},
                {"Defend", 10},
                {"Movement",0}
        };

        public List<Hotkey> MagicKeys
        {
            get { return magicKeys; }
            set { magicKeys = value; }
        }
        List<Hotkey> magicKeys = new List<Hotkey>();

        public List<Hotkey> SkillKeys
        {
            get { return skillKeys; }
            set { skillKeys = value; }
        }
        List<Hotkey> skillKeys = new List<Hotkey>();

        public List<Hotkey> ItemKeys
        {
            get { return itemKeys; }
            set { itemKeys = value; }
        }
        List<Hotkey> itemKeys = new List<Hotkey>();

        public int StartDirection
        {
            get { return startDirection; }
            set { startDirection = value; }
        }
        int startDirection = 0;

        public int AttackPress
        {
            get { return attackPress; }
            set { attackPress = value; }
        }
        int attackPress;
    }

    [Serializable]
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

        public int Key1
        {
            get { return key1; }
            set { key1 = value; }
        }
        int key1;

        public int Key2
        {
            get { return key2; }
            set { key2 = value; }
        }
        int key2 = -1;

        public int Button1
        {
            get { return button1; }
            set { button1 = value; }
        }
        int button1;

        public int Button2
        {
            get { return button2; }
            set { button2 = value; }
        }
        int button2 = -1;

        public int DefaultID
        {
            get { return defaultID; }
            set { defaultID = value; }
        }
        int defaultID = -1;
    }
}
