//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using System.ComponentModel;

namespace EGMGame
{
    public class ComboData : IGameData
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
        /// Start Combo
        /// </summary>
        public int StartCombo
        {
            get { return startCOmbo; }
            set { startCOmbo = value; }
        }
        int startCOmbo = 1;
        /// <summary>
        /// End Combo
        /// </summary>
        public int EndCombo
        {
            get { return endCombo; }
            set { endCombo = value;}
        }
        int endCombo = 1;
        /// <summary>
        /// Combo Effect
        /// </summary>
        public ComboEffect Effect
        {
            get { return comboEffect; }
            set { comboEffect = value; }
        }
        ComboEffect comboEffect = ComboEffect.ExperienceIncrease5Percent;
    }

    public enum ComboEffect
    {
        ExperienceIncrease5Percent,
        DamageIncrease5Percent
    }
}
