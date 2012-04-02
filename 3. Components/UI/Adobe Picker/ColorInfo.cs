using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EGMGame.EGM_Picker
{
	public partial class ColorInfo : UserControl
	{
		EGMColors.HSL hsl;
		Color rgb;
		EGMColors.CMYK cmyk;

		public enum eDrawStyle
		{
			Hue,
			Saturation,
			Brightness,
			Red,
			Green,
			Blue
		}

		public ColorSlider.eDrawStyle ColorSliderDrawStyle;
		public ColorBox.eDrawStyle ColorBoxDrawStyle;
		
		public event EventHandler DrawStyleChanged;

		public event EventHandler ColorChanged;

		public ColorInfo()
		{
			InitializeComponent();
		}

		public Color SelectedColor
		{
			get
			{
				if(allowOpacity)
					return Color.FromArgb((int)nudAlpha.Value, rgb);
				else
					return rgb;
			}
			set
			{
				rgb = value;
				hsl = EGMColors.RGB_to_HSL(rgb);
				cmyk = EGMColors.RGB_to_CMYK(rgb);

				txtHue.Text = Round(hsl.H * 360).ToString();
				txtSat.Text = Round(hsl.S * 100).ToString();
				txtBlack.Text = Round(hsl.L * 100).ToString();
				txtRed.Text = rgb.R.ToString();
				txtGreen.Text = rgb.G.ToString();
				txtBlue.Text = rgb.B.ToString();
				txtCyan.Text = Round(cmyk.C * 100).ToString();
				txtMagenta.Text = Round(cmyk.M * 100).ToString();
				txtYellow.Text = Round(cmyk.Y * 100).ToString();
				txtK.Text = Round(cmyk.K * 100).ToString();
				nudAlpha.Value = rgb.A;

				txtHue.Update();
				txtSat.Update();
				txtRed.Update();
				txtGreen.Update();
				txtBlue.Update();
				txtCyan.Update();
				txtMagenta.Update();
				txtYellow.Update();
				txtK.Update();
				nudAlpha.Update();

				WriteHexData(rgb);

				lblPrimaryColor.BackColor = value;
				lblPrimaryColor.Update();

				if(ColorChanged != null)
					ColorChanged(this, null);
			}
		}

		Color oldColor;

		public Color OldColor
		{
			get { return oldColor; }
			set
			{
				oldColor = value;
				lblSecondaryColor.BackColor = value;
			}

		}

		public eDrawStyle DrawStyle
		{
			get
			{
				if (rbHue.Checked)
					return eDrawStyle.Hue;
				else if (rbSat.Checked)
					return eDrawStyle.Saturation;
				else if (rbBlack.Checked)
					return eDrawStyle.Brightness;
				else if (rbRed.Checked)
					return eDrawStyle.Red;
				else if (rbGreen.Checked)
					return eDrawStyle.Green;
				else if (rbBlue.Checked)
					return eDrawStyle.Blue;
				else
					return eDrawStyle.Hue;
			}
			set
			{
				switch (value)
				{
					case eDrawStyle.Hue:
						rbHue.Checked = true;
						break;
					case eDrawStyle.Saturation:
						rbSat.Checked = true;
						break;
					case eDrawStyle.Brightness:
						rbBlack.Checked = true;
						break;
					case eDrawStyle.Red:
						rbRed.Checked = true;
						break;
					case eDrawStyle.Green:
						rbGreen.Checked = true;
						break;
					case eDrawStyle.Blue:
						rbBlue.Checked = true;
						break;
					default:
						rbHue.Checked = true;
						break;
				}
			}
		}

		public bool AllowOpacity
		{
			get { return allowOpacity; }
			set { allowOpacity = value; CheckOpacity(); }
		}
		bool allowOpacity = false;

		private void CheckOpacity()
		{
			if (allowOpacity)
			{
				lblAlpha.Visible = nudAlpha.Visible = true;
			}
			else
			{
				lblAlpha.Visible = nudAlpha.Visible = false;
			}
		}

		public void UpdateText()
		{
			txtHue.Text = Round(hsl.H * 360).ToString();
			txtSat.Text = Round(hsl.S * 100).ToString();
			txtBlack.Text = Round(hsl.L * 100).ToString();
			txtRed.Text = rgb.R.ToString();
			txtGreen.Text = rgb.G.ToString();
			txtBlue.Text = rgb.B.ToString();
			txtCyan.Text = Round(cmyk.C * 100).ToString();
			txtMagenta.Text = Round(cmyk.M * 100).ToString();
			txtYellow.Text = Round(cmyk.Y * 100).ToString();
			txtK.Text = Round(cmyk.K * 100).ToString();

			txtHue.Update();
			txtSat.Update();
			txtBlack.Update();
			txtRed.Update();
			txtGreen.Update();
			txtBlue.Update();
			txtCyan.Update();
			txtMagenta.Update();
			txtYellow.Update();
			txtK.Update();

			WriteHexData(rgb);

			UpdateColorBox(rgb);

		}
		public void UpdateColorBox(Color rgb)
		{
			lblPrimaryColor.BackColor = rgb;
			lblPrimaryColor.Update();
		}

		private int Round(double val)
		{
			int retval = (int)val;

			int temp = (int)(val * 100);

			if ((temp % 100) >= 50)
				retval += 1;

			return retval;
		}

		private void WriteHexData(Color rgb)
		{
			string red = Convert.ToString(rgb.R, 16);
			if (red.Length < 2) red = "0" + red;
			string green = Convert.ToString(rgb.G, 16);
			if (green.Length < 2) green = "0" + green;
			string blue = Convert.ToString(rgb.B, 16);
			if (blue.Length < 2) blue = "0" + blue;

			txtHex.Text = red.ToUpper() + green.ToUpper() + blue.ToUpper();
			txtHex.Update();
		}


		private Color ParseHexData(string hexdata)
		{
			if (hexdata.Length != 6)
				return Color.Black;

			string rtext, gtext, btext;
			int r, g, b;

			rtext = hexdata.Substring(0, 2);
			gtext = hexdata.Substring(2, 2);
			btext = hexdata.Substring(4, 2);

			r = int.Parse(rtext, System.Globalization.NumberStyles.HexNumber);
			g = int.Parse(gtext, System.Globalization.NumberStyles.HexNumber);
			b = int.Parse(btext, System.Globalization.NumberStyles.HexNumber);

			return Color.FromArgb(r, g, b);
		}

		private void rbHue_CheckedChanged(object sender, EventArgs e)
		{
			if (rbHue.Checked)
			{
				ColorSliderDrawStyle = ColorSlider.eDrawStyle.Hue;
				ColorBoxDrawStyle = ColorBox.eDrawStyle.Hue;
				if(DrawStyleChanged != null)
					DrawStyleChanged(this, null);
			}
		}

		private void rbSat_CheckedChanged(object sender, EventArgs e)
		{
			if (rbSat.Checked)
			{
				ColorSliderDrawStyle = ColorSlider.eDrawStyle.Saturation;
				ColorBoxDrawStyle = ColorBox.eDrawStyle.Saturation;
				if (DrawStyleChanged != null)
					DrawStyleChanged(this, null);
			}
		}

		private void rbBlack_CheckedChanged(object sender, EventArgs e)
		{
			if (rbBlack.Checked)
			{
				ColorSliderDrawStyle = ColorSlider.eDrawStyle.Brightness;
				ColorBoxDrawStyle = ColorBox.eDrawStyle.Brightness;
				if (DrawStyleChanged != null)
					DrawStyleChanged(this, null);
			}
		}

		private void rbRed_CheckedChanged(object sender, EventArgs e)
		{
			if (rbRed.Checked)
			{
				ColorSliderDrawStyle = ColorSlider.eDrawStyle.Red;
				ColorBoxDrawStyle = ColorBox.eDrawStyle.Red;
				if (DrawStyleChanged != null)
					DrawStyleChanged(this, null);
			}
		}

		private void rbGreen_CheckedChanged(object sender, EventArgs e)
		{
			if (rbGreen.Checked)
			{
				ColorSliderDrawStyle = ColorSlider.eDrawStyle.Green;
				ColorBoxDrawStyle = ColorBox.eDrawStyle.Green;
				if (DrawStyleChanged != null)
					DrawStyleChanged(this, null);
			}
		}

		private void rbBlue_CheckedChanged(object sender, EventArgs e)
		{
			if (rbBlue.Checked)
			{
				ColorSliderDrawStyle = ColorSlider.eDrawStyle.Blue;
				ColorBoxDrawStyle = ColorBox.eDrawStyle.Blue;
				if (DrawStyleChanged != null)
					DrawStyleChanged(this, null);
			}
		}

		private void CheckHueText()
		{
			string text = txtHue.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Hue must be a number value between 0 and 360");
				UpdateText();
				return;
			}

			int hue = int.Parse(text);

			if (hue < 0)
			{
				//MessageBox.Show("An integer between 0 and 360 is required.\nClosest value inserted.");
				txtHue.Text = "0";
				hsl.H = 0.0;
			}
			else if (hue > 360)
			{
				//MessageBox.Show("An integer between 0 and 360 is required.\nClosest value inserted.");
				txtHue.Text = "360";
				hsl.H = 1.0;
			}
			else
			{
				hsl.H = (double)hue / 360;
			}

			rgb = EGMColors.HSL_to_RGB(hsl);
			cmyk = EGMColors.RGB_to_CMYK(rgb);

			if(ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}

		private void CheckSatText()
		{
			string text = txtSat.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Saturation must be a number value between 0 and 100");
				UpdateText();
				return;
			}

			int sat = int.Parse(text);

			if (sat < 0)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtSat.Text = "0";
				hsl.S = 0.0;
			}
			else if (sat > 100)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtSat.Text = "100";
				hsl.S = 1.0;
			}
			else
			{
				hsl.S = (double)sat / 100;
			}

			rgb = EGMColors.HSL_to_RGB(hsl);
			cmyk = EGMColors.RGB_to_CMYK(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}
		private void CheckBlackText()
		{
			string text = txtBlack.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Black must be a number value between 0 and 360");
				UpdateText();
				return;
			}

			int lum = int.Parse(text);

			if (lum < 0)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtBlack.Text = "0";
				hsl.L = 0.0;
			}
			else if (lum > 100)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtBlack.Text = "100";
				hsl.L = 1.0;
			}
			else
			{
				hsl.L = (double)lum / 100;
			}

			rgb = EGMColors.HSL_to_RGB(hsl);
			cmyk = EGMColors.RGB_to_CMYK(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}

		private void CheckRedText()
		{
			string text = txtRed.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Red must be a number value between 0 and 255");
				UpdateText();
				return;
			}

			int red = int.Parse(text);

			if (red < 0)
			{
				//MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
				txtSat.Text = "0";
				rgb = Color.FromArgb(0, rgb.G, rgb.B);
			}
			else if (red > 255)
			{
				//MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
				txtSat.Text = "255";
				rgb = Color.FromArgb(255, rgb.G, rgb.B);
			}
			else
			{
				rgb = Color.FromArgb(red, rgb.G, rgb.B);
			}

			hsl = EGMColors.RGB_to_HSL(rgb);
			cmyk = EGMColors.RGB_to_CMYK(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}
		private void CheckGreenText()
		{
			string text = txtGreen.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Green must be a number value between 0 and 255");
				UpdateText();
				return;
			}

			int green = int.Parse(text);

			if (green < 0)
			{
				//MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
				txtGreen.Text = "0";
				rgb = Color.FromArgb(rgb.R, 0, rgb.B);
			}
			else if (green > 255)
			{
				//MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
				txtGreen.Text = "255";
				rgb = Color.FromArgb(rgb.R, 255, rgb.B);
			}
			else
			{
				rgb = Color.FromArgb(rgb.R, green, rgb.B);
			}

			hsl = EGMColors.RGB_to_HSL(rgb);
			cmyk = EGMColors.RGB_to_CMYK(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}

		private void CheckBlueText()
		{
			string text = txtBlue.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Blue must be a number value between 0 and 255");
				UpdateText();
				return;
			}

			int blue = int.Parse(text);

			if (blue < 0)
			{
				//MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
				txtBlue.Text = "0";
				rgb = Color.FromArgb(rgb.R, rgb.G, 0);
			}
			else if (blue > 255)
			{
				//MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
				txtBlue.Text = "255";
				rgb = Color.FromArgb(rgb.R, rgb.G, 255);
			}
			else
			{
				rgb = Color.FromArgb(rgb.R, rgb.G, blue);
			}

			hsl = EGMColors.RGB_to_HSL(rgb);
			cmyk = EGMColors.RGB_to_CMYK(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}

		private void CheckCyanText()
		{
			string text = txtCyan.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Cyan must be a number value between 0 and 100");
				UpdateText();
				return;
			}

			int cyan = int.Parse(text);

			if (cyan < 0)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				cmyk.C = 0.0;
			}
			else if (cyan > 100)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				cmyk.C = 1.0;
			}
			else
			{
				cmyk.C = (double)cyan / 100;
			}

			rgb = EGMColors.CMYK_to_RGB(cmyk);
			hsl = EGMColors.RGB_to_HSL(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}

		private void CheckMagentaText()
		{
			string text = txtMagenta.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Magenta must be a number value between 0 and 100");
				UpdateText();
				return;
			}

			int magenta = int.Parse(text);

			if (magenta < 0)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtMagenta.Text = "0";
				cmyk.M = 0.0;
			}
			else if (magenta > 100)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtMagenta.Text = "100";
				cmyk.M = 1.0;
			}
			else
			{
				cmyk.M = (double)magenta / 100;
			}

			rgb = EGMColors.CMYK_to_RGB(cmyk);
			hsl = EGMColors.RGB_to_HSL(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}

		private void CheckYellowText()
		{
			string text = txtYellow.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Yellow must be a number value between 0 and 100");
				UpdateText();
				return;
			}

			int yellow = int.Parse(text);

			if (yellow < 0)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtYellow.Text = "0";
				cmyk.Y = 0.0;
			}
			else if (yellow > 100)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtYellow.Text = "100";
				cmyk.Y = 1.0;
			}
			else
			{
				cmyk.Y = (double)yellow / 100;
			}

			rgb = EGMColors.CMYK_to_RGB(cmyk);
			hsl = EGMColors.RGB_to_HSL(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}

		private void CheckKText()
		{
			string text = txtK.Text;
			bool has_illegal_chars = false;

			if (text.Length <= 0)
				has_illegal_chars = true;
			else
				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						has_illegal_chars = true;
						break;
					}
				}

			if (has_illegal_chars)
			{
				//MessageBox.Show("Key must be a number value between 0 and 100");
				UpdateText();
				return;
			}

			int key = int.Parse(text);

			if (key < 0)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtK.Text = "0";
				cmyk.K = 0.0;
			}
			else if (key > 100)
			{
				//MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
				txtK.Text = "100";
				cmyk.K = 1.0;
			}
			else
			{
				cmyk.K = (double)key / 100;
			}

			rgb = EGMColors.CMYK_to_RGB(cmyk);
			hsl = EGMColors.RGB_to_HSL(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor = rgb;

			UpdateText();
		}

		private void CheckAlpha()
		{
			rgb = Color.FromArgb((int)nudAlpha.Value, rgb);
			hsl = EGMColors.RGB_to_HSL(rgb);
			cmyk = EGMColors.RGB_to_CMYK(rgb);

			if (ColorChanged != null)
				ColorChanged(this, null);

			lblPrimaryColor.BackColor =  rgb;

		}

		private void CheckHexText()
		{
			string text = txtHex.Text.ToUpper();
			bool has_illegal_chars = false;

			if (text.Length == 6)
			{
				if (text.Length <= 0)
					has_illegal_chars = true;

				foreach (char letter in text)
				{
					if (!char.IsNumber(letter))
					{
						if (letter >= 'A' && letter <= 'F')
							continue;
						has_illegal_chars = true;
						break;
					}
				}

				if (has_illegal_chars)
				{
					//MessageBox.Show("Hex must be a hex value between 0x000000 and 0xFFFFFF");
					WriteHexData(rgb);
					return;
				}

				rgb = ParseHexData(text);
				hsl = EGMColors.RGB_to_HSL(rgb);
				cmyk = EGMColors.RGB_to_CMYK(rgb);

				if (ColorChanged != null)
					ColorChanged(this, null);

				lblPrimaryColor.BackColor = rgb;

				UpdateText();
			}
		}

		private void txtHue_TextChanged(object sender, EventArgs e)
		{
			if (txtHue.Focused)
				CheckHueText();
		}

		private void txtSat_TextChanged(object sender, EventArgs e)
		{
			if (txtSat.Focused)
				CheckSatText();
		}

		private void txtBlack_TextChanged(object sender, EventArgs e)
		{
			if (txtBlack.Focused)
				CheckBlackText();
		}

		private void txtRed_TextChanged(object sender, EventArgs e)
		{
			if (txtRed.Focused)
				CheckRedText();
		}

		private void txtGreen_TextChanged(object sender, EventArgs e)
		{
			if (txtGreen.Focused)
				CheckGreenText();
		}

		private void txtBlue_TextChanged(object sender, EventArgs e)
		{
			if (txtBlue.Focused)
				CheckBlueText();
		}

		private void txtHex_TextChanged(object sender, EventArgs e)
		{
			if (txtHex.Focused)
				CheckHexText();
		}

		private void txtCyan_TextChanged(object sender, EventArgs e)
		{
			if (txtCyan.Focused)
				CheckCyanText();
		}

		private void txtMagenta_TextChanged(object sender, EventArgs e)
		{
			if (txtMagenta.Focused)
				CheckMagentaText();
		}

		private void txtYellow_TextChanged(object sender, EventArgs e)
		{
			if (txtYellow.Focused)
				CheckYellowText();
		}

		private void txtK_TextChanged(object sender, EventArgs e)
		{
			if (txtK.Focused)
				CheckKText();
		}

		private void nudAlpha_ValueChanged(object sender, EventArgs e)
		{
			//CheckAlpha();            
		}

		private void nudAlpha_Validated(object sender, EventArgs e)
		{
			CheckAlpha();
		}

		private void nudAlpha_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				this.Validate();
			}
		}
	}
}
