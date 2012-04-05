//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using System.ComponentModel;

namespace EGMGame
{
    [Serializable]
    public class PhysQuicksetData : IGameData
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

        public float Mass = 1f;
        public float Force = 1f;
        public float LinearDrag = 7.0f;
        public float RotationalDrag = 1.0f;
        public float Friction;
        public float Bounce;
        public float Impulse = 1f;

    }
}
