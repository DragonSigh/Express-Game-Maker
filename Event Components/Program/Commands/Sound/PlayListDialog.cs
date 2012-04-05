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

namespace EGMGame
{
    public partial class PlayListDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; }
        }
        IEvent selectedEvent;
        public EventPageData SelectedPage
        {
            get { return page; }
            set { page = value; Setup(); }
        }
        EventPageData page;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { action = value; SetupAction(value); }
        }
        EventProgramData action;
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayListDialog()
        {
            InitializeComponent();
            this.toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
            // Setup Sound Effects
            SetupSoundEffects();
        }
        /// <summary>
        /// Setup Sound Effects
        /// </summary>
        private void SetupSoundEffects()
        {
            // Clear List
            seList.SetupList(GameData.Audios, typeof(AudioData));

            if (seList.Count > 0)
            {
                impactGroupBox1.Enabled = true;
                playListBox.Enabled = true;
                seList.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Audio;
            action.Code = 3;
            //action.TypeCode = 1;
            action.Value[0] = new List<int>();
        }
        /// <summary>
        /// Setup action
        /// </summary>
        /// <param name="a"></param>
        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Setup Data
            List<int> list = new List<int>((List<int>)action.Value[0]);
            AudioData audio;

            foreach (int id in list)
            {
                if (GameData.Audios.TryGetValue(id, out audio))
                {
                    TreeNode node = new TreeNode(audio.Name);
                    node.Tag = id;
                    playList.Nodes.Add(node);
                }
                else
                {
                    ((List<int>)action.Value[0]).Remove(id);
                }
            }

            numberBox.Value = (decimal)(int)action.Value[1];

            loopBtn.Checked = (bool)action.Value[2];
        }
        /// <summary>
        /// Close Dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (playList.Nodes.Count > 0)
            {
                AudioData audio;
                // Assign Values
                List<int> list = new List<int>();
                foreach (TreeNode node in playList.Nodes)
                {
                    if (GameData.Audios.TryGetValue((int)node.Tag, out audio))
                    {
                        list.Add(audio.ID);
                    }
                }
                action.Value[0] = list;
                action.Value[1] = (int)numberBox.Value;
                action.Value[2] = loopBtn.Checked;
                action.Name = "Create Playlist: " + numberBox.Value.ToString() + " Loop: " + loopBtn.Checked.ToString();
                // Close
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
        /// <summary>
        /// Cancel Dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Drag Over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playList_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (seList.SelectedNode == node)
                    e.Effect = DragDropEffects.All;
            }
        }
        /// <summary>
        /// Drag Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (seList.SelectedNode == node)
                {
                    TreeNode clone = (TreeNode)node.Clone();

                    playList.Nodes.Add(clone);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "40x001");
            }
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (playList.SelectedNode != null)
                playList.SelectedNode.Remove();
        }
        /// <summary>
        /// Move Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (playList.SelectedNode != null && playList.SelectedNode.Index > 0)
            {
                int index = playList.SelectedNode.Index - 1;
                TreeNode node = playList.SelectedNode;
                playList.SelectedNode.Remove();
                playList.Nodes.Insert(index, node);
                playList.SelectedNode = node;
            }
        }
        /// <summary>
        /// Move Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveDownBtn_Click(object sender, EventArgs e)
        {
            if (playList.SelectedNode != null && playList.SelectedNode.Index < playList.Nodes.Count - 1)
            {
                int index = playList.SelectedNode.Index + 1;
                TreeNode node = playList.SelectedNode;
                playList.SelectedNode.Remove();
                playList.Nodes.Insert(index, node);
                playList.SelectedNode = node;
            }
        }
    }
}

