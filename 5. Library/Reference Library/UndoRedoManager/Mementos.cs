using System;
using System.Collections.Generic;
using System.Text;
using GenericUndoRedo;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using EGMGame.Library;
using EGMGame.Controls;
using EGMGame.Controls.EventControls;
using Microsoft.Xna.Framework;
using FarseerPhysics.Collisions;
using FarseerPhysics.Common;
using EGMGame.GameLibrary;

namespace EGMGame
{
    #region IGameData
    /// Delegates
    public delegate void DataAddDelegate(IGameDataAddedHist hist, IGameData data);
    public delegate void DataRemoveDelegate(IGameDataRemovedHist hist, IGameData data);
    public delegate void DataPropertyDelegate(IGameDataChangePropertyHist hist, IGameData data);
    public delegate void DataEAddDelegate(EventAddedHist hist, IGameData data);
    public delegate void DataERemoveDelegate(EventRemovedHist hist, IGameData data);
    public delegate void DataColAddDelegate(ColAddedHist hist, CollisionData data);
    public delegate void DataColRemoveDelegate(ColRemovedHist hist, CollisionData data);
    public delegate void DataTRemoveDelegate(TileData data);
    public delegate void DataIndexDelegate(IGameDataIndexHist hist, IGameData data);
    public delegate void DataTilePropertyDelegate(TileDataChangePropertyHist hist, TileData data);
    public delegate void DataTilesPropertyDelegate(TilesDataChangePropertyHist hist, object[] datas);
    public delegate void DataMenuPartAddDelegate(MenuPartAddedHist hist, IGameData data, MenuData menu);
    public delegate void DataMenuPartRemoveDelegate(MenuPartRemovedHist hist, IGameData data, MenuData menu);
    public delegate void DataMenuPartsAddDelegate(MenuPartsAddedHist hist, List<IMenuParts> data, MenuData menu);
    public delegate void DataMenuPartsRemoveDelegate(MenuPartsRemovedHist hist, List<IMenuParts> data, MenuData menu);
    public delegate void DataMenuPartPropertyDelegate(MenuPartChangePropertyHist hist, IMenuParts data, MenuData menu);
    public delegate void DataMenuPartsPropertyDelegate(MenuPartsChangePropertyHist hist, List<IMenuParts> datas, MenuData menu);
    public delegate void MenuPartsPositionDelegate(MenuPartsPositionChangeHist hist, List<IMenuParts> datas, List<Vector2> positions, Vector2 parentPos, MenuData menu);
    // IGameData Added
    public class IGameDataAddedHist : IMemento<IHistory>, IHistory
    {
        public DataAddDelegate OnDataAdd;
        public DataRemoveDelegate OnDataRemove;
        public IGameData Parent = null;
        public ICollection Collection = null;
        public int Index = 0;
        // Data
        IGameData data;

        public IGameDataAddedHist(IGameData d, DataAddDelegate addDelegate, DataRemoveDelegate remDelegate)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
        }
        public IGameDataAddedHist(IGameData d, DataAddDelegate addDelegate, DataRemoveDelegate remDelegate, IGameData parent)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
        }
        public IGameDataAddedHist(IGameData d, DataAddDelegate addDelegate, DataRemoveDelegate remDelegate, ICollection collection, int index)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IGameDataRemovedHist inverse;
            if (Parent != null)
                inverse = new IGameDataRemovedHist(data, OnDataAdd, OnDataRemove, Parent);
            else if (Collection != null)
                inverse = new IGameDataRemovedHist(data, OnDataAdd, OnDataRemove, Collection, Index);
            else
                inverse = new IGameDataRemovedHist(data, OnDataAdd, OnDataRemove);
            // Remove Data
            OnDataRemove(inverse, data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return data.Name + " Added.";
        }

        #endregion
    }

    // IGameData Removed
    public class IGameDataRemovedHist : IMemento<IHistory>, IHistory
    {
        public DataAddDelegate OnDataAdd;
        public DataRemoveDelegate OnDataRemove;
        public IGameData Parent;
        public ICollection Collection;
        public int Index = 0;
        // Data
        IGameData data;

        public IGameDataRemovedHist(IGameData d, DataAddDelegate addDelegate, DataRemoveDelegate remDelegate)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
        }
        public IGameDataRemovedHist(IGameData d, DataAddDelegate addDelegate, DataRemoveDelegate remDelegate, IGameData parent)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
        }
        public IGameDataRemovedHist(IGameData d, DataAddDelegate addDelegate, DataRemoveDelegate remDelegate, ICollection collection, int index)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IGameDataAddedHist inverse;
            if (Parent != null)
                inverse = new IGameDataAddedHist(data, OnDataAdd, OnDataRemove, Parent);
            else if (Collection != null)
                inverse = new IGameDataAddedHist(data, OnDataAdd, OnDataRemove, Collection, Index);
            else
                inverse = new IGameDataAddedHist(data, OnDataAdd, OnDataRemove);
            // Re Add Data
            OnDataAdd(inverse, data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return data.Name + " Removed.";
        }

        #endregion
    }

    // IGameData Change Properties
    public class IGameDataChangePropertyHist : IMemento<IHistory>, IHistory
    {
        public DataPropertyDelegate OnDataProperty;
        // Data
        IGameData data;
        SkinData cloneSkin;
        Dictionary<PropertyDescriptor, object> Properties;

        public IGameDataChangePropertyHist(IGameData d, DataPropertyDelegate del)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataProperty = del;

            // Properties
            if (d is SkinData)
            {
                cloneSkin = Global.Duplicate<SkinData>(d);
            }
            else
            {
                Properties = new Dictionary<PropertyDescriptor, object>();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data);
                object obj;
                foreach (PropertyDescriptor myProperty in properties)
                {
                    try
                    {
                        if (myProperty.PropertyType.IsSerializable)
                        {
                            obj = myProperty.GetValue(data);
                            if (obj is ICollection || obj is object[])
                            {
                                obj = Global.Duplicate<object>(obj);
                            }
                            Properties.Add(myProperty, obj);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.ShowLogError(ex, "32x001");
                    }
                }
            }
        }

        public IGameDataChangePropertyHist(IGameData d)
        {
            MainForm.NeedSave = true;
            data = d;
            // Properties
            if (d is SkinData)
            {
                cloneSkin = Global.Duplicate<SkinData>(d);
            }
            else
            {
                Properties = new Dictionary<PropertyDescriptor, object>();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data);
                object obj;
                foreach (PropertyDescriptor myProperty in properties)
                {
                    try
                    {
                        if (myProperty.PropertyType.IsSerializable)
                        {
                            obj = myProperty.GetValue(data);
                            if (obj is ICollection || obj is object[])
                            {
                                obj = Global.Duplicate<object>(obj);
                            }
                            Properties.Add(myProperty, obj);
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.ShowLogError(ex, "32x002");
                    }
                }
            }
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            IMemento<IHistory> inverse;

            if (OnDataProperty != null)
                inverse = new IGameDataChangePropertyHist(data, OnDataProperty);
            else
                inverse = new IGameDataChangePropertyHist(data);

            if (data is SkinData)
            {
                SkinData skin = (SkinData)data;
                skin.Button = cloneSkin.Button;
                skin.Category = cloneSkin.Category;
                skin.Cursor = cloneSkin.Cursor;
                skin.DynamicBar = cloneSkin.DynamicBar;
                skin.List = cloneSkin.List;
                skin.Name = cloneSkin.Name;
                skin.Text = cloneSkin.Text;
                skin.Window = cloneSkin.Window;
            }
            else
            {
                foreach (KeyValuePair<PropertyDescriptor, object> myProperty in Properties)
                {
                    try
                    {
                        myProperty.Key.SetValue(data, myProperty.Value);
                    }
                    catch (Exception ex)
                    {
                        Error.ShowLogError(ex, "32x003");
                    }
                }
            }
            if (OnDataProperty != null)
                OnDataProperty(this, data);

            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return data.Name + " Value Changed.";
        }

        #endregion
    }

    // TileData Change Properties
    public class TileDataChangePropertyHist : IMemento<IHistory>, IHistory
    {
        public DataTilePropertyDelegate OnDataProperty;
        // Data
        TileData data;
        Dictionary<PropertyDescriptor, object> Properties;

        public TileDataChangePropertyHist(TileData d, DataTilePropertyDelegate del)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataProperty = del;

            // Properties
            Properties = new Dictionary<PropertyDescriptor, object>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data);
            foreach (PropertyDescriptor myProperty in properties)
            {
                try
                {
                    if (myProperty.PropertyType.IsSerializable)
                    {
                        Properties.Add(myProperty, myProperty.GetValue(data));
                    }
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "32x006");
                }
            }
        }

        public TileDataChangePropertyHist(TileData d)
        {
            MainForm.NeedSave = true;
            data = d;
            // Properties
            Properties = new Dictionary<PropertyDescriptor, object>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data);
            foreach (PropertyDescriptor myProperty in properties)
            {
                try
                {
                    if (myProperty.PropertyType.IsSerializable)
                    {
                        Properties.Add(myProperty, myProperty.GetValue(data));
                    }
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "32x004");
                }
            }
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            IMemento<IHistory> inverse;

            if (OnDataProperty != null)
                inverse = new TileDataChangePropertyHist(data, OnDataProperty);
            else
                inverse = new TileDataChangePropertyHist(data);

            foreach (KeyValuePair<PropertyDescriptor, object> myProperty in Properties)
            {
                try
                {
                    myProperty.Key.SetValue(data, myProperty.Value);
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "32x010");
                }
            }

            if (OnDataProperty != null)
                OnDataProperty(this, data);

            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Tile Value Changed.";
        }

        #endregion
    }
    // TileData Change Properties
    public class TilesDataChangePropertyHist : IMemento<IHistory>, IHistory
    {
        public DataTilesPropertyDelegate OnDataProperty;
        // Data
        object[] data;
        object OldValue;
        object NewValue;
        PropertyDescriptor Property;

        public TilesDataChangePropertyHist(object[] d, PropertyDescriptor desc, object oldValue, object newValue, DataTilesPropertyDelegate del)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataProperty = del;

            OldValue = oldValue;
            NewValue = newValue;
            // Properties
            Property = desc;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            IMemento<IHistory> inverse = new TilesDataChangePropertyHist(data, Property, NewValue, OldValue, OnDataProperty);

            Property.SetValue(data, OldValue);

            if (OnDataProperty != null)
                OnDataProperty(this, data);

            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Tile Value Changed.";
        }

        #endregion
    }
    // IGameData Added
    public class IGameDataIndexHist : IMemento<IHistory>, IHistory
    {
        public DataIndexDelegate OnDataIndex;
        public IGameData Parent = null;
        public ICollection Collection = null;
        public int NewIndex = 0;
        public int OldIndex = 0;
        // Data
        IGameData data;

        public IGameDataIndexHist(IGameData d, DataIndexDelegate idelegate, ICollection collection, int nindex, int oindex)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataIndex = idelegate;
            Collection = collection;
            NewIndex = nindex;
            OldIndex = oindex;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IGameDataIndexHist inverse = new IGameDataIndexHist(data, OnDataIndex, Collection, OldIndex, NewIndex);
            // Call Event
            OnDataIndex(inverse, data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return data.Name + " Moved.";
        }

        #endregion
    }
    #endregion

    #region Collision Map
    // Added
    public class CollisionAddedHist : IMemento<IHistory>, IHistory
    {
        public Vertices Collection = null;
        public int Index = 0;
        // Data
        Vector2 data;

        public CollisionAddedHist(Vector2 d, Vertices collection, int index)
        {
            MainForm.NeedSave = true;
            data = d;
            Collection = collection;
            Index = index;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new CollisionRemovedHist(data, Collection, Index);
            // Remove Data
            Collection.RemoveAt(Index);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node Added.";
        }

        #endregion
    }
    // Removed
    public class CollisionRemovedHist : IMemento<IHistory>, IHistory
    {
        public Vertices Collection = null;
        public int Index = 0;
        // Data
        Vector2 data;

        public CollisionRemovedHist(Vector2 d, Vertices collection, int index)
        {
            MainForm.NeedSave = true;
            data = d;
            Collection = collection;
            Index = index;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new CollisionAddedHist(data, Collection, Index);
            // Remove Data
            Collection.Insert(Index, data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node Removed.";
        }

        #endregion
    }
    // Added
    public class CollisionsAddedHist : IMemento<IHistory>, IHistory
    {
        public Vertices Collection = null;
        // Data
        Vertices data;

        public CollisionsAddedHist(Vertices d, Vertices collection)
        {
            MainForm.NeedSave = true;
            data = new Vertices(d);
            Collection = collection;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new CollisionsRemovedHist(data, Collection);
            // Remove Data
            Collection.Clear();
            Collection.AddRange(data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node Added.";
        }

        #endregion
    }
    // Removed
    public class CollisionsRemovedHist : IMemento<IHistory>, IHistory
    {
        public Vertices Collection = null;
        public int Index = 0;
        // Data
        Vertices data;

        public CollisionsRemovedHist(Vertices d, Vertices collection)
        {
            MainForm.NeedSave = true;
            data = new Vertices(d);
            Collection = collection;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new CollisionsAddedHist(data, Collection);
            // Add Data
            Collection.Clear();
            foreach (Vector2 v in data)
            {
                Collection.Add(v);
            }
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node Removed.";
        }

        #endregion
    }
    // Added
    public class CollisionsEditedHist : IMemento<IHistory>, IHistory
    {
        public Vertices Collection = null;
        // Data
        Vertices OldVertices;
        Vertices NewVertices;

        public CollisionsEditedHist(Vertices oldVertices, Vertices newVertices, Vertices collection)
        {
            MainForm.NeedSave = true;
            OldVertices = new Vertices(oldVertices);
            NewVertices = new Vertices(newVertices);
            Collection = collection;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new CollisionsEditedHist(NewVertices, OldVertices, Collection);
            // Remove Data
            foreach (Vector2 v in NewVertices)
            {
                Collection.Remove(v);
            }
            // Add Data
            foreach (Vector2 v in OldVertices)
            {
                Collection.Add(v);
            }
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node(s) Edited.";
        }

        #endregion
    }
    // Moved
    public class CollisionsMovedHist : IMemento<IHistory>, IHistory
    {
        public Vertices Collection = null;
        // Data
        Vector2 OldPos;
        Vector2 NewPos;
        int Index;

        public CollisionsMovedHist(Vector2 oldPos, Vector2 newPos, Vertices collection, int index)
        {
            MainForm.NeedSave = true;
            Index = index;
            OldPos = oldPos;
            NewPos = newPos;
            Collection = collection;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new CollisionsMovedHist(NewPos, OldPos, Collection, Index);
            // Remove Data
            Collection[Index] = OldPos;
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node(s) Moved.";
        }

        #endregion
    }
    #region Tileset
    // Added
    public class TilesetCollisionAddedHist : IMemento<IHistory>, IHistory
    {
        public List<Vertices> Collection = null;
        public List<int> Index = new List<int>();
        // Data
        List<List<Vector2>> data;

        public TilesetCollisionAddedHist(List<List<Vector2>> d, List<Vertices> collection, List<int> index)
        {
            MainForm.NeedSave = true;
            data = d;
            Collection = collection;
            Index = new List<int>(index);
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new TilesetCollisionRemovedHist(data, Collection, Index);
            // Remove Data
            for (int i = 0; i < Collection.Count; i++)
            {
                for (int nodeIndex = 0; nodeIndex < Index.Count; nodeIndex++)
                {
                    if (Index[nodeIndex] < Collection[i].Count)
                    {
                        Collection[i].RemoveAt(Index[nodeIndex]);
                    }
                }
            }
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node Added.";
        }

        #endregion
    }
    // Removed
    public class TilesetCollisionRemovedHist : IMemento<IHistory>, IHistory
    {
        public List<Vertices> Collection = null;
        public List<int> Index = new List<int>();
        // Data
        List<List<Vector2>> data;

        public TilesetCollisionRemovedHist(List<List<Vector2>> d, List<Vertices> collection, List<int> index)
        {
            MainForm.NeedSave = true;
            data = d;
            Collection = collection;
            Index = new List<int>(index);
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new TilesetCollisionAddedHist(data, Collection, Index);
            // Remove Data
            for (int i = 0; i < Collection.Count; i++)
            {
                for (int nodeIndex = 0; nodeIndex < Index.Count; nodeIndex++)
                {
                    if (nodeIndex < data[i].Count)
                    {
                        Collection[i].Insert(Index[nodeIndex], data[i][nodeIndex]);
                    }
                }
            }
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node Removed.";
        }

        #endregion
    }
    // Added
    public class TilesetCollisionsAddedHist : IMemento<IHistory>, IHistory
    {
        public List<Vertices> Collection = null;
        // Data
        List<Vertices> data;

        public TilesetCollisionsAddedHist(List<Vertices> d, List<Vertices> collection)
        {
            MainForm.NeedSave = true;
            data = new List<Vertices>(d);
            Collection = collection;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new TilesetCollisionsRemovedHist(data, Collection);
            // Remove Data
            for (int i = 0; i < Collection.Count; i++)
            {
                foreach (Vector2 v in data[i])
                {
                    Collection[i].Remove(v);
                }
            }
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node Added.";
        }

        #endregion
    }
    // Removed
    public class TilesetCollisionsRemovedHist : IMemento<IHistory>, IHistory
    {
        public List<Vertices> Collection = null;
        // Data
        List<Vertices> data;

        public TilesetCollisionsRemovedHist(List<Vertices> d, List<Vertices> collection)
        {
            MainForm.NeedSave = true;
            data = new List<Vertices>(d);
            Collection = collection;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new TilesetCollisionsAddedHist(data, Collection);
            // Add Data
            for (int i = 0; i < Collection.Count; i++)
            {
                foreach (Vector2 v in data[i])
                {
                    Collection[i].Add(v);
                }
            }
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node Removed.";
        }

        #endregion
    }
    // Edited
    public class TilesetCollisionsEditedHist : IMemento<IHistory>, IHistory
    {
        List<Vertices> Collection = null;
        // Data
        List<Vertices> OldVertices;
        List<Vertices> NewVertices;

        public TilesetCollisionsEditedHist(List<Vertices> oldVertices, List<Vertices> newVertices, List<Vertices> collection)
        {
            MainForm.NeedSave = true;
            OldVertices = new List<Vertices>();
            NewVertices = new List<Vertices>();

            for (int i = 0; i < collection.Count; i++)
            {
                OldVertices.Add(new Vertices());
                foreach (Vector2 v in oldVertices[i])
                {
                    OldVertices[i].Add(v);
                }
                NewVertices.Add(new Vertices());
                foreach (Vector2 v in newVertices[i])
                {
                    NewVertices[i].Add(v);
                }
            }
            Collection = collection;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new TilesetCollisionsEditedHist(NewVertices, OldVertices, Collection);
            // Remove Data
            for (int i = 0; i < Collection.Count; i++)
            {
                foreach (Vector2 v in NewVertices[i])
                {
                    Collection[i].Remove(v);
                }
                // Add Data
                foreach (Vector2 v in OldVertices[i])
                {
                    Collection[i].Add(v);
                }
            }
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Collision Node(s) Edited.";
        }

        #endregion
    }
    #endregion
    #endregion

    #region Database
    // Dataset Added
    public class DatasetAddedHist : IMemento<IHistory>, IHistory
    {
        DataProperty data;
        IList list;
        IAddRemoveList ctrl;
        IEditor editor;
        Data parent;
        List<DataProperty> childs;
        int index;

        public DatasetAddedHist(DataProperty a, Data p, List<DataProperty> ch, IList l, IAddRemoveList c, IEditor e, int i)
        {
            MainForm.NeedSave = true;
            data = a;
            list = l;
            ctrl = c;
            editor = e;
            parent = p;
            childs = ch;
            index = i;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new DatasetRemovedHist(data, parent, childs, list, ctrl, editor, index);
            // Remove Animation
            int i = list.IndexOf(data);
            list.Remove(data);
            childs.Clear();
            foreach (Data childData in parent.Datas.Values)
            {
                childs.Add(childData.Properties[i]);
                childData.Properties.RemoveAt(i);
            }
            ctrl.ForceIndexChange();
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return data.Name + " Added.";
        }

        #endregion
    }
    // IGameData Removed
    public class DatasetRemovedHist : IMemento<IHistory>, IHistory
    {
        DataProperty data;
        IList list;
        IAddRemoveList ctrl;
        IEditor editor;
        Data parent;
        List<DataProperty> childs;
        int index;

        public DatasetRemovedHist(DataProperty a, Data p, List<DataProperty> ch, IList l, IAddRemoveList c, IEditor e, int i)
        {
            MainForm.NeedSave = true;
            data = a;
            list = l;
            ctrl = c;
            editor = e;
            parent = p;
            childs = ch;
            index = i;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new DatasetAddedHist(data, parent, childs, list, ctrl, editor, index);
            // Remove Animation
            list.Insert(index, data);
            int i = 0;
            foreach (Data childData in parent.Datas.Values)
            {
                childData.Properties.Insert(index, childs[i]);
                i++;
            }
            if (ctrl != null)
                ctrl.ForceIndexChange();
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return data.Name + " Animation Removed.";
        }

        #endregion
    }
    #endregion

    #region Event Data
    // Event Page Added
    public class EventPageAddedHist : IMemento<IHistory>, IHistory
    {
        IGameData data;
        IList list;
        UserControl ctrl;
        int index;

        public EventPageAddedHist(IGameData a, IList l, UserControl c, int i)
        {
            MainForm.NeedSave = true;
            data = a;
            list = l;
            ctrl = c;
            index = i;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new EventPageRemovedHist(data, list, ctrl, index);
            // Remove Animation
            list.Remove(data);
            if (ctrl is EventEditorControl)
                ((EventEditorControl)ctrl).SetupEditor();
            else
                ((GlobalEventPage)ctrl).SetupEditor();
            //ctrl.SelectedIndex = index;
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return data.Name + " Added.";
        }

        #endregion
    }
    // IGameData Removed
    public class EventPageRemovedHist : IMemento<IHistory>, IHistory
    {
        IGameData data;
        IList list;
        UserControl ctrl;
        int index;

        public EventPageRemovedHist(IGameData a, IList l, UserControl c, int i)
        {
            MainForm.NeedSave = true;
            data = a;
            list = l;
            ctrl = c;
            index = i;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new EventPageAddedHist(data, list, ctrl, index);
            // Add Animation
            list.Insert(index, data);
            if (ctrl is EventEditorControl)
            {
                ((EventEditorControl)ctrl).SetupEditor();
                ((EventEditorControl)ctrl).SelectedIndex = index;
            }
            else
            {
                ((GlobalEventPage)ctrl).SetupEditor();
                ((GlobalEventPage)ctrl).SelectedIndex = index;
            }
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return data.Name + " Removed.";
        }

        #endregion
    }
    // IGameData Added
    public class EventProgramAddedHist : IMemento<IHistory>, IHistory
    {
        List<EventProgramData> Collection = null;
        int Index = 0;
        int NodeIndex;

        TreeNode Node;
        TreeNode ParentNode;
        TreeNode ElseNode;
        TreeView ListBox;
        // Data
        EventProgramData data;

        public EventProgramAddedHist(EventProgramData d, List<EventProgramData> collection, int index, int nodeIndex, TreeNode n, TreeNode elseNode, TreeNode pn, TreeView listbox)
        {
            MainForm.NeedSave = true;
            data = d;
            Collection = collection;
            Index = index;

            Node = n;
            ElseNode = elseNode;
            NodeIndex = nodeIndex;
            ParentNode = pn;
            ListBox = listbox;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new EventProgramRemovedHist(data, Collection, Index, NodeIndex, Node, ElseNode, ParentNode, ListBox);
            // Remove Data
            if (ParentNode != null)
            {
                ParentNode.Nodes.Remove(Node);
                if (ElseNode != null)
                    ParentNode.Nodes.Remove(ElseNode);
            }
            else
            {
                ListBox.Nodes.Remove(Node);
                if (ElseNode != null)
                    ListBox.Nodes.Remove(ElseNode);
            }
            Collection.Remove(data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Event Program Added.";
        }

        #endregion
    }

    public class EventProgramRemovedHist : IMemento<IHistory>, IHistory
    {
        List<EventProgramData> Collection = null;
        int Index = 0;
        int NodeIndex;

        TreeNode Node;
        TreeNode ElseNode;
        TreeNode ParentNode;
        TreeView ListBox;
        // Data
        EventProgramData data;

        public EventProgramRemovedHist(EventProgramData d, List<EventProgramData> collection, int index, int nodeIndex, TreeNode n, TreeNode elseNode, TreeNode pn, TreeView listbox)
        {
            MainForm.NeedSave = true;
            data = d;
            Collection = collection;
            Index = index;

            Node = n;
            ElseNode = elseNode;
            NodeIndex = nodeIndex;
            ParentNode = pn;
            ListBox = listbox;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new EventProgramAddedHist(data, Collection, Index, NodeIndex, Node, ElseNode, ParentNode, ListBox);
            // Remove Data
            if (ParentNode != null)
            {
                ParentNode.Nodes.Insert(NodeIndex, Node);
                if (ElseNode != null)
                    ParentNode.Nodes.Insert(NodeIndex + 1, ElseNode);
            }
            else
            {
                ListBox.Nodes.Insert(NodeIndex, Node);
                if (ElseNode != null)
                    ListBox.Nodes.Insert(NodeIndex + 1, ElseNode);
            }
            Collection.Insert(Index, data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Event Program Removed.";
        }

        #endregion
    }
    #endregion

    #region Map Data
    // IGameData Added
    public class ColAddedHist : IMemento<IHistory>, IHistory
    {
        public DataColAddDelegate OnDataAdd;
        public DataColRemoveDelegate OnDataRemove;
        public IGameData Parent = null;
        public ICollection Collection = null;
        public int Index = 0;
        string mapName = "";
        // Data
        CollisionData data;

        public ColAddedHist(CollisionData d, DataColAddDelegate addDelegate, DataColRemoveDelegate remDelegate)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            mapName = MainForm.SelectedMap.Name;
        }
        public ColAddedHist(CollisionData d, DataColAddDelegate addDelegate, DataColRemoveDelegate remDelegate, IGameData parent)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
            mapName = MainForm.SelectedMap.Name;
        }
        public ColAddedHist(CollisionData d, DataColAddDelegate addDelegate, DataColRemoveDelegate remDelegate, ICollection collection, int index)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
            mapName = MainForm.SelectedMap.Name;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            ColRemovedHist inverse;
            if (Parent != null)
                inverse = new ColRemovedHist(data, OnDataAdd, OnDataRemove, Parent);
            else if (Collection != null)
                inverse = new ColRemovedHist(data, OnDataAdd, OnDataRemove, Collection, Index);
            else
                inverse = new ColRemovedHist(data, OnDataAdd, OnDataRemove);
            // Remove Data
            OnDataRemove(inverse, data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Collision Added.";
        }

        #endregion
    }

    // IGameData Removed
    public class ColRemovedHist : IMemento<IHistory>, IHistory
    {
        public DataColAddDelegate OnDataAdd;
        public DataColRemoveDelegate OnDataRemove;
        public IGameData Parent;
        public ICollection Collection;
        public int Index = 0;
        string mapName = "";
        // Data
        CollisionData data;

        public ColRemovedHist(CollisionData d, DataColAddDelegate addDelegate, DataColRemoveDelegate remDelegate)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            mapName = MainForm.SelectedMap.Name;
        }
        public ColRemovedHist(CollisionData d, DataColAddDelegate addDelegate, DataColRemoveDelegate remDelegate, IGameData parent)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
            mapName = MainForm.SelectedMap.Name;
        }
        public ColRemovedHist(CollisionData d, DataColAddDelegate addDelegate, DataColRemoveDelegate remDelegate, ICollection collection, int index)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
            mapName = MainForm.SelectedMap.Name;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            ColAddedHist inverse;
            if (Parent != null)
                inverse = new ColAddedHist(data, OnDataAdd, OnDataRemove, Parent);
            else if (Collection != null)
                inverse = new ColAddedHist(data, OnDataAdd, OnDataRemove, Collection, Index);
            else
                inverse = new ColAddedHist(data, OnDataAdd, OnDataRemove);
            // Re Add Data
            OnDataAdd(inverse, data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Collision Removed.";
        }

        #endregion
    }

    // IGameData Added
    public class EventAddedHist : IMemento<IHistory>, IHistory
    {
        public DataEAddDelegate OnDataAdd;
        public DataERemoveDelegate OnDataRemove;
        public IGameData Parent = null;
        public ICollection Collection = null;
        public int Index = 0;
        string mapName = "";
        // Data
        IGameData data;

        public EventAddedHist(IGameData d, DataEAddDelegate addDelegate, DataERemoveDelegate remDelegate)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            mapName = MainForm.SelectedMap.Name;
        }
        public EventAddedHist(IGameData d, DataEAddDelegate addDelegate, DataERemoveDelegate remDelegate, IGameData parent)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
            mapName = MainForm.SelectedMap.Name;
        }
        public EventAddedHist(IGameData d, DataEAddDelegate addDelegate, DataERemoveDelegate remDelegate, ICollection collection, int index)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
            mapName = MainForm.SelectedMap.Name;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            EventRemovedHist inverse;
            if (Parent != null)
                inverse = new EventRemovedHist(data, OnDataAdd, OnDataRemove, Parent);
            else if (Collection != null)
                inverse = new EventRemovedHist(data, OnDataAdd, OnDataRemove, Collection, Index);
            else
                inverse = new EventRemovedHist(data, OnDataAdd, OnDataRemove);
            // Remove Data
            OnDataRemove(inverse, data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Event " + data.Name + " Added.";
        }

        #endregion
    }

    // IGameData Removed
    public class EventRemovedHist : IMemento<IHistory>, IHistory
    {
        public DataEAddDelegate OnDataAdd;
        public DataERemoveDelegate OnDataRemove;
        public IGameData Parent;
        public ICollection Collection;
        public int Index = 0;
        string mapName = "";
        // Data
        IGameData data;

        public EventRemovedHist(IGameData d, DataEAddDelegate addDelegate, DataERemoveDelegate remDelegate)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            mapName = MainForm.SelectedMap.Name;
        }
        public EventRemovedHist(IGameData d, DataEAddDelegate addDelegate, DataERemoveDelegate remDelegate, IGameData parent)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
            mapName = MainForm.SelectedMap.Name;
        }
        public EventRemovedHist(IGameData d, DataEAddDelegate addDelegate, DataERemoveDelegate remDelegate, ICollection collection, int index)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
            mapName = MainForm.SelectedMap.Name;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            EventAddedHist inverse;
            if (Parent != null)
                inverse = new EventAddedHist(data, OnDataAdd, OnDataRemove, Parent);
            else if (Collection != null)
                inverse = new EventAddedHist(data, OnDataAdd, OnDataRemove, Collection, Index);
            else
                inverse = new EventAddedHist(data, OnDataAdd, OnDataRemove);
            // Re Add Data
            OnDataAdd(inverse, data);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Event " + data.Name + " Removed.";
        }

        #endregion
    }
    // Event Moved
    public class EventMoved : IMemento<IHistory>, IHistory
    {
        EventData Event;
        Vector2 OldPos;
        Vector2 NewPos;
        string mapName = "";

        public EventMoved(EventData ev, Vector2 oldPos, Vector2 newPos)
        {
            MainForm.NeedSave = true;
            OldPos = oldPos;
            NewPos = newPos;
            Event = ev;
            mapName = MainForm.SelectedMap.Name;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse;
            inverse = new EventMoved(Event, NewPos, OldPos);
            // Move Event
            Event.Position = OldPos;
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Event " + Event.Name + " Moved.";
        }

        #endregion
    }
    // Tiles Added
    public class TilesAdded : IMemento<IHistory>, IHistory
    {
        public DataTRemoveDelegate OnDataRemove;
        List<TileData> Tiles;
        List<TileData> ToReplace;
        List<TileData> Collection;
        string mapName = "";

        public TilesAdded(List<TileData> tiles, List<TileData> toReplace, List<TileData> collection, DataTRemoveDelegate onRemove)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            Collection = collection;
            ToReplace = new List<TileData>(toReplace);
            mapName = MainForm.SelectedMap.Name;
            OnDataRemove = onRemove;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new TilesRemoved(Tiles, ToReplace, Collection, OnDataRemove);

            foreach (TileData tile in Tiles)
            {
                Collection.Remove(tile);
                OnDataRemove(tile);
            }

            foreach (TileData tile in ToReplace)
            {
                Collection.Add(tile);
            }


            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Tiles Added.";
        }

        #endregion
    }
    // Tiles Removed
    public class TilesRemoved : IMemento<IHistory>, IHistory
    {
        public DataTRemoveDelegate OnDataRemove;
        List<TileData> Tiles;
        List<TileData> ToReplace;
        List<TileData> Collection;
        string mapName = "";

        public TilesRemoved(List<TileData> tiles, List<TileData> toReplace, List<TileData> collection, DataTRemoveDelegate onRemove)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            Collection = collection;
            ToReplace = new List<TileData>(toReplace);
            mapName = MainForm.SelectedMap.Name;
            OnDataRemove = onRemove;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new TilesAdded(Tiles, ToReplace, Collection, OnDataRemove);

            foreach (TileData tile in Tiles)
            {
                Collection.Remove(tile);
                Collection.Add(tile);
            }

            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Tiles Removed.";
        }

        #endregion
    }
    // Tiles Modified
    public class TilesMoved : IMemento<IHistory>, IHistory
    {
        List<TileData> Tiles;
        List<TileData> ToReplace;
        List<Vector2> SelectedNewPositions;
        List<Vector2> SelectedOldPositions;
        Vector2 OldPos;
        Vector2 NewPos;
        List<TileData> Collection;
        string mapName = "";

        public TilesMoved(List<TileData> tiles, List<TileData> rtiles, Vector2 oldPos, Vector2 newPos, List<TileData> collection)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            ToReplace = new List<TileData>(rtiles);
            OldPos = oldPos;
            NewPos = newPos;
            Collection = collection;
            mapName = MainForm.SelectedMap.Name;
        }

        public TilesMoved(List<TileData> tiles, List<TileData> rtiles, List<Vector2> selectedOldPositions, List<Vector2> selectedNewPositions, List<TileData> collection)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            ToReplace = new List<TileData>(rtiles);
            SelectedNewPositions = new List<Vector2>(selectedNewPositions);
            SelectedOldPositions = new List<Vector2>(selectedOldPositions);
            Collection = collection;
            mapName = MainForm.SelectedMap.Name;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse;
            if (SelectedNewPositions != null)
            {
                inverse = new TilesMovedBack(Tiles, ToReplace, SelectedNewPositions, SelectedOldPositions, Collection);

                // Revert Tiles
                int i = 0;
                foreach (TileData tile in Tiles)
                {
                    tile.Position = SelectedOldPositions[i];
                    i++;
                }
                // Add replaced tiles
                foreach (TileData tile in ToReplace)
                {
                    Collection.Add(tile);
                }
            }
            else
            {
                inverse = new TilesMovedBack(Tiles, ToReplace, NewPos, OldPos, Collection);
                // Revert Tiles
                foreach (TileData tile in Tiles)
                {
                    tile.Position = OldPos;
                }
                // Add replaced tiles
                foreach (TileData tile in ToReplace)
                {
                    Collection.Add(tile);
                }
            }
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Tiles Moved.";
        }

        #endregion
    }






    // Tiles Modified
    public class TilesMovedNoSnap : IMemento<IHistory>, IHistory
    {
        List<TileData> Tiles;
        List<Vector2> SelectedNewPositions;
        List<Vector2> SelectedOldPositions;
        Vector2 OldPos;
        Vector2 NewPos;
        List<TileData> Collection;
        string mapName = "";

        public TilesMovedNoSnap(List<TileData> tiles, Vector2 oldPos, Vector2 newPos, List<TileData> collection)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            OldPos = oldPos;
            NewPos = newPos;
            Collection = collection;
            mapName = MainForm.SelectedMap.Name;
        }

        public TilesMovedNoSnap(List<TileData> tiles, List<Vector2> selectedOldPositions, List<Vector2> selectedNewPositions, List<TileData> collection)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            SelectedNewPositions = new List<Vector2>(selectedNewPositions);
            SelectedOldPositions = new List<Vector2>(selectedOldPositions);
            Collection = collection;
            mapName = MainForm.SelectedMap.Name;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse;
            if (SelectedNewPositions != null)
            {
                inverse = new TilesMovedNoSnapBack(Tiles, SelectedNewPositions, SelectedOldPositions, Collection);

                // Revert Tiles
                int i = 0;
                foreach (TileData tile in Tiles)
                {
                    tile.Position = SelectedOldPositions[i];
                    i++;
                }
            }
            else
            {
                inverse = new TilesMovedNoSnapBack(Tiles, NewPos, OldPos, Collection);
                // Revert Tiles
                foreach (TileData tile in Tiles)
                {
                    tile.Position = OldPos;
                }
            }
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Tiles Moved.";
        }

        #endregion
    }
    // Tiles Modified
    public class TilesMovedNoSnapBack : IMemento<IHistory>, IHistory
    {
        List<TileData> Tiles;
        List<Vector2> SelectedNewPositions;
        List<Vector2> SelectedOldPositions;
        Vector2 OldPos;
        Vector2 NewPos;
        List<TileData> Collection;
        string mapName = "";

        public TilesMovedNoSnapBack(List<TileData> tiles, Vector2 oldPos, Vector2 newPos, List<TileData> collection)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            OldPos = oldPos;
            NewPos = newPos;
            Collection = collection;
            mapName = MainForm.SelectedMap.Name;
        }

        public TilesMovedNoSnapBack(List<TileData> tiles, List<Vector2> selectedOldPositions, List<Vector2> selectedNewPositions, List<TileData> collection)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            SelectedNewPositions = new List<Vector2>(selectedNewPositions);
            SelectedOldPositions = new List<Vector2>(selectedOldPositions);
            Collection = collection;
            mapName = MainForm.SelectedMap.Name;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse;
            if (SelectedNewPositions != null)
            {
                inverse = new TilesMovedNoSnap(Tiles, SelectedNewPositions, SelectedOldPositions, Collection);

                // Revert Tiles
                int i = 0;
                foreach (TileData tile in Tiles)
                {
                    tile.Position = SelectedOldPositions[i];
                    i++;
                }
            }
            else
            {
                inverse = new TilesMovedNoSnap(Tiles, NewPos, OldPos, Collection);
                // Revert Tiles
                foreach (TileData tile in Tiles)
                {
                    tile.Position = OldPos;
                }
            }
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Tiles Moved.";
        }

        #endregion
    }
    // Tiles Modified
    public class TilesMovedBack : IMemento<IHistory>, IHistory
    {
        List<TileData> Tiles;
        List<TileData> ToReplace;
        List<Vector2> SelectedNewPositions;
        List<Vector2> SelectedOldPositions;
        Vector2 OldPos;
        Vector2 NewPos;
        List<TileData> Collection;
        string mapName = "";

        public TilesMovedBack(List<TileData> tiles, List<TileData> rtiles, Vector2 oldPos, Vector2 newPos, List<TileData> collection)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            ToReplace = new List<TileData>(rtiles);
            OldPos = oldPos;
            NewPos = newPos;
            Collection = collection;
            mapName = MainForm.SelectedMap.Name;
        }

        public TilesMovedBack(List<TileData> tiles, List<TileData> rtiles, List<Vector2> selectedOldPositions, List<Vector2> selectedNewPositions, List<TileData> collection)
        {
            MainForm.NeedSave = true;
            Tiles = new List<TileData>(tiles);
            ToReplace = new List<TileData>(rtiles);
            SelectedNewPositions = new List<Vector2>(selectedNewPositions);
            SelectedOldPositions = new List<Vector2>(selectedOldPositions);
            Collection = collection;
            mapName = MainForm.SelectedMap.Name;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse;
            if (SelectedNewPositions != null)
            {
                inverse = new TilesMoved(Tiles, ToReplace, SelectedNewPositions, SelectedOldPositions, Collection);

                // Revert Tiles
                int i = 0;
                foreach (TileData tile in Tiles)
                {
                    tile.Position = SelectedOldPositions[i];
                    i++;
                }
                // Add replaced tiles
                foreach (TileData tile in ToReplace)
                {
                    Collection.Add(tile);
                }
            }
            else
            {
                inverse = new TilesMoved(Tiles, ToReplace, NewPos, OldPos, Collection);
                // Revert Tiles
                foreach (TileData tile in Tiles)
                {
                    tile.Position = OldPos;
                }
                // Add replaced tiles
                foreach (TileData tile in ToReplace)
                {
                    Collection.Add(tile);
                }
            }
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Tiles Moved.";
        }

        #endregion
    }
    // Tiles Modified
    public class TilesMod : IMemento<IHistory>, IHistory
    {
        Dictionary<Vector2, TileData> tiles;
        Dictionary<Vector2, TileData> clones = new Dictionary<Vector2, TileData>();
        string mapName = "";

        public TilesMod(Dictionary<Vector2, TileData> t)
        {
            MainForm.NeedSave = true;
            tiles = new Dictionary<Vector2, TileData>(t);
            foreach (TileData tile in tiles.Values)
            {
                TileData temp = tile.Clone();
                clones.Add(temp.Position, temp);
            }
            mapName = MainForm.SelectedMap.Name;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new TilesMod(tiles);
            // Revert Tiles
            foreach (TileData tile in tiles.Values)
            {
                tile.Convert(clones[tile.Position]);
            }
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Tiles Modified.";
        }

        #endregion
    }
    // Tiles Modified
    public class TileMod : IMemento<IHistory>, IHistory
    {
        TileData tile;
        TileData clone;
        string mapName = "";

        public TileMod(TileData t)
        {
            MainForm.NeedSave = true;
            tile = t;
            clone = t.Clone();
            mapName = MainForm.SelectedMap.Name;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            IMemento<IHistory> inverse = new TileMod(tile);
            // Revert Tiles
            tile.Convert(clone);
            if (MainForm.mapEditor.mapEditor2.mapViewer.tileSettings.SelectedTile == tile)
            {
                MainForm.mapEditor.mapEditor2.mapViewer.tileSettings.SelectedTile = tile;
            }
            // Return Inverse
            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return mapName + ": Tile Modified.";
        }

        #endregion
    }
    #endregion

    #region Menu Data
    // IGameData Added
    public class MenuPartAddedHist : IMemento<IHistory>, IHistory
    {
        public DataMenuPartAddDelegate OnDataAdd;
        public DataMenuPartRemoveDelegate OnDataRemove;
        public IGameData Parent = null;
        public ICollection Collection = null;
        public int Index = 0;
        MenuData Menu;
        // Data
        IGameData data;

        public MenuPartAddedHist(IGameData d, DataMenuPartAddDelegate addDelegate, DataMenuPartRemoveDelegate remDelegate, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Menu = menu;
        }
        public MenuPartAddedHist(IGameData d, DataMenuPartAddDelegate addDelegate, DataMenuPartRemoveDelegate remDelegate, IGameData parent, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
            Menu = menu;
        }
        public MenuPartAddedHist(IGameData d, DataMenuPartAddDelegate addDelegate, DataMenuPartRemoveDelegate remDelegate, ICollection collection, int index, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
            Menu = menu;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            MenuPartRemovedHist inverse;
            if (Parent != null)
                inverse = new MenuPartRemovedHist(data, OnDataAdd, OnDataRemove, Parent, Menu);
            else if (Collection != null)
                inverse = new MenuPartRemovedHist(data, OnDataAdd, OnDataRemove, Collection, Index, Menu);
            else
                inverse = new MenuPartRemovedHist(data, OnDataAdd, OnDataRemove, Menu);
            // Remove Data
            OnDataRemove(inverse, data, Menu);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Menu Part " + data.Name + " Added.";
        }

        #endregion
    }
    // IGameData Removed
    public class MenuPartRemovedHist : IMemento<IHistory>, IHistory
    {
        public DataMenuPartAddDelegate OnDataAdd;
        public DataMenuPartRemoveDelegate OnDataRemove;
        public IGameData Parent;
        public ICollection Collection;
        public int Index = 0;
        // Data
        IGameData data;
        MenuData Menu;

        public MenuPartRemovedHist(IGameData d, DataMenuPartAddDelegate addDelegate, DataMenuPartRemoveDelegate remDelegate, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Menu = menu;
        }
        public MenuPartRemovedHist(IGameData d, DataMenuPartAddDelegate addDelegate, DataMenuPartRemoveDelegate remDelegate, IGameData parent, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
            Menu = menu;
        }
        public MenuPartRemovedHist(IGameData d, DataMenuPartAddDelegate addDelegate, DataMenuPartRemoveDelegate remDelegate, ICollection collection, int index, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
            Menu = menu;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            MenuPartAddedHist inverse;
            if (Parent != null)
                inverse = new MenuPartAddedHist(data, OnDataAdd, OnDataRemove, Parent, Menu);
            else if (Collection != null)
                inverse = new MenuPartAddedHist(data, OnDataAdd, OnDataRemove, Collection, Index, Menu);
            else
                inverse = new MenuPartAddedHist(data, OnDataAdd, OnDataRemove, Menu);
            // Re Add Data
            OnDataAdd(inverse, data, Menu);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Menu Part " + data.Name + " Removed.";
        }

        #endregion
    }
    // TileData Change Properties
    public class MenuPartChangePropertyHist : IMemento<IHistory>, IHistory
    {
        public DataMenuPartPropertyDelegate OnDataProperty;
        // Data
        IMenuParts data;
        MenuData Menu;
        Dictionary<PropertyDescriptor, object> Properties;

        public MenuPartChangePropertyHist(IMenuParts d, DataMenuPartPropertyDelegate del, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataProperty = del;
            Menu = menu;

            // Properties
            Properties = new Dictionary<PropertyDescriptor, object>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data);
            foreach (PropertyDescriptor myProperty in properties)
            {
                try
                {
                    if (myProperty.PropertyType.IsSerializable && myProperty.Name != "Parent" && myProperty.Name != "MenuParts")
                    {
                        object value = Global.Duplicate<object>(myProperty.GetValue(data));
                        Properties.Add(myProperty, value);
                    }
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "32x005");
                }
            }
        }

        public MenuPartChangePropertyHist(IMenuParts d, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            Menu = menu;
            // Properties
            Properties = new Dictionary<PropertyDescriptor, object>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data);
            foreach (PropertyDescriptor myProperty in properties)
            {
                try
                {
                    if (myProperty.PropertyType.IsSerializable && myProperty.Name != "Parent" && myProperty.Name != "MenuParts")
                    {
                        Properties.Add(myProperty, Global.Duplicate<object>(myProperty.GetValue(data)));
                    }
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "32x007");
                }
            }
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            IMemento<IHistory> inverse;

            if (OnDataProperty != null)
                inverse = new MenuPartChangePropertyHist(data, OnDataProperty, Menu);
            else
                inverse = new MenuPartChangePropertyHist(data, Menu);

            foreach (KeyValuePair<PropertyDescriptor, object> myProperty in Properties)
            {
                try
                {
                    myProperty.Key.SetValue(data, myProperty.Value);
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "32x008");
                }
            }

            if (OnDataProperty != null)
                OnDataProperty(this, data, Menu);

            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Menu Part property Changed.";
        }

        #endregion
    }
    // TileData Change Properties
    public class MenuPartsChangePropertyHist : IMemento<IHistory>, IHistory
    {
        public DataMenuPartsPropertyDelegate OnDataProperty;
        // Data
        List<IMenuParts> data;
        List<Dictionary<PropertyDescriptor, object>> Properties = new List<Dictionary<PropertyDescriptor, object>>();
        MenuData Menu;
        public MenuPartsChangePropertyHist(List<IMenuParts> d, DataMenuPartsPropertyDelegate del, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            OnDataProperty = del;
            Menu = menu;

            // Properties
            for (int i = 0; i < data.Count; i++)
            {
                Properties.Add(new Dictionary<PropertyDescriptor, object>());
                Properties[i] = new Dictionary<PropertyDescriptor, object>();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data[i]);
                foreach (PropertyDescriptor myProperty in properties)
                {
                    try
                    {
                        if (myProperty.PropertyType.IsSerializable &&
                            myProperty.Name != "MenuParts" && myProperty.Name != "Parent")
                        {
                            Properties[i].Add(myProperty, Global.Duplicate<object>(myProperty.GetValue(data[i])));
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.ShowLogError(ex, "32x011");
                    }
                }
            }
        }

        public MenuPartsChangePropertyHist(List<IMenuParts> d, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = d;
            Menu = menu;
            // Properties
            for (int i = 0; i < data.Count; i++)
            {
                Properties[i] = new Dictionary<PropertyDescriptor, object>();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(data[i]);
                foreach (PropertyDescriptor myProperty in properties)
                {
                    try
                    {
                        if (myProperty.PropertyType.IsSerializable && myProperty.Name != "Parent" && myProperty.Name != "MenuParts")
                        {
                            Properties[i].Add(myProperty, Global.Duplicate<object>(myProperty.GetValue(data[i])));
                        }
                    }
                    catch (Exception ex)
                    {
                        Error.ShowLogError(ex, "32x009");
                    }
                }
            }
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            IMemento<IHistory> inverse;

            if (OnDataProperty != null)
                inverse = new MenuPartsChangePropertyHist(data, OnDataProperty, Menu);
            else
                inverse = new MenuPartsChangePropertyHist(data, Menu);

            // Properties
            for (int i = 0; i < data.Count; i++)
            {
                foreach (KeyValuePair<PropertyDescriptor, object> myProperty in Properties[i])
                {
                    try
                    {
                        myProperty.Key.SetValue(data[i], myProperty.Value);
                    }
                    catch (Exception ex)
                    {
                        Error.ShowLogError(ex, "32x012");
                    }
                }
            }
            if (OnDataProperty != null)
                OnDataProperty(this, data, Menu);

            return inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Menu Part property Changed.";
        }

        #endregion
    }
    // IGameData Added
    public class MenuPartsAddedHist : IMemento<IHistory>, IHistory
    {
        public DataMenuPartsAddDelegate OnDataAdd;
        public DataMenuPartsRemoveDelegate OnDataRemove;
        public List<IGameData> Parent = null;
        public ICollection Collection = null;
        public int Index = 0;
        // Data
        List<IMenuParts> data;
        MenuData Menu;

        public MenuPartsAddedHist(List<IMenuParts> d, DataMenuPartsAddDelegate addDelegate, DataMenuPartsRemoveDelegate remDelegate, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = new List<IMenuParts>(d);
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Menu = menu;
        }
        public MenuPartsAddedHist(List<IMenuParts> d, DataMenuPartsAddDelegate addDelegate, DataMenuPartsRemoveDelegate remDelegate, List<IGameData> parent, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = new List<IMenuParts>(d);
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
            Menu = menu;
        }
        public MenuPartsAddedHist(List<IMenuParts> d, DataMenuPartsAddDelegate addDelegate, DataMenuPartsRemoveDelegate remDelegate, ICollection collection, int index, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = new List<IMenuParts>(d);
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
            Menu = menu;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            MenuPartsRemovedHist inverse;
            if (Parent != null)
                inverse = new MenuPartsRemovedHist(data, OnDataAdd, OnDataRemove, Parent, Menu);
            else if (Collection != null)
                inverse = new MenuPartsRemovedHist(data, OnDataAdd, OnDataRemove, Collection, Index, Menu);
            else
                inverse = new MenuPartsRemovedHist(data, OnDataAdd, OnDataRemove, Menu);
            // Remove Data
            OnDataRemove(inverse, data, Menu);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Menuparts Added.";
        }

        #endregion
    }
    // IGameData Removed
    public class MenuPartsRemovedHist : IMemento<IHistory>, IHistory
    {
        public DataMenuPartsAddDelegate OnDataAdd;
        public DataMenuPartsRemoveDelegate OnDataRemove;
        public List<IGameData> Parent;
        public ICollection Collection;
        public int Index = 0;
        MenuData Menu;
        // Data
        List<IMenuParts> data;

        public MenuPartsRemovedHist(List<IMenuParts> d, DataMenuPartsAddDelegate addDelegate, DataMenuPartsRemoveDelegate remDelegate, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = new List<IMenuParts>(d);
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Menu = menu;
        }
        public MenuPartsRemovedHist(List<IMenuParts> d, DataMenuPartsAddDelegate addDelegate, DataMenuPartsRemoveDelegate remDelegate, List<IGameData> parent, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = new List<IMenuParts>(d);
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Parent = parent;
            Menu = menu;
        }
        public MenuPartsRemovedHist(List<IMenuParts> d, DataMenuPartsAddDelegate addDelegate, DataMenuPartsRemoveDelegate remDelegate, ICollection collection, int index, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = new List<IMenuParts>(d);
            OnDataAdd = addDelegate;
            OnDataRemove = remDelegate;
            Collection = collection;
            Index = index;
            Menu = menu;
        }

        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            // Create Inverse
            MenuPartsAddedHist inverse;
            if (Parent != null)
                inverse = new MenuPartsAddedHist(data, OnDataAdd, OnDataRemove, Parent, Menu);
            else if (Collection != null)
                inverse = new MenuPartsAddedHist(data, OnDataAdd, OnDataRemove, Collection, Index, Menu);
            else
                inverse = new MenuPartsAddedHist(data, OnDataAdd, OnDataRemove, Menu);
            // Re Add Data
            OnDataAdd(inverse, data, Menu);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Menuparts Removed.";
        }

        #endregion
    }

    public class MenuPartsPositionChangeHist : IMemento<IHistory>, IHistory
    {
        public MenuPartsPositionDelegate OnDataPosition;
        // Data
        List<IMenuParts> data;
        List<Vector2> positions;
        List<Vector2> newPositions;
        Vector2 parentPoint;
        MenuData parent;

        public MenuPartsPositionChangeHist(List<IMenuParts> d, List<Vector2> p, List<Vector2> np, Vector2 pp, MenuPartsPositionDelegate hist, MenuData menu)
        {
            MainForm.NeedSave = true;
            data = new List<IMenuParts>(d);
            positions = new List<Vector2>(p);
            newPositions = new List<Vector2>(np);
            parentPoint = pp;
            OnDataPosition = hist;
            parent = menu;
        }
        #region IMemento<IHistory> Members

        public IMemento<IHistory> Restore(IHistory target)
        {
            Vector2 pp;
            if (data[0].Parent != null)
            {
                pp = data[0].Parent.RealPosition;
            }
            else
                pp = new Vector2(-1000, -1000);
            // Create Inverse
            MenuPartsPositionChangeHist inverse = new MenuPartsPositionChangeHist(data, newPositions, positions, pp, OnDataPosition, parent);
            // Re Add Data
            OnDataPosition(inverse, data, positions, parentPoint, parent);
            // Return Inverse
            return (IMemento<IHistory>)inverse;
        }

        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "Menuparts Moved.";
        }

        #endregion
    }
    #endregion
}