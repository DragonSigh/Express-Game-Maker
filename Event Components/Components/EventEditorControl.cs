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
using GenericUndoRedo;

namespace EGMGame.Controls
{
    public partial class EventEditorControl : UserControl
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

        public UndoRedoHistory<IHistory> SelectedHistory
        {
            set { eventPage.SelectedHistory = value; }
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

        public EventEditorControl()
        {
            InitializeComponent();
            toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
        }

        public void SetupEditor()
        {
            pageList.Items.Clear();
            eventPage.behaviorProgramListBox1.Clear();
            if (SelectedEvent != null)
            {
                eventPage.SelectedHistory = MainForm.EventHistory[MainForm.eventEditor];
                foreach (EventPageData page in SelectedEvent.Pages)
                {
                    pageList.Items.Add(page.Name);
                }
                if (selEvent.SelectedPage == -1 && pageList.Items.Count > 0)
                    selEvent.SelectedPage = 0;
                if (selEvent.SelectedPage >= pageList.Items.Count)
                    selEvent.SelectedPage = pageList.Items.Count - 1;
                pageList.SelectedIndex = selEvent.SelectedPage;
                lblTP.Text = pageList.Items.Count.ToString();
                lblcp.Text = (pageList.SelectedIndex+ 1).ToString() ;
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
            MainForm.EventHistory[(EventEditor)this.Parent].Do(new EventPageAddedHist(page, SelectedEvent.Pages, this, index));
            TabPage p = new TabPage(page.Name);
            // Add TabPage
            pageList.Items.Add(page.Name);
            pageList.SelectedIndex = pageList.Items.Count - 1;
            lblTP.Text = pageList.Items.Count.ToString();
            lblcp.Text = (pageList.SelectedIndex+ 1).ToString() ;
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
                    lblcp.Text = (pageList.SelectedIndex+ 1).ToString() ;
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
                lblcp.Text = (pageList.SelectedIndex+ 1).ToString() ;
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
                lblcp.Text = (pageList.SelectedIndex+ 1).ToString() ;
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
                lblTP.Text = pageList.Items.Count.ToString();
                lblcp.Text = (pageList.SelectedIndex+ 1).ToString() ;
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
            lblcp.Text = (pageList.SelectedIndex+ 1).ToString() ;

        }

        private void syncBtn_Click(object sender, EventArgs c)
        {
            try
            {
                DialogResult d = MessageBox.Show("This command will OVERRIDE all events created from using this template event. There is NO UNDO. Are you sure?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                EventData ev = SelectedEvent;
                if (d == DialogResult.Yes)
                {
                    // TODO
                    // IMPLEMENT LOAD REQUIRED MAP and CHANGE EVENTS and CACHE
                    // Loop Maps
                    foreach (MapData map in GameData.Maps.Values)
                    {
                        foreach (LayerData layer in map.Layers)
                        {
                            foreach (EventData e in layer.Events.Values)
                            {
                                if (e.TemplateID == SelectedEvent.ID)
                                {
                                    e.Name = ev.Name;


                                    e.Pages = new List<EventPageData>();
                                    foreach (EventPageData page in ev.Pages)
                                    {
                                        EventPageData n = new EventPageData();
                                        n.Enabled = true;
                                        n.ActionID = page.ActionID;
                                        n.TriggerConditions = page.TriggerConditions;
                                        n.AnimationID = page.AnimationID;

                                        foreach (EventProgramData a in page.Programs)
                                        {
                                            EventProgramData na = new EventProgramData();
                                            na.Branch = a.Branch;
                                            na.ProgramCategory = a.ProgramCategory;
                                            na.Programs = a.Programs;
                                            na.Code = a.Code;
                                            na.Enabled = a.Enabled;
                                            na.Expand = a.Expand;
                                            na.ID = a.ID;
                                            na.Name = a.Name;
                                            //na.TypeCode = a.TypeCode;
                                            na.Value = (object[])a.Value.Clone();
                                            n.Programs.Add(na);
                                        }

                                        foreach (EventProgramData m in page.MovementPrograms)
                                        {
                                            EventProgramData ma = new EventProgramData();
                                            ma.Branch = m.Branch;
                                            ma.ProgramCategory = m.ProgramCategory;
                                            ma.Programs = m.Programs;
                                            ma.Code = m.Code;
                                            ma.Enabled = m.Enabled;
                                            ma.Expand = m.Expand;
                                            ma.ID = m.ID;
                                            ma.Name = m.Name;
                                            //ma.TypeCode = m.TypeCode;
                                            ma.Value = (object[])m.Value.Clone();
                                            n.MovementPrograms.Add(ma);
                                        }

                                        e.Pages.Add(n);
                                    }
                                    e.Switches = new Dictionary<int, SwitchData>(e.Switches);
                                    e.Variables = new Dictionary<int, VariableData>(e.Variables);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Error.ShowLogError(e, "15x001");
            }
        }

        private void btnCopyToTemplate_Click(object sender, EventArgs e)
        {

        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (pageList.SelectedIndex > 0)
            {
                pageList.SelectedIndex -= 1;
            }
            lblcp.Text = (pageList.SelectedIndex+ 1).ToString() ;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageList.SelectedIndex + 1 < pageList.Items.Count)
            {
                pageList.SelectedIndex += 1;
            }
            lblcp.Text = (pageList.SelectedIndex+ 1).ToString() ;
        }

        internal void ResetProject()
        {
            eventPage.ResetProject();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.Redo();
        }

        private void btnLinktoParent_CheckedChanged(object sender, EventArgs e)
        {

        }


        internal void RefreshPage()
        {
            if (SelectedEvent != null && pageList.SelectedIndex < SelectedEvent.Pages.Count) SetupTabPage(SelectedEvent.Pages[pageList.SelectedIndex]);
        }
    }
}
