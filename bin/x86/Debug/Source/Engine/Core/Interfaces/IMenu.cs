using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Components;
using EGMGame.Library;
using EGMGame.Processors;
using System.Xml.Serialization;

namespace EGMGame.Interfaces
{
    public class IMenu : Interpreter
    {
        #region Field:Settings
        // EventProcessor
        [XmlIgnore, DoNotSerialize]
        public Drawable Owner
        {
            get
            {
                if (owner == null)
                {
                    if (OwnerIsEvent)
                        owner = Global.Instance.CurrentMap.GetEventFromUniqueID(OwnerID);
                    else
                        owner = Global.GetMenuFromUniqueID(OwnerID);
                }
                return owner;
            }
            set
            {
                owner = value;
                OwnerID = owner.UniqueID;
                OwnerIsEvent = (owner is EventProcessor);
            }
        }
        Drawable owner;
        public int OwnerID;
        public bool OwnerIsEvent;
        // Settings
        public bool WaitOnClose;
        public bool ShowOnScene;
        public bool DeactivateScene;
        public bool NeedShow = true;
        // Close
        public virtual void Close()
        {

        }
        public virtual void Show()
        {

        }
        public virtual void SetupText(string text, int p, Microsoft.Xna.Framework.Vector2 vector2, int p_4, int p_5, Microsoft.Xna.Framework.Vector2 vector2_6, Drawable ev)
        {
        }
        public virtual void SetupText(string text, int p, Microsoft.Xna.Framework.Vector2 vector2, int p_4, int p_5, Microsoft.Xna.Framework.Vector2 vector2_6)
        {
        }
        #endregion
    }
}