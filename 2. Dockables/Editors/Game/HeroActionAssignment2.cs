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
    public partial class HeroActionAssignment2 : Form
    {
        public Dictionary<int,int> Actions;
        bool allowChange = true;

        public HeroActionAssignment2()
        {
            InitializeComponent();
        }

        public void Setup(SkillData data)
        {
            addRemoveList.SetupList(GameData.Heroes, typeof(HeroData));

            if (addRemoveList.Count > 0)
            {
                // Add Actions
                Actions = new Dictionary<int, int>(data.HeroActions);
            }
        }
        public void Setup(ItemData data)
        {
            addRemoveList.SetupList(GameData.Heroes, typeof(HeroData));

            if (addRemoveList.Count > 0)
            {
                // Add Actions
                Actions = new Dictionary<int, int>(data.HeroActions);
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

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (cbAction.Data().ID > -1)
            {
                if (Actions.ContainsKey(addRemoveList.Data().ID))
                {
                    Actions[addRemoveList.Data().ID] = cbAction.Data().ID;
                }
                else
                {
                    Actions.Add(addRemoveList.Data().ID, - 1);
                }
            }
            else
            {
                Actions[addRemoveList.Data().ID] = -1;
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            if (addRemoveList.Data().ID > -1)
            {
                allowChange = false; 
                AnimationData animation = Global.GetData<AnimationData>(addRemoveList.Data<HeroData>().AnimationID, GameData.Animations);
                cbAction.RefreshList(false, animation);
                if (!Actions.ContainsKey(addRemoveList.Data().ID))
                {
                    Actions.Add(addRemoveList.Data().ID, -1);
                }
                int actionID = Actions[addRemoveList.Data().ID];
                allowChange = true;
                cbAction.Select(actionID);
                allowChange = true;
            }
            else
            {
                cbAction.Items.Clear();
            }
        }
    }
}
