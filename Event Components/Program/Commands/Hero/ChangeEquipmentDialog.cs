﻿//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.HeroDialogs
{
    public partial class ChangeEquipmentDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
           set { selectedEvent = value; if (action == null ) Setup(); }
        }
        IEvent selectedEvent;
        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; }
        }
        EventPageData selectedPage;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;
        /// <summary>
        /// Consturctor
        /// </summary>
        public ChangeEquipmentDialog()
        {
            InitializeComponent();

            cbHero.RefreshList(false);

            ItemTag tag;
            foreach (KeyValuePair<int, string> slot in Global.Project.EquipmentSlots)
            {
                tag = new ItemTag(slot.Key, slot.Value);
                listSlots.Items.Add(tag);
            }

            if (listSlots.Items.Count > 0)
                listSlots.SelectedIndex = 0;
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            if (SelectedPage == null)
                action.ID = Global.GetProgramID(Programs);
            else
                action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Hero;
            action.Code = 2;
        }

        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            chkFromInvent.Checked = (bool)action.Value[3];
            cbHero.Select((int)action.Value[0]);

            int i = 0;
            foreach (ItemTag tag in listSlots.Items)
            {
                if (tag.ID == (int)action.Value[1])
                {
                    listSlots.SelectedIndex = i;
                    break;
                }
                i++;
            }

            cbDefaultEquip.Select((int)action.Value[2]);
        }

        private void listSlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSlots.SelectedIndex > -1)
            {
                cbDefaultEquip.RefreshList(false, ((ItemTag)listSlots.SelectedItem).ID);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            if (cbHero.Data().ID > -1)
            {
                action.Value[0] = cbHero.Data().ID;
                action.Value[1] = ((ItemTag)listSlots.SelectedItem).ID;
                action.Value[2] = cbDefaultEquip.Data().ID;
                action.Value[3] = chkFromInvent.Checked;

                action.GetName(selectedEvent, selectedPage);
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
    }
}
