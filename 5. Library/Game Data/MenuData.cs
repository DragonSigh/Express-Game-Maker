//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EGMGame.Library
{
    /// <summary>
    /// Stores the menu data.
    /// </summary>
    [Serializable]
    public class MenuData : IGameData
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
        /// Contains the menu parts of the menu.
        /// </summary>
        [Browsable(false)]
        public List<IMenuParts> MenuParts
        {
            get { return menuParts; }
            set { menuParts = value; }
        }
        List<IMenuParts> menuParts = new List<IMenuParts>();


        [DisplayName("Skin"), CategoryAttribute("Appearance"), Description("Determines the menu's default skin.")]
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
        /// <summary>
        /// Gets or sets the skin id of the object.
        /// </summary>
        [Browsable(false)]
        public int SkinID
        {
            get { return skinId; }
            set { skinId = value; }
        }
        int skinId = -1;
        /// <summary>
        /// Gets or sets the size of the canvas.
        /// </summary>
        [DisplayName("Canvas Size"), Category("Properties"), Description("The size of the canvas.")]
        public Vector2 CanvasSize
        {
            get { return canvasSize; }
            set { canvasSize = value; }
        }
        Vector2 canvasSize = new Vector2();
        /// <summary>
        /// Background
        /// </summary>
        [Browsable(false)]
        public int Background
        {
            get { return background; }
            set { background = value; }
        }
        int background = -1;
        [DisplayName("Background Image"), Category("Properties"), Description("The background image of the menu.")]
        [Editor(typeof(ImageTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        [ContentSerializerIgnore, DoNotSerialize]
        public string BackgroundImage
        {
            get
            {
                MaterialData image = Global.GetData<MaterialData>(background, GameData.Materials);
                if (image != null && image.DataType == MaterialDataType.Image)
                {
                    return image.Name;
                }
                return "No Image";
            }

            set
            {
                background = Convert.ToInt32(value);
            }
        }
        /// <summary>
        /// Background Color
        /// </summary>
        [DisplayName("Background Color"), Category("Properties"), Description("The background color of the menu.")]
        public Color BackgroundColor
        {
            get { return bgColour; }
            set { bgColour = value; }
        }
        Color bgColour = new Color(0, 0, 0, 0);
        [CategoryAttribute("Event"), Description("Called when the menu is first shown.")]
        [Editor(typeof(EventTypeConvert), typeof(System.Drawing.Design.UITypeEditor))]
        public List<EventProgramData> OnShown
        {
            get { return onShown; }
            set { onShown = value; }
        }
        List<EventProgramData> onShown = new List<EventProgramData>();
        /// <summary>
        /// Is Message
        /// </summary>
        [CategoryAttribute("Behavior")]
        public bool IsMessage
        {
            get { return isMessage; }
            set { isMessage = value; }
        }
        bool isMessage;
    }
}
