//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores all the necessary variable data.
    /// Including the integer value of the variable.
    /// </summary>
    [Serializable]
    public class VariableData : IGameData
    {
        /// <summary>
        /// Name of the variable.
        /// </summary>
        [Browsable(false)]
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id of the variable.
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
        /// Gets or sets the integer value of the variabe.
        /// </summary>
        public float Value
        {
            get { return val; }
            set { val = value; }
        }
        float val;

        /// <summary>
        /// To string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name;
        }
    }
    /// <summary>
    /// Stores the conditions a variable can be compared to.
    /// </summary>
    [Serializable]
    public class VariableCondition: IGameData
    {
        /// <summary>
        /// Name of the condition.
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
        /// Gets or sets the ID of the variable being compared.
        /// </summary>
        public int VariableID
        {
            get { return variableID; }
            set { variableID = value; }
        }
        int variableID;
        /// <summary>
        /// Gets or sets the ID of the variable that will be compared to the used variable.
        /// </summary>
        public int CompVariableID
        {
            get { return cvariableID; }
            set { cvariableID = value; }
        }
        int cvariableID;

        /// <summary>
        /// 0: Number 1: Variable
        /// </summary>
        public int Type
        {
            get { return ctype; }
            set { ctype = value;}
        }
        int ctype = 0;
        /// <summary>
        /// The value to be compared.
        /// </summary>
        public int Value
        {
            get { return val; }
            set { val = value; }
        }
        int val;
        /// <summary>
        /// Determines if this is an OR condition or not.
        /// </summary>
        public bool OR
        {
            get { return oR; }
            set { oR = value; }
        }
        bool oR = false;
        /// <summary>
        /// Variable Operators that determines how the variable will be compared.
        /// </summary>
        public VariableConditions Condition
        {
            get { return condition; }
            set { condition = value; }
        }
        VariableConditions condition = VariableConditions.Equals;
    }
    /// <summary>
    /// Stores the local conditions a variable can be compared to.
    /// </summary>
    [Serializable]
    public class LocalVariableCondition : IGameData
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
        /// Gets or sets the ID of the variable to be used.
        /// </summary>
        public int VariableID
        {
            get { return variableID; }
            set { variableID = value; }
        }
        int variableID;
        /// <summary>
        /// Gets or sets the ID of the variable that will be compared to the used variable.
        /// </summary>
        public int CompVariableID
        {
            get { return cvariableID; }
            set { cvariableID = value; }
        }
        int cvariableID;

        /// <summary>
        /// 0: Number 1: Variable
        /// </summary>
        public int Type
        {
            get { return ctype; }
            set { ctype = value; }
        }
        int ctype = 0;
        /// <summary>
        /// The value to be compared.
        /// </summary>
        public int Value
        {
            get { return val; }
            set { val = value; }
        }
        int val;
        /// <summary>
        /// Determines if this is an OR condition or not.
        /// </summary>
        public bool OR
        {
            get { return oR; }
            set { oR = value; }
        }
        bool oR = false;
        /// <summary>
        /// Variable Operators that determines how the variable will be compared.
        /// </summary>
        public VariableConditions Condition
        {
            get { return condition; }
            set { condition = value; }
        }
        VariableConditions condition = VariableConditions.Equals;
    }

    public enum VariableConditions
    {
        Equals,
        NotEquals,
        LessThan,
        GreaterThan,
        LessThanEquals,
        GreaterThanEquals
    }
}
