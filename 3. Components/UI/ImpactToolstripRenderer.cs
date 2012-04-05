//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EGMGame.Controls.ImpactUI
{
    class ImpactToolstripRenderer : ToolStripProfessionalRenderer
    {
    //    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    //    {
    //        if (e.Item is ToolStripButton)
    //        {
    //            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    //        }

    //        if (e.Item is ToolStripMenuItem
    //            && !(e.Item.Owner is MenuStrip))
    //        {
    //            Rectangle r = new Rectangle(e.TextRectangle.Location, new Size(e.TextRectangle.Width, 24));
    //            e.TextRectangle = r;
    //            e.TextColor = Color.FromArgb(30,30,30);
    //        }

    //        base.OnRenderItemText(e);
    //    }
    //    protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
    //    {
    //        bool IsChecked = false;

    //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

    //        Rectangle r = new Rectangle(Point.Empty, e.Item.Size);

    //        Rectangle outerBorder = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
    //        Rectangle innerBorder = outerBorder; innerBorder.Inflate(-1, -1);

    //        if (e.Item is ToolStripButton)
    //        {
    //             IsChecked = (e.Item as ToolStripButton).Checked;
    //        }

    //        if (e.Item.Selected || e.Item.Pressed || IsChecked)
    //        {
    //            using (GraphicsPath path =
    //                RoundedRectangle(outerBorder, 2))
    //            {
    //                using (Pen p = new Pen(Color.FromArgb(186, 192, 194)))
    //                {
    //                    e.Graphics.DrawPath(p, path);
    //                }
    //            }

    //            //Checked fill
    //            if (IsChecked)
    //            {
    //                using (GraphicsPath path = RoundedRectangle(innerBorder, 2))
    //                {
    //                    using (LinearGradientBrush b = new LinearGradientBrush(
    //                        new Point(0, 0),
    //                        new Point(0, e.Item.Height),
    //                        Color.Black,
    //                        Color.Black
    //                        ))
    //                    {
    //                        if (e.Item.Selected)
    //                        {
    //                            ColorBlend colourBlend = new ColorBlend();
    //                            colourBlend.Positions = new float[]{
    //                            0.0f,
    //                            0.495f,
    //                            0.5055f,
    //                            1.0f
    //                        };
    //                            colourBlend.Colors = new Color[] {                                
    //                            Color.FromArgb(222,230,236),                          
    //                            Color.FromArgb(213,230,235),
    //                            Color.FromArgb(231,241,248),
    //                            Color.FromArgb(246,247,247)
    //                        };

    //                            b.InterpolationColors = colourBlend;

    //                            e.Graphics.FillRectangle(b, new Rectangle(Point.Empty, e.Item.Size));
    //                        }
    //                        else
    //                        {
    //                            ColorBlend colourBlend = new ColorBlend();
    //                            colourBlend.Positions = new float[]{
    //                            0.0f,
    //                            0.495f,
    //                            0.5055f,
    //                            1.0f
    //                        };
    //                            colourBlend.Colors = new Color[] {
    //                            Color.FromArgb(227,235,241),
    //                            Color.FromArgb(218,235,240),
    //                            Color.FromArgb(236,246,253),
    //                            Color.FromArgb(251,252,252)
    //                        };

    //                            b.InterpolationColors = colourBlend;

    //                            e.Graphics.FillRectangle(b, new Rectangle(Point.Empty, e.Item.Size));
    //                        }
    //                    }
    //                }
    //            }

    //            //Border
    //            using (GraphicsPath path =
    //                RoundedRectangle(outerBorder, 2))
    //            {
    //                using (Pen p = new Pen(Color.FromArgb(172,178,180)))
    //                {
    //                    e.Graphics.DrawPath(p, path);
    //                }
    //            }

    //            // Fill
    //            using (GraphicsPath path = RoundedRectangle(innerBorder, 3))
    //            {
    //                using (Brush b = new LinearGradientBrush(
    //                    new Point(0, innerBorder.Top),
    //                    new Point(0, innerBorder.Bottom),
    //                    Color.Black, Color.Black))
    //                {
    //                    // Testing no fill
    //                    //g.FillPath(b, path);
    //                }
    //            }

    //            Color innerBorderColor = e.Item.Selected || IsChecked ? Color.FromArgb(180,185,188) : Color.FromArgb(168,174,176);

    //            //Inner border
    //            using (GraphicsPath path =
    //                RoundedRectangle(innerBorder, 2))
    //            {
    //                using (Pen p = new Pen(innerBorderColor))
    //                {
    //                    e.Graphics.DrawPath(p, path);
    //                }
    //            }
    //        }

    //        base.OnRenderButtonBackground(e);
    //    }
    //    protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
    //    {

    //        base.OnRenderDropDownButtonBackground(e);
    //    }
    //    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    //    {
    //        base.OnRenderMenuItemBackground(e);
    //    }
    //    protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
    //    {
    //        base.OnRenderSplitButtonBackground(e);
    //    }
    //    protected override void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
    //    {
    //        base.OnRenderLabelBackground(e);
    //    }
    //    protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
    //    {
    //        base.OnRenderItemBackground(e);
    //    }
    //    protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
    //    {
    //        base.OnRenderOverflowButtonBackground(e);
    //    }
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDownMenu)
            {
                return;
            }

            // Interpolate gradient and add stops
            LinearGradientBrush headerBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, e.AffectedBounds.Height),
                Color.Black,
                Color.Black
                );
            ColorBlend colourBlend = new ColorBlend();
            colourBlend.Positions = new float[]{
                0.0f,
                0.495f,
                0.5055f,
                1.0f
            };
            colourBlend.Colors = new Color[] {
                Color.FromArgb(246,247,247),
                Color.FromArgb(231,241,248),
                Color.FromArgb(213,230,235),
                Color.FromArgb(222,230,236)
            };

            headerBrush.InterpolationColors = colourBlend;

            e.Graphics.FillRectangle(headerBrush, e.AffectedBounds);     


            //base.OnRenderToolStripBackground(e);
        }
        //protected override void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        //{
        //    base.OnRenderToolStripPanelBackground(e);
        //}
        //protected override void OnRenderToolStripStatusLabelBackground(ToolStripItemRenderEventArgs e)
        //{
        //    base.OnRenderToolStripStatusLabelBackground(e);
        //}
        //protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        //{
        //    base.OnRenderToolStripContentPanelBackground(e);
        //}
        //protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        //{
        //    Pen pen = new Pen(Color.FromArgb(172, 178, 180));
        //    e.Graphics.DrawRectangle(
        //        pen,
        //        new Rectangle(e.AffectedBounds.X,e.AffectedBounds.Y,e.AffectedBounds.Width -1, e.AffectedBounds.Height -1)
        //        );

        //    base.OnRenderToolStripBorder(e);
        //}
        //
        //private void DrawButtonBackground(ToolStripItemRenderEventArgs e)
        //{
        //    bool chk = false;

        //    if (e.Item is ToolStripButton)
        //    {
        //        chk = (e.Item as ToolStripButton).Checked;
        //    }

        //    DrawButtonBackground(e.Graphics,
        //        new Rectangle(Point.Empty, e.Item.Size),
        //        e.Item.Selected,
        //        e.Item.Pressed,
        //        chk);
        //}

        ///// <summary>
        ///// Renders the background of a button on the specified rectangle using the specified device
        ///// </summary>
        ///// <param name="e"></param>
        //private void DrawButtonBackground(Graphics g, Rectangle r, bool selected, bool pressed, bool checkd)
        //{
        //    g.SmoothingMode = SmoothingMode.AntiAlias;

        //    Rectangle outerBorder = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
        //    Rectangle border = outerBorder; border.Inflate(-1, -1);
        //    Rectangle innerBorder = border; innerBorder.Inflate(-1, -1);
        //    Rectangle glossy = outerBorder; glossy.Height /= 2;
        //    Rectangle fill = innerBorder; fill.Height /= 2;
        //    Rectangle glow = Rectangle.FromLTRB(outerBorder.Left,
        //        outerBorder.Top + Convert.ToInt32(Convert.ToSingle(outerBorder.Height) * .5f),
        //        outerBorder.Right, outerBorder.Bottom);

        //    if (selected || pressed || checkd)
        //    {
        //        #region Layers

        //        //Outer border
        //        using (GraphicsPath path =
        //            RoundedRectangle(outerBorder, 4))
        //        {
        //            using (Pen p = new Pen(ColorTable.ButtonOuterBorder))
        //            {
        //                g.DrawPath(p, path);
        //            }
        //        }

        //        //Checked fill
        //        if (checkd)
        //        {
        //            using (GraphicsPath path = RoundedRectangle(innerBorder, 2))
        //            {
        //                using (Brush b = new SolidBrush(selected ? ColorTable.CheckedButtonFillHot : ColorTable.CheckedButtonFill))
        //                {
        //                    g.FillPath(b, path);
        //                }
        //            }
        //        }

        //        //Glossy effefct
        //        using (GraphicsPath path = GraphicsTools.CreateTopRoundRectangle(glossy, ButtonRadius))
        //        {
        //            using (Brush b = new LinearGradientBrush(
        //                new Point(0, glossy.Top),
        //                new Point(0, glossy.Bottom),
        //                ColorTable.GlossyEffectNorth,
        //                ColorTable.GlossyEffectSouth))
        //            {
        //                g.FillPath(b, path);
        //            }
        //        }

        //        //Border
        //        using (GraphicsPath path =
        //            RoundedRectangle(border, ButtonRadius))
        //        {
        //            using (Pen p = new Pen(ColorTable.ButtonBorder))
        //            {
        //                g.DrawPath(p, path);
        //            }
        //        }

        //        Color fillNorth = pressed ? ColorTable.ButtonFillNorthPressed : ColorTable.ButtonFillNorth;
        //        Color fillSouth = pressed ? ColorTable.ButtonFillSouthPressed : ColorTable.ButtonFillSouth;

        //        //Fill
        //        using (GraphicsPath path = GraphicsTools.CreateTopRoundRectangle(fill, ButtonRadius))
        //        {
        //            using (Brush b = new LinearGradientBrush(
        //                new Point(0, fill.Top),
        //                new Point(0, fill.Bottom),
        //                fillNorth, fillSouth))
        //            {
        //                g.FillPath(b, path);
        //            }
        //        }

        //        Color innerBorderColor = pressed || checkd ? ColorTable.ButtonInnerBorderPressed : ColorTable.ButtonInnerBorder;

        //        //Inner border
        //        using (GraphicsPath path =
        //            GraphicsTools.CreateRoundRectangle(innerBorder, ButtonRadius))
        //        {
        //            using (Pen p = new Pen(innerBorderColor))
        //            {
        //                g.DrawPath(p, path);
        //            }
        //        }

        //        //Glow
        //        using (GraphicsPath clip = RoundedRectangle(glow, 2))
        //        {
        //            g.SetClip(clip, CombineMode.Intersect);

        //            Color glowColor = ColorTable.Glow;

        //            if (checkd)
        //            {
        //                if (selected)
        //                {
        //                    glowColor = ColorTable.CheckedGlowHot;
        //                }
        //                else
        //                {
        //                    glowColor = ColorTable.CheckedGlow;
        //                }
        //            }

        //            using (GraphicsPath brad = CreateBottomRadialPath(glow))
        //            {
        //                using (PathGradientBrush pgr = new PathGradientBrush(brad))
        //                {
        //                    unchecked
        //                    {
        //                        int opacity = 255;
        //                        RectangleF bounds = brad.GetBounds();
        //                        pgr.CenterPoint = new PointF((bounds.Left + bounds.Right) / 2f, (bounds.Top + bounds.Bottom) / 2f);
        //                        pgr.CenterColor = Color.FromArgb(opacity, glowColor);
        //                        pgr.SurroundColors = new Color[] { Color.FromArgb(0, glowColor) };
        //                    }
        //                    g.FillPath(pgr, brad);
        //                }
        //            }
        //            g.ResetClip();
        //        }




        //        #endregion
        //    }
        //}
        //
        //private GraphicsPath RoundedRectangle(Rectangle r, int radius)
        //{
        //    float x = r.X, y = r.Y, w = r.Width, h = r.Height;
        //    GraphicsPath path = new GraphicsPath();
        //    path.AddBezier(x, y + radius, x, y, x + radius, y, x + radius, y);
        //    path.AddLine(x + radius, y, x + w - radius, y);
        //    path.AddBezier(x + w - radius, y, x + w, y, x + w, y + radius, x + w, y + radius);
        //    path.AddLine(x + w, y + radius, x + w, y + h - radius);
        //    path.AddBezier(x + w, y + h - radius, x + w, y + h, x + w - radius, y + h, x + w - radius, y + h);
        //    path.AddLine(x + w - radius, y + h, x + radius, y + h);
        //    path.AddBezier(x + radius, y + h, x, y + h, x, y + h - radius, x, y + h - radius);
        //    path.AddLine(x, y + h - radius, x, y + radius);
        //    return path;
        //}
    }
}
