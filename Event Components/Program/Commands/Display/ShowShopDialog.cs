//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.DisplayDialogs
{
    public partial class ShowShopDialog : Form
    {
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set
            {
                programs = value; if (action == null) Setup();
            }
        }
        List<EventProgramData> programs;

        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; Setup(); }
        }
        EventPageData selectedPage;

        public IEvent SelectedEvent
        {
            get { return selEvent; }
            set
            {
                selEvent = value;
            }
        }
        IEvent selEvent;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;

        List<int> items = new List<int>();
        List<int> equipments = new List<int>();

        public ShowShopDialog()
        {
            InitializeComponent();
            cbMenu.RefreshList(false);
        }

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Display;
            action.Code = 15;
        }

        private void RefreshList()
        {
            listItems.Items.Clear();
            ItemData Item;
            EquipmentData Equipment;
            foreach (int id in items)
            {
                Item = Global.GetData<ItemData>(id, GameData.Items);

                listItems.Items.Add(new ShopItem(true, id, Item, null));
            }

            foreach (int id in equipments)
            {
                Equipment = Global.GetData<EquipmentData>(id, GameData.Equipments);

                listItems.Items.Add(new ShopItem(false, id, null, Equipment));
            }
        }

        private void SetupAction(EventProgramData a)
        {
            action = new EventProgramData();
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            cbMenu.Select((int)a.Value[0]);
            items = (List<int>)a.Value[1];
            equipments = (List<int>)a.Value[2];

            RefreshList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemEquipmentDialog dialog = new ItemEquipmentDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (dialog.rbItems.Checked)
                {
                    if (dialog.cbItems.Data().ID > -1)
                    {
                        if (!items.Contains(dialog.cbItems.Data().ID))
                        {
                            items.Add(dialog.cbItems.Data().ID);
                            RefreshList();
                        }
                    }
                }
                else
                {
                    if (dialog.cbEquipments.Data().ID > -1)
                    {
                        if (!equipments.Contains(dialog.cbEquipments.Data().ID))
                        {
                            equipments.Add(dialog.cbEquipments.Data().ID);
                            RefreshList();
                        }
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listItems.SelectedIndex > -1)
            {
                ShopItem item = ((ShopItem)listItems.Items[listItems.SelectedIndex]);

                if (item.IsItem)
                {
                    items.Remove(item.ID);
                }
                else
                {
                    equipments.Remove(item.ID);
                }

                listItems.Items.RemoveAt(listItems.SelectedIndex);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbMenu.Data().ID;
            action.Value[1] = items;
            action.Value[2] = equipments;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void listItems_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            // Create a new Brush and initialize to a Black colored brush
            // by default.

            e.DrawBackground();
            Brush myBrush = Brushes.Black;

            // Determine the color of the brush to draw each item based on 
            // the index of the item to draw.


            // Draw the current item text based on the current 
            // Font and the custom brush settings.
            //

            if (e.Index > -1 && ((ListBox)sender).Items[e.Index] is ShopItem)
            {
                ShopItem action = ((ShopItem)((ListBox)sender).Items[e.Index]);


                Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height);
                // Draw Priority
                if (action.IsItem)
                    e.Graphics.DrawString(action.Item.Name, e.Font, myBrush, rect, StringFormat.GenericDefault);
                else
                    e.Graphics.DrawString(action.Equipment.Name, e.Font, myBrush, rect, StringFormat.GenericDefault);


                rect.X += 120;
                if (action.IsItem)
                    e.Graphics.DrawString(": " + action.Item.Price.ToString(),
                    e.Font, myBrush, rect, StringFormat.GenericDefault);
                else
                    e.Graphics.DrawString(": " + action.Equipment.Price.ToString(),
                    e.Font, myBrush, rect, StringFormat.GenericDefault);
            }
            else
            {
                Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width, e.Bounds.Height);
                // Draw Priority
                if (e.Index > -1)
                    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, myBrush, rect, StringFormat.GenericDefault);

            }
            // If the ListBox has focus, draw a focus rectangle 
            // around the selected item.

            e.DrawFocusRectangle();
        }

    }

    public class ShopItem
    {
        public bool IsItem;
        public int ID;
        public EquipmentData Equipment;
        public ItemData Item;

        public ShopItem(bool isItem, int id, ItemData i, EquipmentData e)
        {
            IsItem = isItem;
            ID = id;
            Equipment = e;
            Item = i;
        }
    }
}
