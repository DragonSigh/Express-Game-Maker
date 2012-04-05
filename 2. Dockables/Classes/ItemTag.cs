/* -----------------------------
 * ItemTag
 * -----------------------------
 * Purpose:             Used to store more information in a List Item Collection Ex: ((ItemTag)list.Items[0]).ID.
 * Most Used By:        Lists and Checklists in Dialogs, Editors and Components
 * Associated Files:    None
 * Modify:              If you want to add more properties to List Item tags.
 */
//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EGMGame.Library
{
    internal class ItemTag
    {
        internal int ID;
        internal string Name;

        internal ItemTag(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
