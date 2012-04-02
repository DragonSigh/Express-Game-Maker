using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Docking.Explorers;

namespace EGMGame.Dialogs
{
    public partial class ChooseImagesDialog : Form
    {
        public ChooseImagesDialog()
        {
            InitializeComponent();
        }

        public List<MaterialData> SelectedImages;

        private void ChooseImagesDialog_Load(object sender, EventArgs e)
        {
            SelectedImages = new List<MaterialData>();

            MaterialData d = new MaterialData();
            d.ID = -10;
            d.Name = "(None)";
            lbImages.Items.Add(d);
            foreach (MaterialData data in GameData.Materials.Values)
            {
                if (data.DataType == MaterialDataType.Image)
                    lbImages.Items.Add(data);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (MaterialData data in lbImages.SelectedItems)
            {
                SelectedImages.Add(data);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
