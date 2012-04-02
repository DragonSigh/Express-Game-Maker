﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Docking.Editors.Database
{
    public partial class MagicsSelector : Form
    {
        internal int Level = 1;
        internal int Skill = -1;
        public MagicsSelector()
        {
            InitializeComponent();

            listSkills.RefreshList(true, EGMGame.Library.SkillType.Magic);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Level = (int)nudLevel.Value;
            Skill = (int)listSkills.Data().ID;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void Setup(EGMGame.Library.SkillToLearn s)
        {
            Level = s.Level;
            Skill = s.ID;
            nudLevel.Value = Level;
            listSkills.Select(Skill);
        }
    }
}
