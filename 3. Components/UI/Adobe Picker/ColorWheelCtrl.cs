using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EGMGame
{
	public partial class ColorWheelCtrl : UserControl
	{
        public ColorWheelCtrl()
        {
            InitializeComponent();
        }

        private void colorSliderScroll(object sender, EventArgs e)
        {
            colorBox.HSL = colorSlider.HSL;
            ColorChanged(this, null);
        }

        private void colorBoxScroll(object sender, EventArgs e)
        {
            ColorChanged(this, null);
        }

        public event EventHandler ColorChanged;
    }
}
