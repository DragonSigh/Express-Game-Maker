using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using EGMGame.Library;

namespace EGMGame.Docking.Explorers
{
    public partial class MapEventsExplorer : DockContent
    {

        List<EventData> events = new List<EventData>();
        List<bool> nodes = new List<bool>();

        public MapEventsExplorer()
        {
            InitializeComponent();
            // GUI Initialization
            toolStrip1.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
        }

        private void MapEventsExplorer_Shown(object sender, EventArgs e)
        {
            SetupList();
        }

        private void MapEventsExplorer_Activated(object sender, EventArgs e)
        {
            SetupList();
        }

        public void SetupList()
        {
            list.Nodes.Clear();
            events.Clear();
            TreeNode node;
            if (MainForm.SelectedMap != null)
            {
                int i = 0;
                int j = 0;
                foreach (LayerData layer in MainForm.SelectedMap.Layers)
                {
                    node = new TreeNode(layer.Name, 0, 0);
                    list.Nodes.Add(node);
                    foreach (EventData e in layer.Events.Values)
                    {
                        events.Add(e);
                        node = new TreeNode(e.Name, 1, 1);
                        node.Tag = j;
                        list.Nodes[i].Nodes.Add(node);
                        j++;
                    }
                    if (GameData.Player.MapID == MainForm.SelectedMap.ID && GameData.Player.LayerIndex == i)
                    {
                        events.Add(GameData.Player);
                        node = new TreeNode(GameData.Player.Name, 1, 1);
                        node.Tag = j;
                        list.Nodes[i].Nodes.Add(node);
                        j++;
                    }
                    if (i >= nodes.Count)
                    {
                        nodes.Add(true);
                    }
                    i++;
                }

                for (int k = 0; k < list.Nodes.Count; k++)
                {
                    if (nodes[k])
                        list.Nodes[k].Expand();
                }
            }
        }

        public void RemoveEvent()
        {

        }

        internal void Setup()
        {
            SetupList();
        }

        private void list_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            nodes[e.Node.Index] = false;
        }

        private void list_AfterExpand(object sender, TreeViewEventArgs e)
        {
            nodes[e.Node.Index] = true;
        }

        private void list_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode treeNode = list.GetNodeAt(e.Location);
            if (treeNode != null)
                list.SelectedNode = treeNode;
        }

        private void list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list.SelectedNode != null)
            {
                if (list.SelectedNode.Parent != null)
                {
                    if (events[(int)list.SelectedNode.Tag] is PlayerData)
                    {
                        MainForm.playerEditor.Show();
                        return;
                    }
                    if (!MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.Visible)
                        MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.Show(MainForm.mapEditor.mapEditor2.mapViewer);
                    MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.SelectedEvent = events[(int)list.SelectedNode.Tag];
                }
            }
        }

        private void list_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode n = (TreeNode)e.Item;
            if (n.Parent != null)
                DoDragDrop(n, DragDropEffects.Copy);
        }

        private void list_DragOver(object sender, DragEventArgs e)
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
            catch
            {
            }
        }

        private void list_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
            Point p = list.PointToClient(new Point(e.X, e.Y));
            TreeNode overNode = list.GetNodeAt(p);
            if (list.SelectedNode == node && overNode != node && overNode != null)
            {
                // Category Header
                if (overNode.Parent != null)
                {
                    // Event, so get category
                    overNode = overNode.Parent;
                }
                // Get layer index
                int index = overNode.Index;
                // Get selected event
                EventData ev = events[(int)node.Tag];
                if (ev is PlayerData)
                {
                    GameData.Player.LayerIndex = index;
                    // Setup List
                    SetupList();
                    // Need Save
                    MainForm.NeedSave = true;
                }
                else
                {
                    // Get the event's layer index
                    int evIndex = Global.GetLayerIndex(ev, MainForm.SelectedMap);
                    // Remove from the layer
                    if (evIndex != index)
                    {
                        MainForm.SelectedMap.Layers[evIndex].Events.Remove(ev.ID);
                        // Add it to new layer
                        MainForm.SelectedMap.Layers[index].Events.Add(ev.ID, ev);
                        // Setup List
                        SetupList();
                        // Need Save
                        MainForm.NeedSave = true;
                    }
                }
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (list.SelectedNode != null && list.SelectedNode.Parent != null)
            {
                if ((int)list.SelectedNode.Tag < events.Count)
                {
                    if (MessageBox.Show("Are you sure you want to delete event " + list.SelectedNode.Text + "?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        // Get selected event
                        EventData ev = events[(int)list.SelectedNode.Tag];
                        // Get the event's layer index
                        int evIndex = Global.GetLayerIndex(ev, MainForm.SelectedMap);

                        MainForm.MapEditorHistory[MainForm.mapEditor.mapEditor2.mapViewer].Do(new EventRemovedHist(ev, new DataEAddDelegate(MainForm.mapEditor.mapEditor2.mapViewer.EventAdded), new DataERemoveDelegate(MainForm.mapEditor.mapEditor2.mapViewer.EventRemoved), MainForm.SelectedMap.Layers[evIndex]));

                        MainForm.SelectedMap.Layers[evIndex].Events.Remove(ev.ID);
                        SetupList();
                        // Need Save
                        MainForm.NeedSave = true;
                    }
                }
            }
        }


        internal bool RealVisible = false;
        bool allowVisisbleChange = true;
        private void Explorer_VisibleChanged(object sender, EventArgs e)
        {
            if (allowVisisbleChange && EGMGame.Docking.Editors.MapEditor.allowActivateChange)
            {
               // RealVisible = this.Visible;
            }
        }

        internal void CheckVisibility(bool p)
        {
            allowVisisbleChange = false;
            if (this.dockState == DockState.Float)
            {
                if (p)
                {
                    if (RealVisible)
                    {
                        this.Show(MainForm.Instance.dockPanel);
                    }
                }
                else
                {
                    //RealVisible = this.Visible;
                    this.Hide();
                }
            }
            allowVisisbleChange = true;
        }

        DockState dockState = DockState.Unknown;
        protected override void OnDockStateChanged(EventArgs e)
        {
            base.OnDockStateChanged(e);
            if (this.DockState != DockState.Unknown && this.DockState != DockState.Hidden)
                this.dockState = this.DockState;
        }

        internal bool isActive = false;

        internal void ResetProject()
        {
            SetupList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.SelectedNode != null)
            {
                if (list.SelectedNode.Parent != null)
                {
                    if (events[(int)list.SelectedNode.Tag] is PlayerData)
                    {
                        MainForm.playerEditor.Show();
                        return;
                    }
                    if (!MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.Visible)
                        MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.Show(MainForm.mapEditor.mapEditor2.mapViewer);
                    MainForm.mapEditor.mapEditor2.mapViewer.eventDialog.SelectedEvent = events[(int)list.SelectedNode.Tag];
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeBtn_Click(null, null);
        }
    }
}
