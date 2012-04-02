using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace EGMGame
{
	public partial class ColorPickerCtrl : UserControl
	{
		Color m_selectedColor = Color.AntiqueWhite;

        public delegate void ColorChangedEvent(object sender, Color color);
        public event ColorChangedEvent ColorChanged;

        [Browsable(true)]
        public bool AllowOpacity
        {
            get { return colorInfo.AllowOpacity; }
            set { colorInfo.AllowOpacity = value; }
        }

		public Color SelectedColor
		{
			get { return m_selectedColor; }
			set
			{
                colorInfo.SelectedColor = value;

				if (m_colorTable.ColorExist(value) == false)
					m_colorTable.SetCustomColor(value);
				m_colorTable.SelectedItem = value;

                colorInfo.OldColor = value;

                if (ColorChanged != null)
                    ColorChanged(this, value);
			}
		}


		public ColorPickerCtrl()
        {
			InitializeComponent();

			List<Color> colors = new List<Color>();
			float step = 100/8;
			for (float x = 0; x <= 100; x += step)
			{
				float v = 255 * x/100;
				colors.Add(Color.FromArgb(255, (int)v, (int)v, (int)v));
			}
			colors.Add(Color.White);

			colors.Add(Color.FromArgb(255, 255, 000, 000));
			colors.Add(Color.FromArgb(255, 255, 255, 000));
			colors.Add(Color.FromArgb(255, 000, 255, 000));
			colors.Add(Color.FromArgb(255, 000, 255, 255));
			colors.Add(Color.FromArgb(255, 000, 000, 255));
			colors.Add(Color.FromArgb(255, 255, 000, 255));

			int cols = 16;
			int rows = 3;
			float cnt = (rows * cols);
			float huestep = 360 / cnt;
			float hue = 0;
			while (hue < 360)
			{
                colors.Add(new EGMColors.HSL(hue, 1, 0.5,255).Color);
				hue += huestep;
			}
            hue = 0;
			while (hue < 360)
			{
                colors.Add(new EGMColors.HSL(hue, 0.5, 0.5, 255).Color);
				hue += huestep;
			}
			m_colorTable.Colors = colors.ToArray();
			m_colorTable.Cols = cols;

			m_colorTable.SelectedIndexChanged += new EventHandler(OnColorTableSelectionChanged);
			//m_colorWheel.ColorChanged += new EventHandler(OnColorWheelSelectionChanged);
			m_eyedropColorPicker.SelectedColorChanged += new EventHandler(OnEyeDropperSelectionChanged);

		}

		void OnEyeDropperSelectionChanged(object sender, EventArgs e)
		{
			colorInfo.SelectedColor = m_eyedropColorPicker.SelectedColor;
		}

		void OnColorWheelSelectionChanged(object sender, EventArgs e)
		{
            Color selcol = colorInfo.SelectedColor;
            if (selcol != null && selcol != m_selectedColor)
            {
                m_selectedColor = selcol;
                if (ColorChanged != null)
                    ColorChanged(this, m_selectedColor);
                if (lockColorTable == false && selcol != m_colorTable.SelectedItem)
                    m_colorTable.SetCustomColor(selcol);
            }
		}

		bool lockColorTable = false;
		void OnColorTableSelectionChanged(object sender, EventArgs e)
		{
            Color selcol = (Color)m_colorTable.SelectedItem;
            if (selcol != null && selcol != m_selectedColor)
            {
                m_colorWheel.colorBox.HSL = EGMColors.RGB_to_HSL(selcol);
                m_colorWheel.colorSlider.HSL = EGMColors.RGB_to_HSL(selcol);
                lockColorTable = true;
                colorInfo.SelectedColor = selcol;
                lockColorTable = false;
            }
		}

        private void m_colorWheel_ColorChanged(object sender, EventArgs e)
        {
            Color selcol = EGMColors.HSL_to_RGB(m_colorWheel.colorBox.HSL);

            if (selcol != null && selcol != m_selectedColor)
            {
                m_selectedColor = selcol;

                if (ColorChanged != null)
                    ColorChanged(this, m_selectedColor);
                colorInfo.SelectedColor = selcol;
                if (lockColorTable == false && selcol != m_colorTable.SelectedItem)
                    m_colorTable.SetCustomColor(selcol);
            }
        }

        private void colorInfo_ColorChanged(object sender, EventArgs e)
        {
            Color selcol = colorInfo.SelectedColor;

            if (selcol != null && selcol != m_selectedColor)
            {
                m_selectedColor = selcol;
                if (ColorChanged != null)
                    ColorChanged(this, m_selectedColor);
                m_colorWheel.colorBox.HSL = EGMColors.RGB_to_HSL(selcol);
                m_colorWheel.colorSlider.HSL = EGMColors.RGB_to_HSL(selcol);
                if (lockColorTable == false && selcol != m_colorTable.SelectedItem)
                    m_colorTable.SetCustomColor(selcol);
            }
        }

        private void colorInfo_DrawStyleChanged(object sender, EventArgs e)
        {
            m_colorWheel.colorBox.DrawStyle = colorInfo.ColorBoxDrawStyle;
            m_colorWheel.colorSlider.DrawStyle = colorInfo.ColorSliderDrawStyle;
        }
	}

	public class ColorListBox : ListBox
	{
		int m_knownColorCount = 0;
		public ColorListBox()
		{
			DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			PropertyInfo[] propinfos = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
			foreach (PropertyInfo info in propinfos)
			{
				if (info.PropertyType == typeof(Color))
				{
					Color c = (Color)info.GetValue(typeof(Color), null);
					if (c.A == 0) // skip transparent
						continue;
					Items.Add(c);
				}
			}
			m_knownColorCount = Items.Count;
		}
		int ColorIndex(Color color)
		{
			// have to search all colors by value;
			int argb = color.ToArgb();
			for (int index = 0; index < Items.Count; index++)
			{
				Color c = (Color)Items[index];
				if (c.ToArgb() == argb)
					return index;
			}
			return -1;
		}
		public void SelectColor(Color color)
		{
			int index = ColorIndex(color);
			if (index < 0)
				index = SetCustomColor(color);
			SelectedItem = Items[index];
		}
		void RemoveCustomColor()
		{
			if (Items.Count > m_knownColorCount)
				Items.RemoveAt(Items.Count - 1);
		}
		int SetCustomColor(Color col)
		{
			RemoveCustomColor();
			Items.Add(col);
			return Items.Count - 1;
		}
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (e.Index > -1)
			{
				e.DrawBackground();
				Rectangle rect = e.Bounds;
				rect.Inflate(-2,-2);
				rect.Width = 50;
				Color textColor = Color.Empty;
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
					textColor = SystemColors.HighlightText;
				else
					textColor = this.ForeColor;
				Color color = (Color)Items[e.Index];
				using (Brush brush = new SolidBrush(color))
				{
					e.Graphics.FillRectangle(brush, rect);
				}
				if ((e.State & DrawItemState.Selected) != DrawItemState.Selected)
				{
					using (Pen pen = new Pen(e.ForeColor))
					{
						e.Graphics.DrawRectangle(pen, rect);
					}
				}
				using (Brush brush = new SolidBrush(e.ForeColor))
				{
					string name = color.Name + string.Format("({0})", e.Index);
					if (color.IsKnownColor == false)
						name = "<custom>";
					
					StringFormat format = new StringFormat();
					format.LineAlignment = StringAlignment.Center;
					rect = e.Bounds;
					rect.X += 60; 
					e.Graphics.DrawString(name, Font, brush, rect, format);
				}
				e.DrawFocusRectangle();
			}
		}
	}
}
