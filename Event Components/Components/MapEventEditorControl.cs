//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Controls.EventControls;
using EGMGame.Docking.Editors;

namespace EGMGame.Controls
{
    public partial class MapEventEditorControl : UserControl
    {
        public EventData SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; SetupEditor(); }
        }
        EventData selEvent;

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

        public MapEventEditorControl()
        {
            InitializeComponent();
            toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
        }

        public void SetupEditor()
        {
            try
            {
                pageList.Items.Clear();
                if (SelectedEvent != null)
                {
                    eventPage.SelectedHistory = MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer];
                    txtName.Text = SelectedEvent.Name;
                    if (SelectedEvent.LinkToParent)
                    {
                        LinkToParent(SelectedEvent.LinkToParent);
                    }
                    else
                    {
                        foreach (EventPageData page in SelectedEvent.Pages)
                        {
                            pageList.Items.Add(page.Name);
                        }
                        if (selEvent.SelectedPage == -1 && pageList.Items.Count > 0)
                            selEvent.SelectedPage = 0;
                        pageList.SelectedIndex = selEvent.SelectedPage;
                        lblTP.Text = pageList.Items.Count.ToString();
                        lblcp.Text = (pageList.SelectedIndex + 1).ToString();

                    }
                    if (SelectedEvent.MapID > -1)
                    { btnOpenTemplate.Visible = btnLinktoParent.Visible = true; }
                    else
                    { btnOpenTemplate.Visible = btnLinktoParent.Visible = false; }

                    if (SelectedEvent.TemplateID > -1 && SelectedEvent.MapID > -1)
                        btnOpenTemplate.Enabled = btnLinktoParent.Enabled = true;
                    else
                        btnOpenTemplate.Enabled = btnLinktoParent.Enabled = false;

                    btnLinktoParent.Checked = SelectedEvent.LinkToParent;
                }
                else
                    txtName.Clear();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "27x001");
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
            //MainForm.EventHistory[(EventEditor)this.Parent].Do(new EventPageAddedHist(page, SelectedEvent.Pages, this, index));
            // Add TabPage
            pageList.Items.Add(page.Name);
            pageList.SelectedIndex = pageList.Items.Count - 1;
            lblTP.Text = pageList.Items.Count.ToString();
            lblcp.Text = (pageList.SelectedIndex + 1).ToString();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            if (SelectedPage != null)
            {
                Global.Copy(SelectedPage);
            }
        }

        private void cutBtn_Click(object sender, EventArgs e)
        {
            if (SelectedPage != null)
            {
                Global.Copy(SelectedPage);
                deleteBtn_Click(null, null);
            }
        }

        private void pasteBtn_Click(object sender, EventArgs e)
        {
            if (SelectedEvent != null)
            {
                object obj = Global.PasteData();
                if (obj != null && obj is EventPageData)
                {
                    EventPageData page = (EventPageData)obj;
                    page.Name = Global.GetName("Page", SelectedEvent.Pages);
                    page.ID = Global.GetID(SelectedEvent.Pages);
                    SelectedEvent.Pages.Add(page);

                    int index = SelectedEvent.Pages.IndexOf(page);
                    // History
                    //MainForm.EventHistory[(EventEditor)this.Parent].Do(new EventPageAddedHist(page, SelectedEvent.Pages, this, index));
                    // Add TabPage
                    pageList.Items.Add(page.Name);
                    pageList.SelectedIndex = pageList.Items.Count - 1;
                    lblTP.Text = pageList.Items.Count.ToString();
                    lblcp.Text = (pageList.SelectedIndex + 1).ToString();
                }
            }
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
                lblcp.Text = (pageList.SelectedIndex + 1).ToString();
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
                lblcp.Text = (pageList.SelectedIndex + 1).ToString();
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
                //MainForm.EventHistory[(EventEditor)this.Parent].Do(new EventPageRemovedHist(page, SelectedEvent.Pages, this, index));
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
                lblTP.Text = pageList.Items.Count.ToString();
                lblcp.Text = (pageList.SelectedIndex + 1).ToString();
            }
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {

        }

        private void pageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageList.SelectedIndex > -1)
            {
                if (SelectedEvent.LinkToParent)
                {
                    EventData ev = Global.GetData<EventData>(SelectedEvent.TemplateID, GameData.Events);

                    if (ev != null)
                    {
                        SetupTabPage(ev.Pages[pageList.SelectedIndex]);
                    }
                }
                else
                    SetupTabPage(SelectedEvent.Pages[pageList.SelectedIndex]);
            }
            else
            {
                eventPage.Enabled = false;
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (selEvent != null)
            {
                selEvent.Name = txtName.Text;
                this.Parent.Text = selEvent.Name + " ID: " + selEvent.ID.ToString();
                MainForm.mapEventsExplorer.Setup();
            }
        }

        private void btnCopyToTemplate_Click(object sender, EventArgs e)
        {
            if (selEvent != null)
            {
                EventData data = Global.Duplicate<EventData>(selEvent);
                data.MapID = -1;
                data.ID = Global.GetID(GameData.Events);
                GameData.Events.Add(data.ID, data);
                MainForm.eventEditor.SetupList();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (pageList.SelectedIndex > 0)
            {
                pageList.SelectedIndex -= 1;
                lblcp.Text = (pageList.SelectedIndex + 1).ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageList.SelectedIndex < pageList.Items.Count - 1)
            {
                pageList.SelectedIndex += 1;
                lblcp.Text = (pageList.SelectedIndex + 1).ToString();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.Redo();
        }

        private void toolStripSeparator7_Click(object sender, EventArgs e)
        {

        }

        internal void RefreshList()
        {
            eventPage.RefreshList();
        }

        private void LinkToParent(bool link)
        {
            if (SelectedEvent != null)
            {
                if (link)
                {
                    this.Cursor = Cursors.No;
                    EventData ev = Global.GetData<EventData>(SelectedEvent.TemplateID, GameData.Events);
                    if (ev != null)
                    {
                        pageList.Items.Clear();
                        foreach (EventPageData page in ev.Pages)
                        {
                            pageList.Items.Add(page.Name);
                        }
                        if (ev.SelectedPage == -1 && pageList.Items.Count > 0)
                            ev.SelectedPage = 0;
                        pageList.SelectedIndex = ev.SelectedPage;
                        lblTP.Text = pageList.Items.Count.ToString();
                        lblcp.Text = (pageList.SelectedIndex + 1).ToString();
                        SetupTabPage(ev.Pages[pageList.SelectedIndex]);
                    }
                    pageList.Enabled = false;
                    btnNext.Enabled = false;
                    btnPrev.Enabled = false;
                    leftBtn.Enabled = false;
                    rightBtn.Enabled = false;
                    btnCopyToTemplate.Enabled = false;
                    newBtn.Enabled = false;
                    pasteBtn.Enabled = false;
                    cutBtn.Enabled = false;
                    deleteBtn.Enabled = false;
                    btnUndo.Enabled = false;
                    btnRedo.Enabled = false;
                    eventPage.Enabled = !link;
                    renameBtn.Enabled = false;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    pageList.Items.Clear();
                    foreach (EventPageData page in SelectedEvent.Pages)
                    {
                        pageList.Items.Add(page.Name);
                    }
                    if (selEvent.SelectedPage == -1 && pageList.Items.Count > 0)
                        selEvent.SelectedPage = 0;
                    pageList.SelectedIndex = selEvent.SelectedPage;
                    lblTP.Text = pageList.Items.Count.ToString();
                    lblcp.Text = (pageList.SelectedIndex + 1).ToString();
                    pageList.Enabled = true;
                    btnCopyToTemplate.Enabled = true;
                    btnNext.Enabled = true;
                    btnPrev.Enabled = true;
                    newBtn.Enabled = true;
                    pasteBtn.Enabled = true;
                    cutBtn.Enabled = true;
                    leftBtn.Enabled = true;
                    rightBtn.Enabled = true;
                    deleteBtn.Enabled = true;
                    eventPage.Enabled = !link;
                    btnUndo.Enabled = true;
                    btnRedo.Enabled = true;
                    renameBtn.Enabled = true;
                }
            }
            this.toolStrip1.Cursor = Cursors.Default;
        }

        private void btnLinktoParent_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedEvent != null)
            {
                SelectedEvent.LinkToParent = btnLinktoParent.Checked;
                LinkToParent(SelectedEvent.LinkToParent);
            }
        }

        private void btnOpenTemplate_Click(object sender, EventArgs e)
        {
            if (SelectedEvent != null && SelectedEvent.TemplateID > -1)
            {
                ((Form)this.Parent).Close();
                MainForm.eventEditor.Show();
                MainForm.eventEditor.SelectedEvent(SelectedEvent.TemplateID);
            }
        }

        internal void RefreshPage()
        {
            if (SelectedEvent != null && pageList.SelectedIndex < SelectedEvent.Pages.Count) SetupTabPage(SelectedEvent.Pages[pageList.SelectedIndex]);
        }
    }
}
