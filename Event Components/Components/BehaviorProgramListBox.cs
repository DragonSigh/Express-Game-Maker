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
using EGMGame.Controls.EventControls.EventDialogs;
using System.Media;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs;
using EGMGame.EventControls.EventDialogs.CommandDialogs.DisplayDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.DisplayDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Picture;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.ConditionDialogs;
using EGMGame.EventControls.EventDialogs.CommandDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.DataDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.EventDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Screen_Dialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.PartyDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.HeroDialogs;
using GenericUndoRedo;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.OtherDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.SoundDialogs;

namespace EGMGame.Controls.EventControls
{
    public partial class BehaviorProgramListBox : UserControl, IEditor
    {

        [Browsable(false)]
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; }
        }
        IEvent selectedEvent;

        [Browsable(false)]
        public EventPageData SelectedPage
        {
            get { return page; }
            set
            {
                page = value;
                Setup(); ;
            }
        }
        EventPageData page;
        private void CopyPage(EventPageData value)
        {
            if (value != null)
            {
                EventProgramData action;
                foreach (EventProgramData pData in value.Programs)
                {
                    action = new EventProgramData();
                    action.ID = pData.ID;
                    action.Name = pData.Name;
                    action.ProgramCategory = pData.ProgramCategory;
                    action.Code = pData.Code;
                    //action.TypeCode = pData.TypeCode;
                    action.Value = (object[])pData.Value.Clone();
                    action.Enabled = pData.Enabled;
                    programs.Add(action);
                    CloneChildPrograms(pData, action);
                }
            }
            Setup();
        }
        private void CloneChildPrograms(EventProgramData parent, EventProgramData clone)
        {
            EventProgramData action;
            foreach (EventProgramData pData in parent.Programs)
            {
                action = new EventProgramData();
                action.ID = pData.ID;
                action.Name = pData.Name;
                action.ProgramCategory = pData.ProgramCategory;
                action.Code = pData.Code;
                //action.TypeCode = pData.TypeCode;
                action.Value = (object[])pData.Value.Clone();
                action.Enabled = pData.Enabled;
                clone.Programs.Add(action);
                CloneChildPrograms(pData, action);
            }

            foreach (EventProgramData pData in parent.ElsePrograms)
            {
                action = new EventProgramData();
                action.ID = pData.ID;
                action.Name = pData.Name;
                action.ProgramCategory = pData.ProgramCategory;
                action.Code = pData.Code;
                //action.TypeCode = pData.TypeCode;
                action.Value = (object[])pData.Value.Clone();
                action.Enabled = pData.Enabled;
                clone.ElsePrograms.Add(action);
                CloneChildPrograms(pData, action);
            }
        }


        [Browsable(false)]
        public EventProgramData SelectedAction
        {
            get { return selectedAction; }
            set { selectedAction = value; }
        }
        EventProgramData selectedAction;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; }
        }
        List<EventProgramData> programs = new List<EventProgramData>();

        public UndoRedoHistory<IHistory> SelectedHistory;

        TreeNode previousNode;


        public BehaviorProgramListBox()
        {
            InitializeComponent();
        }

        internal void Clear()
        {
            list.Nodes.Clear();
        }

        private void PropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            if (data == SelectedPage)
            {
                Setup();
            }
            else if (data is EventProgramData)
            {
                Setup();
            }
        }

        internal void Setup()
        {
            if (SelectedPage != null)
            {
                if (list.SelectedNode != null && list.SelectedNode.Tag != null && list.SelectedNode.Tag is EventProgramData)
                {
                    selectedAction = (EventProgramData)list.SelectedNode.Tag;
                }
                list.Nodes.Clear();
                Programs = SelectedPage.Programs;
                foreach (EventProgramData action in Programs)
                {
                    TreeNode node = new TreeNode(action.GetName(selectedEvent, SelectedPage));
                    node.Tag = action;
                    node.Checked = action.Enabled;
                    ColorNode(node, action);
                    list.Nodes.Add(node);
                    if (action.Expand)
                        node.Expand();
                    if (PopulateList(action, node))
                    {
                        EndBranch(action, list.Nodes);
                    }
                    if (action.Else)
                    {
                        node = new TreeNode("Else");
                        node.Tag = action;
                        node.ForeColor = Color.Blue;
                        node.Checked = action.Enabled;
                        list.Nodes.Add(node);
                        if (PopulateElseList(action, node))
                        {
                            EndBranch(action, list.Nodes);
                        }
                    }
                    else if (action.ProgramCategory == ProgramCategory.Movement && action.Code == 10)
                    {
                        // Program Dynamics
                        List<EventProgramData> dynamics = (List<EventProgramData>)action.Value[4];
                        TreeNode dNode;
                        foreach (EventProgramData dynamic in dynamics)
                        {
                            dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                            dNode.Tag = action;
                            dNode.ForeColor = node.ForeColor;
                            dNode.Checked = dynamic.Enabled;
                            node.Nodes.Add(dNode);
                        }
                        if (action.Expand)
                            node.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 1)
                    {
                        // Program Display - Message
                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] texts;
                        texts = ((string)action.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                        TreeNode dNode;
                        for (int i = 0; i < texts.Length; i++)
                        {
                            dNode = new TreeNode(texts[i]);
                            dNode.Tag = action;
                            dNode.ForeColor = node.ForeColor;
                            dNode.Checked = false;
                            node.Nodes.Add(dNode);
                        }
                        if (action.Expand)
                            node.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 14)
                    {
                        // Program Display - Options
                        List<object> options = (List<object>)action.Value[0];
                        TreeNode dNode;
                        string text;
                        for (int i = 0; i < options.Count; i++)
                        {
                            if (options[i] is int)
                            {
                                text = "Text [" + options[i].ToString() + "]";
                            }
                            else
                                text = options[i].ToString();
                            dNode = new TreeNode(options[i].ToString());
                            dNode.Tag = action;
                            dNode.ForeColor = node.ForeColor;
                            dNode.Checked = false;
                            node.Nodes.Add(dNode);
                        }
                        if (action.Expand)
                            node.Expand();
                    }
                    if (action == selectedAction)
                        list.SelectedNode = node;
                }

                TreeNode n = new TreeNode("...");
                list.Nodes.Add(n);
            }
            if (programs != null && Programs.Count > 0 && list.SelectedNode == null)
                list.SelectedNode = list.Nodes[0];
        }

        private bool PopulateElseList(EventProgramData pAction, TreeNode pNode)
        {
            bool parent = pAction.Branch;
            foreach (EventProgramData action in pAction.ElsePrograms)
            {
                TreeNode node = new TreeNode(action.GetName(selectedEvent, SelectedPage));
                node.Tag = action;
                node.Checked = action.Enabled;
                ColorNode(node, action);
                pNode.Nodes.Add(node);
                if (action.Expand)
                    node.Expand();
                if (action == SelectedAction)
                    list.SelectedNode = node;
                if (PopulateList(action, node))
                {
                    EndBranch(action, pNode.Nodes);
                }
                if (action.Else)
                {
                    node = new TreeNode("Else");
                    node.Tag = action;
                    node.ForeColor = Color.Blue;
                    node.Checked = action.Enabled;
                    pNode.Nodes.Add(node);
                    if (PopulateElseList(action, node))
                    {
                        EndBranch(action, list.Nodes);
                    }
                }
                else if (action.ProgramCategory == ProgramCategory.Movement && action.Code == 10)
                {
                    // Program Dynamics
                    List<EventProgramData> dynamics = (List<EventProgramData>)action.Value[4];
                    TreeNode dNode;
                    foreach (EventProgramData dynamic in dynamics)
                    {
                        dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                        dNode.Tag = action;
                        dNode.ForeColor = node.ForeColor;
                        dNode.Checked = dynamic.Enabled;
                        node.Nodes.Add(dNode);
                    }
                    if (action.Expand)
                        node.Expand();
                }
                else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 1)
                {
                    // Program Display - Message
                    char[] delimiters = new char[] { '\r', '\n' };
                    string[] texts = ((string)action.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                    string text = action.Value[1].ToString();
                    TreeNode dNode;
                    for (int i = 0; i < texts.Length; i++)
                    {
                        dNode = new TreeNode(texts[i]);
                        dNode.Tag = action;
                        dNode.ForeColor = node.ForeColor;
                        dNode.Checked = false;
                        node.Nodes.Add(dNode);
                    }
                    if (action.Expand)
                        node.Expand();
                }
                else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 14)
                {
                    // Program Display - Options
                    List<object> options = (List<object>)action.Value[0];
                    TreeNode dNode;
                    string text;
                    for (int i = 0; i < options.Count; i++)
                    {
                        if (options[i] is int)
                        {
                            text = "Text [" + options[i].ToString() + "]";
                        }
                        else
                            text = options[i].ToString();
                        dNode = new TreeNode(options[i].ToString());
                        dNode.Tag = action;
                        dNode.ForeColor = node.ForeColor;
                        dNode.Checked = false;
                        node.Nodes.Add(dNode);
                    }
                    if (action.Expand)
                        node.Expand();
                }
                if (action == selectedAction)
                    list.SelectedNode = node;
                parent = true;
            }
            if (parent)
            {
                TreeNode node = new TreeNode("...");
                node.Tag = pAction;
                pNode.Nodes.Add(node);
                if (pAction.Expand)
                    pNode.Expand();
            }
            return parent;
        }

        private bool PopulateList(EventProgramData pAction, TreeNode pNode)
        {
            bool parent = pAction.Branch;
            foreach (EventProgramData action in pAction.Programs)
            {
                TreeNode node = new TreeNode(action.GetName(selectedEvent, SelectedPage));
                node.Tag = action;
                node.Checked = action.Enabled;
                ColorNode(node, action);
                pNode.Nodes.Add(node);
                if (action.Expand)
                    node.Expand();
                if (PopulateList(action, node))
                {
                    EndBranch(action, pNode.Nodes);
                }
                if (action.Else)
                {
                    node = new TreeNode("Else");
                    node.Tag = action;
                    node.ForeColor = Color.Blue;
                    node.Checked = action.Enabled;
                    pNode.Nodes.Add(node);
                    if (PopulateElseList(action, node))
                    {
                        EndBranch(action, list.Nodes);
                    }
                }
                else if (action.ProgramCategory == ProgramCategory.Movement && action.Code == 10)
                {
                    // Program Dynamics
                    List<EventProgramData> dynamics = (List<EventProgramData>)action.Value[4];
                    TreeNode dNode;
                    foreach (EventProgramData dynamic in dynamics)
                    {
                        dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                        dNode.Tag = action;
                        dNode.ForeColor = node.ForeColor;
                        dNode.Checked = dynamic.Enabled;
                        node.Nodes.Add(dNode);
                    }
                    if (action.Expand)
                        node.Expand();
                }
                else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 1)
                {
                    // Program Display - Message
                    char[] delimiters = new char[] { '\r', '\n' };
                    string[] texts = ((string)action.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                    string text = action.Value[1].ToString();
                    TreeNode dNode;
                    for (int i = 0; i < texts.Length; i++)
                    {
                        dNode = new TreeNode(texts[i]);
                        dNode.Tag = action;
                        dNode.ForeColor = node.ForeColor;
                        dNode.Checked = false;
                        node.Nodes.Add(dNode);
                    }
                    if (action.Expand)
                        node.Expand();
                }
                else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 14)
                {
                    // Program Display - Options
                    List<object> options = (List<object>)action.Value[0];
                    TreeNode dNode;
                    string text;
                    for (int i = 0; i < options.Count; i++)
                    {
                        if (options[i] is int)
                        {
                            text = "Text [" + options[i].ToString() + "]";
                        }
                        else
                            text = options[i].ToString();
                        dNode = new TreeNode(options[i].ToString());
                        dNode.Tag = action;
                        dNode.ForeColor = node.ForeColor;
                        dNode.Checked = false;
                        node.Nodes.Add(dNode);
                    }
                    if (action.Expand)
                        node.Expand();
                }
                if (action == selectedAction)
                    list.SelectedNode = node;
                parent = true;
            }
            if (parent)
            {
                TreeNode node = new TreeNode("...");
                node.Tag = pAction;
                pNode.Nodes.Add(node);
                if (pAction.Expand)
                    pNode.Expand();
            }
            return parent;
        }

        private void EndBranch(EventProgramData action, TreeNodeCollection nodes)
        {
        }

        private void ColorNode(TreeNode node, EventProgramData program)
        {
            if (program.Branch)
            {
                node.ForeColor = Color.Blue;
            }
            else
            {
                if (program.ProgramCategory == ProgramCategory.Movement)
                {
                    node.ForeColor = Color.BlueViolet;
                }
                else if (program.ProgramCategory == ProgramCategory.Settings)
                {
                    node.ForeColor = Color.Black;
                }
                else if (program.ProgramCategory == ProgramCategory.Display)
                {
                    node.ForeColor = Color.Green;
                }
                else if (program.ProgramCategory == ProgramCategory.Conditions)
                {
                    node.ForeColor = Color.Blue;
                }
                else if (program.ProgramCategory == ProgramCategory.Loops)
                {
                    if (program.Code == 2)
                        node.ForeColor = Color.Blue;
                    else
                        node.ForeColor = Color.Purple;
                }
                else if (program.ProgramCategory == ProgramCategory.Audio)
                {
                    // Audio
                    node.ForeColor = Color.OrangeRed;
                }
                else if (program.ProgramCategory == ProgramCategory.Data)
                {
                    node.ForeColor = Color.Red;
                }
                else if (program.ProgramCategory == ProgramCategory.Event)
                {
                    node.ForeColor = Color.DarkCyan;
                }
                else if (program.ProgramCategory == ProgramCategory.Map)
                {
                    node.ForeColor = Color.SaddleBrown;
                }
                else if (program.ProgramCategory == ProgramCategory.Screen)
                {
                    node.ForeColor = Color.OliveDrab;
                }
                else if (program.ProgramCategory == ProgramCategory.Graphics)
                {

                }
                else if (program.ProgramCategory == ProgramCategory.Guide)
                {

                }
                else if (program.ProgramCategory == ProgramCategory.Other)
                {
                    if (program.Code == 3)
                        node.ForeColor = Color.DarkGreen;
                    else
                        node.ForeColor = Color.BlueViolet;
                }
            }
        }

        private void Rename()
        {
            RenameNodes(list.Nodes);
        }

        private void RenameNodes(TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Text != "Else" && nodes[i].Text != "...")
                {
                    nodes[i].Text = ((EventProgramData)nodes[i].Tag).GetName(selectedEvent, SelectedPage);
                }
                // Rename childeren
                RenameNodes(nodes[i].Nodes);
            }
        }

        private void list_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Text != "...")
            {
                if (e.Node.Parent != null && e.Node.Tag == e.Node.Parent.Tag)
                {
                    EventProgramData action = (EventProgramData)e.Node.Tag;

                    if (action.ProgramCategory == ProgramCategory.Display && (action.Code == 1 || action.Code == 14))
                        return;
                    ((List<EventProgramData>)action.Value[4])[e.Node.Index].Enabled = (e.Node.Checked);
                }
                else
                {
                    EventProgramData action = (EventProgramData)e.Node.Tag;

                    action.Enabled = (e.Node.Checked);
                }
            }
            else if (e.Node.Checked)
                e.Node.Checked = false;
        }

        private void list_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                EventProgramData action = (EventProgramData)e.Node.Tag;

                action.Expand = (e.Action == TreeViewAction.Expand);
            }
        }

        private void list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.X < 32) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                editBtn_Click(this, e);
                return;
            }
            // Get Node
            TreeNode node = list.GetNodeAt(e.Location);
            if (node == null || node.Text == "Else")
                return;
            if (node.Parent != null && node.Tag == node.Parent.Tag && (node.Parent.Text.Contains("Program Dynamics") || node.Parent.Text.Contains("Show Message") || node.Parent.Text.Contains("Set Options")))
                return;
            TreeNode dots = new TreeNode("...");
            // Show Commands List
            MainForm.CommandDialog.SelectedPage = SelectedPage; MainForm.CommandDialog.SelectedEvent = SelectedEvent;
            MainForm.CommandDialog.ShowDialog();
            if (MainForm.CommandDialog.ThisResult == DialogResult.OK)
            {
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedPage, new DataPropertyDelegate(PropertyChanged)));

                SelectedAction = MainForm.CommandDialog.SelectedAction;
                // Create Action Node
                EventProgramData action = MainForm.CommandDialog.SelectedAction;
                TreeNode actionNode = new TreeNode(action.GetName(selectedEvent, page));
                actionNode.Tag = action;
                ColorNode(actionNode, action);
                actionNode.Checked = action.Enabled;
                // If then node is dots, then add before the dot.
                if (node.Text == "...")
                {
                    #region Dots
                    // Get the node to add to
                    TreeNode parentNode = null;
                    if (node.Parent == null)
                    {
                        // Top most node
                        list.Nodes.Insert(list.Nodes.Count - 1, actionNode);
                        // Add Action
                        Programs.Add(action);
                    }
                    else
                    {
                        // Not top most node
                        parentNode = node.Parent;
                        // Add Node
                        parentNode.Nodes.Insert(parentNode.Nodes.Count - 1, actionNode);
                        // Add action
                        if (parentNode.Text != "Else")
                        {
                            // Main branch
                            ((EventProgramData)parentNode.Tag).Programs.Add(action);
                        }
                        else
                        {
                            // Else Branch
                            ((EventProgramData)parentNode.Tag).ElsePrograms.Add(action);

                        }
                    }
                    // If the action node is branched, add ....
                    if (action.Branch)
                    {
                        dots.Tag = action;
                        actionNode.Nodes.Add(dots);
                        if (action.Expand)
                            actionNode.Expand();
                    }
                    // If the action node is elsed, add ...
                    TreeNode elseNode = null;
                    if (action.Else)
                    {
                        elseNode = new TreeNode("Else");
                        elseNode.Tag = action;
                        ColorNode(elseNode, action);
                        elseNode.Checked = selectedAction.Enabled;
                        dots = (TreeNode)dots.Clone();
                        dots.Tag = action;
                        elseNode.Nodes.Add(dots);
                        if (parentNode == null)
                        {
                            // Top most node
                            list.Nodes.Insert(list.Nodes.Count - 1, elseNode);
                        }
                        else
                        {
                            // Not top most node
                            parentNode.Nodes.Insert(parentNode.Nodes.Count - 1, elseNode);
                        }
                        if (action.Expand)
                            elseNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Movement && action.Code == 10)
                    {
                        // Program Dynamics
                        List<EventProgramData> dynamics = (List<EventProgramData>)action.Value[4];
                        TreeNode dNode;
                        foreach (EventProgramData dynamic in dynamics)
                        {
                            dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = dynamic.Enabled;
                            actionNode.Nodes.Add(dNode);
                        }
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 1)
                    {
                        // Program Display - Message
                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] texts = ((string)action.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                        string text = action.Value[1].ToString();
                        TreeNode dNode;
                        for (int i = 0; i < texts.Length; i++)
                        {
                            dNode = new TreeNode(texts[i]);
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 14)
                    {
                        // Program Display - Options
                        List<object> options = (List<object>)action.Value[0];
                        TreeNode dNode;
                        string text;
                        for (int i = 0; i < options.Count; i++)
                        {
                            if (options[i] is int)
                            {
                                text = "Text [" + options[i].ToString() + "]";
                            }
                            else
                                text = options[i].ToString();
                            dNode = new TreeNode(options[i].ToString());
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    #endregion
                }
                else
                {
                    // The node is not dots, add before selected node/action.
                    #region Not Dots
                    // Get the node to add to
                    TreeNode parentNode = null;
                    // Get Index
                    int indexToAdd = 0;
                    // Add Node
                    if (node.Parent == null)
                    {
                        // Get Index
                        indexToAdd = SelectedPage.Programs.IndexOf((EventProgramData)node.Tag);
                        // Top most node
                        list.Nodes.Insert(node.Index, actionNode);
                        // Add Action
                        Programs.Insert(indexToAdd, action);
                    }
                    else
                    {
                        // Not top most node
                        parentNode = node.Parent;
                        // Add Node
                        parentNode.Nodes.Insert(node.Index, actionNode);
                        // Add action
                        if (parentNode.Text != "Else")
                        {
                            // Get Index
                            indexToAdd = ((EventProgramData)parentNode.Tag).Programs.IndexOf((EventProgramData)node.Tag);
                            // Main branch
                            ((EventProgramData)parentNode.Tag).Programs.Insert(indexToAdd, action);
                        }
                        else
                        {
                            // Get Index
                            indexToAdd = ((EventProgramData)parentNode.Tag).ElsePrograms.IndexOf((EventProgramData)node.Tag);
                            // Else Branch
                            ((EventProgramData)parentNode.Tag).ElsePrograms.Insert(indexToAdd, action);

                        }
                    }
                    // If the action node is branched, add ....
                    if (action.Branch)
                    {
                        dots.Tag = action;
                        actionNode.Nodes.Add(dots);
                        if (action.Expand)
                            actionNode.Expand();
                    }
                    // If the action node is elsed, add ...
                    TreeNode elseNode = null;
                    if (action.Else)
                    {
                        elseNode = new TreeNode("Else");
                        elseNode.Tag = action;
                        ColorNode(elseNode, action);
                        elseNode.Checked = selectedAction.Enabled;
                        dots = (TreeNode)dots.Clone();
                        dots.Tag = action;
                        elseNode.Nodes.Add(dots);
                        if (parentNode == null)
                        {
                            // Top most node
                            list.Nodes.Insert(indexToAdd + 1, elseNode);
                        }
                        else
                        {
                            // Not top most node
                            parentNode.Nodes.Insert(indexToAdd + 1, elseNode);
                        }
                        if (action.Expand)
                            elseNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Movement && action.Code == 10)
                    {
                        // Program Dynamics
                        List<EventProgramData> dynamics = (List<EventProgramData>)action.Value[4];
                        TreeNode dNode;
                        foreach (EventProgramData dynamic in dynamics)
                        {
                            dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = dynamic.Enabled;
                            actionNode.Nodes.Add(dNode);
                        }
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 1)
                    {
                        // Program Display - Message
                        char[] delimiters = new char[] { '\r', '\n' };
                        TreeNode dNode;
                        if (action.Value[1] is string)
                        {
                            string[] texts = ((string)action.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                            string text = action.Value[1].ToString();
                            for (int i = 0; i < texts.Length; i++)
                            {
                                dNode = new TreeNode(texts[i]);
                                dNode.Tag = action;
                                dNode.ForeColor = actionNode.ForeColor;
                                dNode.Checked = false;
                                actionNode.Nodes.Add(dNode);
                            }
                        }
                        else
                        {
                            dNode = new TreeNode("Text: [" + action.Value[1].ToString() + "]");
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 14)
                    {
                        // Program Display - Options
                        List<object> options = (List<object>)action.Value[0];
                        TreeNode dNode;
                        string text;
                        for (int i = 0; i < options.Count; i++)
                        {
                            if (options[i] is int)
                            {
                                text = "Text [" + options[i].ToString() + "]";
                            }
                            else
                                text = options[i].ToString();
                            dNode = new TreeNode(options[i].ToString());
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    #endregion
                }
                // Select node
                list.SelectedNode = actionNode;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Get Node
            if (list.SelectedNode == null)
                list.SelectedNode = list.Nodes[0];
            TreeNode node = list.SelectedNode;
            if (node.Text == "Else")
                return;
            if (node.Parent != null && node.Tag == node.Parent.Tag && (node.Parent.Text.Contains("Program Dynamics") || node.Parent.Text.Contains("Show Message") || node.Parent.Text.Contains("Set Options")))
                return;
            TreeNode dots = new TreeNode("...");
            // Show Commands List
            MainForm.CommandDialog.SelectedPage = SelectedPage; MainForm.CommandDialog.SelectedEvent = SelectedEvent;
            MainForm.CommandDialog.ShowDialog();
            if (MainForm.CommandDialog.ThisResult == DialogResult.OK)
            {
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedPage, new DataPropertyDelegate(PropertyChanged)));

                SelectedAction = MainForm.CommandDialog.SelectedAction;
                // Create Action Node
                EventProgramData action = MainForm.CommandDialog.SelectedAction;
                TreeNode actionNode = new TreeNode(action.GetName(selectedEvent, page));
                actionNode.Tag = action;
                ColorNode(actionNode, action);
                actionNode.Checked = action.Enabled;
                // If then node is dots, then add before the dot.
                if (node.Text == "...")
                {
                    #region Dots
                    // Get the node to add to
                    TreeNode parentNode = null;
                    if (node.Parent == null)
                    {
                        // Top most node
                        list.Nodes.Insert(list.Nodes.Count - 1, actionNode);
                        // Add Action
                        SelectedPage.Programs.Add(action);
                    }
                    else
                    {
                        // Not top most node
                        parentNode = node.Parent;
                        // Add Node
                        parentNode.Nodes.Insert(parentNode.Nodes.Count - 1, actionNode);
                        // Add action
                        if (parentNode.Text != "Else")
                        {
                            // Main branch
                            ((EventProgramData)parentNode.Tag).Programs.Add(action);
                        }
                        else
                        {
                            // Else Branch
                            ((EventProgramData)parentNode.Tag).ElsePrograms.Add(action);

                        }
                    }
                    // If the action node is branched, add ....
                    if (action.Branch)
                    {
                        dots.Tag = action;
                        actionNode.Nodes.Add(dots);
                        if (action.Expand)
                            actionNode.Expand();
                    }
                    // If the action node is elsed, add ...
                    if (action.Else)
                    {
                        TreeNode elseNode = new TreeNode("Else");
                        elseNode.Tag = action;
                        ColorNode(elseNode, action);
                        elseNode.Checked = selectedAction.Enabled;
                        dots = (TreeNode)dots.Clone();
                        dots.Tag = action;
                        elseNode.Nodes.Add(dots);
                        if (parentNode == null)
                        {
                            // Top most node
                            list.Nodes.Insert(list.Nodes.Count - 1, elseNode);
                        }
                        else
                        {
                            // Not top most node
                            parentNode.Nodes.Insert(parentNode.Nodes.Count - 1, elseNode);
                        }
                        if (action.Expand)
                            elseNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Movement && action.Code == 10)
                    {
                        // Program Dynamics
                        List<EventProgramData> dynamics = (List<EventProgramData>)action.Value[4];
                        TreeNode dNode;
                        foreach (EventProgramData dynamic in dynamics)
                        {
                            dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = dynamic.Enabled;
                            actionNode.Nodes.Add(dNode);
                        }
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 1)
                    {
                        // Program Display - Message
                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] texts = ((string)action.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                        string text = action.Value[1].ToString();
                        TreeNode dNode;
                        for (int i = 0; i < texts.Length; i++)
                        {
                            dNode = new TreeNode(texts[i]);
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 14)
                    {
                        // Program Display - Options
                        List<object> options = (List<object>)action.Value[0];
                        TreeNode dNode;
                        string text;
                        for (int i = 0; i < options.Count; i++)
                        {
                            if (options[i] is int)
                            {
                                text = "Text [" + options[i].ToString() + "]";
                            }
                            else
                                text = options[i].ToString();
                            dNode = new TreeNode(options[i].ToString());
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    #endregion
                }
                else
                {
                    // The node is not dots, add before selected node/action.
                    #region Not Dots
                    // Get the node to add to
                    TreeNode parentNode = null;
                    // Get Index
                    int indexToAdd = 0;
                    // Add Node
                    if (node.Parent == null)
                    {
                        // Get Index
                        indexToAdd = SelectedPage.Programs.IndexOf((EventProgramData)node.Tag);
                        // Top most node
                        list.Nodes.Insert(node.Index, actionNode);
                        // Add Action
                        SelectedPage.Programs.Insert(indexToAdd, action);
                    }
                    else
                    {
                        // Not top most node
                        parentNode = node.Parent;
                        // Add Node
                        parentNode.Nodes.Insert(node.Index, actionNode);
                        // Add action
                        if (parentNode.Text != "Else")
                        {
                            // Get Index
                            indexToAdd = ((EventProgramData)parentNode.Tag).Programs.IndexOf((EventProgramData)node.Tag);
                            // Main branch
                            ((EventProgramData)parentNode.Tag).Programs.Insert(indexToAdd, action);
                        }
                        else
                        {
                            // Get Index
                            indexToAdd = ((EventProgramData)parentNode.Tag).ElsePrograms.IndexOf((EventProgramData)node.Tag);
                            // Else Branch
                            ((EventProgramData)parentNode.Tag).ElsePrograms.Insert(indexToAdd, action);

                        }
                    }
                    // If the action node is branched, add ....
                    if (action.Branch)
                    {
                        dots.Tag = action;
                        actionNode.Nodes.Add(dots);
                        if (action.Expand)
                            actionNode.Expand();
                    }
                    // If the action node is elsed, add ...
                    if (action.Else)
                    {
                        TreeNode elseNode = new TreeNode("Else");
                        elseNode.Tag = action;
                        ColorNode(elseNode, action);
                        elseNode.Checked = selectedAction.Enabled;
                        dots = (TreeNode)dots.Clone();
                        dots.Tag = action;
                        elseNode.Nodes.Add(dots);
                        if (parentNode == null)
                        {
                            // Top most node
                            list.Nodes.Insert(indexToAdd + 1, elseNode);
                        }
                        else
                        {
                            // Not top most node
                            parentNode.Nodes.Insert(indexToAdd + 1, elseNode);
                        }
                        if (action.Expand)
                            elseNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Movement && action.Code == 10)
                    {
                        // Program Dynamics
                        List<EventProgramData> dynamics = (List<EventProgramData>)action.Value[4];
                        TreeNode dNode;
                        foreach (EventProgramData dynamic in dynamics)
                        {
                            dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = dynamic.Enabled;
                            actionNode.Nodes.Add(dNode);
                        }
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 1)
                    {
                        // Program Display - Message
                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] texts = ((string)action.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                        string text = action.Value[1].ToString();
                        TreeNode dNode;
                        for (int i = 0; i < texts.Length; i++)
                        {
                            dNode = new TreeNode(texts[i]);
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 14)
                    {
                        // Program Display - Options
                        List<object> options = (List<object>)action.Value[0];
                        TreeNode dNode;
                        string text;
                        for (int i = 0; i < options.Count; i++)
                        {
                            if (options[i] is int)
                            {
                                text = "Text [" + options[i].ToString() + "]";
                            }
                            else
                                text = options[i].ToString();
                            dNode = new TreeNode(options[i].ToString());
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    #endregion
                }
                // Select node
                list.SelectedNode = actionNode;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (list.SelectedNode != null && list.SelectedNode.Text != "..." && list.SelectedNode.Text != "Else")
            {
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedPage, new DataPropertyDelegate(PropertyChanged)));

                TreeNode node = list.SelectedNode;
                if (node.Parent == null)
                {
                    int i = node.Index;
                    EventProgramData a = (EventProgramData)node.Tag;
                    // Remove From List
                    list.Nodes.RemoveAt(i);
                    if (a.Else)
                        list.Nodes.RemoveAt(i);

                    Programs.Remove(a);
                }
                else if (node.Parent != null)
                {
                    int i = node.Index;
                    TreeNode pnode = node.Parent;
                    EventProgramData a = ((EventProgramData)node.Tag);

                    if ((a.ProgramCategory == ProgramCategory.Movement && a.Code == 10) || (a.ProgramCategory == ProgramCategory.Display && (a.Code == 1 || a.Code == 14)))
                    {
                        if (node.Nodes.Count > 0) // Parent
                        {
                            // Remove From List
                            pnode.Nodes.RemoveAt(i);
                            if (pnode.Text == "Else")
                                ((EventProgramData)pnode.Tag).ElsePrograms.Remove(a);
                            else
                                ((EventProgramData)pnode.Tag).Programs.Remove(a);
                        }
                        else // Child
                        {
                            if (pnode.Parent != null)
                            {
                                pnode.Parent.Nodes.Remove(pnode);
                                if (pnode.Text == "Else")
                                    ((EventProgramData)pnode.Tag).ElsePrograms.Remove(a);
                                else
                                    ((EventProgramData)pnode.Tag).Programs.Remove(a);
                            }
                            else
                            {
                                list.Nodes.Remove(pnode);
                                Programs.Remove(a);
                            }
                        }
                    }
                    else
                    {
                        // Remove From List
                        pnode.Nodes.RemoveAt(i);
                        if (a.Else)
                            pnode.Nodes.RemoveAt(i);
                        if (pnode.Text == "Else")
                            ((EventProgramData)pnode.Tag).ElsePrograms.Remove(a);
                        else
                            ((EventProgramData)pnode.Tag).Programs.Remove(a);
                    }
                }
            }
        }

        private void upBtn_Click(object sender, EventArgs e)
        {
            // Make sure the node is there.
            if (list.SelectedNode != null && list.SelectedNode.Text != "Else" && list.SelectedNode.Text != "...")
            {
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedPage, new DataPropertyDelegate(PropertyChanged)));

                TreeNode node = list.SelectedNode;
                TreeNode elseNode = null;
                // Make sure the node can go up.
                if (node.Parent == null && node.Index > 0)
                {
                    // Top most branch
                    EventProgramData action = (EventProgramData)node.Tag;
                    // Get node index
                    int nodeIndex = node.Index;
                    // Get action index
                    int actionIndex = SelectedPage.Programs.IndexOf(action);
                    // Remove Node
                    list.Nodes.RemoveAt(nodeIndex);
                    // Remove Action
                    SelectedPage.Programs.Remove(action);
                    // Remove else if there is
                    if (action.Else)
                    {
                        elseNode = list.Nodes[nodeIndex];
                        list.Nodes.RemoveAt(nodeIndex);
                    }
                    // Re-Add
                    list.Nodes.Insert(nodeIndex - 1, node);
                    SelectedPage.Programs.Insert(actionIndex - 1, action);
                    if (action.Else)
                    {
                        list.Nodes.Insert(nodeIndex, elseNode);
                    }
                    list.SelectedNode = node;
                }
                else if (node.Parent != null && node.Index > 0)
                {
                    if (node.Tag == node.Parent.Tag)
                        return;
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedPage, new DataPropertyDelegate(PropertyChanged)));

                    // Top most branch
                    EventProgramData action = (EventProgramData)node.Tag;
                    // Parent Node
                    TreeNode parentNode = node.Parent;
                    EventProgramData parentProgram = (EventProgramData)parentNode.Tag;
                    // Get node index
                    int nodeIndex = node.Index;
                    // Get action index
                    int actionIndex = parentProgram.Programs.IndexOf(action);
                    // Remove Node
                    parentNode.Nodes.RemoveAt(nodeIndex);
                    // Remove else if there is
                    if (action.Else)
                    {
                        elseNode = parentNode.Nodes[nodeIndex];
                        parentNode.Nodes.RemoveAt(nodeIndex);
                    }
                    // Check node index
                    if (parentNode.Nodes[nodeIndex - 1].Text == "Else")
                        nodeIndex--;

                    if (parentNode.Text == "Else")
                    {
                        actionIndex = parentProgram.ElsePrograms.IndexOf(action);
                        // Remove Action
                        parentProgram.ElsePrograms.Remove(action);
                        // Re-Add
                        parentNode.Nodes.Insert(nodeIndex - 1, node);
                        parentProgram.ElsePrograms.Insert(actionIndex - 1, action);
                    }
                    else
                    {
                        // Remove Action
                        parentProgram.Programs.Remove(action);
                        // Re-Add
                        parentNode.Nodes.Insert(nodeIndex - 1, node);
                        parentProgram.Programs.Insert(actionIndex - 1, action);
                    }
                    if (action.Else)
                    {
                        parentNode.Nodes.Insert(nodeIndex, elseNode);
                    }
                    list.SelectedNode = node;
                }
            }
        }

        private void downBtn_Click(object sender, EventArgs e)
        {
            // Make sure the node is there.
            if (list.SelectedNode != null && list.SelectedNode.Text != "Else" && list.SelectedNode.Text != "...")
            {
                if (list.SelectedNode.Parent != null && list.SelectedNode.Parent.Tag != null && list.SelectedNode.Tag == list.SelectedNode.Parent.Tag)
                    return;
                SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedPage, new DataPropertyDelegate(PropertyChanged)));

                TreeNode node = list.SelectedNode;
                TreeNode elseNode = null;
                // Make sure the node can go up.
                if (node.Parent == null && node.Index < list.Nodes.Count - 2)
                {
                    // Top most branch
                    EventProgramData action = (EventProgramData)node.Tag;
                    // Get node index
                    int nodeIndex = node.Index;
                    // Get action index
                    int actionIndex = SelectedPage.Programs.IndexOf(action);
                    // Remove Node
                    list.Nodes.RemoveAt(nodeIndex);
                    // Remove Action
                    SelectedPage.Programs.Remove(action);
                    // Remove else if there is
                    if (action.Else)
                    {
                        elseNode = list.Nodes[nodeIndex];
                        list.Nodes.RemoveAt(nodeIndex);
                    }
                    // Re-Add
                    list.Nodes.Insert(nodeIndex + 1, node);
                    SelectedPage.Programs.Insert(actionIndex + 1, action);
                    if (action.Else)
                    {
                        list.Nodes.Insert(nodeIndex, elseNode);
                    }
                    list.SelectedNode = node;
                }
                else if (node.Parent != null && node.Index < node.Parent.Nodes.Count - 2)
                {
                    if (node.Tag == node.Parent.Tag)
                        return;
                    SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedPage, new DataPropertyDelegate(PropertyChanged)));

                    // Top most branch
                    EventProgramData action = (EventProgramData)node.Tag;
                    // Parent Node
                    TreeNode parentNode = node.Parent;
                    EventProgramData parentProgram = (EventProgramData)parentNode.Tag;
                    // Get node index
                    int nodeIndex = node.Index;
                    // Get action index
                    int actionIndex = parentProgram.Programs.IndexOf(action);
                    // Remove Node
                    parentNode.Nodes.RemoveAt(nodeIndex);
                    // Remove else if there is
                    if (action.Else)
                    {
                        elseNode = parentNode.Nodes[nodeIndex];
                        parentNode.Nodes.RemoveAt(nodeIndex);
                    }
                    // Check node index
                    if (parentNode.Nodes[nodeIndex + 1].Text == "Else")
                        nodeIndex++;

                    if (parentNode.Text == "Else")
                    {
                        actionIndex = parentProgram.ElsePrograms.IndexOf(action);
                        // Remove Action
                        parentProgram.ElsePrograms.Remove(action);
                        // Re-Add
                        parentNode.Nodes.Insert(nodeIndex + 1, node);
                        parentProgram.ElsePrograms.Insert(actionIndex + 1, action);
                    }
                    else
                    {
                        // Remove Action
                        parentProgram.Programs.Remove(action);
                        // Re-Add
                        parentNode.Nodes.Insert(nodeIndex + 1, node);
                        parentProgram.Programs.Insert(actionIndex + 1, action);
                    }
                    if (action.Else)
                    {
                        parentNode.Nodes.Insert(nodeIndex, elseNode);
                    }
                    list.SelectedNode = node;
                }
            }
        }

        private void list_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode n = (TreeNode)e.Item;
            if (n.Parent != null && n.Tag == n.Parent.Tag)
                return;
            if (n.Tag != null && n.Text != "...")
                DoDragDrop(n, DragDropEffects.Copy);
        }

        private void listBox_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));

                    if (list.SelectedNode == node)
                        e.Effect = DragDropEffects.All;

                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "5x001");
            }
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));

                if (list.SelectedNode == node && node != null)
                {
                    TreeNode overNode = list.GetNodeAt(list.PointToClient(new Point(e.X, e.Y)));

                    if (overNode == null)
                        return;
                    if (overNode.Parent != null && overNode.Tag == overNode.Parent.Tag && (overNode.Parent.Text.Contains("Program Attachment Dynamics") || overNode.Parent.Text.Contains("Program Dynamics") || overNode.Parent.Text.Contains("Show Message") || overNode.Parent.Text.Contains("Set Options")))
                        return;
                    if (node.Nodes.Count > 0)
                    {
                        if (overNode.Parent != null && overNode.Parent.Text == "Else" && ((EventProgramData)overNode.Parent.Tag).ElsePrograms == ((EventProgramData)node.Tag).ElsePrograms) return;
                        if (overNode.Text == "Else" && ((EventProgramData)overNode.Tag).ElsePrograms == ((EventProgramData)node.Tag).ElsePrograms) return;
                    }
                    if (overNode != null && overNode != node && overNode.Parent != node && overNode.Text != "Else")
                    {
                        SelectedHistory.Do(new IGameDataChangePropertyHist(SelectedPage, new DataPropertyDelegate(PropertyChanged)));

                        TreeNodeCollection parentNodes;
                        List<EventProgramData> actions;
                        if (overNode.Parent == null)
                        {
                            parentNodes = list.Nodes;
                            actions = programs;
                        }
                        else
                        {
                            parentNodes = overNode.Parent.Nodes;
                            if (overNode.Parent.Text != "Else")
                                actions = ((EventProgramData)overNode.Parent.Tag).Programs;
                            else
                                actions = ((EventProgramData)overNode.Parent.Tag).ElsePrograms;
                        }
                        // Get action
                        EventProgramData action = (EventProgramData)node.Tag;
                        // Else node
                        TreeNode elseNode = null;
                        // Curre Node Parent
                        TreeNode nodeParent = node.Parent;
                        int nodeIndex = 0;
                        if (nodeParent == null)
                        {
                            nodeIndex = list.Nodes.IndexOf(node);
                            list.Nodes.Remove(node);
                            // Remove Action
                            programs.Remove(action);
                        }
                        else
                        {
                            nodeIndex = nodeParent.Nodes.IndexOf(node);
                            nodeParent.Nodes.Remove(node);
                            // Remove action
                            if (nodeParent.Text == "Else")
                                ((EventProgramData)nodeParent.Tag).ElsePrograms.Remove(action);
                            else
                                ((EventProgramData)nodeParent.Tag).Programs.Remove(action);
                        }

                        if (action.Else)
                        {
                            if (nodeParent == null)
                            {
                                elseNode = list.Nodes[nodeIndex];
                                list.Nodes.Remove(elseNode);
                            }
                            else
                            {
                                elseNode = nodeParent.Nodes[nodeIndex];
                                nodeParent.Nodes.Remove(elseNode);
                            }
                        }
                        // Get index of the overnode
                        int index = parentNodes.IndexOf(overNode);
                        int actionIndex = actions.IndexOf((EventProgramData)overNode.Tag);
                        if (overNode.Tag == null || overNode.Text == "...")
                        {
                            // No Parent
                            actionIndex = actions.Count;
                        }
                        if (actionIndex < 0)
                            actionIndex = 0;
                        // Insert over node
                        parentNodes.Insert(index, node);
                        if (action.Else)
                            parentNodes.Insert(index + 1, elseNode);
                        // Insert action
                        actions.Insert(actionIndex, action);
                        // Select node
                        list.SelectedNode = node;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "5x002");
            }
        }

        private void list_MouseDown(object sender, MouseEventArgs e)
        {
            list.SelectedNode = list.GetNodeAt(e.Location);

            if (list.SelectedNode != null && list.SelectedNode.Parent != null)
            {
                list.SelectedNode.Parent.ForeColor = Color.DarkViolet;
                //list.SelectedNode.Parent.BackColor = Color.WhiteSmoke;
                //list.SelectedNode.Parent.NodeFont = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Bold);
            }
        }

        private void list_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (previousNode != null)
            {
                previousNode.BackColor = Color.White;
                //previousNode.NodeFont = new Font("Microsoft Sans Serif", 8.5f, FontStyle.Regular);
                ColorNode(previousNode, (EventProgramData)previousNode.Tag);
            }
            if (list.SelectedNode != null && list.SelectedNode.Parent != null)
            {
                previousNode = list.SelectedNode.Parent;
            }
        }

        #region IEditor Members

        public void SetupList()
        {
            Setup();
        }

        #endregion

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.SelectedNode != null && list.SelectedNode.Text != "Else" && list.SelectedNode.Text != "...")
            {
                EventProgramData a = (EventProgramData)list.SelectedNode.Tag;
                Global.Copy(a);
                deleteBtn_Click(null, null);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.SelectedNode != null && list.SelectedNode.Text != "Else" && list.SelectedNode.Text != "...")
            {
                EventProgramData a = (EventProgramData)list.SelectedNode.Tag;
                Global.Copy(a);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.PasteData() is EventProgramData)
            {
                EventProgramData pastedData = (EventProgramData)Global.PasteData();
                // Get Node
                if (list.SelectedNode == null)
                    list.SelectedNode = list.Nodes[0];
                TreeNode node = list.SelectedNode;
                if (node.Text == "Else")
                    return;
                TreeNode dots = new TreeNode("...");
                // Show Commands List
                SelectedAction = pastedData;
                // Create Action Node
                EventProgramData action = pastedData;
                TreeNode actionNode = new TreeNode(action.GetName(selectedEvent, page));
                actionNode.Tag = action;
                ColorNode(actionNode, action);
                actionNode.Checked = action.Enabled;
                // If then node is dots, then add before the dot.
                if (node.Text == "...")
                {
                    #region Dots
                    // Get the node to add to
                    TreeNode parentNode = null;
                    if (node.Parent == null)
                    {
                        // Top most node
                        list.Nodes.Insert(list.Nodes.Count - 1, actionNode);
                        // Add Action
                        SelectedPage.Programs.Add(action);
                    }
                    else
                    {
                        // Not top most node
                        parentNode = node.Parent;
                        // Add Node
                        parentNode.Nodes.Insert(parentNode.Nodes.Count - 1, actionNode);
                        // Add action
                        if (parentNode.Text != "Else")
                        {
                            // Main branch
                            ((EventProgramData)parentNode.Tag).Programs.Add(action);
                        }
                        else
                        {
                            // Else Branch
                            ((EventProgramData)parentNode.Tag).ElsePrograms.Add(action);

                        }
                    }
                    // If the action node is branched, add ....
                    if (action.Branch)
                    {
                        dots.Tag = action;
                        actionNode.Nodes.Add(dots);
                        if (action.Expand)
                            actionNode.Expand();
                    }
                    // If the action node is elsed, add ...
                    if (action.Else)
                    {
                        TreeNode elseNode = new TreeNode("Else");
                        elseNode.Tag = action;
                        ColorNode(elseNode, action);
                        elseNode.Checked = selectedAction.Enabled;
                        dots = (TreeNode)dots.Clone();
                        dots.Tag = action;
                        elseNode.Nodes.Add(dots);
                        if (parentNode == null)
                        {
                            // Top most node
                            list.Nodes.Insert(list.Nodes.Count - 1, elseNode);
                        }
                        else
                        {
                            // Not top most node
                            parentNode.Nodes.Insert(parentNode.Nodes.Count - 1, elseNode);
                        }
                        if (action.Expand)
                            elseNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Movement && action.Code == 10)
                    {
                        // Program Dynamics
                        List<EventProgramData> dynamics = (List<EventProgramData>)action.Value[4];
                        TreeNode dNode;
                        foreach (EventProgramData dynamic in dynamics)
                        {
                            dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = dynamic.Enabled;
                            actionNode.Nodes.Add(dNode);
                        }
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 1)
                    {
                        // Program Display - Message
                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] texts = ((string)action.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                        string text = action.Value[1].ToString();
                        TreeNode dNode;
                        for (int i = 0; i < texts.Length; i++)
                        {
                            dNode = new TreeNode(texts[i]);
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 14)
                    {
                        // Program Display - Options
                        List<object> options = (List<object>)action.Value[0];
                        TreeNode dNode;
                        string text;
                        for (int i = 0; i < options.Count; i++)
                        {
                            if (options[i] is int)
                            {
                                text = "Text [" + options[i].ToString() + "]";
                            }
                            else
                                text = options[i].ToString();
                            dNode = new TreeNode(options[i].ToString());
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    if (action.Programs.Count > 0 || action.ElsePrograms.Count > 0)
                        SetupList();
                    #endregion
                }
                else
                {
                    if (node.Parent != null && node.Tag == node.Parent.Tag && (node.Parent.Text.Contains("Program Attachment Dynamics") || node.Parent.Text.Contains("Program Dynamics") || node.Parent.Text.Contains("Show Message") || node.Parent.Text.Contains("Set Options")))
                        return;
                    // The node is not dots, add before selected node/action.
                    #region Not Dots
                    // Get the node to add to
                    TreeNode parentNode = null;
                    // Get Index
                    int indexToAdd = 0;
                    // Add Node
                    if (node.Parent == null)
                    {
                        // Get Index
                        indexToAdd = SelectedPage.Programs.IndexOf((EventProgramData)node.Tag);
                        // Top most node
                        list.Nodes.Insert(node.Index, actionNode);
                        // Add Action
                        SelectedPage.Programs.Insert(indexToAdd, action);
                    }
                    else
                    {
                        // Not top most node
                        parentNode = node.Parent;
                        // Add Node
                        parentNode.Nodes.Insert(node.Index, actionNode);
                        // Add action
                        if (parentNode.Text != "Else")
                        {
                            // Get Index
                            indexToAdd = ((EventProgramData)parentNode.Tag).Programs.IndexOf((EventProgramData)node.Tag);
                            // Main branch
                            ((EventProgramData)parentNode.Tag).Programs.Insert(indexToAdd, action);
                        }
                        else
                        {
                            // Get Index
                            indexToAdd = ((EventProgramData)parentNode.Tag).ElsePrograms.IndexOf((EventProgramData)node.Tag);
                            // Else Branch
                            ((EventProgramData)parentNode.Tag).ElsePrograms.Insert(indexToAdd, action);

                        }
                    }
                    // If the action node is branched, add ....
                    if (action.Branch)
                    {
                        dots.Tag = action;
                        actionNode.Nodes.Add(dots);
                        if (action.Expand)
                            actionNode.Expand();
                    }
                    // If the action node is elsed, add ...
                    if (action.Else)
                    {
                        TreeNode elseNode = new TreeNode("Else");
                        elseNode.Tag = action;
                        ColorNode(elseNode, action);
                        elseNode.Checked = selectedAction.Enabled;
                        dots = (TreeNode)dots.Clone();
                        dots.Tag = action;
                        elseNode.Nodes.Add(dots);
                        if (parentNode == null)
                        {
                            // Top most node
                            list.Nodes.Insert(node.Index, elseNode);
                        }
                        else
                        {
                            // Not top most node
                            parentNode.Nodes.Insert(node.Index, elseNode);
                        }
                        if (action.Expand)
                            elseNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Movement && action.Code == 10)
                    {
                        // Program Dynamics
                        List<EventProgramData> dynamics = (List<EventProgramData>)action.Value[4];
                        TreeNode dNode;
                        foreach (EventProgramData dynamic in dynamics)
                        {
                            dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = dynamic.Enabled;
                            actionNode.Nodes.Add(dNode);
                        }
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 1)
                    {
                        // Program Display - Message
                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] texts = ((string)action.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                        string text = action.Value[1].ToString();
                        TreeNode dNode;
                        for (int i = 0; i < texts.Length; i++)
                        {
                            dNode = new TreeNode(texts[i]);
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }
                    else if (action.ProgramCategory == ProgramCategory.Display && action.Code == 14)
                    {
                        // Program Display - Options
                        List<object> options = (List<object>)action.Value[0];
                        TreeNode dNode;
                        string text;
                        for (int i = 0; i < options.Count; i++)
                        {
                            if (options[i] is int)
                            {
                                text = "Text [" + options[i].ToString() + "]";
                            }
                            else
                                text = options[i].ToString();
                            dNode = new TreeNode(options[i].ToString());
                            dNode.Tag = action;
                            dNode.ForeColor = actionNode.ForeColor;
                            dNode.Checked = false;
                            actionNode.Nodes.Add(dNode);
                        }
                        actionNode.Expand();
                    }

                    if (action.Programs.Count > 0 || action.ElsePrograms.Count > 0)
                        SetupList();
                    #endregion
                }
                // Select node
                list.SelectedNode = actionNode;
            }
        }

        private void list_MouseHover(object sender, EventArgs e)
        {
        }

        ProgramOverviewDialog overViewDialog = new ProgramOverviewDialog();
        private void list_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = new Point(e.X, e.Y);
            return;
            TreeNode node = list.GetNodeAt(e.X, e.Y);

            if (node != null && node.Text != "Else" && node.Text != "...")
            {
                EventProgramData a = (EventProgramData)node.Tag;

                if (a != null && (a.ProgramCategory == ProgramCategory.Movement && a.Code == 10) || (a.ProgramCategory == ProgramCategory.Display && (a.Code == 1 || a.Code == 14)))
                {
                    if (!overViewDialog.Visible)
                    {
                        // Show Dialog for more info
                        overViewDialog = new ProgramOverviewDialog();
                        overViewDialog.Setup(a);
                        Point location = e.Location;
                        location.X += 10;
                        overViewDialog.Location = list.PointToScreen(location);
                        overViewDialog.Show();
                    }
                }
                else if (overViewDialog.Visible)
                {
                    overViewDialog.Close();
                    this.Parent.Parent.Parent.Focus();
                }
            }
            else if (overViewDialog.Visible)
            {
                overViewDialog.Close();
                this.Parent.Parent.Parent.Focus();
            }
        }
        Point mousePosition = new Point();
        private void list_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            TreeNode node = e.Node;
            return;
            if (node != null && node.Text != "Else" && node.Text != "...")
            {
                EventProgramData a = (EventProgramData)node.Tag;

                if (a != null && (a.ProgramCategory == ProgramCategory.Movement && a.Code == 10) || (a.ProgramCategory == ProgramCategory.Display && (a.Code == 1 || a.Code == 14)))
                {
                    if (!overViewDialog.Visible)
                    {
                        // Show Dialog for more info
                        overViewDialog = new ProgramOverviewDialog();
                        overViewDialog.Setup(a);
                        Point location = mousePosition;
                        location.X += 10;
                        overViewDialog.Location = list.PointToScreen(location);
                        overViewDialog.Show();
                    }
                }
                else if (overViewDialog.Visible)
                {
                    overViewDialog.Close();
                    this.Parent.Parent.Parent.Focus();
                }
            }
            else if (overViewDialog.Visible)
            {
                overViewDialog.Close();
                this.Parent.Parent.Parent.Focus();
            }
        }
        /// <summary>
        /// Edit Program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (list.SelectedNode != null && list.SelectedNode.Text != "Else" && list.SelectedNode.Text != "..." && list.SelectedNode.Tag != null)
            {
                EventProgramData data = (EventProgramData)list.SelectedNode.Tag;

                if (data != null)
                {
                    switch (data.ProgramCategory)
                    {
                        case ProgramCategory.Movement: // Movement
                            if (EditCategoryMovement(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Settings: // Settings
                            if (EditCategorySettings(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Display: // Display
                            if (EditCategoryDisplay(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Conditions: // Conditions
                            bool setup = false;
                            if (EditCategoryConditions(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list, ref setup)) { list.SelectedNode.Text = data.Name; }
                            if (setup) Setup();
                            break;
                        case ProgramCategory.Loops: // Loops
                            if (EditCategoryLoop(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Audio: // Audio
                            if (EditCategoryAudio(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Data: // Data
                            if (EditCategoryData(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Event: // Event
                            if (EditCategoryEvent(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Map: // Map
                            if (EditCategoryMap(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Screen: // Screen
                            if (EditCategoryScreen(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Graphics: // Graphics
                            if (EditCategoryGraphics(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Guide: // Memory
                            if (EditCategoryMemory(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Other: // Other
                            if (EditCategoryOther(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Party: // Party
                            if (EditCategoryParty(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Hero: // Hero
                            if (EditCategoryHero(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                        case ProgramCategory.Battle: // Battle
                            if (EditCategoryBattle(data, Programs, SelectedEvent, SelectedPage, new DataPropertyDelegate(PropertyChanged), SelectedHistory, list)) { list.SelectedNode.Text = data.Name; }// Setup();
                            break;
                    }
                }
            }
        }

        public static bool EditCategoryGraphics(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1:
                    BeginDrawDialog dialog1 = new BeginDrawDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }


        public static bool EditCategoryBattle(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1:
                    PlayerCommandDialog dialog1 = new PlayerCommandDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 2:
                    ComandAlliesDialog dialog2 = new ComandAlliesDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 3:
                    AssigneAllyAsTargetDialog dialog3 = new AssigneAllyAsTargetDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4:
                    TargetsDialog dialog4 = new TargetsDialog();
                    dialog4.Programs = programs;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.ProgramData = data;
                    if (dialog4.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog4.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 6:
                    UseItemDialog dialog5 = new UseItemDialog();
                    dialog5.Programs = programs;
                    dialog5.SelectedEvent = SelectedEvent;
                    dialog5.SelectedPage = SelectedPage;
                    dialog5.ProgramData = data;
                    if (dialog5.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog5.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 7:
                    UseSkillDialog dialog6 = new UseSkillDialog();
                    dialog6.Programs = programs;
                    dialog6.SelectedEvent = SelectedEvent;
                    dialog6.SelectedPage = SelectedPage;
                    dialog6.ProgramData = data;
                    if (dialog6.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog6.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 8:
                    BattleCondtionsDialog dialog7 = new BattleCondtionsDialog();
                    dialog7.Programs = programs;
                    dialog7.SelectedEvent = SelectedEvent;
                    dialog7.SelectedPage = SelectedPage;
                    dialog7.ProgramData = data;
                    if (dialog7.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog7.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 10:
                    ForceUseSlotDialog dialog10 = new ForceUseSlotDialog();
                    dialog10.Programs = programs;
                    dialog10.SelectedEvent = SelectedEvent;
                    dialog10.SelectedPage = SelectedPage;
                    dialog10.ProgramData = data;
                    if (dialog10.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog10.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 11:
                    IndestructibleDialog dialog11 = new IndestructibleDialog();
                    dialog11.Programs = programs;
                    dialog11.SelectedEvent = SelectedEvent;
                    dialog11.SelectedPage = SelectedPage;
                    dialog11.ProgramData = data;
                    if (dialog11.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog11.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryMovement(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 10:
                    ProgramMovementDialog dialog1 = new ProgramMovementDialog();
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;

                    dialog1.Values = data.Value;
                    dialog1.Programs = (List<EventProgramData>)data.Value[4];
                    dialog1.IsProgramMovement = false;

                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        data.Value[4] = dialog1.Programs;
                        data.Name = data.GetName(SelectedEvent, SelectedPage);

                        if (list.SelectedNode.Text != data.Name)
                            list.SelectedNode = list.SelectedNode.Parent;

                        list.SelectedNode.Nodes.Clear();

                        // Program Dynamics
                        List<EventProgramData> dynamics = (List<EventProgramData>)data.Value[4];
                        TreeNode dNode;
                        foreach (EventProgramData dynamic in dynamics)
                        {
                            dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                            dNode.Tag = data;
                            dNode.ForeColor = list.SelectedNode.ForeColor;
                            dNode.Checked = dynamic.Enabled;
                            list.SelectedNode.Nodes.Add(dNode);
                        }
                        if (data.Expand)
                            list.SelectedNode.Expand();

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryAttachment(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1:
                    ChangeAttAnimationDialog dialog2 = new ChangeAttAnimationDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 2:
                    ProgramMovementDialog dialog1 = new ProgramMovementDialog();
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.IsAttachment = true;
                    dialog1.Values = data.Value;
                    dialog1.Programs = (List<EventProgramData>)data.Value[4];
                    dialog1.IsProgramMovement = false;

                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        data.Value[4] = dialog1.Programs;
                        data.Name = "Program Attachment Dynamics";

                        if (list.SelectedNode.Text != data.Name)
                            list.SelectedNode = list.SelectedNode.Parent;

                        list.SelectedNode.Nodes.Clear();

                        // Program Dynamics
                        List<EventProgramData> dynamics = (List<EventProgramData>)data.Value[4];
                        TreeNode dNode;
                        foreach (EventProgramData dynamic in dynamics)
                        {
                            dNode = new TreeNode(dynamic.GetName(SelectedEvent, SelectedPage));
                            dNode.Tag = data;
                            dNode.ForeColor = list.SelectedNode.ForeColor;
                            dNode.Checked = dynamic.Enabled;
                            list.SelectedNode.Nodes.Add(dNode);
                        }
                        if (data.Expand)
                            list.SelectedNode.Expand();

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategorySettings(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            throw new NotImplementedException();
        }

        public static bool EditCategoryDisplay(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // Show Message
                    ShowMessageDialog dialog1 = new ShowMessageDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = "Show Message";
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;


                        // Program Display - Message
                        char[] delimiters = new char[] { '\r', '\n' };
                        string[] texts = ((string)data.Value[1].ToString()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                        if (list.SelectedNode.Text != data.Name && list.SelectedNode.Parent.Text == data.Name)
                            list.SelectedNode = list.SelectedNode.Parent;

                        list.SelectedNode.Nodes.Clear();

                        string text = data.Value[1].ToString();
                        TreeNode dNode;
                        for (int i = 0; i < texts.Length; i++)
                        {
                            dNode = new TreeNode(texts[i]);
                            dNode.Tag = data;
                            dNode.ForeColor = list.SelectedNode.ForeColor;
                            dNode.Checked = false;
                            list.SelectedNode.Nodes.Add(dNode);
                        }
                        if (data.Expand)
                            list.SelectedNode.Expand();

                        return true;
                    }
                    break;
                case 2: // Show Menu
                    ShowMenuDialog dialog2 = new ShowMenuDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 3: // Show Picture
                    ShowPictureDialog dialog3 = new ShowPictureDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4: // Clear Picture
                    ErasePictureDialog dialog4 = new ErasePictureDialog();
                    dialog4.Programs = programs;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.ProgramData = data;
                    if (dialog4.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog4.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 5: // Show Animation
                    ShowAnimationDialog dialog5 = new ShowAnimationDialog();
                    dialog5.Programs = programs;
                    dialog5.SelectedEvent = SelectedEvent;
                    dialog5.SelectedPage = SelectedPage;
                    dialog5.ProgramData = data;
                    if (dialog5.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog5.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 6: // Show Video
                    ShowVideoDialog dialog6 = new ShowVideoDialog();
                    dialog6.Programs = programs;
                    dialog6.SelectedEvent = SelectedEvent;
                    dialog6.SelectedPage = SelectedPage;
                    dialog6.ProgramData = data;
                    if (dialog6.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog6.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 7: // Video Controls
                    VideoControlDialog dialog7 = new VideoControlDialog();
                    dialog7.Programs = programs;
                    dialog7.SelectedEvent = SelectedEvent;
                    dialog7.SelectedPage = SelectedPage;
                    dialog7.ProgramData = data;
                    if (dialog7.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog7.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 8: // Move Picture
                    MovePictureDialog dialog8 = new MovePictureDialog();
                    dialog8.Programs = programs;
                    dialog8.SelectedEvent = SelectedEvent;
                    dialog8.SelectedPage = SelectedPage;
                    dialog8.ProgramData = data;
                    if (dialog8.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog8.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 9: // Tint Picture
                    TintPictureDialog dialog9 = new TintPictureDialog();
                    dialog9.Programs = programs;
                    dialog9.SelectedEvent = SelectedEvent;
                    dialog9.SelectedPage = SelectedPage;
                    dialog9.ProgramData = data;
                    if (dialog9.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog9.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 11: // Show Particle
                    ShowParticleDialog dialog10 = new ShowParticleDialog();
                    dialog10.Programs = programs;
                    dialog10.SelectedEvent = SelectedEvent;
                    dialog10.SelectedPage = SelectedPage;
                    dialog10.ProgramData = data;
                    if (dialog10.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog10.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 12: // Edit Particle
                    MoveParticleDialog dialog11 = new MoveParticleDialog();
                    dialog11.Programs = programs;
                    dialog11.SelectedEvent = SelectedEvent;
                    dialog11.SelectedPage = SelectedPage;
                    dialog11.ProgramData = data;
                    if (dialog11.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog11.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 13: // Erase Particle
                    EraseParticleDialog dialog13 = new EraseParticleDialog();
                    dialog13.Programs = programs;
                    dialog13.SelectedEvent = SelectedEvent;
                    dialog13.SelectedPage = SelectedPage;
                    dialog13.ProgramData = data;
                    if (dialog13.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog13.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 14: // SetOptions
                    SetOptionsDialog dialog14 = new SetOptionsDialog();
                    dialog14.Programs = programs;
                    dialog14.SelectedEvent = SelectedEvent;
                    dialog14.SelectedPage = SelectedPage;
                    dialog14.ProgramData = data;
                    if (dialog14.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog14.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;


                        if (list.SelectedNode.Text != data.Name && list.SelectedNode.Parent.Text == data.Name)
                            list.SelectedNode = list.SelectedNode.Parent;

                        list.SelectedNode.Nodes.Clear();

                        // Program Display - Options
                        List<object> options = (List<object>)data.Value[0];
                        TreeNode dNode;
                        string text;
                        for (int i = 0; i < options.Count; i++)
                        {
                            if (options[i] is int)
                            {
                                text = "Text [" + options[i].ToString() + "]";
                            }
                            else
                                text = options[i].ToString();
                            dNode = new TreeNode(options[i].ToString());
                            dNode.Tag = data;
                            dNode.ForeColor = list.SelectedNode.ForeColor;
                            dNode.Checked = false;
                            list.SelectedNode.Nodes.Add(dNode);
                        }
                        if (data.Expand)
                            list.SelectedNode.Expand();
                        return true;
                    }
                    break;
                case 15: // SetOptions
                    ShowShopDialog dialog15 = new ShowShopDialog();
                    dialog15.Programs = programs;
                    dialog15.SelectedEvent = SelectedEvent;
                    dialog15.SelectedPage = SelectedPage;
                    dialog15.ProgramData = data;
                    if (dialog15.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog15.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 18: // Move Picture
                    ScalePictureDialog dialog18 = new ScalePictureDialog();
                    dialog18.Programs = programs;
                    dialog18.SelectedEvent = SelectedEvent;
                    dialog18.SelectedPage = SelectedPage;
                    dialog18.ProgramData = data;
                    if (dialog18.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog18.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 19: // Move Picture
                    RotatePictureDialog dialog19 = new RotatePictureDialog();
                    dialog19.Programs = programs;
                    dialog19.SelectedEvent = SelectedEvent;
                    dialog19.SelectedPage = SelectedPage;
                    dialog19.ProgramData = data;
                    if (dialog19.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog19.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryConditions(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list, ref bool setup)
        {
            bool el = false;
            switch (data.Code)
            {
                case 1: // Switch
                    SwitchConditionDialog dialog1 = new SwitchConditionDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }
                        return true;
                    }
                    break;
                case 2: // Variable
                    VariableConditionDialog dialog2 = new VariableConditionDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
                case 3: // List
                    ListConditionDialog dialog3 = new ListConditionDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
                case 4: // Database;
                    DataConditionDialog dialog4 = new DataConditionDialog();
                    dialog4.Programs = programs;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.ProgramData = data;
                    if (dialog4.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog4.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
                case 5: // Button Input
                    ButtonInputConditionDialog dialog5 = new ButtonInputConditionDialog();
                    dialog5.Programs = programs;
                    dialog5.SelectedEvent = SelectedEvent;
                    dialog5.SelectedPage = SelectedPage;
                    dialog5.ProgramData = data;
                    if (dialog5.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog5.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
                case 6: // Mouse Input
                    MouseConditionDialog dialog6 = new MouseConditionDialog();
                    dialog6.Programs = programs;
                    dialog6.SelectedEvent = SelectedEvent;
                    dialog6.SelectedPage = SelectedPage;
                    dialog6.ProgramData = data;
                    if (dialog6.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog6.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
                case 7: // Event
                    EventConditionDialog dialog7 = new EventConditionDialog();
                    dialog7.Programs = programs;
                    dialog7.SelectedEvent = SelectedEvent;
                    dialog7.SelectedPage = SelectedPage;
                    dialog7.ProgramData = data;
                    if (dialog7.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog7.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
                case 8: // Timer
                    TimerConditionDialog dialog8 = new TimerConditionDialog();
                    dialog8.Programs = programs;
                    dialog8.SelectedEvent = SelectedEvent;
                    dialog8.SelectedPage = SelectedPage;
                    dialog8.ProgramData = data;
                    if (dialog8.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog8.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
                case 9: // String
                    StringCondition dialog9 = new StringCondition();
                    dialog9.Programs = programs;
                    dialog9.SelectedEvent = SelectedEvent;
                    dialog9.SelectedPage = SelectedPage;
                    dialog9.ProgramData = data;
                    if (dialog9.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog9.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
                case 10: // Other
                    OtherConditionDialog dialog10 = new OtherConditionDialog();
                    dialog10.Programs = programs;
                    dialog10.SelectedEvent = SelectedEvent;
                    dialog10.SelectedPage = SelectedPage;
                    dialog10.ProgramData = data;
                    if (dialog10.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog10.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }
                        return true;
                    }
                    break;
                case 11: // Other
                    ItemSkillConditionDialog dialog11 = new ItemSkillConditionDialog();
                    dialog11.Programs = programs;
                    dialog11.SelectedEvent = SelectedEvent;
                    dialog11.SelectedPage = SelectedPage;
                    dialog11.ProgramData = data;
                    if (dialog11.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog11.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
                case 12: // Other
                    HeroConditionsDialog dialog12 = new HeroConditionsDialog();
                    dialog12.Programs = programs;
                    dialog12.SelectedEvent = SelectedEvent;
                    dialog12.SelectedPage = SelectedPage;
                    dialog12.ProgramData = data;
                    if (dialog12.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog12.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        el = data.Else;
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        if (el != data.Else)
                        {
                            if (data.Else)
                            {
                                setup = true;
                            }
                            else
                            {
                                setup = true;
                            }
                        }

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryLoop(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // Loop
                    break;
                case 2: // Break Loop
                    break;
                case 3: // Label
                    LabelDialog dialog1 = new LabelDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4: // Go To Label
                    GoToLabelDialog dialog2 = new GoToLabelDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryAudio(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // Play Audio
                    AudioPlayDialog dialog1 = new AudioPlayDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 2: // Control Audio Channel
                    AudioControlsDialog dialog2 = new AudioControlsDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 3: // Create PlayList
                    PlayListDialog dialog3 = new PlayListDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4: // Control PlayList
                    PlaylistControls dialog4 = new PlaylistControls();
                    dialog4.Programs = programs;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.ProgramData = data;
                    if (dialog4.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog4.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 5: // Play 3D Audio
                    Audio3DPlayDialog dialog5 = new Audio3DPlayDialog();
                    dialog5.Programs = programs;
                    dialog5.SelectedEvent = SelectedEvent;
                    dialog5.SelectedPage = SelectedPage;
                    dialog5.ProgramData = data;
                    if (dialog5.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog5.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 6: // Control 3D Audio
                    AudioCTRLDialog dialog6 = new AudioCTRLDialog();
                    dialog6.Programs = programs;
                    dialog6.SelectedEvent = SelectedEvent;
                    dialog6.SelectedPage = SelectedPage;
                    dialog6.ProgramData = data;
                    if (dialog6.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog6.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryData(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // Switch
                    EditSwitchDialog dialog1 = new EditSwitchDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 2: // Variable
                    EditVariableDialog dialog2 = new EditVariableDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 3: // Local Switch
                    LocalSwitchConditionDialog dialog3 = new LocalSwitchConditionDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4: // Local Variable
                    EditVariableDialog dialog4 = new EditVariableDialog();
                    dialog4.IsLocal = true; dialog4.Variables = SelectedEvent.Variables;
                    dialog4.Programs = programs;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.ProgramData = data;
                    if (dialog4.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog4.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 5: // List
                    EditListDialog dialog5 = new EditListDialog();
                    dialog5.Programs = programs;
                    dialog5.SelectedEvent = SelectedEvent;
                    dialog5.SelectedPage = SelectedPage;
                    dialog5.ProgramData = data;
                    if (dialog5.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog5.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 6: // Database
                    EditDatabaseValueDialog dialog6 = new EditDatabaseValueDialog();
                    dialog6.Programs = programs;
                    dialog6.SelectedEvent = SelectedEvent;
                    dialog6.SelectedPage = SelectedPage;
                    dialog6.ProgramData = data;
                    if (dialog6.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog6.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 7: // String
                    EditStringDialog dialog7 = new EditStringDialog();
                    dialog7.Programs = programs;
                    dialog7.SelectedEvent = SelectedEvent;
                    dialog7.SelectedPage = SelectedPage;
                    dialog7.ProgramData = data;
                    if (dialog7.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog7.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 8: // String
                    EditEventSwitchesDialog dialog8 = new EditEventSwitchesDialog();
                    dialog8.Programs = programs;
                    dialog8.SelectedEvent = SelectedEvent;
                    dialog8.SelectedPage = SelectedPage;
                    dialog8.ProgramData = data;
                    if (dialog8.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog8.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryEvent(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // Create Event
                    AddEventDialog dialog1 = new AddEventDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 2: // Edit Event Animation
                    ChangeAnimationDialog dialog2 = new ChangeAnimationDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 3: // Set Event Location
                    SetEventLocation dialog3 = new SetEventLocation();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4: // Delete Event
                    DeleteEventDialog dialog4 = new DeleteEventDialog();
                    dialog4.Programs = programs;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.ProgramData = data;
                    if (dialog4.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog4.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 5: // Exit Branch
                    break;
                case 6: // Activate Global Event
                    ActivateGlobalEventDialog dialog6 = new ActivateGlobalEventDialog();
                    dialog6.Programs = programs;
                    dialog6.SelectedEvent = SelectedEvent;
                    dialog6.SelectedPage = SelectedPage;
                    dialog6.ProgramData = data;
                    if (dialog6.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog6.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 7: // Change Event Layer
                    EventLayerDialog dialog7 = new EventLayerDialog();
                    dialog7.Programs = programs;
                    dialog7.SelectedEvent = SelectedEvent;
                    dialog7.SelectedPage = SelectedPage;
                    dialog7.ProgramData = data;
                    if (dialog7.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog7.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 8: // Edit Event Particle
                    EditEventParticle dialog8 = new EditEventParticle();
                    dialog8.Programs = programs;
                    dialog8.SelectedEvent = SelectedEvent;
                    dialog8.SelectedPage = SelectedPage;
                    dialog8.ProgramData = data;
                    if (dialog8.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog8.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 9: // Knockbackfield
                    ApplyKnockbackFieldDialog dialog9 = new ApplyKnockbackFieldDialog();
                    dialog9.Programs = programs;
                    dialog9.SelectedEvent = SelectedEvent;
                    dialog9.SelectedPage = SelectedPage;
                    dialog9.ProgramData = data;
                    if (dialog9.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog9.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 12: // 
                    ApplyEffectToEventDialog dialog10 = new ApplyEffectToEventDialog();
                    dialog10.Programs = programs;
                    dialog10.SelectedEvent = SelectedEvent;
                    dialog10.SelectedPage = SelectedPage;
                    dialog10.ProgramData = data;
                    if (dialog10.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog10.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 13: // 
                    GravityEventsDialog dialog13 = new GravityEventsDialog();
                    dialog13.Programs = programs;
                    dialog13.SelectedEvent = SelectedEvent;
                    dialog13.SelectedPage = SelectedPage;
                    dialog13.ProgramData = data;
                    if (dialog13.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog13.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryMap(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // Toggle Map Layer
                    ToggleMapLayerDialog dialog1 = new ToggleMapLayerDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 2: // Transfer Event
                    TransferPlayerDialog dialog2 = new TransferPlayerDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 3: // Fog
                    EditFogDialog dialog3 = new EditFogDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4: // Weather
                    EditWeatherDialog dialog4 = new EditWeatherDialog();
                    dialog4.Programs = programs;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.ProgramData = data;
                    if (dialog4.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog4.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 5: // Camera
                    CameraSettingsDialog dialog5 = new CameraSettingsDialog();
                    dialog5.Programs = programs;
                    dialog5.SelectedEvent = SelectedEvent;
                    dialog5.SelectedPage = SelectedPage;
                    dialog5.ProgramData = data;
                    if (dialog5.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog5.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 6: // Camera
                    CenterCameraDialog dialog6 = new CenterCameraDialog();
                    dialog6.Programs = programs;
                    dialog6.SelectedEvent = SelectedEvent;
                    dialog6.SelectedPage = SelectedPage;
                    dialog6.ProgramData = data;
                    if (dialog6.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog6.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 7: // Camera
                    ScrollCameraToDialog dialog7 = new ScrollCameraToDialog();
                    dialog7.Programs = programs;
                    dialog7.SelectedEvent = SelectedEvent;
                    dialog7.SelectedPage = SelectedPage;
                    dialog7.ProgramData = data;
                    if (dialog7.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog7.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 8: // Camera
                    ChangeGravityDialog dialog8 = new ChangeGravityDialog();
                    dialog8.Programs = programs;
                    dialog8.SelectedEvent = SelectedEvent;
                    dialog8.SelectedPage = SelectedPage;
                    dialog8.ProgramData = data;
                    if (dialog8.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog8.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 10: // 
                    ApplyEffectToMapDialog dialog10 = new ApplyEffectToMapDialog();
                    dialog10.Programs = programs;
                    dialog10.SelectedEvent = SelectedEvent;
                    dialog10.SelectedPage = SelectedPage;
                    dialog10.ProgramData = data;
                    if (dialog10.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog10.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 11: // 
                    GravityPointsDialog dialog11 = new GravityPointsDialog();
                    dialog11.Programs = programs;
                    dialog11.SelectedEvent = SelectedEvent;
                    dialog11.SelectedPage = SelectedPage;
                    dialog11.ProgramData = data;
                    if (dialog11.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog11.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 12: // 
                    AttachCameraToEventDialog dialog12 = new AttachCameraToEventDialog();
                    dialog12.Programs = programs;
                    dialog12.SelectedEvent = SelectedEvent;
                    dialog12.SelectedPage = SelectedPage;
                    dialog12.ProgramData = data;
                    if (dialog12.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog12.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryScreen(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // FadeOut
                    break;
                case 2: // FadeIn
                    break;
                case 3: // Tint Screen
                    TintEventDialog dialog1 = new TintEventDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4: // Flash
                    FlashScreenEventDialog dialog2 = new FlashScreenEventDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 5: // Shake
                    ShakeScreenEventDialog dialog3 = new ShakeScreenEventDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 6: // Zoom
                    ZoomDialog dialog6 = new ZoomDialog();
                    dialog6.Programs = programs;
                    dialog6.SelectedEvent = SelectedEvent;
                    dialog6.SelectedPage = SelectedPage;
                    dialog6.ProgramData = data;
                    if (dialog6.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog6.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryMemory(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // Save
                    SaveStateDialog dialog1 = new SaveStateDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 2: // Load
                    LoadStateDialog dialog2 = new LoadStateDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 8: // Load
                    ShowFriendsDialog dialog8 = new ShowFriendsDialog();
                    dialog8.Programs = programs;
                    dialog8.SelectedEvent = SelectedEvent;
                    dialog8.SelectedPage = SelectedPage;
                    dialog8.ProgramData = data;
                    if (dialog8.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog8.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 11: // Load
                    ShowStorageDialog dialog11 = new ShowStorageDialog();
                    dialog11.Programs = programs;
                    dialog11.SelectedEvent = SelectedEvent;
                    dialog11.SelectedPage = SelectedPage;
                    dialog11.ProgramData = data;
                    if (dialog11.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog11.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryOther(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1:
                    WaitDialog dialog5 = new WaitDialog();
                    dialog5.Programs = programs;
                    dialog5.SelectedEvent = SelectedEvent;
                    dialog5.SelectedPage = SelectedPage;
                    dialog5.ProgramData = data;
                    if (dialog5.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog5.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 3:
                    CommentDialog dialog1 = new CommentDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4:
                    TimerDialog dialog2 = new TimerDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 5:
                    VibrateControllerDialog dialog3 = new VibrateControllerDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 6:
                    ControllerDeadzoneDialog dialog4 = new ControllerDeadzoneDialog();
                    dialog4.Programs = programs;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.ProgramData = data;
                    if (dialog4.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog4.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 9:
                    ChangeResDialog dialog9 = new ChangeResDialog();
                    dialog9.Programs = programs;
                    dialog9.SelectedEvent = SelectedEvent;
                    dialog9.SelectedPage = SelectedPage;
                    dialog9.ProgramData = data;
                    if (dialog9.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog9.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 11:
                    ToggleControlsDialog dialog11 = new ToggleControlsDialog();
                    dialog11.Programs = programs;
                    dialog11.SelectedEvent = SelectedEvent;
                    dialog11.SelectedPage = SelectedPage;
                    dialog11.ProgramData = data;
                    if (dialog11.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog11.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 12:
                    HotKeysDialog dialog12 = new HotKeysDialog();
                    dialog12.Programs = programs;
                    dialog12.SelectedEvent = SelectedEvent;
                    dialog12.SelectedPage = SelectedPage;
                    dialog12.ProgramData = data;
                    if (dialog12.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog12.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 13:
                    LockScreenDialog dialog13 = new LockScreenDialog();
                    dialog13.Programs = programs;
                    dialog13.SelectedEvent = SelectedEvent;
                    dialog13.SelectedPage = SelectedPage;
                    dialog13.ProgramData = data;
                    if (dialog13.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog13.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryParty(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // Change Party Member
                    ChangePartyMemberDialog dialog2 = new ChangePartyMemberDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 5: // Party Conditions Dialog
                    PartyConditionsDialog dialog5 = new PartyConditionsDialog();
                    dialog5.Programs = programs;
                    dialog5.SelectedEvent = SelectedEvent;
                    dialog5.SelectedPage = SelectedPage;
                    dialog5.ProgramData = data;
                    if (dialog5.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog5.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 6:
                    UseItemMDialog dialog3 = new UseItemMDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 7:
                    UseSkillMDialog dialog7 = new UseSkillMDialog();
                    dialog7.Programs = programs;
                    dialog7.SelectedEvent = SelectedEvent;
                    dialog7.SelectedPage = SelectedPage;
                    dialog7.ProgramData = data;
                    if (dialog7.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog7.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 9:
                    ChangeItemsVariableDialog dialog9 = new ChangeItemsVariableDialog();
                    dialog9.Programs = programs;
                    dialog9.SelectedEvent = SelectedEvent;
                    dialog9.SelectedPage = SelectedPage;
                    dialog9.ProgramData = data;
                    if (dialog9.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog9.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 10:
                    ChangeEquipmentsVariableDialog dialog10 = new ChangeEquipmentsVariableDialog();
                    dialog10.Programs = programs;
                    dialog10.SelectedEvent = SelectedEvent;
                    dialog10.SelectedPage = SelectedPage;
                    dialog10.ProgramData = data;
                    if (dialog10.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog10.ProgramData;
                        data.Name = a.Name;
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        public static bool EditCategoryHero(EventProgramData data, List<EventProgramData> programs, IEvent SelectedEvent, EventPageData SelectedPage, DataPropertyDelegate propChanged, UndoRedoHistory<IHistory> SelectedHistory, CustomTreeView list)
        {
            switch (data.Code)
            {
                case 1: // Change Name
                    ChangeNameDialog dialog1 = new ChangeNameDialog();
                    dialog1.Programs = programs;
                    dialog1.SelectedEvent = SelectedEvent;
                    dialog1.SelectedPage = SelectedPage;
                    dialog1.ProgramData = data;
                    if (dialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog1.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 2: // Change Equipment
                    ChangeEquipmentDialog dialog2 = new ChangeEquipmentDialog();
                    dialog2.Programs = programs;
                    dialog2.SelectedEvent = SelectedEvent;
                    dialog2.SelectedPage = SelectedPage;
                    dialog2.ProgramData = data;
                    if (dialog2.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog2.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 3: // Change State
                    ChangeStateDialog dialog3 = new ChangeStateDialog();
                    dialog3.Programs = programs;
                    dialog3.SelectedEvent = SelectedEvent;
                    dialog3.SelectedPage = SelectedPage;
                    dialog3.ProgramData = data;
                    if (dialog3.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog3.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 4: // Heal All
                    HealAllDialog dialog4 = new HealAllDialog();
                    dialog4.Programs = programs;
                    dialog4.SelectedEvent = SelectedEvent;
                    dialog4.SelectedPage = SelectedPage;
                    dialog4.ProgramData = data;
                    if (dialog4.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog4.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 5: // Skill
                    ChangeSkillDialog dialog5 = new ChangeSkillDialog();
                    dialog5.Programs = programs;
                    dialog5.SelectedEvent = SelectedEvent;
                    dialog5.SelectedPage = SelectedPage;
                    dialog5.ProgramData = data;
                    if (dialog5.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog5.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 6: // Magic
                    ChangeMagicDialog dialog6 = new ChangeMagicDialog();
                    dialog6.Programs = programs;
                    dialog6.SelectedEvent = SelectedEvent;
                    dialog6.SelectedPage = SelectedPage;
                    dialog6.ProgramData = data;
                    if (dialog6.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog6.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 7: // Parameter
                    ChangeParameterDialog dialog7 = new ChangeParameterDialog();
                    dialog7.Programs = programs;
                    dialog7.SelectedEvent = SelectedEvent;
                    dialog7.SelectedPage = SelectedPage;
                    dialog7.ProgramData = data;
                    if (dialog7.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog7.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 8: // Change Items
                    ChangeItemsDialog dialog8 = new ChangeItemsDialog();
                    dialog8.Programs = programs;
                    dialog8.SelectedEvent = SelectedEvent;
                    dialog8.SelectedPage = SelectedPage;
                    dialog8.ProgramData = data;
                    if (dialog8.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog8.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 9: // Change Equipments
                    ChangeEquipmentsDialog dialog9 = new ChangeEquipmentsDialog();
                    dialog9.Programs = programs;
                    dialog9.SelectedEvent = SelectedEvent;
                    dialog9.SelectedPage = SelectedPage;
                    dialog9.ProgramData = data;
                    if (dialog9.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog9.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
                case 10: // Change Equipments
                    ChangeHeroAnimationDialog dialog10 = new ChangeHeroAnimationDialog();
                    dialog10.Programs = programs;
                    dialog10.SelectedEvent = SelectedEvent;
                    dialog10.SelectedPage = SelectedPage;
                    dialog10.ProgramData = data;
                    if (dialog10.ShowDialog() == DialogResult.OK)
                    {
                        if (SelectedHistory != null) SelectedHistory.Do(new IGameDataChangePropertyHist(data, propChanged));

                        EventProgramData a = dialog10.ProgramData;
                        data.Name = a.GetName(SelectedEvent, SelectedPage);
                        data.ProgramCategory = a.ProgramCategory;
                        data.Code = a.Code;
                        data.Value = (object[])a.Value.Clone();
                        data.Enabled = a.Enabled; data.Else = a.Else;

                        return true;
                    }
                    break;
            }
            return false;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.Redo();
        }

        private void list_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                editBtn_Click(this, e);
            }
        }

    }
}
