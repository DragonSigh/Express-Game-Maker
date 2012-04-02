using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using System.Threading;
using System.IO;
using EGMGame.Docking.Explorers;

namespace EGMGame
{
    public partial class LayerBGDialog : Form
    {
        LayerData layer;

        public LayerBGDialog()
        {
            InitializeComponent();
            sizeType.SelectedIndex = 0;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            layer.ScrollType = sizeType.SelectedIndex;
            layer.MoveSpeed = new Microsoft.Xna.Framework.Vector2((float)speedX.Value, (float)speedY.Value);
            this.DialogResult = DialogResult.OK;
            MainForm.NeedSave = true;
            IsOK = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        internal void Setup(LayerData selectedLayer)
        {
            layer = selectedLayer;
            sizeType.SelectedIndex = (int)selectedLayer.ScrollType;

            speedX.Value = (decimal)selectedLayer.MoveSpeed.X;
            speedY.Value = (decimal)selectedLayer.MoveSpeed.Y;
            settingsBox.Enabled = true;
        }

        public bool IsOK = false;


        private void ChooseMaterialDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void sizeType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
