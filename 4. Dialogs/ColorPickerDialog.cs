using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.Dialogs
{
    public partial class ColorPickerDialog : Form
    {
        public delegate void ColorChangedEvent(object sender, Color color);
        public event ColorChangedEvent ColorChanged;

        public ColorPickerDialog()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            colorPickerCtrl.ColorChanged += new ColorPickerCtrl.ColorChangedEvent(colorPickerCtrl_ColorChanged);

            colorPickerCtrl.AllowOpacity = true;
        }

        void colorPickerCtrl_ColorChanged(object sender, Color color)
        {
            if (ColorChanged != null)
                ColorChanged(sender, color);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
