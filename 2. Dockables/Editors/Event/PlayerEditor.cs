//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
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
using EGMGame.Library;

namespace EGMGame.Docking.Editors
{
    public partial class PlayerEditor : DockContent, IHistory
    {
        public PlayerEditor()
        {
            MainForm.PlayerHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }

        private void PlayerEditor_Activated(object sender, EventArgs e)
        {
            MainForm.HistoryExplorer.SelectedHistory = MainForm.PlayerHistory[this];
        }

        private void PlayerEditor_Shown(object sender, EventArgs e)
        {
            playerPageControl1.SelectedEvent = GameData.Player;
            playerPageControl1.SelectedEventPage = GameData.Player.Page;
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

        private void PlayerEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        #region IHistory Members

        string IHistory.GetActionName()
        {
            throw new NotImplementedException();
        }

        #endregion


        internal void ResetProject()
        {
            playerPageControl1.ResetProject();

            playerPageControl1.SelectedEvent = GameData.Player;
            playerPageControl1.SelectedEventPage = GameData.Player.Page;

        }

        internal void Unload()
        {
            playerPageControl1.Unload();

        }
    }
}
