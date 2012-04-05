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

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class MoveTowardEvent : Form
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
            set { programs = value;  }
        }
        List<EventProgramData> programs;


        List<EventData> events = new List<EventData>();

        public MoveTowardEvent()
        {
            InitializeComponent();
            pixelBox.Value = (decimal)Global.Project.DefaultPixel;
            cbType.SelectedIndex = 0;
        }

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Movement;
            action.Code = 4;
            //action.TypeCode = 1;
            action.Value[0] = new List<int>();
            eventsList.Items.Clear();
            events.Clear();
            // Add all the events on the map
            if (selectedEvent.MapID > -1)
            {
                // Add only player
                eventsList.Items.Add(GameData.Player.Name, ((List<int>)action.Value[0]).Contains(-1));
                events.Add(GameData.Player);
                foreach (LayerData layer in GameData.Maps[selectedEvent.MapID].Layers)
                {
                    foreach (EventData ev in layer.Events.Values)
                    {
                        eventsList.Items.Add(ev.Name, ((List<int>)action.Value[0]).Contains(ev.ID));
                        events.Add(ev);
                    }
                }
            }
            else
            {
                // Add only player
                eventsList.Items.Add(GameData.Player.Name,((List<int>)action.Value[0]).Contains(-1));
                events.Add(GameData.Player);
            }
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

            pixelBox.Value = (decimal)(float)action.Value[1];
            turnBox.Checked = (bool)action.Value[2];
            chWait.Checked = (bool)action.Value[4];
            chImpulse.Checked = (bool)action.Value[5];

            eventsList.Items.Clear();
            events.Clear();
            // Add all the events on the map
            if (selectedEvent.MapID > -1)
            {
                // Add only player
                eventsList.Items.Add(GameData.Player.Name, ((List<int>)action.Value[0]).Contains(-1));
                events.Add(GameData.Player);
                foreach (LayerData layer in GameData.Maps[selectedEvent.MapID].Layers)
                {
                    foreach (EventData ev in layer.Events.Values)
                    {
                        eventsList.Items.Add(ev.Name, ((List<int>)action.Value[0]).Contains(ev.ID));
                        events.Add(ev);
                    }
                }
            }
            else
            {
                // Add only player
                eventsList.Items.Add(GameData.Player.Name, ((List<int>)action.Value[0]).Contains(-1));
                events.Add(GameData.Player);
            }

            // Direction
            List<int> dir = new List<int>((List<int>)action.Value[3]);
            upBtn.Checked = dir.Contains(0);
            downBtn.Checked = dir.Contains(1);
            leftBtn.Checked = dir.Contains(2);
            rightBtn.Checked = dir.Contains(3);
            upLeftBtn.Checked = dir.Contains(4);
            upRightBtn.Checked = dir.Contains(5);
            downLeftBtn.Checked = dir.Contains(6);
            downRightBtn.Checked = dir.Contains(7);

            cbType.SelectedIndex = (int)action.Value[6];
        }


        private void okBtn_Click(object sender, EventArgs e)
        {
            // Save Data
            List<int> list = new List<int>();
            for (int i = 0; i < eventsList.Items.Count; i++ )
            {
                if (eventsList.CheckedItems.Contains(eventsList.Items[i]))
                {
                    list.Add(events[i].ID);
                }
            }
            if (list.Count == 0)
            { this.Close(); }
            action.Value[0] = list;
            action.Value[1] = (float)pixelBox.Value;
            action.Value[2] = turnBox.Checked;
            List<int> dir = new List<int>();
            if (upBtn.Checked)
                dir.Add(0);
            if (downBtn.Checked)
                dir.Add(1);
            if (leftBtn.Checked)
                dir.Add(2);
            if (rightBtn.Checked)
                dir.Add(3);
            if (upLeftBtn.Checked)
                dir.Add(4);
            if (upRightBtn.Checked)
                dir.Add(5);
            if (downLeftBtn.Checked)
                dir.Add(6);
            if (downRightBtn.Checked)
                dir.Add(7);
            action.Value[3] = dir;
            action.Value[4] = chWait.Checked;
            action.Value[5] = chImpulse.Checked;
            action.Value[6] = cbType.SelectedIndex;
            action.Name = "Move Toward Events";
            // Close
            this.DialogResult = DialogResult.OK;
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

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
