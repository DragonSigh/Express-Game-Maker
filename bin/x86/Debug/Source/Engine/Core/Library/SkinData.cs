//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EGMGame.Library
{
    
    public class SkinData : IGameData
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

        public SkinObjectButton Button;

        public SkinObjectText Text;

        public SkinObjectDynamicBar DynamicBar;

        public SkinObjectCursor Cursor;

        public SkinObjectWindow Window;

        public SkinObjectList List;

        public SkinObjectPointer Pointer;

    }
    public enum TextPosition
    {
        Left,
        Right,
        Center,
        Static
    }
    
    public class SkinObjectButton
    {
        public bool Rounded;

        public int BackgroundID;

        public int LeftID;

        public int RightID;

        public TextPosition TextPosition;
        
        public int StaticTextPosition;

    }
    
    public class SkinObjectText
    {
        public bool Rounded;

        public int BackgroundID;

        public int LeftID;

        public int RightID;

        public int TextOffset;
    }
    
    public class SkinObjectDynamicBar
    {
        public bool Rounded;

        public int BackgroundID;

        public int LeftID;

        public int RightID;

        public int BarBackgroundID;

        public int BarLeftID;

        public int BarRightID;
    }
    
    public class SkinObjectCursor
    {
        public int BackgroundID;

        public Vector2 Hotspot;
    }
    
    public class SkinObjectWindow
    {
        public bool Rounded;

        public int BackgroundID;

        public int TopID;

        public int BottomID;

        public int LeftID;

        public int RightID;

        public int TopLeftID;

        public int TopRightID;

        public int BottomLeftID;

        public int BottomRightID;
    }

    
    public class SkinObjectList
    {
        public bool Rounded;

        public int BackgroundID;

        public int TopID;

        public int BottomID;

        public int LeftID;

        public int RightID;

        public int TopLeftID;

        public int TopRightID;

        public int BottomLeftID;

        public int BottomRightID;
    }
    
    public class SkinObjectPointer
    {
        public int AnimationID;
        public int ActionID;
        public int Direction;

    }
}
