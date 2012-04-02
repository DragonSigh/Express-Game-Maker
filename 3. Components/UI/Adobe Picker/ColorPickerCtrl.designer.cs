using System;
namespace EGMGame
{
	partial class ColorPickerCtrl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_colorWheel = new EGMGame.ColorWheelCtrl();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_eyedropColorPicker = new EGMGame.EyedropColorPicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_colorTable = new EGMGame.ColorTable();
            this.colorInfo = new EGMGame.EGM_Picker.ColorInfo();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_colorWheel
            // 
            this.m_colorWheel.BackColor = System.Drawing.Color.Transparent;
            this.m_colorWheel.Location = new System.Drawing.Point(3, 3);
            this.m_colorWheel.Name = "m_colorWheel";
            this.m_colorWheel.Size = new System.Drawing.Size(287, 206);
            this.m_colorWheel.TabIndex = 0;
            this.m_colorWheel.ColorChanged += new System.EventHandler(this.m_colorWheel_ColorChanged);
            // 
            // m_eyedropColorPicker
            // 
            this.m_eyedropColorPicker.BackColor = System.Drawing.SystemColors.Control;
            this.m_eyedropColorPicker.Location = new System.Drawing.Point(6, 158);
            this.m_eyedropColorPicker.Name = "m_eyedropColorPicker";
            this.m_eyedropColorPicker.SelectedColor = System.Drawing.Color.Empty;
            this.m_eyedropColorPicker.Size = new System.Drawing.Size(281, 48);
            this.m_eyedropColorPicker.TabIndex = 5;
            this.m_eyedropColorPicker.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_eyedropColorPicker, "Color Selector. Click and Drag to pick a color from the screen");
            this.m_eyedropColorPicker.Zoom = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(301, 238);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.m_colorWheel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(293, 212);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Color Picker";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_colorTable);
            this.tabPage2.Controls.Add(this.m_eyedropColorPicker);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(293, 212);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Color Table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // m_colorTable
            // 
            this.m_colorTable.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.DarkGreen,
        System.Drawing.Color.DarkSlateGray,
        System.Drawing.Color.Navy,
        System.Drawing.Color.Teal,
        System.Drawing.Color.Olive,
        System.Drawing.Color.Maroon,
        System.Drawing.Color.Purple,
        System.Drawing.Color.Green,
        System.Drawing.Color.Indigo,
        System.Drawing.Color.MidnightBlue,
        System.Drawing.Color.DarkCyan,
        System.Drawing.Color.DarkMagenta,
        System.Drawing.Color.DarkBlue,
        System.Drawing.Color.DarkRed,
        System.Drawing.Color.DarkOliveGreen,
        System.Drawing.Color.SaddleBrown,
        System.Drawing.Color.ForestGreen,
        System.Drawing.Color.OliveDrab,
        System.Drawing.Color.SeaGreen,
        System.Drawing.Color.DarkGoldenrod,
        System.Drawing.Color.DarkSlateBlue,
        System.Drawing.Color.MediumBlue,
        System.Drawing.Color.Sienna,
        System.Drawing.Color.Brown,
        System.Drawing.Color.DarkTurquoise,
        System.Drawing.Color.DimGray,
        System.Drawing.Color.LightSeaGreen,
        System.Drawing.Color.DarkViolet,
        System.Drawing.Color.Firebrick,
        System.Drawing.Color.MediumVioletRed,
        System.Drawing.Color.MediumSeaGreen,
        System.Drawing.Color.Crimson,
        System.Drawing.Color.Chocolate,
        System.Drawing.Color.Goldenrod,
        System.Drawing.Color.MediumSpringGreen,
        System.Drawing.Color.SteelBlue,
        System.Drawing.Color.LawnGreen,
        System.Drawing.Color.DarkOrchid,
        System.Drawing.Color.Gold,
        System.Drawing.Color.Red,
        System.Drawing.Color.LimeGreen,
        System.Drawing.Color.Orange,
        System.Drawing.Color.Lime,
        System.Drawing.Color.SpringGreen,
        System.Drawing.Color.OrangeRed,
        System.Drawing.Color.Magenta,
        System.Drawing.Color.Cyan,
        System.Drawing.Color.DarkOrange,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.CadetBlue,
        System.Drawing.Color.Chartreuse,
        System.Drawing.Color.Blue,
        System.Drawing.Color.DeepSkyBlue,
        System.Drawing.Color.Aqua,
        System.Drawing.Color.YellowGreen,
        System.Drawing.Color.Fuchsia,
        System.Drawing.Color.Gray,
        System.Drawing.Color.SlateGray,
        System.Drawing.Color.Peru,
        System.Drawing.Color.BlueViolet,
        System.Drawing.Color.LightSlateGray,
        System.Drawing.Color.DeepPink,
        System.Drawing.Color.MediumTurquoise,
        System.Drawing.Color.DodgerBlue,
        System.Drawing.Color.Turquoise,
        System.Drawing.Color.RoyalBlue,
        System.Drawing.Color.SlateBlue,
        System.Drawing.Color.MediumOrchid,
        System.Drawing.Color.DarkKhaki,
        System.Drawing.Color.IndianRed,
        System.Drawing.Color.GreenYellow,
        System.Drawing.Color.MediumAquamarine,
        System.Drawing.Color.Tomato,
        System.Drawing.Color.DarkSeaGreen,
        System.Drawing.Color.Orchid,
        System.Drawing.Color.PaleVioletRed,
        System.Drawing.Color.MediumPurple,
        System.Drawing.Color.RosyBrown,
        System.Drawing.Color.Coral,
        System.Drawing.Color.CornflowerBlue,
        System.Drawing.Color.DarkGray,
        System.Drawing.Color.SandyBrown,
        System.Drawing.Color.MediumSlateBlue,
        System.Drawing.Color.Tan,
        System.Drawing.Color.DarkSalmon,
        System.Drawing.Color.BurlyWood,
        System.Drawing.Color.HotPink,
        System.Drawing.Color.Salmon,
        System.Drawing.Color.LightCoral,
        System.Drawing.Color.Violet,
        System.Drawing.Color.SkyBlue,
        System.Drawing.Color.LightSalmon,
        System.Drawing.Color.Khaki,
        System.Drawing.Color.Plum,
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.Aquamarine,
        System.Drawing.Color.Silver,
        System.Drawing.Color.LightSkyBlue,
        System.Drawing.Color.LightSteelBlue,
        System.Drawing.Color.LightBlue,
        System.Drawing.Color.PaleGreen,
        System.Drawing.Color.PowderBlue,
        System.Drawing.Color.Thistle,
        System.Drawing.Color.PaleGoldenrod,
        System.Drawing.Color.PaleTurquoise,
        System.Drawing.Color.LightGray,
        System.Drawing.Color.Wheat,
        System.Drawing.Color.NavajoWhite,
        System.Drawing.Color.Moccasin,
        System.Drawing.Color.LightPink,
        System.Drawing.Color.PeachPuff,
        System.Drawing.Color.Gainsboro,
        System.Drawing.Color.Pink,
        System.Drawing.Color.Bisque,
        System.Drawing.Color.LightGoldenrodYellow,
        System.Drawing.Color.LemonChiffon,
        System.Drawing.Color.BlanchedAlmond,
        System.Drawing.Color.Beige,
        System.Drawing.Color.AntiqueWhite,
        System.Drawing.Color.PapayaWhip,
        System.Drawing.Color.Cornsilk,
        System.Drawing.Color.LightYellow,
        System.Drawing.Color.LightCyan,
        System.Drawing.Color.Lavender,
        System.Drawing.Color.MistyRose,
        System.Drawing.Color.Linen,
        System.Drawing.Color.OldLace,
        System.Drawing.Color.WhiteSmoke,
        System.Drawing.Color.SeaShell,
        System.Drawing.Color.Azure,
        System.Drawing.Color.AliceBlue,
        System.Drawing.Color.Ivory,
        System.Drawing.Color.Honeydew,
        System.Drawing.Color.FloralWhite,
        System.Drawing.Color.LavenderBlush,
        System.Drawing.Color.MintCream,
        System.Drawing.Color.GhostWhite,
        System.Drawing.Color.Snow,
        System.Drawing.Color.White};
            this.m_colorTable.Cols = 16;
            this.m_colorTable.FieldSize = new System.Drawing.Size(12, 12);
            this.m_colorTable.Location = new System.Drawing.Point(20, 6);
            this.m_colorTable.Name = "m_colorTable";
            this.m_colorTable.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.m_colorTable.RotatePointAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_colorTable.SelectedItem = System.Drawing.Color.Black;
            this.m_colorTable.Size = new System.Drawing.Size(253, 146);
            this.m_colorTable.TabIndex = 3;
            this.m_colorTable.Text = "m_colorTable";
            this.m_colorTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_colorTable.TextAngle = 0F;
            // 
            // colorInfo
            // 
            this.colorInfo.AllowOpacity = false;
            this.colorInfo.BackColor = System.Drawing.Color.Transparent;
            this.colorInfo.DrawStyle = EGMGame.EGM_Picker.ColorInfo.eDrawStyle.Hue;
            this.colorInfo.Location = new System.Drawing.Point(313, 27);
            this.colorInfo.Name = "colorInfo";
            this.colorInfo.OldColor = System.Drawing.Color.Empty;
            this.colorInfo.SelectedColor = System.Drawing.Color.Empty;
            this.colorInfo.Size = new System.Drawing.Size(177, 217);
            this.colorInfo.TabIndex = 11;
            this.colorInfo.ColorChanged += new System.EventHandler(this.colorInfo_ColorChanged);
            this.colorInfo.DrawStyleChanged += new System.EventHandler(this.colorInfo_DrawStyleChanged);
            // 
            // ColorPickerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.colorInfo);
            this.Controls.Add(this.tabControl1);
            this.Name = "ColorPickerCtrl";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.Size = new System.Drawing.Size(495, 252);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private ColorWheelCtrl m_colorWheel;
        private System.Windows.Forms.ToolTip m_tooltip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ColorTable m_colorTable;
        private EyedropColorPicker m_eyedropColorPicker;
        internal EGMGame.EGM_Picker.ColorInfo colorInfo;
	}
}
