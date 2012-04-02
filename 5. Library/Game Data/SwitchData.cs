using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EGMGame.Library
{   
    /// <summary>
    /// Stores all the necessary switch data.
    /// Including the integer sate of the switch.
    /// </summary>
    [Serializable]
    public class SwitchData : IGameData
    {
        /// <summary>
        /// Name of the switch.
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id of the switch.
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
        /// Switch's state. TRUE = ON/FALSE = OFF.
        /// </summary>
        public bool State
        {
            get { return state; }
            set { state = value; }
         }
        bool state = false;

    }
    /// <summary>
    /// Stores the conditions a switch can be compared to.
    /// </summary>
    [Serializable]
    public class SwitchCondition : IGameData 
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
        /// Gets or sets the ID of the switch being compared.
        /// </summary>
        public int SwitchID
        {
            get { return switchID; }
            set { switchID = value; }
        }
        int switchID;
        /// <summary>
        /// Gets or sets the state which the switch will be compared to.
        /// </summary>
        public bool State
        {
            get { return state; }
            set { state = value; }
        }
        bool state;
        
        /// <summary>
        /// Determines if this is an OR condition or not.
        /// </summary>
        public bool OR
        {
            get { return oR; }
            set { oR = value; }
        }
        bool oR = false;
    }
    /// <summary>
    /// Stores the local conditions a switch can be compared to.
    /// </summary>
    [Serializable]
    public class LocalSwitchCondition : IGameData
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
        /// Gets or sets the ID of the switch being compared.
        /// </summary>
        public int SwitchID
        {
            get { return switchID; }
            set { switchID = value; }
        }
        int switchID;
        /// <summary>
        /// Gets or sets the state which the switch will be compared to.
        /// </summary>
        public bool State
        {
            get { return state; }
            set { state = value; }
        }
        bool state;

        /// <summary>
        /// Determines if this is an OR condition or not.
        /// </summary>
        public bool OR
        {
            get { return oR; }
            set { oR = value; }
        }
        bool oR = false;
    }
}
