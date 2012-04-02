using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using GenericUndoRedo;

namespace EGMGame.Docking.Explorers
{
    public partial class HistoryExplorer : DockContent
    {
        #region Variables
        UndoRedoHistory<IHistory> selectedHistory;
        List<string> list;
        int undoIndex;

        // Allow Change
        bool allowChange = false;
        public bool UndoRedoEnabled
        {
            get { return selectedHistory.UndoRedoEnabled; }
            set { if (selectedHistory != null)
                selectedHistory.UndoRedoEnabled = value;}
        }
        #endregion

        #region Properties
        public UndoRedoHistory<IHistory> SelectedHistory
        {
            get { return selectedHistory; }
            set { selectedHistory = value; RefreshList(); }
        }
        #endregion
        // Construct
        public HistoryExplorer()
        {
            InitializeComponent();
        }

        #region Methods
        public void RefreshList()
        {
            allowChange = false;
            // Disable
            clearBtn.Enabled = false;
            undoBtn.Enabled = false;
            redoBtn.Enabled = false;
            MainForm.Instance.undoToolStripMenuItem.Enabled = false;
            MainForm.Instance.redoToolStripMenuItem.Enabled = false;
            MainForm.Instance.undoBtn.Enabled = false;
            MainForm.Instance.redoBtn.Enabled = false;
            historyList.Items.Clear();

            if (selectedHistory != null)
            {
                // Index
                undoIndex = 0;
                list = new List<string>();
                // Loop All Undos
                for (int i = 0; i < selectedHistory.UndoStack.Items.Length; i++)
                {
                    if (selectedHistory.UndoStack.Items[i] != null)
                        list.Add(((IHistory)selectedHistory.UndoStack.Items[i]).GetActionName());
                }
                undoIndex = list.Count - 1;
                if (list.Count > 0)
                {
                    undoBtn.Enabled = true;
                    MainForm.Instance.undoToolStripMenuItem.Enabled = true;
                    MainForm.Instance.undoBtn.Enabled = true;
                    list.Reverse();
                    foreach (string item in list)
                    {
                        //MainForm.curForm.undoBtn.DropDownItems.Add(item);
                    }
                    list.Reverse();
                }
                // Loop All Redos
                for (int i = 0; i < selectedHistory.RedoStack.Items.Length; i++)
                {
                    if (selectedHistory.RedoStack.Items[i] != null)
                        list.Add(((IHistory)selectedHistory.RedoStack.Items[i]).GetActionName());
                }
                list.Reverse(undoIndex + 1, list.Count - undoIndex - 1);
                if (undoIndex < list.Count - 1)
                {
                    redoBtn.Enabled = true;
                    MainForm.Instance.redoToolStripMenuItem.Enabled = true;
                    MainForm.Instance.redoBtn.Enabled = true;
                    int i = 0;
                    foreach (string item in list)
                    {
                        if (i <= undoIndex) { i++; continue; }
                        //MainForm.curForm.redoBtn.DropDownItems.Add(item);
                    }
                }
                // Add To ListBox
                historyList.DataList = list;
                if (historyList.Items.Count > 0) historyList.SelectedIndex = undoIndex;
                if (list.Count > 0) clearBtn.Enabled = true;
            }
            allowChange = true;
        }
        #endregion

        #region Events
        private void historyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                if (historyList.SelectedIndex > -1)
                {
                    if (historyList.SelectedIndex > undoIndex)
                    {
                        // Redo
                        int diff = historyList.SelectedIndex - undoIndex;
                        // Redo Times
                        selectedHistory.Redo(diff);
                    }
                    else if (historyList.SelectedIndex < undoIndex)
                    {
                        // Undo
                        int diff = undoIndex - historyList.SelectedIndex;
                        // Undo Times
                        selectedHistory.Undo(diff);
                    }
                }
            }
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            selectedHistory.Undo();
        }

        private void redoBtn_Click(object sender, EventArgs e)
        {
            selectedHistory.Redo();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            selectedHistory.Clear();
        }
        #endregion

        internal void Undo()
        {
            if (selectedHistory != null) selectedHistory.Undo();
        }

        internal void Redo()
        {
            if (selectedHistory != null) selectedHistory.Redo();
        }

        internal void Undo(int i)
        {
            if (selectedHistory != null) selectedHistory.Undo(i);
        }

        internal void Redo(int i)
        {
            if (selectedHistory != null) selectedHistory.Redo(i);
        }

        internal void ResetProject()
        {
            selectedHistory.Clear(); RefreshList();
        }
    }
}
