using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using Microsoft.Xna.Framework;
using GenericUndoRedo;
using EGMGame.Docking.Editors;

namespace EGMGame.Controls.EventControls
{
    public partial class EventPhysicSettingsDialog : Form
    {
        IGameData Data;
        DataPropertyDelegate Delegate;
        UndoRedoHistory<IHistory> SelectedHistory;
        public EventPhysicSettingsDialog()
        {
            InitializeComponent();

            cbQuick.Items.Clear();
            cbQuick.Items.Add("None");
            foreach (PhysQuicksetData quick in GameData.PhysQuicksets)
            {
                cbQuick.Items.Add(quick.Name);
            }
            cbQuick.SelectedIndex = 0;
        }

        public void Setup(EventPageData data, UndoRedoHistory<IHistory> selectedHistory, DataPropertyDelegate _delegate)
        {
            Delegate = _delegate;
            SelectedHistory = selectedHistory;
            Data = data;
            chkMass.Checked = data.CustomMass;
            chkForce.Checked = data.CustomForce;
            chkLinearDrag.Checked = data.CustomLinearDrag;
            chkRotationalDrag.Checked = data.CustomRotationalDrag;
            chkFriction.Checked = data.CustomFriction;
            chkBounce.Checked = data.CustomBounce;
            chkVelocity.Checked = data.CustomImpulse;
            chkMOI.Checked = data.CustomMOI;

            nudFriction.Value = (decimal)data.Friction;
            nudBounce.Value = (decimal)data.Bounce;
            nudVelocityX.Value = (decimal)data.Impulse;
            nudMass.Value = (decimal)data.Mass;
            nudForce.Value = (decimal)data.Force;
            nudDrag.Value = (decimal)data.LinearDrag;
            nudRotDrag.Value = (decimal)data.RotationalDrag;
            nudMOI.Value = (decimal)data.MomentOfInertia;

            chkIgnoreGravity.Checked = data.IgnoreGravity;
            chkIsFixedRotatio.Checked = data.IsFixedRotation;


            chkCustomGravity.Checked = data.CustomGravity;
            nudGravityX.Value = (decimal)data.Gravity.X;
            nudGravityY.Value = (decimal)data.Gravity.Y;
        }

        internal void Setup(ProjectileData data, UndoRedoHistory<IHistory> selectedHistory, DataPropertyDelegate _delegate)
        {
            Delegate = _delegate;
            SelectedHistory = selectedHistory;
            Data = data;
            chkMass.Checked = data.CustomMass;
            chkForce.Checked = data.CustomForce;
            chkLinearDrag.Checked = data.CustomLinearDrag;
            chkRotationalDrag.Checked = data.CustomRotationalDrag;
            chkFriction.Checked = data.CustomFriction;
            chkBounce.Checked = data.CustomBounce;
            chkVelocity.Checked = data.CustomImpulse;
            chkMOI.Checked = data.CustomMOI;

            nudFriction.Value = (decimal)data.Friction;
            nudBounce.Value = (decimal)data.Bounce;
            nudVelocityX.Value = (decimal)data.Impulse;
            nudMass.Value = (decimal)data.Mass;
            nudForce.Value = (decimal)data.Force;
            nudDrag.Value = (decimal)data.LinearDrag;
            nudRotDrag.Value = (decimal)data.RotationalDrag;
            nudMOI.Value = (decimal)data.MomentOfInertia;

            chkIgnoreGravity.Checked = data.IgnoreGravity;
            chkIsFixedRotatio.Checked = data.IsFixedRotation;

            chkCustomGravity.Checked = data.CustomGravity;
            nudGravityX.Value = (decimal)data.Gravity.X;
            nudGravityY.Value = (decimal)data.Gravity.Y;
        }

        public void Setup(PhysicsSettings data)
        {
            Data = data;
            chkMass.Checked = data.CustomMass;
            chkForce.Checked = data.CustomForce;
            chkLinearDrag.Checked = data.CustomLinearDrag;
            chkRotationalDrag.Checked = data.CustomRotationalDrag;
            chkFriction.Checked = data.CustomFriction;
            chkBounce.Checked = data.CustomBounce;
            chkVelocity.Checked = data.CustomImpulse;
            chkMOI.Checked = data.CustomMOI;

            nudFriction.Value = (decimal)data.Friction;
            nudBounce.Value = (decimal)data.Bounce;
            nudVelocityX.Value = (decimal)data.Impulse;
            nudMass.Value = (decimal)data.Mass;
            nudForce.Value = (decimal)data.Force;
            nudDrag.Value = (decimal)data.LinearDrag;
            nudRotDrag.Value = (decimal)data.RotationalDrag;
            nudMOI.Value = (decimal)data.MomentOfInertia;

            chkIgnoreGravity.Checked = data.IgnoreGravity;

            chkIsFixedRotatio.Checked = data.IsFixedRotation;

            chkCustomGravity.Checked = data.CustomGravity;
            nudGravityX.Value = (decimal)data.Gravity.X;
            nudGravityY.Value = (decimal)data.Gravity.Y;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (SelectedHistory != null)
                SelectedHistory.Do(new IGameDataChangePropertyHist(Data, Delegate));

            if (Data is EventPageData)
            {
                EventPageData data = (EventPageData)Data;
                data.CustomMass = chkMass.Checked;
                data.CustomForce = chkForce.Checked;
                data.CustomLinearDrag = chkLinearDrag.Checked;
                data.CustomRotationalDrag = chkRotationalDrag.Checked;
                data.CustomFriction = chkFriction.Checked;
                data.CustomBounce = chkBounce.Checked;
                data.CustomImpulse = chkVelocity.Checked;
                data.CustomMOI = chkMOI.Checked;

                data.Mass = (float)nudMass.Value;
                data.Force = (float)nudForce.Value;
                data.LinearDrag = (float)nudDrag.Value;
                data.RotationalDrag = (float)nudRotDrag.Value;
                data.Friction = (float)nudFriction.Value;
                data.Bounce = (float)nudBounce.Value;
                data.Impulse = (float)nudVelocityX.Value;
                data.MomentOfInertia = (float)nudMOI.Value;

                data.IgnoreGravity = chkIgnoreGravity.Checked;
                data.IsFixedRotation = chkIsFixedRotatio.Checked;

                data.CustomGravity = chkCustomGravity.Checked;
                data.Gravity = new Vector2((float)nudGravityX.Value, (float)nudGravityY.Value);
            }
            else if (Data is ProjectileData)
            {
                ProjectileData data = (ProjectileData)Data;
                data.CustomMass = chkMass.Checked;
                data.CustomForce = chkForce.Checked;
                data.CustomLinearDrag = chkLinearDrag.Checked;
                data.CustomRotationalDrag = chkRotationalDrag.Checked;
                data.CustomFriction = chkFriction.Checked;
                data.CustomBounce = chkBounce.Checked;
                data.CustomImpulse = chkVelocity.Checked;
                data.CustomMOI = chkMOI.Checked;

                data.Mass = (float)nudMass.Value;
                data.Force = (float)nudForce.Value;
                data.LinearDrag = (float)nudDrag.Value;
                data.RotationalDrag = (float)nudRotDrag.Value;
                data.Friction = (float)nudFriction.Value;
                data.Bounce = (float)nudBounce.Value;
                data.Impulse = (float)nudVelocityX.Value;
                data.MomentOfInertia = (float)nudMOI.Value;

                data.IgnoreGravity = chkIgnoreGravity.Checked;
                data.IsFixedRotation = chkIsFixedRotatio.Checked;
                data.CustomGravity = chkCustomGravity.Checked;
                data.Gravity = new Vector2((float)nudGravityX.Value, (float)nudGravityY.Value);
            }
            else if (Data is PhysicsSettings)
            {
                PhysicsSettings data = (PhysicsSettings)Data;
                data.CustomMass = chkMass.Checked;
                data.CustomForce = chkForce.Checked;
                data.CustomLinearDrag = chkLinearDrag.Checked;
                data.CustomRotationalDrag = chkRotationalDrag.Checked;
                data.CustomFriction = chkFriction.Checked;
                data.CustomBounce = chkBounce.Checked;
                data.CustomImpulse = chkVelocity.Checked;
                data.CustomMOI = chkMOI.Checked;

                data.Mass = (float)nudMass.Value;
                data.Force = (float)nudForce.Value;
                data.LinearDrag = (float)nudDrag.Value;
                data.RotationalDrag = (float)nudRotDrag.Value;
                data.Friction = (float)nudFriction.Value;
                data.Bounce = (float)nudBounce.Value;
                data.Impulse = (float)nudVelocityX.Value;
                data.MomentOfInertia = (float)nudMOI.Value;

                data.IgnoreGravity = chkIgnoreGravity.Checked;
                data.IsFixedRotation = chkIsFixedRotatio.Checked;
                data.CustomGravity = chkCustomGravity.Checked;
                data.Gravity = new Vector2((float)nudGravityX.Value, (float)nudGravityY.Value);
            }

            close = true;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void chkFriction_CheckedChanged(object sender, EventArgs e)
        {
            nudFriction.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkBounce_CheckedChanged(object sender, EventArgs e)
        {
            nudBounce.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkRotationalDrag_CheckedChanged(object sender, EventArgs e)
        {
            nudRotDrag.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkLinearDrag_CheckedChanged(object sender, EventArgs e)
        {
            nudDrag.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkForce_CheckedChanged(object sender, EventArgs e)
        {
            nudForce.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkMass_CheckedChanged(object sender, EventArgs e)
        {
            nudMass.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkVelocity_CheckedChanged(object sender, EventArgs e)
        {
            nudVelocityX.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkMOI_CheckedChanged(object sender, EventArgs e)
        {
            nudMOI.Enabled = ((CheckBox)sender).Checked;
        }

        private void chkCustomGravity_CheckedChanged(object sender, EventArgs e)
        {
            nudGravityX.Enabled = ((CheckBox)sender).Checked;
            nudGravityY.Enabled = ((CheckBox)sender).Checked;
        }

        private void cbQuick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQuick.SelectedIndex > 0)
            {
                int index = cbQuick.SelectedIndex - 1;
                nudFriction.Value = (decimal)GameData.PhysQuicksets[index].Friction;
                nudBounce.Value = (decimal)GameData.PhysQuicksets[index].Bounce;
                nudVelocityX.Value = (decimal)GameData.PhysQuicksets[index].Impulse;
                nudMass.Value = (decimal)GameData.PhysQuicksets[index].Mass;
                nudForce.Value = (decimal)GameData.PhysQuicksets[index].Force;
                nudDrag.Value = (decimal)GameData.PhysQuicksets[index].LinearDrag;
                nudRotDrag.Value = (decimal)GameData.PhysQuicksets[index].RotationalDrag;
            }
        }

        private void btnEditQuickset_Click(object sender, EventArgs e)
        {
            PhysicsQuicksetDialog dialog = new PhysicsQuicksetDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int i = cbQuick.SelectedIndex;
                cbQuick.Items.Clear();
                cbQuick.Items.Add("None");
                foreach (PhysQuicksetData quick in GameData.PhysQuicksets)
                {
                    cbQuick.Items.Add(quick.Name);
                }

                if (i < cbQuick.Items.Count) cbQuick.SelectedIndex = i;
                else cbQuick.SelectedIndex = 0;
            }
        }

        bool close;
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            //if (!close) e.Cancel = true;
        }

    }
}
