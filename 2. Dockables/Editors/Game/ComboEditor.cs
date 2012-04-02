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
    public partial class ComboEditor : DockContent, IHistory, IEditor
    {
        bool allowChange = true;
        
        public ComboEditor()
        {
            MainForm.CombosHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();

            allowChange = false;
            cbEffects.SelectedIndex = 0;
            allowChange = true;
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetupList();
        }

        public void SetupList()
        {
            addRemoveList.SetupList(GameData.Combos, typeof(ComboData));
        }

        private void ComboEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.CombosHistory[this];
            SetupList();
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Combos.Add(data.ID, (ComboData)data);
            addRemoveList.AddNode(data);
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        private void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Combos.Remove(data.ID);

            addRemoveList.RemoveNode(data);
        }
        #endregion

        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(ComboData obj)
        {
            allowChange = false;

            if (obj != null)
            {
                impactGroupBox1.Enabled = true;
                startNud.Value = (decimal)obj.StartCombo;
                endNud.Value = (decimal)obj.EndCombo;
                cbEffects.SelectedIndex = (int)obj.Effect;
            }
            else
            {
                startNud.Value = startNud.Minimum;
                endNud.Value = endNud.Minimum;
                impactGroupBox1.Enabled = false;
            }
            allowChange = true;
        }

        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                ComboData a = new ComboData();
                a.Name = Global.GetName("Combo", GameData.Combos);
                a.ID = Global.GetID(GameData.Combos);
                a.Category = ca.Category;
                GameData.Combos.Add(a.ID, a);
                int index = a.ID;
                // History
                MainForm.CombosHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "7x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Combos.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.CombosHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Combos.Remove(addRemoveList.SelectedID);
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(GameData.Combos[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "7x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.Combos.ContainsKey(e.ID))
                    SetupProperty(GameData.Combos[e.ID]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "7x003");
            }
        }
        #endregion

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange)
                return;
            if (addRemoveList.Data().ID > -1)
            {
                addRemoveList.Data<ComboData>().StartCombo = (int)startNud.Value;
            }
        }

        private void endNud_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange)
                return;
            if (addRemoveList.Data().ID > -1)
            {
                addRemoveList.Data<ComboData>().EndCombo = (int)endNud.Value;
            }
        }

        private void cbEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange)
                return;
            if (addRemoveList.Data().ID > -1)
            {
                addRemoveList.Data<ComboData>().Effect = (ComboEffect)cbEffects.SelectedIndex;
            }
        }

        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        #region IEditor Members

        void IEditor.SetupList()
        {
            throw new NotImplementedException();
        }

        #endregion

        internal void ResetProject()
        {
            SetupList();
        }
    }
}
