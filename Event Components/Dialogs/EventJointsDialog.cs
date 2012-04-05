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
using Microsoft.Xna.Framework;
using GenericUndoRedo;
using EGMGame.Docking.Editors;

namespace EGMGame.Controls.EventControls
{
    public partial class EventJointsDialog : Form
    {
        bool allowChange = false;

        EventPageData Page;
        List<Dictionary<string, float>> JointSettings;

        public EventJointsDialog()
        {
            InitializeComponent();

            cbEvents.RefreshList(false);
            cbJoints.SelectedIndex = 0;

            allowChange = true;
        }

        public void Setup(EventPageData page)
        {
            Page = page;

            //settings = Global.Duplicate<List<Dictionary<string, float>>>(Page.JointSettings);


        }


        private void okBtn_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
