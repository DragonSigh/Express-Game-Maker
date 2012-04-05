//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
    [Serializable]
    public class MenuWindow : IMenuParts
    {
        public MenuWindow()
        {
            IsContainer = true;
        }

        // Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
    }

    [Serializable]
    public class MenuButton : IMenuParts
    {
        [CategoryAttribute("Text")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string text = "";
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        // Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
    }

    [Serializable]
    public class MenuOptions : IMenuParts
    {
        [CategoryAttribute("List")]
        [Editor(typeof(ListItemTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<ListItem> Options
        {
            get { return options; }
            set { options = value; }
        }
        List<ListItem> options = new List<ListItem>();

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        [DisplayName("Variable"), CategoryAttribute("List"), Description("The variable the selected index should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }

        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;

        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)150);

        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    #endregion

    #region Texts
    [Serializable]
    public class TextPartStatic : IMenuParts
    {
        [CategoryAttribute("Text")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string text = "";
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        [CategoryAttribute("Behavior")]
        public bool IsMessage
        {
            get { return isMessage; }
            set { isMessage = value; }
        }
        bool isMessage;
    }
    [Serializable]
    public class TextPartSource : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        // Database
        [CategoryAttribute("Database"), DisplayName("Database")]
        [Editor(typeof(DatabaseTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public string DatabaseName
        {
            get
            {
                Data cDatabase = Global.GetData<Data>(dataBase, GameData.Databases);
                Data cData;
                DataProperty cProp;
                if (cDatabase != null)
                {
                    cData = Global.GetData<Data>(data, cDatabase.Datas);
                    if (cData != null)
                    {
                        cProp = Global.GetData<DataProperty>(property, cData.Properties);
                        if (cProp != null)
                        {
                            if (cProp.ValueType == DataType.Number)
                            {
                                return "Database: " + cDatabase.Name + " Data: " + cData.Name + " Property: " + cProp.Name;
                            }
                        }
                        return "Database: " + cDatabase.Name + " Data: " + cData.Name + " Property: (None)";
                    }
                    return "Database: " + cDatabase.Name + " Data: (None)" + " Property: (None)";
                }
                return "(None)";
            }
            set { }
        }
        [Browsable(false)]
        public int Database
        {
            get { return dataBase; }
            set { dataBase = value; }
        }
        int dataBase = -1;
        [Browsable(false)]
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        int data = -1;
        [Browsable(false)]
        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property = -1;
    }
    [Serializable]
    public class TextPartData : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        // Database
        [CategoryAttribute("Database"), DisplayName("Database")]
        [Editor(typeof(DatabaseTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public string DatabaseName
        {
            get
            {
                Data cDatabase = Global.GetData<Data>(dataBase, GameData.Databases);
                Data cData;
                DataProperty cProp;
                if (cDatabase != null)
                {
                    cData = Global.GetData<Data>(data, cDatabase.Datas);
                    if (cData != null)
                    {
                        cProp = Global.GetData<DataProperty>(property, cData.Properties);
                        if (cProp != null)
                        {
                            if (cProp.ValueType == DataType.Number)
                            {
                                return "Database: " + cDatabase.Name + " Data: " + cData.Name + " Property: " + cProp.Name;
                            }
                        }
                        return "Database: " + cDatabase.Name + " Data: " + cData.Name + " Property: (None)";
                    }
                    return "Database: " + cDatabase.Name + " Data: (None)" + " Property: (None)";
                }
                return "(None)";
            }
            set { }
        }
        [Browsable(false)]
        public int Database
        {
            get { return dataBase; }
            set { dataBase = value; }
        }
        int dataBase = -1;
        [Browsable(false)]
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        int data = -1;
        [Browsable(false)]
        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property = -1;
    }
    [Serializable]
    public class TextPartString : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        [CategoryAttribute("Variable"), DisplayName("String")]
        [Editor(typeof(StringTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public StringData StringName
        {
            get
            {
                StringData fontData = new StringData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (stringId == -1 || !GameData.Strings.ContainsKey(stringId))
                    return fontData;
                else
                    return GameData.Strings[stringId];
            }

            set
            {
                stringId = value.ID;
            }
        }
        [Browsable(false)]
        public int String
        {
            get { return stringId; }
            set { stringId = value; }
        }
        int stringId = -1;
    }
    [Serializable]
    public class TextPartVariable : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        // Database
        [CategoryAttribute("Variable"), DisplayName("Variable")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        [CategoryAttribute("Variable")]
        public int Decimals { get; set; }
    }
    [Serializable]
    public class TextPartPartyFromList : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [DisplayName("Property Type"), CategoryAttribute("Party")]
        public PartyPropertyType PropertyType
        {
            get { return propType; }
            set { propType = value; }
        }
        PartyPropertyType propType;

        [DisplayName("Level Plus"), CategoryAttribute("Party"), Description("Get the property from the level that is the definded amount above the current level.")]
        public int LevelPlus
        {
            get { return levelPlus; }
            set { levelPlus = value; }
        }
        int levelPlus = 0;
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Property"), CategoryAttribute("Party")]
        [Browsable(false)]
        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property;

        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Property"), CategoryAttribute("Party")]
        [Editor(typeof(PropertyTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [DoNotSerialize, XmlIgnore, ContentSerializerIgnore]
        public string PropertyTypeS
        {
            get
            {
                foreach (DataProperty data in GameData.Databases[0].Properties)
                    if (property == data.ID)
                        return data.Name;
                return "(none)";
            }
            set { property = int.Parse(value); }
        }
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class TextPartParty : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [DisplayName("Property Type"), CategoryAttribute("Party")]
        public PartyPropertyType PropertyType
        {
            get { return propType; }
            set { propType = value; }
        }
        PartyPropertyType propType;

        [DisplayName("Level Plus"), CategoryAttribute("Party"), Description("Get the property from the level that is the definded amount above the current level.")]
        public int LevelPlus
        {
            get { return levelPlus; }
            set { levelPlus = value; }
        }
        int levelPlus = 0;
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Property"), CategoryAttribute("Party")]
        [Browsable(false)]
        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property;
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Property"), CategoryAttribute("Party")]
        [Editor(typeof(PropertyTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [DoNotSerialize, XmlIgnore, ContentSerializerIgnore]
        public string PropertyTypeS
        {
            get
            {
                foreach (DataProperty data in GameData.Databases[0].Properties)
                    if (property == data.ID)
                        return data.Name;
                return "(none)";
            }
            set { property = int.Parse(value); }
        }
    }
    [Serializable]
    public class TextPartItem : IMenuParts
    {
        [DisplayName("Show"), CategoryAttribute("Source")]
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;

        [Browsable(false)]
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Item"), CategoryAttribute("Source"), Description("The variable the item id is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    [Serializable]
    public class TextPartSkill : IMenuParts
    {
        [DisplayName("Show"), CategoryAttribute("Source")]
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;

        [Browsable(false)]
        public int SkillID
        {
            get { return skillID; }
            set { skillID = value; }
        }
        int skillID = 0;
        [DisplayName("Item"), CategoryAttribute("Source"), Description("The variable the skill id is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (skillID == -1 || !GameData.Variables.ContainsKey(skillID))
                    return fontData;
                else
                    return GameData.Variables[skillID];
            }

            set
            {
                skillID = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    [Serializable]
    public class TextPartEquipment : IMenuParts
    {
        [DisplayName("Show"), CategoryAttribute("Source")]
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;

        [Browsable(false)]
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Equipment"), CategoryAttribute("Source"), Description("The variable the equipment id is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    [Serializable]
    public class TextPartCount : IMenuParts
    {
        [DisplayName("Show"), CategoryAttribute("Source")]
        public ShowCountType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowCountType show;

        [Browsable(false)]
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Item"), CategoryAttribute("Source"), Description("The variable the item id is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    [Serializable]
    public class TextPartEquipped : IMenuParts
    {
        [DisplayName("Show"), CategoryAttribute("Source")]
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;
        [Browsable(false)]
        public int SlotID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Slot"), CategoryAttribute("Source"), Description("The variable the slot is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    [Serializable]
    public class TextPartEquipped2 : IMenuParts
    {
        [DisplayName("Show"), CategoryAttribute("Source")]
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;
        [Browsable(false)]
        public int EquipmentID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Equipment"), CategoryAttribute("Source"), Description("The variable the equipment is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    [Serializable]
    public class TextPartEquipStat : IMenuParts
    {
        [Browsable(false)]
        public int EquipmentID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Equipment"), CategoryAttribute("Source"), Description("The variable the equipment is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    [Serializable]
    public class TextPartEquippedStat : IMenuParts
    {
        [Browsable(false)]
        public int EquipmentID
        {
            get { return equipID; }
            set { equipID = value; }
        }
        int equipID = 0;
        [DisplayName("Equipment"), CategoryAttribute("Source"), Description("The variable the compare equipment is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData EquipIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (equipID == -1 || !GameData.Variables.ContainsKey(equipID))
                    return fontData;
                else
                    return GameData.Variables[equipID];
            }

            set
            {
                equipID = value.ID;
            }
        }
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Property"), CategoryAttribute("Source")]
        [Browsable(false)]
        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property;
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Property"), CategoryAttribute("Party")]
        [Editor(typeof(PropertyTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [DoNotSerialize, XmlIgnore, ContentSerializerIgnore]
        public string PropertyType
        {
            get
            {
                foreach (DataProperty data in GameData.Databases[0].Properties)
                    if (property == data.ID)
                        return data.Name;
                return "(none)";
            }
            set { property = int.Parse(value); }
        }

        [Browsable(false)]
        public int SlotID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Slot"), CategoryAttribute("Source"), Description("The variable the slot is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
    }
    [Serializable]
    public class TextPartNameParty : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }
    }

    [Serializable]
    public class TextPartSaveLoad : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        int index = 0;
        [DisplayName("File Index"), CategoryAttribute("File"), Description("The variable the file index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (index == -1 || !GameData.Variables.ContainsKey(index))
                    return fontData;
                else
                    return GameData.Variables[index];
            }

            set
            {
                index = value.ID;
            }
        }


        [DisplayName("File Index"), CategoryAttribute("File"), Description("The variable the file index is stored in.")]
        public FileDisplayType Display
        {
            get { return display; }
            set { display = value; }
        }
        FileDisplayType display;
    }


    [Serializable]
    public class TextPartCountFromList : IMenuParts
    {
        [DisplayName("Show"), CategoryAttribute("Source")]
        public ShowCountType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowCountType show;

        [Browsable(false)]
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Item"), CategoryAttribute("Source"), Description("The variable the item id is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class TextPartEquippedFromList : IMenuParts
    {
        [DisplayName("Show"), CategoryAttribute("Source")]
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;
        [Browsable(false)]
        public int SlotID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Slot"), CategoryAttribute("Source"), Description("The variable the slot is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class TextPartEquipped2FromList : IMenuParts
    {
        [DisplayName("Show"), CategoryAttribute("Source")]
        public ShowItemType Show
        {
            get { return show; }
            set { show = value; }
        }
        ShowItemType show;
        [Browsable(false)]
        public int EquipmentID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Equipment"), CategoryAttribute("Source"), Description("The variable the equipment is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class TextPartEquipStatFromList : IMenuParts
    {
        [Browsable(false)]
        public int EquipmentID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Equipment"), CategoryAttribute("Source"), Description("The variable the equipment is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class TextPartEquippedStatFromList : IMenuParts
    {
        [Browsable(false)]
        public int EquipmentID
        {
            get { return equipID; }
            set { equipID = value; }
        }
        int equipID = 0;
        [DisplayName("Equipment"), CategoryAttribute("Source"), Description("The variable the compare equipment is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData EquipIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (equipID == -1 || !GameData.Variables.ContainsKey(equipID))
                    return fontData;
                else
                    return GameData.Variables[equipID];
            }

            set
            {
                equipID = value.ID;
            }
        }
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Property"), CategoryAttribute("Source")]
        [Browsable(false)]
        public int Property
        {
            get { return property; }
            set { property = value; }
        }
        int property;
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Property"), CategoryAttribute("Party")]
        [Editor(typeof(PropertyTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [DoNotSerialize, XmlIgnore, ContentSerializerIgnore]
        public string PropertyType
        {
            get
            {
                foreach (DataProperty data in GameData.Databases[0].Properties)
                    if (property == data.ID)
                        return data.Name;
                return "(none)";
            }
            set { property = int.Parse(value); }
        }

        [Browsable(false)]
        public int SlotID
        {
            get { return itemID; }
            set { itemID = value; }
        }
        int itemID = 0;
        [DisplayName("Slot"), CategoryAttribute("Source"), Description("The variable the slot is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData ItemIDName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (itemID == -1 || !GameData.Variables.ContainsKey(itemID))
                    return fontData;
                else
                    return GameData.Variables[itemID];
            }

            set
            {
                itemID = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Source"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class TextPartNamePartyFromList : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }

    #endregion

    #region Lists
    [Serializable]
    public class ListPartyFromList : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        [DisplayName("Variable"), CategoryAttribute("List"), Description("The variable the selected index should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }

        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;

        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);

        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }

        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }

    }
    [Serializable]
    public class ListStatic : IMenuParts
    {
        [CategoryAttribute("List")]
        [Editor(typeof(ListItemTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<ListItem> Options
        {
            get { return options; }
            set { options = value; }
        }
        List<ListItem> options = new List<ListItem>();

        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        [DisplayName("Variable"), CategoryAttribute("List"), Description("The variable the selected index should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }

        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;

        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);

        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListParty : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        [DisplayName("Variable"), CategoryAttribute("List"), Description("The variable the selected index should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }

        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;

        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);

        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListItem : IMenuParts
    {
        #region List
        [CategoryAttribute("Text")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string text;
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        [Browsable(false)]
        public int Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        int icon = -1;

        [DisplayName("Icon"), CategoryAttribute("Image")]
        [Editor(typeof(MaterialTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public MaterialData IconName
        {
            get
            {
                MaterialData fontData = new MaterialData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (icon == -1 || !GameData.Materials.ContainsKey(icon))
                    return fontData;
                else
                    return GameData.Materials[icon];
            }

            set
            {
                icon = value.ID;
            }
        }
        #endregion
    }
    [Serializable]
    public class ListItemParty : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Item"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;
        [DisplayName("Show Count"), CategoryAttribute("Item")]
        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListItemPartyFromList : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Item"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;
        [DisplayName("Show Count"), CategoryAttribute("Item")]
        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class ListSkillParty : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Skill"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion

        public SkillType Show
        {
            get { return show; }
            set { show = value; }
        }
        SkillType show = SkillType.Skill;
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Skill")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Skill")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Cost"), CategoryAttribute("Skill")]
        public bool ShowCost
        {
            get { return showCost; }
            set { showCost = value; }
        }
        bool showCost = true;
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListEquipmentParty : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Item"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;
        [DisplayName("Show Count"), CategoryAttribute("Item")]
        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Disable Slots
        /// </summary>
        [DisplayName("Disable Slots"), CategoryAttribute("Item"), Description("Determines if the slots other then the selected slot should be disabled.")]
        public bool DisableSlots
        {
            get { return disableSlots; }
            set { disableSlots = value; }
        }
        bool disableSlots;
        /// <summary>
        /// Selected Slot
        /// </summary>
        [Browsable(false)]
        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;
        [DisplayName("Selected Slot"), CategoryAttribute("Item"), Description("The variable the slot is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData SelectedSlotName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (selectedSlot == -1 || !GameData.Variables.ContainsKey(selectedSlot))
                    return fontData;
                else
                    return GameData.Variables[selectedSlot];
            }

            set
            {
                selectedSlot = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListEquippedParty : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;
        [DisplayName("Show Count"), CategoryAttribute("Item")]
        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Selected Slot
        /// </summary>
        [Browsable(false)]
        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;
        [DisplayName("Selected Slot"), CategoryAttribute("Item"), Description("The variable the slot is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData SelectedSlotName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (selectedSlot == -1 || !GameData.Variables.ContainsKey(selectedSlot))
                    return fontData;
                else
                    return GameData.Variables[selectedSlot];
            }

            set
            {
                selectedSlot = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListItemShop : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Shop"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]

        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion


        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListEquipmentShop : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Shop"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }

        [Browsable(false)]
        public int Slot
        {
            get { return slot; }
            set { slot = value; }
        }
        int slot = -1;
        [DisplayName("Slot"), CategoryAttribute("Shop"), Description("The variable the selected slot should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData SlotName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (slot == -1 || !GameData.Variables.ContainsKey(slot))
                    return fontData;
                else
                    return GameData.Variables[slot];
            }

            set
            {
                slot = value.ID;
            }
        }

        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion


        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListItemSource : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Item"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;
        [DisplayName("Show Count"), CategoryAttribute("Item")]
        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Source"), Description("The list the items are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListSkillSource : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Skill"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion

        public SkillType Show
        {
            get { return show; }
            set { show = value; }
        }
        SkillType show = SkillType.Skill;
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Skill")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Skill")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Cost"), CategoryAttribute("Skill")]
        public bool ShowCost
        {
            get { return showCost; }
            set { showCost = value; }
        }
        bool showCost = true;

        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Source"), Description("The list the items are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListEquipmentSource : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Item"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;
        [DisplayName("Show Count"), CategoryAttribute("Item")]
        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Disable Slots
        /// </summary>
        [DisplayName("Disable Slots"), CategoryAttribute("Item"), Description("Determines if the slots other then the selected slot should be disabled.")]
        public bool DisableSlots
        {
            get { return disableSlots; }
            set { disableSlots = value; }
        }
        bool disableSlots;
        /// <summary>
        /// Selected Slot
        /// </summary>
        [Browsable(false)]
        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;
        [DisplayName("Selected Slot"), CategoryAttribute("Item"), Description("The variable the slot is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData SelectedSlotName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (selectedSlot == -1 || !GameData.Variables.ContainsKey(selectedSlot))
                    return fontData;
                else
                    return GameData.Variables[selectedSlot];
            }

            set
            {
                selectedSlot = value.ID;
            }
        }

        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Source"), Description("The list the items are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }
    [Serializable]
    public class ListSaveLoad : IMenuParts
    {
        #region LIST
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;

        [DisplayName("Variable"), CategoryAttribute("List"), Description("The variable the selected index should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }

        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;

        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;

        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);

        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [DisplayName("Max Files"), Category("File")]
        public int MaxFiles
        {
            get { return maxFiles; }
            set { maxFiles = Math.Min(Math.Max(1, value), 10); }
        }
        int maxFiles = 0;

        [DisplayName("Name"), Category("File")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;

        [DisplayName("Date"), Category("File")]
        public bool ShowDate
        {
            get { return showDate; }
            set { showDate = value; }
        }
        bool showDate;

        [DisplayName("Time"), Category("File")]
        public bool ShowTime
        {
            get { return showTime; }
            set { showTime = value; }
        }
        bool showTime;

        [DisplayName("Name"), Category("File - Positions")]
        public Vector2 NamePos
        {
            get { return namePos; }
            set { namePos = value; }
        }
        Vector2 namePos;

        [DisplayName("Date"), Category("File - Positions")]
        public Vector2 DatePos
        {
            get { return datePos; }
            set { datePos = value; }
        }
        Vector2 datePos;

        [DisplayName("Time"), Category("File - Positions")]
        public Vector2 TimePos
        {
            get { return timePos; }
            set { timePos = value; }
        }
        Vector2 timePos;


        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
    }


    [Serializable]
    public class ListSkillPartyFromList : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Skill"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion

        public SkillType Show
        {
            get { return show; }
            set { show = value; }
        }
        SkillType show = SkillType.Skill;
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Skill")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Skill")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Cost"), CategoryAttribute("Skill")]
        public bool ShowCost
        {
            get { return showCost; }
            set { showCost = value; }
        }
        bool showCost = true;
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class ListEquipmentPartyFromList : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;
        /// <summary>
        /// Variable
        /// </summary>
        [Browsable(false)]
        public int Variable
        {
            get { return variableId; }
            set { variableId = value; }
        }
        int variableId = -1;
        [DisplayName("Variable"), CategoryAttribute("Item"), Description("The variable the selected item's id should be stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableId == -1 || !GameData.Variables.ContainsKey(variableId))
                    return fontData;
                else
                    return GameData.Variables[variableId];
            }

            set
            {
                variableId = value.ID;
            }
        }
        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;
        [DisplayName("Show Count"), CategoryAttribute("Item")]
        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Disable Slots
        /// </summary>
        [DisplayName("Disable Slots"), CategoryAttribute("Item"), Description("Determines if the slots other then the selected slot should be disabled.")]
        public bool DisableSlots
        {
            get { return disableSlots; }
            set { disableSlots = value; }
        }
        bool disableSlots;
        /// <summary>
        /// Selected Slot
        /// </summary>
        [Browsable(false)]
        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;
        [DisplayName("Selected Slot"), CategoryAttribute("Item"), Description("The variable the slot is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData SelectedSlotName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (selectedSlot == -1 || !GameData.Variables.ContainsKey(selectedSlot))
                    return fontData;
                else
                    return GameData.Variables[selectedSlot];
            }

            set
            {
                selectedSlot = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class ListEquippedPartyFromList : IMenuParts
    {
        #region List
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;
        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }
        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        bool selected = false;
        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        [CategoryAttribute("Appearance"), Description("Determines the height of the options.")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }
        int itemHeight = 32;
        [CategoryAttribute("Appearance")]
        public int Columns
        {
            get { return columns; }
            set { if (value > 0) columns = value; }
        }
        int columns = 1;
        [CategoryAttribute("Appearance"), Description("Determines the selection type.")]
        public ListSelectionType SelectionType
        {
            get { return selectionType; }
            set { selectionType = value; }
        }
        ListSelectionType selectionType = ListSelectionType.Rectangle;

        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
        #endregion
        // Show Icon
        [DisplayName("Show Icon"), CategoryAttribute("Item")]
        public bool ShowIcon
        {
            get { return showIcon; }
            set { showIcon = value; }
        }
        bool showIcon = true;
        [DisplayName("Show Name"), CategoryAttribute("Item")]
        public bool ShowName
        {
            get { return showName; }
            set { showName = value; }
        }
        bool showName = true;
        [DisplayName("Show Price"), CategoryAttribute("Item")]
        public bool ShowPrice
        {
            get { return showPrice; }
            set { showPrice = value; }
        }
        bool showPrice = true;
        [DisplayName("Show Count"), CategoryAttribute("Item")]
        public bool ShowCount
        {
            get { return showCount; }
            set { showCount = value; }
        }
        bool showCount = false;
        /// <summary>
        /// Selected Slot
        /// </summary>
        [Browsable(false)]
        public int SelectedSlot
        {
            get { return selectedSlot; }
            set { selectedSlot = value; }
        }
        int selectedSlot = 0;
        [DisplayName("Selected Slot"), CategoryAttribute("Item"), Description("The variable the slot is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData SelectedSlotName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (selectedSlot == -1 || !GameData.Variables.ContainsKey(selectedSlot))
                    return fontData;
                else
                    return GameData.Variables[selectedSlot];
            }

            set
            {
                selectedSlot = value.ID;
            }
        }
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }

        #region Events
        [CategoryAttribute("Event"), Description("Called when the object is pressed by a cursor or button.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnPressed
        {
            get { return onPressed; }
            set { onPressed = value; }
        }
        List<EventProgramData> onPressed = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelected
        {
            get { return onSelected; }
            set { onSelected = value; }
        }
        List<EventProgramData> onSelected = new List<EventProgramData>();
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnSelectedIndex
        {
            get { return onSelectedIndex; }
            set { onSelectedIndex = value; }
        }
        List<EventProgramData> onSelectedIndex = new List<EventProgramData>();
        #endregion

        [CategoryAttribute("List"), DisplayName("Text Offset"), Description("Offsets the text and allows you to position it.")]
        public Vector2 TextOffset { get; set; }

        [CategoryAttribute("List"), DisplayName("Cursor Offset"), Description("Offsets the cursor and allows you to position it.")]
        public Vector2 CursorOffset { get; set; }
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    #endregion

    #region Dynamic Bars
    [Serializable]
    public class DynamicBarParty : IMenuParts
    {
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }
        [DisplayName("Property Type"), CategoryAttribute("Party")]
        public PartyPropertyType PropertyType
        {
            get { return propType; }
            set { propType = value; }
        }
        PartyPropertyType propType;

        [DisplayName("Level Plus"), CategoryAttribute("Party"), Description("Get the property from the level that is the definded amount above the current level.")]
        public int LevelPlus
        {
            get { return levelPlus; }
            set { levelPlus = value; }
        }
        int levelPlus = 0;
        /// <summary>
        /// Property
        /// </summary>
        [Browsable(false)]
        public int MaxProperty
        {
            get { return maxproperty; }
            set { maxproperty = value; }
        }
        int maxproperty;
        /// <summary>
        /// Property
        /// </summary>
        [Browsable(false)]
        public int MinProperty
        {
            get { return min; }
            set { min = value; }
        }
        int min;
        /// <summary>
        /// Property
        /// </summary>
        [Browsable(false)]
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        int _value;

        [DisplayName("Value"), CategoryAttribute("Party")]
        [Editor(typeof(PropertyTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [DoNotSerialize, XmlIgnore, ContentSerializerIgnore]
        public string ValueType
        {
            get
            {
                foreach (DataProperty data in GameData.Databases[0].Properties)
                    if (_value == data.ID)
                        return data.Name;
                return "(none)";
            }
            set { _value = int.Parse(value); }
        }
        [DisplayName("Max"), CategoryAttribute("Party")]
        [Editor(typeof(PropertyTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [DoNotSerialize, XmlIgnore, ContentSerializerIgnore]
        public string MaxPropertyType
        {
            get
            {
                foreach (DataProperty data in GameData.Databases[0].Properties)
                    if (maxproperty == data.ID)
                        return data.Name;
                return "(none)";
            }
            set { maxproperty = int.Parse(value); }
        }
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Min"), CategoryAttribute("Party")]
        [Editor(typeof(PropertyTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [DoNotSerialize, XmlIgnore, ContentSerializerIgnore]
        public string MinPropertyType
        {
            get
            {
                foreach (DataProperty data in GameData.Databases[0].Properties)
                    if (min == data.ID)
                        return data.Name;
                return "(none)";
            }
            set { min = int.Parse(value); }
        }
    }
    [Serializable]
    public class DynamicBarPartyFromList : IMenuParts
    {
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;

        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }
        [DisplayName("Property Type"), CategoryAttribute("Party")]
        public PartyPropertyType PropertyType
        {
            get { return propType; }
            set { propType = value; }
        }
        PartyPropertyType propType;

        [DisplayName("Level Plus"), CategoryAttribute("Party"), Description("Get the property from the level that is the definded amount above the current level.")]
        public int LevelPlus
        {
            get { return levelPlus; }
            set { levelPlus = value; }
        }
        int levelPlus = 0;
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Max"), CategoryAttribute("Party")]
        [Browsable(false)]
        public int MaxProperty
        {
            get { return maxproperty; }
            set { maxproperty = value; }
        }
        int maxproperty;
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Min"), CategoryAttribute("Party")]
        [Browsable(false)]
        public int MinProperty
        {
            get { return min; }
            set { min = value; }
        }
        int min;
        /// <summary>
        /// Property
        /// </summary>
        [DisplayName("Value"), CategoryAttribute("Party")]
        [Browsable(false)]
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        int _value;
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    [Serializable]
    public class DynamicBarVariable : IMenuParts
    {
        // Database
        [CategoryAttribute("Variable"), DisplayName("Max")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableMaxName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableMax == -1 || !GameData.Variables.ContainsKey(variableMax))
                    return fontData;
                else
                    return GameData.Variables[variableMax];
            }

            set
            {
                variableMax = value.ID;
            }
        }
        [Browsable(false)]
        public int VariableMax
        {
            get { return variableMax; }
            set { variableMax = value; }
        }
        int variableMax = -1;
        // Variable
        [CategoryAttribute("Variable"), DisplayName("Min")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableMinName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableMin == -1 || !GameData.Variables.ContainsKey(variableMin))
                    return fontData;
                else
                    return GameData.Variables[variableMin];
            }

            set
            {
                variableMin = value.ID;
            }
        }
        [Browsable(false)]
        public int VariableMin
        {
            get { return variableMin; }
            set { variableMin = value; }
        }
        int variableMin = -1;
        // Database
        [CategoryAttribute("Variable"), DisplayName("Value")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData VariableValueName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (variableValue == -1 || !GameData.Variables.ContainsKey(variableValue))
                    return fontData;
                else
                    return GameData.Variables[variableValue];
            }

            set
            {
                variableValue = value.ID;
            }
        }
        [Browsable(false)]
        public int VariableValue
        {
            get { return variableValue; }
            set { variableValue = value; }
        }
        int variableValue = -1;

    }
    #endregion

    #region Animations
    [Serializable]
    public class AnimationPartStatic : IMenuParts
    {
        /// <summary>
        /// Animation ID
        /// </summary>
        [Browsable(false)]
        public int Animation
        {
            get { return animation; }
            set { animation = value; }
        }
        int animation = -1;
        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("Animation"), CategoryAttribute("Animation")]
        [Editor(typeof(AnimationTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public AnimationData AnimationName
        {
            get
            {
                AnimationData fontData = new AnimationData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (animation == -1 || !GameData.Animations.ContainsKey(animation))
                    return fontData;
                else
                    return GameData.Animations[animation];
            }

            set
            {
                animation = value.ID;
            }
        }
        /// <summary>
        /// Action ID
        /// </summary>
        [Browsable(false)]
        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        int action = -1;
        /// <summary>
        /// Animation ID
        /// </summary>
        [Browsable(false)]
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        int direction = 0;
        [CategoryAttribute("Animation")]
        [Editor(typeof(DirectionTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
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

        [CategoryAttribute("Animation")]
        public bool Animate
        {
            get { return animate; }
            set { animate = value; }
        }
        bool animate = false;
    }

    [Serializable]
    public class AnimationPartParty : IMenuParts
    {
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }
        /// <summary>
        /// Action Index
        /// </summary>
        [DisplayName("Action Index"), CategoryAttribute("Party")]
        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        int action = 0;
        /// <summary>
        /// Animation ID
        /// </summary>
        [Browsable(false)]
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        int direction = 0;
        [CategoryAttribute("Party")]
        [Editor(typeof(DirectionTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
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

        [CategoryAttribute("Party")]
        public bool Animate
        {
            get { return animate; }
            set { animate = value; }
        }
        bool animate = false;
    }
    [Serializable]
    public class AnimationPartPartyFromList : IMenuParts
    {
        /// <summary>
        /// Party Index
        /// </summary>
        [Browsable(false)]
        public int PartyIndex
        {
            get { return partyIndex; }
            set { partyIndex = value; }
        }
        int partyIndex = 0;
        [DisplayName("Party Index"), CategoryAttribute("Party"), Description("The variable the party index is stored in.")]
        [Editor(typeof(VariableTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public VariableData PartyIndexName
        {
            get
            {
                VariableData fontData = new VariableData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (partyIndex == -1 || !GameData.Variables.ContainsKey(partyIndex))
                    return fontData;
                else
                    return GameData.Variables[partyIndex];
            }

            set
            {
                partyIndex = value.ID;
            }
        }
        /// <summary>
        /// Action Index
        /// </summary>
        [DisplayName("Action Index"), CategoryAttribute("Party")]
        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        int action = 0;
        /// <summary>
        /// Animation ID
        /// </summary>
        [Browsable(false)]
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        int direction = 0;
        [CategoryAttribute("Party")]
        [Editor(typeof(DirectionTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
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

        [CategoryAttribute("Party")]
        public bool Animate
        {
            get { return animate; }
            set { animate = value; }
        }
        bool animate = false;
        /// <summary>
        /// List
        /// </summary>
        [Browsable(false)]
        public int List
        {
            get { return list; }
            set { list = value; }
        }
        int list = 0;
        [DisplayName("List"), CategoryAttribute("Party"), Description("The list that the party members are stored in.")]
        [Editor(typeof(ListTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public ListData ListName
        {
            get
            {
                ListData fontData = new ListData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (list == -1 || !GameData.Lists.ContainsKey(list))
                    return fontData;
                else
                    return GameData.Lists[list];
            }

            set
            {
                list = value.ID;
            }
        }
    }
    #endregion

    [Serializable]
    public class TextBoxPart : IMenuParts
    {
        [Browsable(false)]
        public int Font
        {
            get { return fontId; }
            set { fontId = value; }
        }
        int fontId = 0;

        [DisplayName("Font"), CategoryAttribute("Text")]
        [Editor(typeof(FontTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public FontData FontName
        {
            get
            {
                FontData fontData = new FontData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (fontId == -1 || !GameData.Fonts.ContainsKey(fontId))
                    return fontData;
                else
                    return GameData.Fonts[fontId];
            }

            set
            {
                fontId = value.ID;
            }
        }

        [DisplayName("Style"), CategoryAttribute("Text")]
        public int Style
        {
            get { return styleId; }
            set { styleId = value; }
        }
        int styleId = 0;

        [CategoryAttribute("Text")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color TextColor
        {
            get { return textColour; }
            set { textColour = value; }
        }
        Color textColour = Color.Black;

        [CategoryAttribute("Text"), DisplayName("Text"), Description("The String that the text should be stored in.")]
        [Editor(typeof(StringTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public StringData StringName
        {
            get
            {
                StringData fontData = new StringData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (stringId == -1 || !GameData.Strings.ContainsKey(stringId))
                    return fontData;
                else
                    return GameData.Strings[stringId];
            }

            set
            {
                stringId = value.ID;
            }
        }
        [Browsable(false)]
        public int String
        {
            get { return stringId; }
            set { stringId = value; }
        }
        int stringId = -1;

        [CategoryAttribute("Text - Behavior")]
        public bool AllowSpaces
        {
            get;
            set;
        }
        [CategoryAttribute("Text - Behavior")]
        public bool AllowSpecialChar
        {
            get;
            set;
        }
        [CategoryAttribute("Text - Behavior")]
        public bool PasswordChars
        {
            get;
            set;
        }

        [CategoryAttribute("Text - Behavior")]
        public string DoNotAllow
        {
            get;
            set;
        }
        [CategoryAttribute("Text - Behavior")]
        public int MaxNumberOfChars
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ImagePart : IMenuParts
    {
        /// <summary>
        /// Image
        /// </summary>
        [Browsable(false)]
        public int Image
        {
            get { return image; }
            set { image = value; }
        }
        int image = -1;

        [DisplayName("Image"), CategoryAttribute("Image")]
        [Editor(typeof(MaterialTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public MaterialData ImageName
        {
            get
            {
                MaterialData fontData = new MaterialData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (image == -1 || !GameData.Materials.ContainsKey(image))
                    return fontData;
                else
                    return GameData.Materials[image];
            }

            set
            {
                image = value.ID;

                Texture2D tex = EGMGame.Controls.Loader.Texture2D(MainForm.menuEditor.menuViewer1.contentManager, image);
                if (tex != null)
                    Size = new Vector2(tex.Width, tex.Height);
            }
        }
    }

    [Serializable]
    public class HighlighterStatic : IMenuParts
    {
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightBorderColor
        {
            get { return highlightBorderColor; }
            set { highlightBorderColor = value; }
        }
        Color highlightBorderColor = Color.OrangeRed;
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightStartGradient
        {
            get { return highlightStartGradient; }
            set { highlightStartGradient = value; }
        }
        Color highlightStartGradient = new Color(255, 255, 255, (byte)150);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color HighlightEndGradient
        {
            get { return highlightEndGradient; }
            set { highlightEndGradient = value; }
        }
        Color highlightEndGradient = new Color(255, 75, 0, (byte)150);
        /// <summary>
        /// Highlight Border Color
        /// </summary>
        [DisplayName("Disabled Border Color"), CategoryAttribute("Selection Higlight"), Description("Sets the border disabled highlight color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledBorderColor
        {
            get { return disabledBorderColor; }
            set { disabledBorderColor = value; }
        }
        Color disabledBorderColor = new Color(255, 75, 0, (byte)50);
        /// <summary>
        /// Start gradient
        /// </summary>
        [DisplayName("Disabled Gradient Start"), CategoryAttribute("Selection Higlight"), Description("Sets the start (top) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledStartGradient
        {
            get { return disabledStartGradient; }
            set { disabledStartGradient = value; }
        }
        Color disabledStartGradient = new Color(255, 255, 255, (byte)50);
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Disabled Gradient End"), CategoryAttribute("Selection Higlight"), Description("Sets the end (bottom) disabled highlight gradient color of the object.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color DisabledEndGradient
        {
            get { return disabledEndGradient; }
            set { disabledEndGradient = value; }
        }
        Color disabledEndGradient = new Color(255, 75, 0, (byte)50);
    }

    [Serializable]
    public class BackgroundProcessPart : IMenuParts
    {
        [CategoryAttribute("Event"), Description("Called when the object is selected but not pressed.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> BackgroundEvent
        {
            get { return backgroundEvent; }
            set { backgroundEvent = value; }
        }
        List<EventProgramData> backgroundEvent = new List<EventProgramData>();
    }

    //[XmlInclude(typeof(TextPartData))]
    //[XmlInclude(typeof(TextPartString))]
    //[XmlInclude(typeof(TextPartVariable))]
    //[XmlInclude(typeof(TextPartParty))]
    //[XmlInclude(typeof(TextPartItem))]
    //[XmlInclude(typeof(TextPartSkill))]
    //[XmlInclude(typeof(TextPartEquipment))]
    //[XmlInclude(typeof(TextPartCount))]
    //[XmlInclude(typeof(TextPartEquipped))]
    //[XmlInclude(typeof(TextPartEquipped2))]
    //[XmlInclude(typeof(TextPartEquipStat))]
    //[XmlInclude(typeof(TextPartEquippedStat))]
    //[XmlInclude(typeof(TextPartNameParty))]
    //[XmlInclude(typeof(TextPartSaveLoad))]
    //[XmlInclude(typeof(MenuButton))]
    //[XmlInclude(typeof(MenuOptions))]
    //[XmlInclude(typeof(ListStatic))]
    //[XmlInclude(typeof(ListParty))]
    //[XmlInclude(typeof(ListItem))]
    //[XmlInclude(typeof(ListItemParty))]
    //[XmlInclude(typeof(ListSkillParty))]
    //[XmlInclude(typeof(ListEquipmentParty))]
    //[XmlInclude(typeof(ListEquippedParty))]
    //[XmlInclude(typeof(ListItemShop))]
    //[XmlInclude(typeof(ListEquipmentShop))]
    //[XmlInclude(typeof(ListItemSource))]
    //[XmlInclude(typeof(ListSkillSource))]
    //[XmlInclude(typeof(ListEquipmentSource))]
    //[XmlInclude(typeof(MenuWindow))]
    //[XmlInclude(typeof(DynamicBarParty))]
    //[XmlInclude(typeof(DynamicBarVariable))]
    //[XmlInclude(typeof(TextBoxPart))]
    //[XmlInclude(typeof(AnimationPartStatic))]
    //[XmlInclude(typeof(AnimationPartParty))]
    //[XmlInclude(typeof(TextPartStatic))]
    //[XmlInclude(typeof(TextPartSource))]
    //[XmlInclude(typeof(AnimationPartStatic))]
    //[XmlInclude(typeof(ImagePart))]
    //[XmlInclude(typeof(HighlighterStatic))]
    //[XmlInclude(typeof(ListSaveLoad))]
    [Serializable]
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
        /// Contains the menu parts of the menu.
        /// </summary>
        [Browsable(false)]
        public List<IMenuParts> MenuParts
        {
            get { return menuParts; }
            set { menuParts = value; }
        }
        List<IMenuParts> menuParts = new List<IMenuParts>();
        /// <summary>
        /// Contains the menu parts of the menu.
        /// </summary>
        [Browsable(false)]
        public bool IsContainer
        {
            get { return container; }
            set { container = value; }
        }
        bool container = false;
        /// <summary>
        /// Gets or sets whether the object is enabled or not.
        /// </summary> 
        [CategoryAttribute("Behavior")]
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
        [CategoryAttribute("Behavior")]
        public bool Visible
        {
            get
            {
                return visible;
            }
            set { visible = value; }
        }
        bool visible = true;
        /// <summary>
        /// Anchor position
        /// </summary>
        [CategoryAttribute("Layout"), Description("Anchors the object to given position"), RefreshProperties(RefreshProperties.Repaint), Localizable(true), DefaultValue(5)]
        public Anchor Anchor
        {
            get { return anchor; }
            set { anchor = value; }
        }
        Anchor anchor = Anchor.Top | Anchor.Left;
        /// <summary>
        /// Gets or sets the skin id of the object.
        /// </summary>

        [DisplayName("Skin"), CategoryAttribute("Appearance"), Description("Determines the object's skin.")]
        [Editor(typeof(SkinTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public SkinData SkinName
        {
            get
            {
                SkinData fontData = new SkinData();
                fontData.ID = -1; fontData.Name = "(none)";
                if (skinId == -1 || !GameData.Skins.ContainsKey(skinId))
                    return fontData;
                else
                    return GameData.Skins[skinId];
            }

            set
            {
                skinId = value.ID;
            }
        }

        [Browsable(false)]
        public int SkinID
        {
            get { return skinId; }
            set { skinId = value; }
        }
        int skinId = -1;
        /// <summary>
        /// Parent
        /// </summary>
        [XmlIgnore, Browsable(false), ContentSerializerIgnore, DoNotSerialize]
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
        [DisplayName("Gradient Start"), CategoryAttribute("Appearance"), Description("Sets the start (top) gradient color of the object. Not displayed when skinned.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color StartGradient
        {
            get { return startGradient; }
            set { startGradient = value; }
        }
        Color startGradient = Color.White;
        /// <summary>
        /// End gradient
        /// </summary>
        [DisplayName("Gradient End"), CategoryAttribute("Appearance"), Description("Sets the end (bottom) gradient color of the object. Not displayed when skinned.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color EndGradient
        {
            get { return endGradient; }
            set { endGradient = value; }
        }
        Color endGradient = Color.LightBlue;
        /// <summary>
        /// The rectangle holding the position(x, y) and size(width, height) of the object.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        [Browsable(false)]
        public Rectangle Bounds
        {
            get { return new Rectangle((int)RealPosition.X, (int)RealPosition.Y, (int)Width, (int)Height); }
        }

        /// <summary>
        /// Position of the object.
        /// </summary>
        [CategoryAttribute("Layout"), Description("The position of the object.")]
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        Vector2 position = new Vector2(0, 0);

        /// <summary>
        /// The X position of the object.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        [Browsable(false)]
        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        /// <summary>
        /// The Y position of the object.
        /// </summary>
        [ContentSerializerIgnore, DoNotSerialize]
        [Browsable(false)]
        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        /// <summary>
        /// Gets or sets the size of the object.
        /// </summary>
        [CategoryAttribute("Layout"), Description("The size of the object.")]
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
        [ContentSerializerIgnore, DoNotSerialize]
        [Browsable(false)]
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
        [ContentSerializerIgnore, DoNotSerialize]
        [Browsable(false)]
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
        [DisplayName("Horizontal Flip"), CategoryAttribute("Image"), Description("Determines whether the object will be flipped on the horizontal axis.")]
        public bool HorizontalFlip
        {
            get { return horizontalFlip; }
            set { horizontalFlip = value; }
        }
        bool horizontalFlip;

        /// <summary>
        /// Gets or sets whether the object will be flipped on the vertical axis.
        /// </summary>
        [DisplayName("Vertical Flip"), CategoryAttribute("Image"), Description("Determines whether the object will be flipped on the vertical axis.")]
        public bool VerticalFlip
        {
            get { return verticalFlip; }
            set { verticalFlip = value; }
        }
        bool verticalFlip;

        /// <summary>
        /// Gets or sets the opacity of the animation.
        /// </summary>
        [CategoryAttribute("Image"), Description("The object's opacity.")]
        public byte Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }
        byte opacity = 255;

        /// <summary>
        /// Gets or sets the tint of the animation.
        /// </summary>
        [CategoryAttribute("Image"), Description("The object's tint.")]
        [Editor(typeof(XnaColorTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public Color Tint
        {
            get { return tint; }
            set { tint = value; }
        }
        Color tint = Color.White;
        /// <summary>
        /// Stores events on visible changed.
        /// </summary>
        [CategoryAttribute("Event"), Description("Called when the object's visiblity changes.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnVisibleChanged
        {
            get { return onVisibleChanged; }
            set { onVisibleChanged = value; }
        }
        List<EventProgramData> onVisibleChanged = new List<EventProgramData>();
        /// <summary>
        /// Srotres events on enabled changed.
        /// </summary>
        [CategoryAttribute("Event"), Description("Called when the object is enabled or disabled.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnEnableChanged
        {
            get { return onEnableChanged; }
            set { onEnableChanged = value; }
        }
        List<EventProgramData> onEnableChanged = new List<EventProgramData>();
        /// <summary>
        /// On Confirm
        /// </summary>
        [CategoryAttribute("Event"), Description("Called when the action/confirm key is pressed.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnConfirm
        {
            get { return onConfirm; }
            set { onConfirm = value; }
        }
        List<EventProgramData> onConfirm = new List<EventProgramData>();
        /// <summary>
        /// On Cancel
        /// </summary>
        [CategoryAttribute("Event"), Description("Called when the cancel key is pressed.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnCancel
        {
            get { return onCancel; }
            set { onCancel = value; }
        }
        List<EventProgramData> onCancel = new List<EventProgramData>();
        /// <summary>
        /// On Cancel
        /// </summary>
        [CategoryAttribute("Event"), Description("Called when a new key is pressed.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnKeyPress
        {
            get { return onKeyPress; }
            set { onKeyPress = value; }
        }
        List<EventProgramData> onKeyPress = new List<EventProgramData>();

        [CategoryAttribute("Event"), Description("Called when a key is released.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnKeyRelease
        {
            get { return onKeyRelease; }
            set { onKeyRelease = value; }
        }
        List<EventProgramData> onKeyRelease = new List<EventProgramData>();

        [CategoryAttribute("Event"), Description("Called when a key is pressed down.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnKeyDown
        {
            get { return onKeyDown; }
            set { onKeyDown = value; }
        }
        List<EventProgramData> onKeyDown = new List<EventProgramData>();

        [CategoryAttribute("Event"), Description("Called when mouse button is down on the object.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnMouseDown
        {
            get { return onMouseDown; }
            set { onMouseDown = value; }
        }
        List<EventProgramData> onMouseDown = new List<EventProgramData>();

        [CategoryAttribute("Event"), Description("Called when mouse button is up on the object.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnMouseUp
        {
            get { return onMouseUp; }
            set { onMouseUp = value; }
        }
        List<EventProgramData> onMouseUp = new List<EventProgramData>();

        [CategoryAttribute("Event"), Description("Called when mouse button is moving on the object.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnMouseMove
        {
            get { return onMouseMove; }
            set { onMouseMove = value; }
        }
        List<EventProgramData> onMouseMove = new List<EventProgramData>();

        [CategoryAttribute("Event"), Description("Called when mouse enters to the object's area.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnMouseEnter
        {
            get { return onMouseEnter; }
            set { onMouseEnter = value; }
        }
        List<EventProgramData> onMouseEnter = new List<EventProgramData>();

        [CategoryAttribute("Event"), Description("Called when mouse leaves the object's area.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnMouseLeave
        {
            get { return onMouseLeave; }
            set { onMouseLeave = value; }
        }
        List<EventProgramData> onMouseLeave = new List<EventProgramData>();

        [CategoryAttribute("Event"), Description("Called when mouse hovers on the object.")]
        [Editor(typeof(EventTypeConvert),
             typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnMouseHover
        {
            get { return onMouseHover; }
            set { onMouseEnter = value; }
        }
        List<EventProgramData> onMouseHover = new List<EventProgramData>();
    }

    [Serializable]
    [Flags, Editor("System.Windows.Forms.Design.AnchorEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
    public enum Anchor
    {
        None = 0,
        Top = 1,
        Bottom = 2,
        Left = 4,
        Right = 8
    }

    [Serializable]
    public enum PartyPropertyType
    {
        Modified,
        Unmodified,
        Difference
    }

    [Serializable]
    public enum ShowItemType
    {
        Name,
        Cost,
        Value,
        Description,
        Icon
    }

    [Serializable]
    public enum ShowCountType
    {
        Item,
        Equipment
    }
    [Serializable]
    public enum BorderType
    {
        None,
        Single
    }

    [Serializable]
    public enum ListSelectionType
    {
        None,
        Rectangle,
        Cursor
    }

    [Serializable]
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

    [Serializable]
    public enum DescType
    {
        Items,
        Skills,
        Equipment
    }

    [Serializable]
    public enum FileDisplayType
    {
        Name,
        Date,
        Time
    }
}
