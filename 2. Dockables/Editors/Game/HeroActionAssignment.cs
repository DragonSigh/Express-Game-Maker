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
    public partial class HeroActionAssignment : Form
    {
        public Dictionary<int, List<int>> Actions;
        bool allowChange = true;
        public HeroActionAssignment()
        {
            InitializeComponent();
        }

        public void Setup(EquipmentData data)
        {
            addRemoveList.SetupList(GameData.Heroes, typeof(HeroData));

            if (addRemoveList.Count > 0)
            {
                // Add Actions
                Actions = new Dictionary<int, List<int>>(data.HeroActions);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (Actions != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void addMagicBtn_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1)
            {
                Actions[addRemoveList.Data().ID].Add(-1);
                listBox.Items.Add("Action " + Actions[addRemoveList.Data().ID].Count.ToString());
            }
        }

        private void removeMagicBtn_Click(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1 && listBox.SelectedIndex > 0)
            {
                Actions[addRemoveList.Data().ID].RemoveAt(listBox.SelectedIndex);

                int index = listBox.SelectedIndex;
                listBox.Items.RemoveAt(listBox.SelectedIndex);

                listBox.Items.Clear();
                for (int i = 0; i < Actions[addRemoveList.Data().ID].Count; i++)
                {
                    listBox.Items.Add("Action " + (i + 1).ToString());
                }

                listBox.SelectedIndex = index - 1;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addRemoveList.Data().ID > -1 && listBox.SelectedIndex > -1)
            {
                AnimationData animation = Global.GetData<AnimationData>(addRemoveList.Data<HeroData>().AnimationID, GameData.Animations);
                allowChange = false;
                cbAction.RefreshList(false, animation);
                int actionID = Actions[addRemoveList.Data().ID][listBox.SelectedIndex];
                allowChange = true;
                cbAction.Select(actionID);
            }
            else
            {
                cbAction.Items.Clear();
            }
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (cbAction.Data().ID > -1)
            {
                if (Actions.ContainsKey(addRemoveList.Data().ID))
                {
                    Actions[addRemoveList.Data().ID][listBox.SelectedIndex] = cbAction.Data().ID;
                }
                else
                {
                    Actions.Add(addRemoveList.Data().ID, new List<int>() { cbAction.Data().ID });
                }
            }
            else
            {
                Actions[addRemoveList.Data().ID][listBox.SelectedIndex] = -1;
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (addRemoveList.Data().ID > -1)
            {
                allowChange = false;
                if (!Actions.ContainsKey(addRemoveList.Data().ID))
                {
                    Actions.Add(addRemoveList.Data().ID, new List<int>() { -1 });
                }

                listBox.Items.Clear();

                for (int i = 0; i < Actions[addRemoveList.Data().ID].Count; i++)
                {
                    listBox.Items.Add("Action " + (i + 1).ToString());
                }
                allowChange = true;
                listBox.SelectedIndex = 0;
            }
            else
            {
                cbAction.Items.Clear();
                listBox.Items.Clear();
            }
        }
    }
}
