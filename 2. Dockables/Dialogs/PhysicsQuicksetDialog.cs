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
    public partial class PhysicsQuicksetDialog : DockContent
    {
        bool allowChange = true;


        static List<PhysQuicksetData> physQuicksets;


        public PhysicsQuicksetDialog()
        {
            InitializeComponent();

            physQuicksets = Global.Duplicate<List<PhysQuicksetData>>(GameData.PhysQuicksets);
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);



            SetupList();
        }

        public void SetupList()
        {
            addRemoveList.SetupList(physQuicksets, typeof(PhysQuicksetData));
        }

        private void PhysQuicksetEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            //MainForm.HistoryExplorer.SelectedHistory = MainForm.PhysQuicksetsHistory[this];
            SetupList();
        }

        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(PhysQuicksetData data)
        {
            allowChange = false;

            if (data != null)
            {
                nudFriction.Value = (decimal)data.Friction;
                nudBounce.Value = (decimal)data.Bounce;
                nudVelocityX.Value = (decimal)data.Impulse;
                nudMass.Value = (decimal)data.Mass;
                nudForce.Value = (decimal)data.Force;
                nudDrag.Value = (decimal)data.LinearDrag;
                nudRotDrag.Value = (decimal)data.RotationalDrag;

                impactGroupBox1.Enabled = true;
            }
            else
            {
                impactGroupBox1.Enabled = false;
            }
            allowChange = true;
        }

        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                PhysQuicksetData a = new PhysQuicksetData();
                a.Name = Global.GetName("Quickset", physQuicksets);
                a.ID = Global.GetID(physQuicksets);
                a.Category = ca.Category;
                physQuicksets.Add(a);
                int index = a.ID;
                // History
                //MainForm.PhysQuicksetsHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "39x002");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex > -1 && addRemoveList.SelectedIndex < physQuicksets.Count)
                {
                    physQuicksets.Remove(addRemoveList.Data<PhysQuicksetData>());
                    addRemoveList.RemoveSelectedNode();
                    if (addRemoveList.SelectedIndex >= 0)
                        SetupProperty(physQuicksets[addRemoveList.SelectedIndex]);
                    else
                        SetupProperty(null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "39x001");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && e.Index < physQuicksets.Count)
                    SetupProperty(physQuicksets[e.Index]);
                else
                    SetupProperty(null);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "39x002");
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }


        internal void ResetProject()
        {
            SetupList();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            GameData.PhysQuicksets = physQuicksets;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudForce_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            addRemoveList.Data<PhysQuicksetData>().Force = (float)nudForce.Value;

        }

        private void nudVelocityX_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            addRemoveList.Data<PhysQuicksetData>().Impulse = (float)nudVelocityX.Value;
        }

        private void nudDrag_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            addRemoveList.Data<PhysQuicksetData>().LinearDrag = (float)nudDrag.Value;
        }

        private void nudRotDrag_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            addRemoveList.Data<PhysQuicksetData>().RotationalDrag = (float)nudRotDrag.Value;
        }

        private void nudMass_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            addRemoveList.Data<PhysQuicksetData>().Mass = (float)nudMass.Value;
        }

        private void nudFriction_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            addRemoveList.Data<PhysQuicksetData>().Friction = (float)nudFriction.Value;
        }

        private void nudBounce_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            addRemoveList.Data<PhysQuicksetData>().Bounce = (float)nudBounce.Value;
        }

    }
}
