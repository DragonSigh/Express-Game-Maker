/* -----------------------------
 * MenuList
 * -----------------------------
 * Purpose:             This the class that holds the Menu text.
 * Most Used By:        MenuListCollection.cs
 * Associated Files:    MenuList.cs, MenuListItemCollection.cs
 * Modify:              When you want to modify the ways are displayed.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace EGMGame.Docking.Homepage
{
    public partial class MenuListItem : MarshalByRefObject, ICloneable, ISerializable
    {

        public delegate void ClickeEvent(object sender);
        public event ClickeEvent Clicked;

        public MenuListItem()
        {
            text = "menuListItem";
            isCategory = false;
        }
        public MenuListItem(string t)
        {
            text = t;
            isCategory = false;
        }

        public Image Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        Image icon;

        public string Name
        {
            get { return name; }
            set { name = value;}
        }
        string name;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        string path;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string text;

        public string SubText
        {
            get { return subText; }
            set { subText = value; }
        }
        string subText;

        public bool IsCategory
        {
            get { return isCategory; }
            set { isCategory = value; }
        }
        bool isCategory;

        public bool IsDetailed
        {
            get { return isDetailed; }
            set { isDetailed = value; }
        }
        bool isDetailed;

        Rectangle rectangle;
        [Browsable(false)]
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        [Browsable(false)]
        public bool isHighlighted;

        public override string ToString()
        {
            string type;
            if (isCategory)
                type = "Category";
            else
                type = "Button";
            return type + ": " + text;
        }

        public void Click()
        {
            if (Clicked != null)
                Clicked(this);
        }

        #region ICloneable Members

        public object Clone()
        {
            MenuListItem n = new MenuListItem();
            n.Icon = this.Icon;
            n.IsCategory = this.IsCategory;
            n.IsDetailed = this.IsDetailed;
            n.Rectangle = this.Rectangle;
            n.SubText = this.SubText;
            n.Text = this.Text;
            return n;
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this.Serialize(info, context);
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.SerializationFormatter), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        protected virtual void Serialize(SerializationInfo si, StreamingContext context)
        {
            si.AddValue("Icon", this.Icon);
            si.AddValue("Text", this.Text);
            si.AddValue("SubText", this.subText);
            si.AddValue("IsCategory", this.IsCategory);
            si.AddValue("IsDetailed", this.IsDetailed);
            si.AddValue("Rectangle", this.Rectangle);
        }

        #endregion

        internal void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
