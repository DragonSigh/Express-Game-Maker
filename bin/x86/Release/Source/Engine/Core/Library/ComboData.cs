﻿//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;

namespace EGMGame
{
    public class ComboData : IGameData
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
        /// Start Combo
        /// </summary>
        public int StartCombo;
        /// <summary>
        /// End Combo
        /// </summary>
        public int EndCombo;
        /// <summary>
        /// Combo Effect
        /// </summary>
        public ComboEffect Effect;
    }

    public enum ComboEffect
    {
        ExperienceIncrease5Percent,
        DamageIncrease5Percent
    }
}
