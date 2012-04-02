using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Docking.Editors;

namespace EGMGame.Controls.EventControls
{
    public partial class GlobalEventPage : UserControl
    {
        public GlobalEventData SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; SetupEditor(); }
        }
        GlobalEventData selEvent;

        public int SelectedIndex
        {
            get { return pageList.SelectedIndex; }
            set { pageList.SelectedIndex = value; }
        }

        public EventPageData SelectedPage
        {
            get
            {
                if (SelectedEvent.Pages.Count > 0)
                    return SelectedEvent.Pages[pageList.SelectedIndex];
                return null;
            }
        }

        public GlobalEventPage()
        {
            InitializeComponent();
            toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
        }

        public void SetupEditor()
        {
            pageList.Items.Clear();
            if (SelectedEvent != null)
            {
                foreach (EventPageData page in SelectedEvent.Pages)
                {
                    pageList.Items.Add(page.Name);
                }
                if (selEvent.SelectedPage >= pageList.Items.Count)
                    selEvent.SelectedPage = pageList.Items.Count - 1;
                if (selEvent.SelectedPage == -1 && SelectedEvent.Pages.Count > 0)
                    selEvent.SelectedPage = 0;
                pageList.SelectedIndex = selEvent.SelectedPage;
            }
            else
            {
                eventPage.SelectedEvent = null;
                eventPage.SelectedEventPage = null;
            }
        }

        private void SetupTabPage(EventPageData data)
        {
            eventPage.SelectedEvent = SelectedEvent;
            eventPage.SelectedEventPage = data;
            eventPage.Enabled = true;
            selEvent.SelectedPage = pageList.SelectedIndex;
        }

        private void EventEditorControl_Load(object sender, EventArgs e)
        {
        }

        internal void newBtn_Click(object sender, EventArgs e)
        {
            EventPageData page = new EventPageData();
            page.Enabled = true;
            page.Name = Global.GetName("Page", SelectedEvent.Pages);
            page.ID = Global.GetID(SelectedEvent.Pages);
            SelectedEvent.Pages.Add(page);

            int index = SelectedEvent.Pages.IndexOf(page);
            // History
            //MainForm.GlobalEventHistory[(GlobalEventEditor)this.Parent].Do(new EventPageAddedHist(page, SelectedEvent.Pages, this, index));
            //TabPage p = new TabPage(page.Name);
            // Add TabPage
            pageList.Items.Add(page.Name);
            pageList.SelectedIndex = pageList.Items.Count - 1;
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {

        }

        private void cutBtn_Click(object sender, EventArgs e)
        {

        }

        private void pasteBtn_Click(object sender, EventArgs e)
        {

        }

        private void leftBtn_Click(object sender, EventArgs e)
        {
            if (SelectedPage != null && pageList.SelectedIndex > 0)
            {
                EventPageData page = SelectedEvent.Pages[pageList.SelectedIndex];
                int index = pageList.SelectedIndex;
                SelectedEvent.Pages.Remove(page);
                SelectedEvent.Pages.Insert(index - 1, page);
                SetupEditor();
                pageList.SelectedIndex = index - 1;
            }
        }

        private void rightBtn_Click(object sender, EventArgs e)
        {
            if (SelectedPage != null && pageList.SelectedIndex < SelectedEvent.Pages.Count - 1)
            {
                EventPageData page = SelectedEvent.Pages[pageList.SelectedIndex];
                int index = pageList.SelectedIndex;
                SelectedEvent.Pages.Remove(page);
                SelectedEvent.Pages.Insert(index + 1, page);
                SetupEditor();
                pageList.SelectedIndex = index + 1;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (pageList.SelectedIndex > -1)
            {
                // Get Index
                int index = pageList.SelectedIndex;
                // Get Event Page
                EventPageData page = SelectedEvent.Pages[index];
                // History
                MainForm.EventHistory[(EventEditor)this.Parent].Do(new EventPageRemovedHist(page, SelectedEvent.Pages, this, index));
                // Delete it
                SelectedEvent.Pages.RemoveAt(index);
                // Delete the Tab Page
                pageList.Items.RemoveAt(index);
                // Select Next
                if (index > 1)
                    pageList.SelectedIndex = index - 1;
                else if (pageList.Items.Count > 0)
                    pageList.SelectedIndex = 0;
                else
                {
                    eventPage.Enabled = false;
                    pageList.SelectedIndex = -1;
                }
            }
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {

        }

        private void pageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageList.SelectedIndex > -1)
            {
                SetupTabPage(SelectedEvent.Pages[pageList.SelectedIndex]);
            }
            else
            {
                eventPage.Enabled = false;
            }

        }

        internal void RefreshPage()
        {
            if (SelectedEvent != null && pageList.SelectedIndex < SelectedEvent.Pages.Count) SetupTabPage(SelectedEvent.Pages[pageList.SelectedIndex]);
        }
    }
}
