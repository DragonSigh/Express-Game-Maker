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

namespace EGMGame
{
    public partial class BeginDrawDialog : Form
    {

        PhysicsSettings settings = new PhysicsSettings();
        #region Constructor
        public BeginDrawDialog()
        {
            InitializeComponent();

            cbEndX.RefreshList(false);
            cbEndY.RefreshList(false);
            cbStartX.RefreshList(false);
            cbStartY.RefreshList(false);
            cbShape.SelectedIndex = 0;
        }
        #endregion

        #region Event Properties
        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; Setup(); }
        }
        EventPageData selectedPage;

        public IEvent SelectedEvent
        {
            get { return selEvent; }
            set { selEvent = value; }
        }
        IEvent selEvent;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;
        #endregion

        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
        }
        List<EventProgramData> programs;

        #region Setup Methods
        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Graphics;
            action.Code = 1;

        }

        private void SetupAction(EventProgramData a)
        {
            action = new EventProgramData();
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            cbStartX.Select((int)action.Value[0]);
            cbStartY.Select((int)action.Value[1]);
            cbEndX.Select((int)action.Value[2]);
            cbEndY.Select((int)action.Value[3]);

            cbShape.SelectedIndex = (int)action.Value[4];

            cbColor.SelectedItem = GetColor((Microsoft.Xna.Framework.Color)action.Value[5]);

            nudLayer.Value = (int)action.Value[6];
            nudThickness.Value = (int)action.Value[7];

            chkCollision.Checked = (bool)action.Value[8];
            chkContDraw.Checked = (bool)action.Value[9];
            chkFillShape.Checked = (bool)action.Value[10];

            settings = Global.Duplicate<PhysicsSettings>((PhysicsSettings)action.Value[11]);

            btnPhysics.Enabled = chkCollision.Checked;
        }

        private System.Drawing.Color GetColor(Microsoft.Xna.Framework.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private Microsoft.Xna.Framework.Color GetColor(System.Drawing.Color color)
        {
            return new Microsoft.Xna.Framework.Color(color.R, color.G, color.B, color.A);
        }
        #endregion

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = cbStartX.Data().ID;
            action.Value[1] = cbStartY.Data().ID;
            action.Value[2] = cbEndX.Data().ID;
            action.Value[3] = cbEndY.Data().ID;
            action.Value[4] = cbShape.SelectedIndex;
            action.Value[5] = GetColor(cbColor.SelectedItem);
            action.Value[6] = (int)nudLayer.Value;
            action.Value[7] = (int)nudThickness.Value;
            action.Value[8] = chkCollision.Checked;
            action.Value[9] = chkContDraw.Checked;
            action.Value[10] = chkFillShape.Checked;
            action.Value[11] = settings;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnPhysics_Click(object sender, EventArgs e)
        {
            EGMGame.Controls.EventControls.EventPhysicSettingsDialog dialog = new Controls.EventControls.EventPhysicSettingsDialog();

            dialog.Setup(settings);

            dialog.ShowDialog();
        }

        private void chkCollision_CheckedChanged(object sender, EventArgs e)
        {
            btnPhysics.Enabled = chkCollision.Checked;
        }
    }
}
