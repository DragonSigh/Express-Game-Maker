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
    public partial class AnimationAssignment : Form
    {
        public int[] Actions;
        public AnimationData Animation;
        bool allowChange = false;

        public AnimationAssignment()
        {
            InitializeComponent();
        }

        internal void Setup(HeroData heroData)
        {
            Actions =(int[])heroData.Actions.Clone();

            if (GameData.Animations.TryGetValue(heroData.AnimationID, out Animation))
            {
                allowChange = false;
                cbAction.RefreshList(false, Animation);
                listTypes.SelectedIndex = 0;
                allowChange = true;
            }
        }

        internal void Setup(EnemyData heroData)
        {
            Actions = (int[])heroData.Actions.Clone();

            if (GameData.Animations.TryGetValue(heroData.AnimationID, out Animation))
            {
                allowChange = false;
                cbAction.RefreshList(false, Animation);
                listTypes.SelectedIndex = 0;
                allowChange = true;
            }
        }

        private void listTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Animation == null) return;
            List<int> list = Actions.ToList();
            Actions = list.ToArray();
            cbAction.Select(Actions[listTypes.SelectedIndex]);
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange || Animation == null) return;
            Actions[listTypes.SelectedIndex] = cbAction.Data().ID;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
