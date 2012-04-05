/* -----------------------------
 * NewsMenuListItemCollection - Needs Work
 * -----------------------------
 * Purpose:             This the class that holds the News Item.
 * Most Used By:        NewsMenuList.cs
 * Associated Files:    NewsMenuList.cs, NewsMenuListItem.cs
 * Modify:              When you want to modify the ways News are displayed.
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
    public class NewsMenuListItemCollection : IList<NewsMenuListItem>
    {
        List<NewsMenuListItem> list = new List<NewsMenuListItem>();
        #region IList<NewsMenuListItem> Members
        NewsMenuList owner;

        public NewsMenuListItemCollection(NewsMenuList o)
        {
            owner = o;
        }

        public int IndexOf(NewsMenuListItem item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, NewsMenuListItem item)
        {
            list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
            owner.Invalidate();
        }

        public NewsMenuListItem this[int index]
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

        #region ICollection<NewsMenuListItem> Members

        public void Add(NewsMenuListItem item)
        {
            list.Add(item);
            owner.Invalidate();
        }

        public void Clear()
        {
            list.Clear();
            owner.Invalidate();
        }

        public bool Contains(NewsMenuListItem item)
        {
            return list.Contains(item);
        }

        public void CopyTo(NewsMenuListItem[] array, int arrayIndex)
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

        public bool Remove(NewsMenuListItem item)
        {
            owner.Invalidate();
            return list.Remove(item);
        }

        #endregion

        #region IEnumerable<MenuListItem> Members

        public IEnumerator<NewsMenuListItem> GetEnumerator()
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
