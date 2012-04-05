/* -----------------------------
 * MenuListItemCollection
 * -----------------------------
 * Purpose:             This the class that holds the Menu Items.
 * Most Used By:        MenuList.cs
 * Associated Files:    MenuList.cs, MenuListItem.cs
 * Modify:              When you want to modify the ways are displayed.
 */
//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Collections;

namespace EGMGame.Docking.Homepage
{
    [ListBindable(false)]
    //[Editor("ExpressGameMaker.Docking.Homepage.MenuListItemCollectionEditor", typeof(UITypeEditor))]
    public class MenuListItemCollection : IList<MenuListItem>
    {
        List<MenuListItem> list = new List<MenuListItem>();
        #region IList<MenuListItem> Members
        MenuList owner;

        public MenuListItemCollection(MenuList o)
        {
            owner = o;
        }

        public int IndexOf(MenuListItem item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, MenuListItem item)
        {
            list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
            owner.Invalidate();
        }

        public MenuListItem this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        #endregion

        #region ICollection<MenuListItem> Members

        public void Add(MenuListItem item)
        {
            list.Add(item);
            owner.Invalidate();
        }

        public void Clear()
        {
            list.Clear();
            owner.Invalidate();
        }

        public bool Contains(MenuListItem item)
        {
            return list.Contains(item);
        }

        public void CopyTo(MenuListItem[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(MenuListItem item)
        {
            owner.Invalidate();
            return list.Remove(item);
        }

        #endregion

        #region IEnumerable<MenuListItem> Members

        public IEnumerator<MenuListItem> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion
    }
}
