/******************************************************************/
/*****                                                        *****/
/*****     Project:           EGM Color Picker Clone 1      *****/
/*****     Filename:          EGMColors.cs                  *****/
/*****     Original Author:   Danny Blanchard                 *****/
/*****                        - scrabcakes@gmail.com          *****/
/*****     Updates:	                                          *****/
/*****      3/28/2005 - Initial Version : Danny Blanchard     *****/
/*****                                                        *****/
/******************************************************************/

using System;
using System.Drawing;

namespace EGMGame
{
	/// <summary>
	/// Summary description for EGMColors.
	/// </summary>
	public class EGMColors
	{
		#region Constructors / Destructors

		public EGMColors() 
		{ 
		} 


		#endregion

		#region Public Methods

		/// <summary> 
		/// Sets the absolute brightness of a colour 
		/// </summary> 
		/// <param name="c">Original colour</param> 
		/// <param name="brightness">The luminance level to impose</param> 
		/// <returns>an adjusted colour</returns> 
		public static  Color SetBrightness(Color c, double brightness) 
		{ 
			HSL hsl = RGB_to_HSL(c); 
			hsl.L=brightness; 
			return HSL_to_RGB(hsl); 
		} 


		/// <summary> 
		/// Modifies an existing brightness level 
		/// </summary> 
		/// <remarks> 
		/// To reduce brightness use a number smaller than 1. To increase brightness use a number larger tnan 1 
		/// </remarks> 
		/// <param name="c">The original colour</param> 
		/// <param name="brightness">The luminance delta</param> 
		/// <returns>An adjusted colour</returns> 
		public static  Color ModifyBrightness(Color c, double brightness) 
		{ 
			HSL hsl = RGB_to_HSL(c); 
			hsl.L*=brightness; 
			return HSL_to_RGB(hsl); 
		} 


		/// <summary> 
		/// Sets the absolute saturation level 
		/// </summary> 
		/// <remarks>Accepted values 0-1</remarks> 
		/// <param name="c">An original colour</param> 
		/// <param name="Saturation">The saturation value to impose</param> 
		/// <returns>An adjusted colour</returns> 
		public static  Color SetSaturation(Color c, double Saturation) 
		{ 
			HSL hsl = RGB_to_HSL(c); 
			hsl.S=Saturation; 
			return HSL_to_RGB(hsl); 
		} 


		/// <summary> 
		/// Modifies an existing Saturation level 
		/// </summary> 
		/// <remarks> 
		/// To reduce Saturation use a number smaller than 1. To increase Saturation use a number larger tnan 1 
		/// </remarks> 
		/// <param name="c">The original colour</param> 
		/// <param name="Saturation">The saturation delta</param> 
		/// <returns>An adjusted colour</returns> 
		public static  Color ModifySaturation(Color c, double Saturation) 
		{ 
			HSL hsl = RGB_to_HSL(c); 
			hsl.S*=Saturation; 
			return HSL_to_RGB(hsl); 
		} 


		/// <summary> 
		/// Sets the absolute Hue level 
		/// </summary> 
		/// <remarks>Accepted values 0-1</remarks> 
		/// <param name="c">An original colour</param> 
		/// <param name="Hue">The Hue value to impose</param> 
		/// <returns>An adjusted colour</returns> 
		public static  Color SetHue(Color c, double Hue) 
		{ 
			HSL hsl = RGB_to_HSL(c); 
			hsl.H=Hue; 
			return HSL_to_RGB(hsl); 
		} 


		/// <summary> 
		/// Modifies an existing Hue level 
		/// </summary> 
		/// <remarks> 
		/// To reduce Hue use a number smaller than 1. To increase Hue use a number larger tnan 1 
		/// </remarks> 
		/// <param name="c">The original colour</param> 
		/// <param name="Hue">The Hue delta</param> 
		/// <returns>An adjusted colour</returns> 
		public static  Color ModifyHue(Color c, double Hue) 
		{ 
			HSL hsl = RGB_to_HSL(c); 
			hsl.H*=Hue; 
			return HSL_to_RGB(hsl); 
		} 


		/// <summary> 
		/// Converts a colour from HSL to RGB 
		/// </summary> 
		/// <remarks>Adapted from the algoritm in Foley and Van-Dam</remarks> 
		/// <param name="hsl">The HSL value</param> 
		/// <returns>A Color structure containing the equivalent RGB values</returns> 
		public static Color HSL_to_RGB(HSL hsl) 
		{ 
			int Max, Mid, Min;
			double q;
            
			Max = Round(hsl.L * 255);
			Min = Round((1.0 - hsl.S)*(hsl.L/1.0)*255);
			q   = (double)(Max - Min)/255;

			if ( hsl.H >= 0 && hsl.H <= (double)1/6 )
			{
				Mid = Round(((hsl.H - 0) * q) * 1530 + Min);
				return Color.FromArgb(hsl.Alpha, Max,Mid,Min);
			}
			else if ( hsl.H <= (double)1/3 )
			{
				Mid = Round(-((hsl.H - (double)1/6) * q) * 1530 + Max);
                return Color.FromArgb(hsl.Alpha, Mid, Max, Min);
			}
			else if ( hsl.H <= 0.5 )
			{
				Mid = Round(((hsl.H - (double)1/3) * q) * 1530 + Min);
                return Color.FromArgb(hsl.Alpha, Min, Max, Mid);
			}
			else if ( hsl.H <= (double)2/3 )
			{
				Mid = Round(-((hsl.H - 0.5) * q) * 1530 + Max);
                return Color.FromArgb(hsl.Alpha, Min, Mid, Max);
			}
			else if ( hsl.H <= (double)5/6 )
			{
				Mid = Round(((hsl.H - (double)2/3) * q) * 1530 + Min);
                return Color.FromArgb(hsl.Alpha, Mid, Min, Max);
			}
			else if ( hsl.H <= 1.0 )
			{
				Mid = Round(-((hsl.H - (double)5/6) * q) * 1530 + Max);
                return Color.FromArgb(hsl.Alpha, Max, Min, Mid);
			}
            else return Color.FromArgb(hsl.Alpha, 0, 0, 0);
		} 
  

		/// <summary> 
		/// Converts RGB to HSL 
		/// </summary> 
		/// <remarks>Takes advantage of whats already built in to .NET by using the Color.GetHue, Color.GetSaturation and Color.GetBrightness methods</remarks> 
		/// <param name="c">A Color to convert</param> 
		/// <returns>An HSL value</returns> 
		public static HSL RGB_to_HSL (Color c) 
		{ 
			HSL hsl =  new HSL();
            hsl.Alpha = c.A;
			int Max, Min, Diff, Sum;

			//	Of our RGB values, assign the highest value to Max, and the Smallest to Min
			if ( c.R > c.G )	{ Max = c.R; Min = c.G; }
			else				{ Max = c.G; Min = c.R; }
			if ( c.B > Max )	  Max = c.B;
			else if ( c.B < Min ) Min = c.B;

			Diff = Max - Min;
			Sum = Max + Min;

			//	Luminance - a.k.a. Brightness - EGM photoshop uses the logic that the
			//	site VBspeed regards (regarded) as too primitive = superior decides the 
			//	level of brightness.
			hsl.L = (double)Max/255;

			//	Saturation
			if ( Max == 0 ) hsl.S = 0;	//	Protecting from the impossible operation of division by zero.
			else hsl.S = (double)Diff/Max;	//	The logic of EGM Photoshops is this simple.

			//	Hue		R is situated at the angel of 360 eller noll degrees; 
			//			G vid 120 degrees
			//			B vid 240 degrees
			double q;
			if ( Diff == 0 ) q = 0; // Protecting from the impossible operation of division by zero.
			else q = (double)60/Diff;
			
			if ( Max == c.R )
			{
					if ( c.G < c.B )	hsl.H = (double)(360 + q * (c.G - c.B))/360;
				else				hsl.H = (double)(q * (c.G - c.B))/360;
			}
			else if ( Max == c.G )	hsl.H = (double)(120 + q * (c.B - c.R))/360;
			else if ( Max == c.B )	hsl.H = (double)(240 + q * (c.R - c.G))/360;
			else					hsl.H = 0.0;

			return hsl; 
		} 


		/// <summary>
		/// Converts RGB to CMYK
		/// </summary>
		/// <param name="c">A color to convert.</param>
		/// <returns>A CMYK object</returns>
		public static CMYK RGB_to_CMYK(Color c)
		{
			CMYK _cmyk = new CMYK();
			double low = 1.0;

			_cmyk.C = (double)(255 - c.R)/255;
			if ( low > _cmyk.C )
				low = _cmyk.C;

			_cmyk.M = (double)(255 - c.G)/255;
			if ( low > _cmyk.M )
				low = _cmyk.M;

			_cmyk.Y = (double)(255 - c.B)/255;
			if ( low > _cmyk.Y )
				low = _cmyk.Y;

			if ( low > 0.0 )
			{
				_cmyk.K = low;
			}
            _cmyk.Alpha = c.A;

			return _cmyk;
		}


		/// <summary>
		/// Converts CMYK to RGB
		/// </summary>
		/// <param name="_cmyk">A color to convert</param>
		/// <returns>A Color object</returns>
		public static Color CMYK_to_RGB(CMYK _cmyk)
		{
			int red, green, blue;

			red =	Round(255 - (255 * _cmyk.C));
			green =	Round(255 - (255 * _cmyk.M));
			blue =	Round(255 - (255 * _cmyk.Y));

			return Color.FromArgb(_cmyk.Alpha, red, green, blue);
		}


		/// <summary>
		/// Custom rounding function.
		/// </summary>
		/// <param name="val">Value to round</param>
		/// <returns>Rounded value</returns>
		private static int Round(double val)
		{
			int ret_val = (int)val;
			
			int temp = (int)(val * 100);

			if ( (temp % 100) >= 50 )
				ret_val += 1;

			return ret_val;
		}


		#endregion

		#region Public Classes

		public class HSL 
		{ 
			#region Class Variables

			public HSL() 
			{ 
				_h=0; 
				_s=0; 
				_l=0;
                _alpha = 255;
			} 

			double _h; 
			double _s; 
			double _l;
            int _alpha;

			#endregion

			#region Public Methods

			public double H 
			{ 
				get{return _h;} 
				set 
				{ 
					_h=value; 
					_h=_h>1 ? 1 : _h<0 ? 0 : _h; 
				} 
			} 


			public double S 
			{ 
				get{return _s;} 
				set 
				{ 
					_s=value; 
					_s=_s>1 ? 1 : _s<0 ? 0 : _s; 
				} 
			} 


			public double L 
			{ 
				get{return _l;} 
				set 
				{ 
					_l=value; 
					_l=_l>1 ? 1 : _l<0 ? 0 : _l; 
				} 
			}

            public int Alpha
            {
                get { return _alpha; }
                set
                {
                    _alpha = value;
                    _alpha = _alpha > 255 ? 255 : _alpha < 0 ? 0 : _alpha;
                }
            }

            public HSL(double hue, double saturation, double lightness, int alpha)
		    {
			    _h = Math.Min(360, hue);
			    _s = Math.Min(1, saturation);
			    _l = Math.Min(1, lightness);
                _alpha = Math.Min(255, alpha);
		    }

            public Color Color
            {
                get { return ToRGB(); }
                set { FromRGB(value); }
            }
            void FromRGB(Color cc)
            {
                double r = (double)cc.R / 255d;
                double g = (double)cc.G / 255d;
                double b = (double)cc.B / 255d;
                
                _alpha = cc.A;

                double min = Math.Min(Math.Min(r, g), b);
                double max = Math.Max(Math.Max(r, g), b);
                // calulate hue according formula given in
                // "Conversion from RGB to HSL or HSV"
                _h = 0;
                if (min != max)
                {
                    if (r == max && g >= b)
                    {
                        _h = 60 * ((g - b) / (max - min)) + 0;
                    }
                    else
                        if (r == max && g < b)
                        {
                            _h = 60 * ((g - b) / (max - min)) + 360;
                        }
                        else
                            if (g == max)
                            {
                                _h = 60 * ((b - r) / (max - min)) + 120;
                            }
                            else
                                if (b == max)
                                {
                                    _h = 60 * ((r - g) / (max - min)) + 240;
                                }
                }
                // find lightness
                _l = (min + max) / 2;

                // find saturation
                if (_l == 0 || min == max)
                    _s = 0;
                else
                    if (_l > 0 && _l <= 0.5)
                        _s = (max - min) / (2 * _l);
                    else
                        if (_l > 0.5)
                            _s = (max - min) / (2 - 2 * _l);
            }
            Color ToRGB()
            {
                // convert to RGB according to
                // "Conversion from HSL to RGB"

                double r = _l;
                double g = _l;
                double b = _l;
                if (_s == 0)
                    return Color.FromArgb(255, (int)(r * 255), (int)(g * 255), (int)(b * 255));

                double q = 0;
                if (_l < 0.5)
                    q = _l * (1 + _s);
                else
                    q = _l + _s - (_l * _s);
                double p = 2 * _l - q;
                double hk = _h / 360;

                // r,g,b colors
                double[] tc = new double[3] { hk + (1d / 3d), hk, hk - (1d / 3d) };
                double[] colors = new double[3] { 0, 0, 0 };

                for (int color = 0; color < colors.Length; color++)
                {
                    if (tc[color] < 0)
                        tc[color] += 1;
                    if (tc[color] > 1)
                        tc[color] -= 1;

                    if (tc[color] < (1d / 6d))
                        colors[color] = p + ((q - p) * 6 * tc[color]);
                    else
                        if (tc[color] >= (1d / 6d) && tc[color] < (1d / 2d))
                            colors[color] = q;
                        else
                            if (tc[color] >= (1d / 2d) && tc[color] < (2d / 3d))
                                colors[color] = p + ((q - p) * 6 * (2d / 3d - tc[color]));
                            else
                                colors[color] = p;

                    colors[color] *= 255; // convert to value expected by Color
                }
                return Color.FromArgb(_alpha, (int)colors[0], (int)colors[1], (int)colors[2]);
            }

            public static bool operator !=(HSL left, HSL right)
            {
                return !(left == right);
            }
            public static bool operator ==(HSL left, HSL right)
            {
                return (left.H == right.H &&
                        left.L == right.L &&
                        left.S == right.S);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
			#endregion
		} 


		public class CMYK 
		{ 
			#region Class Variables

			public CMYK() 
			{ 
				_c=0; 
				_m=0; 
				_y=0; 
				_k=0;
                _alpha = 255;
			} 


			double _c; 
			double _m; 
			double _y; 
			double _k;
            int _alpha;

			#endregion

			#region Public Methods

			public double C 
			{ 
				get{return _c;} 
				set 
				{ 
					_c=value; 
					_c=_c>1 ? 1 : _c<0 ? 0 : _c; 
				} 
			} 


			public double M 
			{ 
				get{return _m;} 
				set 
				{ 
					_m=value; 
					_m=_m>1 ? 1 : _m<0 ? 0 : _m; 
				} 
			} 


			public double Y 
			{ 
				get{return _y;} 
				set 
				{ 
					_y=value; 
					_y=_y>1 ? 1 : _y<0 ? 0 : _y; 
				} 
			} 


			public double K 
			{ 
				get{return _k;} 
				set 
				{ 
					_k=value; 
					_k=_k>1 ? 1 : _k<0 ? 0 : _k; 
				} 
			}

            public int Alpha
            {
                get { return _alpha; }
                set
                {
                    _alpha = value;
                    _alpha = _alpha > 255 ? 255 : _alpha < 0 ? 0 : _alpha;
                }
            }


			#endregion
		} 


		#endregion
	}
}
