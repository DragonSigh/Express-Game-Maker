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

namespace EGMGame.Docking.Editors.Database
{
    public partial class DropableItemsDialog : Form
    {
        internal List<int> ItemDrops = new List<int>();
        internal List<int> EquipDrops = new List<int>();
        internal int DropProb;

        public DropableItemsDialog()
        {
            InitializeComponent();
        }

        private void barPriority_ValueChanged(object sender, decimal value)
        {
            if (value != nudProb.Value)
            {
                nudProb.Value = value;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (nudProb.Value != barProb.Value)
            {
                barProb.Value = (int)nudProb.Value;
            }

        }

        private void okBtn_Click(object sender, EventArgs e)
        {

            foreach (ItemTag tag in listItems.CheckedItems)
            {
                ItemDrops.Add(tag.ID);
            }
            foreach (ItemTag tag in listEquipments.CheckedItems)
            {
                EquipDrops.Add(tag.ID);
            }

            DropProb = (int)nudProb.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        internal void Setup(EnemyData data)
        {
            nudProb.Value = (decimal)data.DropProbality;
            ItemTag tag;
            foreach (ItemData item in GameData.Items.Values)
            {
                tag = new ItemTag(item.ID, item.Name);
                listItems.Items.Add(tag, data.ItemDrops.Contains(item.ID));
            }
            foreach (EquipmentData item in GameData.Equipments.Values)
            {
                tag = new ItemTag(item.ID, item.Name);
                listEquipments.Items.Add(tag, data.EquipDrops.Contains(item.ID));
            }
        }
    }
}
