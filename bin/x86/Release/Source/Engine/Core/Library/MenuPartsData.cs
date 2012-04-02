//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Content;

namespace EGMGame.Library
{
    #region Menu
    
    public class MenuWindow : IMenuParts
    {
        public MenuWindow()
        {
            IsContainer = true;
        }

        // Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;
    }
    
    public class MenuButton : IMenuParts
    {
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string text = "";

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        //typeof(XnaColorTypeConvert),//.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        // Events
        //typeof(EventTypeConvert),
        //.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;
        //typeof(EventTypeConvert),
        //.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;
    }
    
    public class MenuOptions : IMenuParts
    {
        public List<ListItem> Options
        {
            get { return options; }
            set { options = value; }
        }
        List<ListItem> options = new List<ListItem>();

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;

        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        //typeof(EventTypeConvert),//.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    #endregion

    #region Text
    
    public class TextPartStatic : IMenuParts
    {
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string text = "";

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;


        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        public bool IsMessage
        {
            get { return isMessage; }
            set { isMessage = value; }
        }
        bool isMessage;
    }
    
    public class TextPartSaveLoad : IMenuParts
    {
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;


        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;


        /// <summary>
        /// Party Index
        /// </summary>
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        int index = 0;

        public FileDisplayType Display
        {
            get { return display; }
            set { display = value; }
        }
        FileDisplayType display;


    }
    
    public class TextPartParty : IMenuParts
    {
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        public PartyPropertyType PropertyType
        {
            get { return propType; }
            set { propType = value; }
        }
        PartyPropertyType propType;

        public int LevelPlus
        {
            get { return levelPlus; }
            set { levelPlus = value; }
        }
        int levelPlus = 0;
        /// <summary>
        /// Property
        /// </summary>
        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property;
    }
    
    public class TextPartPartyFromList : IMenuParts
    {
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        public PartyPropertyType PropertyType
        {
            get { return propType; }
            set { propType = value; }
        }
        PartyPropertyType propType;

        public int LevelPlus
        {
            get { return levelPlus; }
            set { levelPlus = value; }
        }
        int levelPlus = 0;
        /// <summary>
        /// Property
        /// </summary>
        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property;
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
    }
    
    public class TextPartSource : IMenuParts
    {

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        public int Database
        {
            get { return dataBase; }
            set { dataBase = value; }
        }
        int dataBase = -1;

        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        int data = -1;

        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property = -1;
    }
    
    public class TextPartData : IMenuParts
    {

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        public int Database
        {
            get { return dataBase; }
            set { dataBase = value; }
        }
        int dataBase = -1;

        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        int data = -1;

        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property = -1;
    }
    
    public class TextPartString : IMenuParts
    {

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;


        public int String
        {
            get { return stringId; }
            set { stringId = value; }
        }
        int stringId = -1;
    }
    
    public class TextPartVariable : IMenuParts
    {

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;


        public int Decimals;
    }
    
    public class TextPartItem : IMenuParts
    {
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;

        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID;

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;



        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    
    public class TextPartSkill : IMenuParts
    {
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;

        public int SkillID
        {
            get { return skillID; }
            set { skillID = value; }
        }
        int skillID = 0;

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    
    public class TextPartEquipment : IMenuParts
    {
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;

        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    
    public class TextPartCount : IMenuParts
    {
        public ShowCountType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowCountType show;

        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    
    public class TextPartEquipped : IMenuParts
    {

        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;

        public int SlotID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;


        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    
    public class TextPartEquipped2 : IMenuParts
    {

        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;

        public int EquipmentID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;


        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    
    public class TextPartEquipStat : IMenuParts
    {
        public int EquipmentID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex;

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    
    public class TextPartEquippedStatFromList : IMenuParts
    {
        public int EquipmentID
        {
            get { return equipID; }
            set { equipID = value; }
        }
        int equipID = 0;

        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property;

        public int SlotID
        {
            get { return slotID; }
            set { slotID = value; }
        }
        int slotID = 0;

        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex;

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
    }
    
    public class TextPartEquippedStat : IMenuParts
    {
        public int EquipmentID
        {
            get { return equipID; }
            set { equipID = value; }
        }
        int equipID = 0;

        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property;

        public int SlotID
        {
            get { return slotID; }
            set { slotID = value; }
        }
        int slotID = 0;

        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex;

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    
    public class TextPartNameParty : IMenuParts
    {
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

    }
    
    public class TextPartNamePartyFromList : IMenuParts
    {
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;

    }
    #endregion

    #region List
    
    public class ListStatic : IMenuParts
    {
        public List<ListItem> Options
        {
            get { return options; }
            set { options = value; }
        }
        List<ListItem> options = new List<ListItem>();


        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;

        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListParty : IMenuParts
    {
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;

        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListPartyFromList : IMenuParts
    {
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;

        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
    }
    
    public class ListItem : IMenuParts
    {
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string text = "";

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        // Icon Material id

        public int Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        int icon = -1;
    }
    
    public class ListItemPartyFromList : IMenuParts
    {
        #region List
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;


        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType;

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;


        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
    }
    
    public class ListItemParty : IMenuParts
    {
        #region List
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;


        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType;

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;


        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListSkillPartyFromList : IMenuParts
    {
        #region List
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType;
        /// <summary>
        /// Highlight Border Color
        /// </summary>

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion

        public SkillType Show
        {
            get { return show; }
            set { show = value; }
        }
        SkillType show = SkillType.Skill;
        // Show Icon

        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowCost
        {
            get { return showCost; }
            set { showCost = value; }
        }
        bool showCost = true;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
    }
    
    public class ListSkillParty : IMenuParts
    {
        #region List
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType;
        /// <summary>
        /// Highlight Border Color
        /// </summary>

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion

        public SkillType Show
        {
            get { return show; }
            set { show = value; }
        }
        SkillType show = SkillType.Skill;
        // Show Icon

        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowCost
        {
            get { return showCost; }
            set { showCost = value; }
        }
        bool showCost = true;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListEquipmentParty : IMenuParts
    {
        #region List
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType;

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Disable Slots
        /// </summary>
        public bool DisableSlots
        {
            get { return disableSlots; }
            set { disableSlots = value; }
        }
        bool disableSlots;
        /// <summary>
        /// Selected Slot
        /// </summary>
        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListEquipmentPartyFromList : IMenuParts
    {
        #region List
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType;

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Disable Slots
        /// </summary>
        public bool DisableSlots
        {
            get { return disableSlots; }
            set { disableSlots = value; }
        }
        bool disableSlots;
        /// <summary>
        /// Selected Slot
        /// </summary>
        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }

        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
    }
    
    public class ListEquippedParty : IMenuParts
    {
        #region List
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType;

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Selected Slot
        /// </summary>
        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListEquippedPartyFromList : IMenuParts
    {
        #region List
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = -1;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType;

        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Selected Slot
        /// </summary>
        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }

        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;

    }
    
    public class ListItemShop : IMenuParts
    {
        #region List

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListEquipmentShop : IMenuParts
    {
        #region List

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int Slot
        {
            get { return slot; }
            set { slot = value; }
        }
        int slot = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListItemSource : IMenuParts
    {
        #region List

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;
        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListSkillSource : IMenuParts
    {
        #region List

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion

        public SkillType Show
        {
            get { return show; }
            set { show = value; }
        }
        SkillType show = SkillType.Skill;
        // Show Icon

        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowCost
        {
            get { return showCost; }
            set { showCost = value; }
        }
        bool showCost = true;

        /// <summary>
        /// List
        /// </summary>
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListEquipmentSource : IMenuParts
    {
        #region List

        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
        #endregion
        // Show Icon
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;

        public bool DisableSlots
        {
            get { return disableSlots; }
            set { disableSlots = value; }
        }
        bool disableSlots;

        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;

        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;

        #region Events
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    
    public class ListSaveLoad : IMenuParts
    {
        #region List
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
        int columns = 1;

        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;

        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed;

        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected;

        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex;
        #endregion

        public int MaxFiles
        {
            get { return maxFiles; }
            set { maxFiles = Math.Min(Math.Max(1, value), 10); }
        }
        int maxFiles = 0;

        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        public bool ShowDate
        {
            get { return showDate; }
            set { showDate = value; }
        }
        bool showDate;

        public bool ShowTime
        {
            get { return showTime; }
            set { showTime = value; }
        }
        bool showTime;

        public Vector2 NamePos
        {
            get { return namePos; }
            set { namePos = value; }
        }
        Vector2 namePos;

        public Vector2 DatePos
        {
            get { return datePos; }
            set { datePos = value; }
        }
        Vector2 datePos;

        public Vector2 TimePos
        {
            get { return timePos; }
            set { timePos = value; }
        }
        Vector2 timePos;

        public Vector2 TextOffset { get; set; }
        public Vector2 CursorOffset { get; set; }
    }
    #endregion

    #region Dynamic Bar
    
    public class DynamicBarPartyFromList : IMenuParts
    {
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        public PartyPropertyType PropertyType
        {
            get { return propType; }
            set { propType = value; }
        }
        PartyPropertyType propType;

        public int LevelPlus
        {
            get { return levelPlus; }
            set { levelPlus = value; }
        }
        int levelPlus = 0;
        /// <summary>
        /// Property
        /// </summary>
        public int MaxProperty
        {
            get { return maxproperty; }
            set { maxproperty = value; }
        }
        int maxproperty;
        /// <summary>
        /// Property
        /// </summary>
        public int MinProperty
        {
            get { return min; }
            set { min = value; }
        }
        int min;
        /// <summary>
        /// Property
        /// </summary>
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        int _value;
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
    }
    
    public class DynamicBarParty : IMenuParts
    {
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        public PartyPropertyType PropertyType
        {
            get { return propType; }
            set { propType = value; }
        }
        PartyPropertyType propType;

        public int LevelPlus
        {
            get { return levelPlus; }
            set { levelPlus = value; }
        }
        int levelPlus = 0;
        /// <summary>
        /// Property
        /// </summary>
        public int MaxProperty
        {
            get { return maxproperty; }
            set { maxproperty = value; }
        }
        int maxproperty;
        /// <summary>
        /// Property
        /// </summary>
        public int MinProperty
        {
            get { return min; }
            set { min = value; }
        }
        int min;
        /// <summary>
        /// Property
        /// </summary>
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        int _value;
    }
    
    public class DynamicBarVariable : IMenuParts
    {
        public int VariableMax
        {
            get { return variableMax; }
            set { variableMax = value; }
        }
        int variableMax = -1;

        public int VariableMin
        {
            get { return variableMin; }
            set { variableMin = value; }
        }
        int variableMin = -1;

        public int VariableValue
        {
            get { return variableValue; }
            set { variableValue = value; }
        }
        int variableValue = -1;

    }
    #endregion

    #region Aniamtion
    
    public class AnimationPartPartyFromList : IMenuParts
    {
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex;
        /// <summary>
        /// Action Index
        /// </summary>
        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        int action;
        /// <summary>
        /// Animation ID
        /// </summary>
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        int direction;

        public string DirectionName
        {
            get
            {
                switch (direction)
                {
                    case 0:
                        return "Up";
                    case 1:
                        return "Down";
                    case 2:
                        return "Left";
                    case 3:
                        return "Right";
                    case 4:
                        return "Up/Left";
                    case 5:
                        return "Up/Right";
                    case 6:
                        return "Down/Left";
                    case 7:
                        return "Down/Right";
                }
                return "Up";
            }

            set
            {
                switch ((string)value)
                {
                    case "Up":
                        direction = 0;
                        break;
                    case "Down":
                        direction = 1;
                        break;
                    case "Left":
                        direction = 2;
                        break;
                    case "Right":
                        direction = 3;
                        break;
                    case "Up/Left":
                        direction = 4;
                        break;
                    case "Up/Right":
                        direction = 5;
                        break;
                    case "Down/Left":
                        direction = 6;
                        break;
                    case "Down/Right":
                        direction = 7;
                        break;
                }
            }
        }

        public bool Animate
        {
            get { return animate; }
            set { animate = value; }
        }
        bool animate;

        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
    }
    
    public class AnimationPartParty : IMenuParts
    {
        /// <summary>
        /// Party Index
        /// </summary>
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex;
        /// <summary>
        /// Action Index
        /// </summary>
        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        int action;
        /// <summary>
        /// Animation ID
        /// </summary>
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        int direction;

        public string DirectionName
        {
            get
            {
                switch (direction)
                {
                    case 0:
                        return "Up";
                    case 1:
                        return "Down";
                    case 2:
                        return "Left";
                    case 3:
                        return "Right";
                    case 4:
                        return "Up/Left";
                    case 5:
                        return "Up/Right";
                    case 6:
                        return "Down/Left";
                    case 7:
                        return "Down/Right";
                }
                return "Up";
            }

            set
            {
                switch ((string)value)
                {
                    case "Up":
                        direction = 0;
                        break;
                    case "Down":
                        direction = 1;
                        break;
                    case "Left":
                        direction = 2;
                        break;
                    case "Right":
                        direction = 3;
                        break;
                    case "Up/Left":
                        direction = 4;
                        break;
                    case "Up/Right":
                        direction = 5;
                        break;
                    case "Down/Left":
                        direction = 6;
                        break;
                    case "Down/Right":
                        direction = 7;
                        break;
                }
            }
        }

        public bool Animate
        {
            get { return animate; }
            set { animate = value; }
        }
        bool animate;
    }
    
    public class AnimationPartStatic : IMenuParts
    {
        /// <summary>
        /// Animation ID
        /// </summary>

        public int Animation
        {
            get { return animation; }
            set { animation = value; }
        }
        int animation = -1;
        /// <summary>
        /// Action ID
        /// </summary>
        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        int action = -1;
        /// <summary>
        /// Animation ID
        /// </summary>

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        int direction = 0;
        public string DirectionName
        {
            get
            {
                switch (direction)
                {
                    case 0:
                        return "Up";
                    case 1:
                        return "Down";
                    case 2:
                        return "Left";
                    case 3:
                        return "Right";
                    case 4:
                        return "Up/Left";
                    case 5:
                        return "Up/Right";
                    case 6:
                        return "Down/Left";
                    case 7:
                        return "Down/Right";
                }
                return "Up";
            }

            set
            {
                switch ((string)value)
                {
                    case "Up":
                        direction = 0;
                        break;
                    case "Down":
                        direction = 1;
                        break;
                    case "Left":
                        direction = 2;
                        break;
                    case "Right":
                        direction = 3;
                        break;
                    case "Up/Left":
                        direction = 4;
                        break;
                    case "Up/Right":
                        direction = 5;
                        break;
                    case "Down/Left":
                        direction = 6;
                        break;
                    case "Down/Right":
                        direction = 7;
                        break;
                }
            }
        }

        public bool Animate
        {
            get { return animate; }
            set { animate = value; }
        }
        bool animate = false;
    }
    #endregion

    
    public class TextBoxPart : IMenuParts
    {
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;


        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        public int String
        {
            get { return stringId; }
            set { stringId = value; }
        }
        int stringId = -1;

        public bool AllowSpaces
        {
            get;
            set;
        }
        public bool AllowSpecialChar
        {
            get;
            set;
        }
        public bool PasswordChars
        {
            get;
            set;
        }
        public string DoNotAllow
        {
            get;
            set;
        }
        public int MaxNumberOfChars
        {
            get;
            set;
        }
    }

    
    public class ImagePart : IMenuParts
    {
        /// <summary>
        /// Image
        /// </summary>

        public int Image
        {
            get { return image; }
            set { image = value; }
        }
        int image;
    }

    
    public class HighlighterStatic : IMenuParts
    {
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient;
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor;
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient;
    }

    
    public class BackgroundProcessPart : IMenuParts
    {
        public List<EventProgramData> BackgroundEvent = new List<EventProgramData>();
    }

    
    public enum BorderType
    {
        None,
        Single
    }

    
    public enum ListSelectionType
    {
        None,
        Rectangle,
        Cursor
    }

    
    public enum SourceType
    {
        AllItems,
        Items,
        Skills,
        Magics,
        Equipment,
        Heroes,
        Enemies
    }

    
    //[XmlInclude(typeof(MenuWindow))]
    //[XmlInclude(typeof(MenuButton))]
    //[XmlInclude(typeof(MenuOptions))]
    //[XmlInclude(typeof(TextPartCount))]
    //[XmlInclude(typeof(TextPartData))]
    //[XmlInclude(typeof(TextPartEquipment))]
    //[XmlInclude(typeof(TextPartEquipped))]
    //[XmlInclude(typeof(TextPartEquipped2))]
    //[XmlInclude(typeof(TextPartEquipStat))]
    //[XmlInclude(typeof(TextPartEquippedStat))]
    //[XmlInclude(typeof(TextPartItem))]
    //[XmlInclude(typeof(TextPartNameParty))]
    //[XmlInclude(typeof(TextPartSkill))]
    //[XmlInclude(typeof(TextPartSource))]
    //[XmlInclude(typeof(TextPartStatic))]
    //[XmlInclude(typeof(TextPartString))]
    //[XmlInclude(typeof(TextPartVariable))]
    //[XmlInclude(typeof(ImagePart))]
    //[XmlInclude(typeof(HighlighterStatic))]
    //[XmlInclude(typeof(ListItem))]
    //[XmlInclude(typeof(ListItemParty))]
    //[XmlInclude(typeof(ListItemShop))]
    //[XmlInclude(typeof(ListItemSource))]
    //[XmlInclude(typeof(ListParty))]
    //[XmlInclude(typeof(ListSkillParty))]
    //[XmlInclude(typeof(ListEquipmentParty))]
    //[XmlInclude(typeof(ListEquipmentShop))]
    //[XmlInclude(typeof(ListEquipmentSource))]
    //[XmlInclude(typeof(ListEquippedParty))]
    //[XmlInclude(typeof(ListSkillSource))]
    //[XmlInclude(typeof(ListStatic))]
    //[XmlInclude(typeof(DynamicBarParty))]
    //[XmlInclude(typeof(DynamicBarVariable))]
    //[XmlInclude(typeof(AnimationPartParty))]
    //[XmlInclude(typeof(AnimationPartStatic))]
    //[XmlInclude(typeof(ListSaveLoad))]
    //[XmlInclude(typeof(TextPartSaveLoad))]
    //[XmlInclude(typeof(TextBoxPart))]
    public class IMenuParts : IGameData
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
        /// Contains the menu parts of the menu.
        /// </summary>

        public List<IMenuParts> MenuParts
        {
            get { return menuParts; }
            set { menuParts = value; }
        }
        List<IMenuParts> menuParts = new List<IMenuParts>();
        /// <summary>
        /// Contains the menu parts of the menu.
        /// </summary>

        public bool IsContainer
        {
            get { return container; }
            set { container = value; }
        }
        bool container = false;
        /// <summary>
        /// Gets or sets whether the object is enabled or not.
        /// </summary> 
        public bool Enabled
        {
            get
            {
                if (parent != null && !parent.Enabled)
                    return false;
                return enabled;
            }
            set { enabled = value; }
        }
        bool enabled = true;
        /// <summary>
        /// Gets or sets whether the object is enabled or not.
        /// </summary> 
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        bool visible = true;
        /// <summary>
        /// Anchor position
        /// </summary>
        public Anchor Anchor
        {
            get { return anchor; }
            set { anchor = value; }
        }
        Anchor anchor = Anchor.Top | Anchor.Left;
        /// <summary>
        /// Gets or sets the skin id of the object.
        /// </summary>
        public int SkinID
        {
            get { return skinId; }
            set { skinId = value; }
        }
        int skinId = -1;
        /// <summary>
        /// Parent
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize, XmlIgnore]
        public IMenuParts Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        IMenuParts parent;
        /// <summary>
        /// Real Position
        /// </summary>
        public Vector2 RealPosition
        {
            get
            {
                if (parent == null)
                    return position;
                else
                    return parent.RealPosition + position;
            }
        }
        /// <summary>
        /// Start gradient
        /// </summary>
        public Color StartGradient
        {
            get { return startGradient; }
            set { startGradient = value; }
        }
        Color startGradient = Color.White;
        /// <summary>
        /// End gradient
        /// </summary>
        public Color EndGradient
        {
            get { return endGradient; }
            set { endGradient = value; }
        }
        Color endGradient = Color.LightBlue;
        /// <summary>
        /// The rectangle holding the position(x, y) and size(width, height) of the object.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public Rectangle Bounds
        {
            get
            {
                bounds.X = (int)RealPosition.X;
                bounds.Y = (int)RealPosition.Y;
                bounds.Width = (int)Width;
                bounds.Height = (int)Height;
                return bounds;
            }
        }
        Rectangle bounds = new Rectangle();

        /// <summary>
        /// Position of the object.
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position = new Vector2(0, 0);

        /// <summary>
        /// The X position of the object.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        /// <summary>
        /// The Y position of the object.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]

        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        /// <summary>
        /// Gets or sets the size of the object.
        /// </summary>
        public Vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        Vector2 size = new Vector2(0, 0);
        /// <summary>
        /// Gets or sets the width of the object.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]
        public float Width
        {
            get
            {
                return size.X;
            }
            set
            {
                size.X = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the object.
        /// </summary>
        [XmlIgnore, ContentSerializerIgnore, DoNotSerialize]

        public float Height
        {
            get
            {
                return size.Y;
            }
            set
            {
                size.Y = value;
            }
        }
        /// <summary>
        /// Gets or sets whether the object will be flipped on the horizontal axis.
        /// </summary>
        public bool HorizontalFlip
        {
            get { return horizontalFlip; }
            set { horizontalFlip = value; }
        }
        bool horizontalFlip;

        /// <summary>
        /// Gets or sets whether the object will be flipped on the vertical axis.
        /// </summary>
        public bool VerticalFlip
        {
            get { return verticalFlip; }
            set { verticalFlip = value; }
        }
        bool verticalFlip;

        /// <summary>
        /// Gets or sets the opacity of the animation.
        /// </summary>
        public byte Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }
        byte opacity = 255;

        /// <summary>
        /// Gets or sets the tint of the animation.
        /// </summary>
        public Color Tint
        {
            get { return tint; }
            set { tint = value; }
        }
        Color tint = Color.White;
        /// <summary>
        /// Stores events on visible changed.
        /// </summary>
        public List<EventProgramData> OnVisibleChanged
        {
            get { return onVisibleChanged; }
            set { onVisibleChanged = value; }
        }
        List<EventProgramData> onVisibleChanged;
        /// <summary>
        /// Srotres events on enabled changed.
        /// </summary>
        public List<EventProgramData> OnEnableChanged
        {
            get { return onEnableChanged; }
            set { onEnableChanged = value; }
        }
        List<EventProgramData> onEnableChanged;
        /// <summary>
        /// On Confirm
        /// </summary>
        public List<EventProgramData> OnConfirm
        {
            get { return onConfirm; }
            set { onConfirm = value; }
        }
        List<EventProgramData> onConfirm;
        /// <summary>
        /// On Cancel
        /// </summary>
        public List<EventProgramData> OnCancel
        {
            get { return onCancel; }
            set { onCancel = value; }
        }
        List<EventProgramData> onCancel;

        public List<EventProgramData> OnKeyPress
        {
            get { return onKeyPress; }
            set { onKeyPress = value; }
        }
        List<EventProgramData> onKeyPress;

        public List<EventProgramData> OnKeyRelease
        {
            get { return onKeyRelease; }
            set { onKeyRelease = value; }
        }
        List<EventProgramData> onKeyRelease;

        public List<EventProgramData> OnKeyDown
        {
            get { return onKeyDown; }
            set { onKeyDown = value; }
        }
        List<EventProgramData> onKeyDown;

        public List<EventProgramData> OnMouseDown
        {
            get { return onMouseDown; }
            set { onMouseDown = value; }
        }
        List<EventProgramData> onMouseDown;

        public List<EventProgramData> OnMouseUp
        {
            get { return onMouseUp; }
            set { onMouseUp = value; }
        }
        List<EventProgramData> onMouseUp;

        public List<EventProgramData> OnMouseMove
        {
            get { return onMouseMove; }
            set { onMouseMove = value; }
        }
        List<EventProgramData> onMouseMove;

        public List<EventProgramData> OnMouseEnter
        {
            get { return onMouseEnter; }
            set { onMouseEnter = value; }
        }
        List<EventProgramData> onMouseEnter;

        public List<EventProgramData> OnMouseLeave
        {
            get { return onMouseLeave; }
            set { onMouseLeave = value; }
        }
        List<EventProgramData> onMouseLeave;

        public List<EventProgramData> OnMouseHover
        {
            get { return onMouseHover; }
            set { onMouseHover = value; }
        }
        List<EventProgramData> onMouseHover;
    }

    
    [Flags]
    public enum Anchor
    {
        None = 0,
        Top = 1,
        Bottom = 2,
        Left = 4,
        Right = 8
    }

    public enum PartyPropertyType
    {
        Modified,
        Unmodified,
        Difference
    }

    public enum ShowItemType
    {
        Name,
        Cost,
        Value,
        Description,
        Icon
    }

    
    public enum ShowCountType
    {
        Item,
        Equipment
    }

    public enum FileDisplayType
    {
        Name,
        Date,
        Time
    }
}
