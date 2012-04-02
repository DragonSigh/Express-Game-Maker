using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Processors;
using EGMGame.Components;
using EGMGame.Interfaces;
using EGMGame.Library;
using System.Xml.Serialization;
using EGMGame;
using Microsoft.Xna.Framework;

namespace EGMGame.Framework
{
    /// <summary>
    /// This is an example class with comments to guide you to do a similar class.
    /// Use Global.AddMenu to add your menu to the current scene or as a new scene.
    /// </summary>
    public class MenuFramework : IMenu
    {
        #region Fields
        /// <summary>
        /// Declare your menu items as fields for easy access.
        /// </summary>
        #endregion

        #region Constructor
        /// <summary>
        /// Constrcutor
        /// </summary>
        public MenuFramework() {}
        #endregion

        #region Show
        public override void Show()
        {
            // ToDo: Create and setup menu items here.
            // You can use MenuItem.Create... to create your menu items.
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            // ToDo: Update your menu items here and add general keyboard logic as well as other logic.
        }
        #endregion

        #region Draw
        public override void Draw(GameTime gameTime)
        {
            // ToDo: Draw your menu items here.
        }
        #endregion
    }
}
