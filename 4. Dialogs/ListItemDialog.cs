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

namespace EGMGame.Dialogs
{
    public partial class ListItemDialog : Form
    {
        public List<ListItem> ListItems
        {
            get { return listItems; }
            set { listItems = value; Setup(); }
        }
        List<ListItem> listItems;

        public ListItemDialog()
        {
            InitializeComponent();

            this.toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
        }
        /// <summary>
        /// Setup
        /// </summary>
        private void Setup()
        {
            listBox.Items.Clear();

            foreach (ListItem item in listItems)
            {
                listBox.Items.Add(item.Name);
            }

            if (listBox.Items.Count > 0)
                listBox.SelectedIndex = 0;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                propertyGrid.SelectedObject = listItems[listBox.SelectedIndex];
            }
            else
                propertyGrid.SelectedObject = null;
        }


        private void addBTn_Click(object sender, EventArgs e)
        {
            ListItem item = new ListItem();
            item.ID = Global.GetID(listItems);
            item.Name = Global.GetName("Option", listItems);
            listItems.Add(item);
            listBox.Items.Add(item.Name);

            listBox.SelectedIndex = listBox.Items.Count - 1;
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                listItems.RemoveAt(listBox.SelectedIndex);
                listBox.Items.RemoveAt(listBox.SelectedIndex);
                listBox.SelectedIndex = listBox.Items.Count - 1;
            }
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > 0)
            {
                int index = listBox.SelectedIndex;
                ListItem item = listItems[listBox.SelectedIndex];
                listItems.RemoveAt(listBox.SelectedIndex);
                listBox.Items.RemoveAt(listBox.SelectedIndex);

                listItems.Insert(index - 1, item); ;
                listBox.Items.Insert(index-1, item.Name);

                listBox.SelectedIndex = index - 1;
            }
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1 && listBox.SelectedIndex < listBox.Items.Count - 1)
            {
                int index = listBox.SelectedIndex;
                ListItem item = listItems[listBox.SelectedIndex];
                listItems.RemoveAt(listBox.SelectedIndex);
                listBox.Items.RemoveAt(listBox.SelectedIndex);

                listItems.Insert(index + 1, item); ;
                listBox.Items.Insert(index + 1, item.Name);

                listBox.SelectedIndex = index + 1;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            int index = listBox.SelectedIndex;


            if (index > -1 && index < listBox.Items.Count)
            {
                listBox.Items[index] = listItems[index].Name;
            }
        }
    }
}
