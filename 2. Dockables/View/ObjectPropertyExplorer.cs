//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using EGMGame.Library;

namespace EGMGame.Docking.Explorers
{
    public partial class ObjectPropertyExplorer : DockContent
    {
        bool isMenuPart = false;

        MenuData SelectedMenu;
        object SelectedObj;

        public ObjectPropertyExplorer()
        {
            InitializeComponent();
        }

        public void SetMapProperties()
        {
            cbMenus.Enabled = false;
            cbMenus.Items.Clear();
        }

        public void PopulateMenuParts(MenuData selectedMenu)
        {
            SelectedMenu = selectedMenu;
            isMenuPart = true;
            cbMenus.Enabled = true;
            cbMenus.Items.Clear();
            if (selectedMenu != null)
            {

                allowChange = false;
                cbMenus.Items.Add(new ItemMenuPart(-1, null, selectedMenu.Name + " <Menu>"));
                AddMenuParts(null);
                allowChange = true;
                cbMenus.SelectedIndex = 0;
            }
            else
            {
                allowChange = false;
                propertyGrid.SelectedObject = null;
                allowChange = true;
            }
        }

        void AddMenuParts(IMenuParts parent)
        {
            if (parent == null)
            {
                foreach (IMenuParts part in SelectedMenu.MenuParts)
                {
                    cbMenus.Items.Add(new ItemMenuPart(part.ID, part, part.Name));
                    AddMenuParts(part);
                }
            }
            else
            {
                foreach (IMenuParts part in parent.MenuParts)
                {
                    cbMenus.Items.Add(new ItemMenuPart(part.ID, part, part.Name));
                    AddMenuParts(part);
                }
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange && cbMenus.SelectedIndex > -1)
            {
                if (((ItemMenuPart)cbMenus.Items[cbMenus.SelectedIndex]).ID == -1)
                {
                    propertyGrid.SelectedObject = SelectedMenu;

                    MainForm.menuEditor.menuViewer1.selectedObject = null;
                    
                    MainForm.menuEditor.menuViewer1.SelectedObjects.Clear();
                }
                else
                {
                    MainForm.menuEditor.menuViewer1.SelectedObjects.Clear();
                    propertyGrid.SelectedObject = MainForm.menuEditor.menuViewer1.selectedObject = ((ItemMenuPart)cbMenus.Items[cbMenus.SelectedIndex]).Part;
                }
            }
        }

        bool allowChange = true;
        private void propertyGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {
            allowChange = false;
            if (propertyGrid.SelectedObjects.Length > 1)
            {
                cbMenus.SelectedIndex = -1;
            }
            else
            {
                if (propertyGrid.SelectedObject is IMenuParts)
                {
                    cbMenus.Enabled = true;
                    int i = 0;
                    foreach (ItemMenuPart part in cbMenus.Items)
                    {
                        if (part.ID == ((IMenuParts)propertyGrid.SelectedObject).ID)
                        {
                            cbMenus.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                else if (propertyGrid.SelectedObject is MenuData)
                {
                    cbMenus.Enabled = true;
                    if (cbMenus.Items.Count > 0)
                        cbMenus.SelectedIndex = 0;
                }
                //else if (propertyGrid.SelectedObject is EventData)
                //{
                //    SetMapProperties();
                //}
                //else if (propertyGrid.SelectedObject is TileData)
                //{
                //    SetMapProperties();
                //}
                //else if (propertyGrid.SelectedObject is LayerData)
                //{
                //    SetMapProperties();
                //}
            }
            allowChange = true;
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //if (cbMenus.SelectedIndex > 0)
            //{
            //    object newValue = e.ChangedItem.Value;

            //    foreach (object obj in propertyGrid.SelectedObjects)
            //    {
            //        if (e.ChangedItem.Parent != null)
            //        {
            //            TypeDescriptor.getPro
            //            e.ChangedItem.PropertyDescriptor.SetValue(, e.OldValue);
            //        }
            //        else
            //            e.ChangedItem.PropertyDescriptor.SetValue(obj, e.OldValue);
            //    }

            //    MainForm.MenuEditorHistory[MainForm.menuEditor.menuViewer1].Do(new MenuPartsChangePropertyHist(new List<IMenuParts>(MainForm.menuEditor.menuViewer1.SelectedObjects), new DataMenuPartsPropertyDelegate(MainForm.menuEditor.menuViewer1.MenuPartsPropertyChanged)));

            //    foreach (object obj in propertyGrid.SelectedObjects)
            //    {
            //        if (e.ChangedItem.Parent != null)
            //            e.ChangedItem.Parent.PropertyDescriptor.SetValue(obj, newValue);
            //        else
            //            e.ChangedItem.PropertyDescriptor.SetValue(obj, newValue);
            //    }
            //    // If name is changed, re populate combobox
            //    if (e.ChangedItem.Label == "Name")
            //    {
            //        int i = cbMenus.SelectedIndex;
            //        PopulateMenuParts(SelectedMenu);
            //        cbMenus.SelectedIndex = i;
            //    }
            //}
            //else if (cbMenus.SelectedIndex == 0)
            //{

            //}
        }

        internal void ResetProject()
        {
            propertyGrid.SelectedObject = null;
        }
    }

    public class ItemMenuPart
    {
        public int ID;
        public IMenuParts Part;
        public string Name;

        public ItemMenuPart(int id, IMenuParts part, string name)
        {
            ID = id;
            Part = part;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
