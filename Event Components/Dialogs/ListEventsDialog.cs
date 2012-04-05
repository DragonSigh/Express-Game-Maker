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

namespace EGMGame.Controls.EventControls.EventDialogs
{
    public partial class ListEventsDialog : Form
    {

        public EventData SelectedEvent;

        public EventPageData EventPage
        {
            get { return eventPage; }
            set
            {
                eventPage = value;
                touchEventIDs = new List<int>(EventPage.TouchEventIDs);
                touchTEventIDs = new List<int>(EventPage.TouchTemplateEventIDs); Setup();
            }
        }

        public List<int> TouchEventIDs
        {
            get { return touchEventIDs; }
        }
        List<int> touchEventIDs;


        public List<int> TouchTEventIDs
        {
            get { return touchTEventIDs; }
        }
        List<int> touchTEventIDs;

        internal void Setup()
        {
            listBox.Items.Clear();

            if (SelectedEvent.MapID > -1)
            {
                ItemTag tag;

                // Player
                tag = new ItemTag(-1, "Player");
                listBox.Items.Add(tag, touchEventIDs.Contains(-1));
                foreach (EventData e in Global.GetMapEventList(MainForm.SelectedMap))
                {
                    tag = new ItemTag(e.ID, e.Name);
                    listBox.Items.Add(tag, touchEventIDs.Contains(e.ID));
                }

                // Template Events
                foreach (EventData e in GameData.Events.Values)
                {
                    tag = new ItemTag(e.ID, e.Name);
                    listBox2.Items.Add(tag, touchTEventIDs.Contains(e.ID));
                }
            }
            else
            {
                ItemTag tag;

                // Player
                tag = new ItemTag(-1, "Player");
                listBox.Items.Add(tag, touchEventIDs.Contains(-1));

                // Template Events
                foreach (EventData e in GameData.Events.Values)
                {
                    tag = new ItemTag(e.ID, e.Name);
                    listBox2.Items.Add(tag, touchTEventIDs.Contains(e.ID));
                }
            }
        }
        EventPageData eventPage;
        public ListEventsDialog()
        {
            InitializeComponent();
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

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            List<int> tags = new List<int>();
            foreach (ItemTag tag in listBox.CheckedItems)
            {
                tags.Add(tag.ID);
            }

            touchEventIDs = tags;


            tags = new List<int>();
            foreach (ItemTag tag in listBox2.CheckedItems)
            {
                tags.Add(tag.ID);
            }

            touchTEventIDs = tags;

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
