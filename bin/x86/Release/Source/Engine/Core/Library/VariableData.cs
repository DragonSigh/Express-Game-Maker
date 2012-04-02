//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
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
    
    public class VariableData : IGameData
    {
        /// <summary>
        /// Name of the variable.
        /// </summary>

        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        string name;
        /// <summary>
        /// The unique id of the variable.
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
        /// Gets or sets the float value of the variabe.
        /// </summary>
        public float Value;
    }
    /// <summary>
    /// Stores the conditions a variable can be compared to.
    /// </summary>
    
    public class VariableCondition : IGameData
    {
        /// <summary>
        /// Name of the condition.
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
        /// Gets or sets the ID of the variable being compared.
        /// </summary>
        public int VariableID;
        /// <summary>
        /// Gets or sets the ID of the variable that will be compared to the used variable.
        /// </summary>
        public int CompVariableID;
        /// <summary>
        /// 0: Number 1: Variable
        /// </summary>
        public int Type;
        /// <summary>
        /// The value to be compared.
        /// </summary>
        public int Value;
        /// <summary>
        /// Determines if this is an OR condition or not.
        /// </summary>
        public bool OR = false;
        /// <summary>
        /// Variable Operators that determines how the variable will be compared.
        /// </summary>
        public VariableConditions Condition = VariableConditions.Equals;
    }
    /// <summary>
    /// Stores the local conditions a variable can be compared to.
    /// </summary>
    
    public class LocalVariableCondition : IGameData
    {
        /// <summary>
        /// Name
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
        /// Gets or sets the ID of the variable to be used.
        /// </summary>
        public int VariableID;
        /// <summary>
        /// Gets or sets the ID of the variable that will be compared to the used variable.
        /// </summary>
        public int CompVariableID;

        /// <summary>
        /// 0: Number 1: Variable
        /// </summary>
        public int Type;
        /// <summary>
        /// The value to be compared.
        /// </summary>
        public int Value;
        /// <summary>
        /// Determines if this is an OR condition or not.
        /// </summary>
        public bool OR;
        /// <summary>
        /// Variable Operators that determines how the variable will be compared.
        /// </summary>
        public VariableConditions Condition;
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
