using System;
namespace EGMGame
{
	partial class ColorWheelCtrl
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
            EGMGame.EGMColors.HSL hsl1 = new EGMGame.EGMColors.HSL();
            EGMGame.EGMColors.HSL hsl2 = new EGMGame.EGMColors.HSL();
            this.colorBox = new EGMGame.ColorBox();
            this.colorSlider = new EGMGame.ColorSlider();
            this.SuspendLayout();
            // 
            // colorBox
            // 
            this.colorBox.DrawStyle = EGMGame.ColorBox.eDrawStyle.Hue;
            hsl1.H = 0;
            hsl1.L = 1;
            hsl1.S = 1;
            this.colorBox.HSL = hsl1;
            this.colorBox.Location = new System.Drawing.Point(3, 3);
            this.colorBox.Name = "colorBox";
            this.colorBox.RGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorBox.Size = new System.Drawing.Size(236, 203);
            this.colorBox.TabIndex = 3;
            this.colorBox.Scroll += new EventHandler(this.colorBoxScroll);
            // 
            // colorSlider
            // 
            this.colorSlider.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider.DrawStyle = EGMGame.ColorSlider.eDrawStyle.Hue;
            hsl2.H = 0;
            hsl2.L = 1;
            hsl2.S = 1;
            this.colorSlider.HSL = hsl2;
            this.colorSlider.Location = new System.Drawing.Point(245, 3);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.RGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorSlider.Size = new System.Drawing.Size(40, 203);
            this.colorSlider.TabIndex = 2;
            this.colorSlider.Scroll += new EventHandler(this.colorSliderScroll);
            // 
            // ColorWheelCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.colorSlider);
            this.DoubleBuffered = true;
            this.Name = "ColorWheelCtrl";
            this.Size = new System.Drawing.Size(285, 206);
            this.ResumeLayout(false);

		}

		#endregion

        public ColorSlider colorSlider;
        public ColorBox colorBox;

    }
}
