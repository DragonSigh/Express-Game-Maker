// Author: Vlad Untu/Asterix Software
// For updates: http://www.asterixsoft.ro/dyn/open/treeview_filter/

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;

using System.CodeDom;

namespace EGMGame.Controls
{
	public class TreeNodeCollectionEx : IEnumerable, ICollection, IList {
	    internal ArrayList items;
        public TreeNodeEx owner;

        internal TreeNodeCollectionEx(TreeNodeEx owner) {
            items = new ArrayList();

            this.owner = owner;
        }

		public int Add(TreeNodeEx node) {
            if (node == this.owner)
                throw new Exception("Cannot add node to itself.");

            if (items.Contains(node))
                throw new Exception("Cannot add the same node twice to Collection");

            if (node.NodeType == NodeType.Filter) 
                throw new Exception("Filter nodes cannot be added to Collection");

            node.SetParent(this.owner);

            if (this.owner.TreeView != null) {
                this.owner.TreeView.InvalidateNode(this.owner, true);
                this.owner.TreeView.ForceReLayout();
            }

            if (items == null)
                items = new ArrayList();

            return items.Add(node);
		}

        public void AddRange(TreeNodeEx[] nodes) {
            if (owner.TreeView != null)
                owner.TreeView.BeginUpdate();

            foreach (TreeNodeEx node in nodes) {
                this.Add(node);
            }

            if (owner.TreeView != null) {
                owner.TreeView.EndUpdate();
            }
        }

		public int Length {
			get { return items.Count; }
		}

        public TreeNodeEx FilterNode {
            get {
                if (this.Count > 0 && this[0].NodeType == NodeType.Filter)
                    return this[0];
                else
                    return null;
            }
            set {
                if (value == null) return;

                if (items.Count > 0)
                    throw new Exception("Cannot set FilterNode on non-empty Collection.");

                if (value.NodeType == NodeType.Normal)
                    throw new Exception("Cannot set Normal node as Filter node.");

                value.SetParent(this.owner);

                items.Clear();
                items.Add(value);
            }
        }

		public TreeNodeEx this[int index] {
			get { return (TreeNodeEx) items[index]; }
			set { items[index] = value;	}
		}

        public TreeNodeEx[] ToArray() {
            return (TreeNodeEx[])items.ToArray(typeof(TreeNodeEx));
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator() {
            return new TreeNodeEnumerator(this);
        }

        #endregion

		#region ICollection Members
		public bool IsSynchronized {
			get {
				return false;
			}
		}

		public int Count {
			get {
				return items.Count;
			}
		}

        public void CopyTo(Array array) {
            this.CopyTo(array, 0);
        }

		public void CopyTo(Array array, int index) {
            items.CopyTo(array, index);
		}

		public object SyncRoot {
			get { return null; }
		}
		#endregion

        #region IList Members

        public int Add(object item) {
            if (item is TreeNodeEx)
                return this.Add((TreeNodeEx)item);
            else
                throw new Exception("Only TreeNodeEx items can be added to collection");
        }

        public int Add(string text)
        {
            return this.Add(new TreeNodeEx(text));
        }

        public void Clear() {
            if (items.Count > 0) {
                if (this[0].NodeType == NodeType.Filter) {
                    if (Count == 1) return;

                    items.RemoveRange(1, this.Count - 1);
                }
                else
                    this.items.Clear();

                if (this.owner.TreeView != null)
                    this.owner.TreeView.InvalidateNode(this.owner, true);
            }
        }

        public bool Contains(object value) {
            return items.Contains(value);
        }

        public int IndexOf(object value) {
            return items.IndexOf(value);
        }

        public void Insert(int index, object value) {
            throw new Exception("The Insert method or operation is not implemented.");
        }

        public bool IsFixedSize {
            get { return false; }
        }

        public bool IsReadOnly {
            get { return false; }
        }

        public void Remove(object value) {
            items.Remove(value);
        }

        public void RemoveAt(int index) {
            items.RemoveAt(index);
        }

        object IList.this[int index] {
            get {
                return items[index];
            }
            set {
                items[index] = value;
            }
        }

        #endregion

        #region TreeNodeEnumerator Implementation
        public class TreeNodeEnumerator : IEnumerator {
            int crt_index = -1;

            TreeNodeCollectionEx crt_collection;
            TreeNodeCollectionEx root_collection;

            Stack tree = new Stack();

            public TreeNodeEnumerator(TreeNodeCollectionEx root_collection) {
                this.root_collection = root_collection;

                Reset();
            }

            #region IEnumerator Members

            public void Reset() {
                crt_index = -1;
                crt_collection = this.root_collection;

                tree = new Stack();
            }

            public object Current {
                get {
                    return crt_collection[crt_index];
                }
            }

            public bool MoveNext() {
                if (crt_index >= 0 && crt_collection[crt_index].IsExpanded) {
                    tree.Push(new DictionaryEntry(crt_index, crt_collection));
                    crt_collection = crt_collection[crt_index].Nodes;
                    crt_index = -1;
                    return MoveNext();
                }

                crt_index++;

                if (crt_index < crt_collection.Length)
                    return true;
                else {
                    while (tree.Count != 0) {
                        DictionaryEntry item = (DictionaryEntry)tree.Pop();
                        crt_index = (int)item.Key;
                        crt_collection = (TreeNodeCollectionEx)item.Value;
                        crt_index++;

                        if (crt_index < crt_collection.Length)
                            return true;
                        else
                            continue;
                    }

                    return false;
                }
            }

            #endregion
        }
        #endregion
    }

    public enum EnumeratorMode { Strict, AllVisible, All }
}
