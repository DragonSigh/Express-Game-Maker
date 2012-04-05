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
    public partial class StealableItemsDialog : Form
    {
        internal int ItemID = -1;
        internal ItemType type = ItemType.Item;
        internal int DropProb;

        public StealableItemsDialog()
        {
            InitializeComponent();

            cbEquip.RefreshList(false);
            cbItems.RefreshList(false);
        }

        private void nudProb_ValueChanged(object sender, EventArgs e)
        {
            if (nudProb.Value != barProb.Value)
            {
                barProb.Value = (int)nudProb.Value;
            }
        }

        private void barProb_ValueChanged(object sender, decimal value)
        {
            if (value != nudProb.Value)
            {
                nudProb.Value = value;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {

            if (rbEquipment.Checked)
            {
                ItemID = cbEquip.Data().ID;
                type = ItemType.Equipment;
            }
            else
            {
                ItemID = cbItems.Data().ID;
                type = ItemType.Item;
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
            switch (data.StealType)
            {
                case ItemType.Item:
                    rbItem.Checked = true;
                    rbEquipment.Checked = false;
                    cbItems.Select(data.Steal);
                    break;
                case ItemType.Equipment:
                    rbItem.Checked = false;
                    rbEquipment.Checked = true;
                    cbEquip.Select(data.Steal);
                    break;
            }
            nudProb.Value = (decimal)data.StealProbality;
        }
    }
}
