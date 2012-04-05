//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace EGMGame.Library
{
    [Serializable]
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

        public SkinObjectButton Button
        {
            get { return button; }
            set { button = value; }
        }
        SkinObjectButton button = new SkinObjectButton();

        public SkinObjectText Text
        {
            get { return text; }
            set { text = value; }
        }
        SkinObjectText text = new SkinObjectText();

        public SkinObjectDynamicBar DynamicBar
        {
            get { return dynamicBar; }
            set { dynamicBar = value; }
        }
        SkinObjectDynamicBar dynamicBar = new SkinObjectDynamicBar();

        public SkinObjectCursor Cursor
        {
            get { return cursor; }
            set { cursor = value; }
        }
        SkinObjectCursor cursor = new SkinObjectCursor();

        public SkinObjectWindow Window
        {
            get { return window; }
            set { window = value; }
        }
        SkinObjectWindow window = new SkinObjectWindow();

        public SkinObjectList List
        {
            get { return list; }
            set { list = value; }
        }
        SkinObjectList list = new SkinObjectList();

        public SkinObjectPointer Pointer
        {
            get { return pointer; }
            set { pointer = value; }
        }
        SkinObjectPointer pointer = new SkinObjectPointer();

        public override string ToString()
        {
            return this.name;
        }
    }
    public enum TextPosition
    {
        Left,
        Right,
        Center,
        Static
    }
    [Serializable]
    public class SkinObjectButton
    {
        public bool Rounded
        {
            get { return rounded; }
            set { rounded = value; }
        }
        bool rounded;

        public int BackgroundID
        {
            get { return backgroundID; }
            set { backgroundID = value; }
        }
        int backgroundID = -1;

        public int LeftID
        {
            get { return leftID; }
            set { leftID = value; }
        }
        int leftID = -1;

        public int RightID
        {
            get { return rightID; }
            set { rightID = value; }
        }
        int rightID = -1;

        public TextPosition TextPosition
        {
            get { return textPosition; }
            set { textPosition = value; }
        }
        TextPosition textPosition;

        public int StaticTextPosition
        {
            get { return staticTextPosition; }
            set { staticTextPosition = value; }
        }
        int staticTextPosition;

    }
    [Serializable]
    public class SkinObjectText
    {
        public bool Rounded
        {
            get { return rounded; }
            set { rounded = value; }
        }
        bool rounded;

        public int BackgroundID
        {
            get { return backgroundID; }
            set { backgroundID = value; }
        }
        int backgroundID = -1;

        public int LeftID
        {
            get { return leftID; }
            set { leftID = value; }
        }
        int leftID = -1;

        public int RightID
        {
            get { return rightID; }
            set { rightID = value; }
        }
        int rightID = -1;

        public int TextOffset
        {
            get { return textOffset; }
            set { textOffset = value; }
        }
        int textOffset;
    }
    [Serializable]
    public class SkinObjectDynamicBar
    {
        public bool Rounded
        {
            get { return rounded; }
            set { rounded = value; }
        }
        bool rounded;

        public int BackgroundID
        {
            get { return backgroundID; }
            set { backgroundID = value; }
        }
        int backgroundID = -1;

        public int LeftID
        {
            get { return leftID; }
            set { leftID = value; }
        }
        int leftID = -1;

        public int RightID
        {
            get { return rightID; }
            set { rightID = value; }
        }
        int rightID = -1;

        public int BarBackgroundID
        {
            get { return barBackgroundID; }
            set { barBackgroundID = value; }
        }
        int barBackgroundID = -1;

        public int BarLeftID
        {
            get { return barLeftID; }
            set { barLeftID = value; }
        }
        int barLeftID = -1;

        public int BarRightID
        {
            get { return barRightID; }
            set { barRightID = value; }
        }
        int barRightID = -1;
    }
    [Serializable]
    public class SkinObjectCursor
    {
        public int BackgroundID
        {
            get { return backgroundID; }
            set { backgroundID = value; }
        }
        int backgroundID = -1;

        public Vector2 Hotspot
        {
            get { return hotspot; }
            set { hotspot = value; }
        }
        Vector2 hotspot;
    }
    [Serializable]
    public class SkinObjectPointer
    {
        public int AnimationID { get; set; }
        public int ActionID { get; set; }
        public int Direction { get; set; }

    }
    [Serializable]
    public class SkinObjectWindow
    {
        public bool Rounded
        {
            get { return rounded; }
            set { rounded = value; }
        }
        bool rounded;

        public int BackgroundID
        {
            get { return backgroundID; }
            set { backgroundID = value; }
        }
        int backgroundID = -1;

        public int TopID
        {
            get { return topID; }
            set { topID = value; }
        }
        int topID = -1;

        public int BottomID
        {
            get { return bottomID; }
            set { bottomID = value; }
        }
        int bottomID = -1;

        public int LeftID
        {
            get { return leftID; }
            set { leftID = value; }
        }
        int leftID = -1;

        public int RightID
        {
            get { return rightID; }
            set { rightID = value; }
        }
        int rightID = -1;

        public int TopLeftID
        {
            get { return topLeftID; }
            set { topLeftID = value; }
        }
        int topLeftID = -1;

        public int TopRightID
        {
            get { return topRightID; }
            set { topRightID = value; }
        }
        int topRightID = -1;

        public int BottomLeftID
        {
            get { return bottomLeftID; }
            set { bottomLeftID = value; }
        }
        int bottomLeftID = -1;

        public int BottomRightID
        {
            get { return bottomRightID; }
            set { bottomRightID = value; }
        }
        int bottomRightID = -1;
    }

    [Serializable]
    public class SkinObjectList
    {
        public bool Rounded
        {
            get { return rounded; }
            set { rounded = value; }
        }
        bool rounded;

        public int BackgroundID
        {
            get { return backgroundID; }
            set { backgroundID = value; }
        }
        int backgroundID = -1;

        public int TopID
        {
            get { return topID; }
            set { topID = value; }
        }
        int topID = -1;

        public int BottomID
        {
            get { return bottomID; }
            set { bottomID = value; }
        }
        int bottomID = -1;

        public int LeftID
        {
            get { return leftID; }
            set { leftID = value; }
        }
        int leftID = -1;

        public int RightID
        {
            get { return rightID; }
            set { rightID = value; }
        }
        int rightID = -1;

        public int TopLeftID
        {
            get { return topLeftID; }
            set { topLeftID = value; }
        }
        int topLeftID = -1;

        public int TopRightID
        {
            get { return topRightID; }
            set { topRightID = value; }
        }
        int topRightID = -1;

        public int BottomLeftID
        {
            get { return bottomLeftID; }
            set { bottomLeftID = value; }
        }
        int bottomLeftID = -1;

        public int BottomRightID
        {
            get { return bottomRightID; }
            set { bottomRightID = value; }
        }
        int bottomRightID = -1;
    }
}
