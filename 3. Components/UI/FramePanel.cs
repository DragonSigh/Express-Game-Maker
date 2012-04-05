//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Dialogs;

namespace EGMGame.Controls.UI
{
    public partial class FramePanel : UserControl
    {
        public static int FrameSize = 80;

        List<AnimationFrame> SelectedDirection
        {
            get { return MainForm.animationEditor.SelectedDirection; }
        }

        AnimationFrame SelectedFrame
        {
            get { return MainForm.animationEditor.SelectedFrame; }
        }

        public FramePanel()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (MainForm.animationEditor != null && SelectedDirection != null && SelectedDirection.Count > 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), e.ClipRectangle);
                int numberOfFrames = SelectedDirection.Count;
                int totalFrames = 0, frameWidth = 0, xFrame = 0, cSwitch = 0;
                int width = e.ClipRectangle.Width;
                System.Drawing.Rectangle frames = new System.Drawing.Rectangle();

                // Add Number of frames
                totalFrames = MainForm.animationEditor.TimeLapse;
                // Create Brushes
                SolidBrush oneBrush = new SolidBrush(System.Drawing.Color.LightGray);
                SolidBrush twoBrush = new SolidBrush(System.Drawing.Color.Gray);

                System.Drawing.Color h1 = System.Drawing.Color.FromArgb(255, 206, 237, 250);
                SolidBrush hbackBrush = new SolidBrush(h1);
                Brush br = new SolidBrush(System.Drawing.Color.Black);
                Pen pen = new Pen(System.Drawing.Color.FromArgb(51, 153, 255), 3);
                Font font = new System.Drawing.Font("Georgia", 14);
                Image img = global::EGMGame.Properties.Resources.delete;
                bool movementFound = false;
                Rectangle movementRect = new Rectangle();
                // Create Rectangles
                for (int i = MainForm.animationEditor.scrollFrame.Value; i < MainForm.animationEditor.scrollFrame.Value + (this.Width / FrameSize) && i < numberOfFrames; i++)
                {
                    frameWidth = FrameSize;
                    frames.X = xFrame;
                    frames.Width = frameWidth - 2;
                    frames.Height = e.ClipRectangle.Height - 2;

                    if (MousePosition.X < xFrame && !movementFound && IsMouseDown)
                    {
                        MouseOverFrame = i;
                        movementRect = new Rectangle(xFrame - 4, 0, 8, frames.Height);
                        movementFound = true;
                    }

                    xFrame += frameWidth;
                    if (cSwitch == 0)
                    { e.Graphics.FillRectangle(oneBrush, frames); cSwitch = 1; }
                    else
                    { e.Graphics.FillRectangle(twoBrush, frames); cSwitch = 0; }

                    e.Graphics.DrawString(SelectedDirection[i].TimeElapse.ToString(), font, new SolidBrush(System.Drawing.Color.Black), frames.X + frameWidth / 2 - 14, frames.Height / 4, StringFormat.GenericDefault);
                    e.Graphics.DrawRectangle(new Pen(System.Drawing.Color.Black, 2), frames);

                    if (MainForm.animationEditor.OriginalFrame == i)
                    {
                        h1 = System.Drawing.Color.FromArgb(255, 206, 237, 250);
                        hbackBrush = new SolidBrush(h1);
                        pen = new Pen(System.Drawing.Color.FromArgb(51, 153, 255), 3);
                        e.Graphics.FillRectangle(hbackBrush, frames);
                        e.Graphics.DrawString(SelectedDirection[i].TimeElapse.ToString(), font, new SolidBrush(System.Drawing.Color.Black), frames.X + frameWidth / 2 - 14, frames.Height / 4, StringFormat.GenericDefault);
                        e.Graphics.DrawRectangle(pen, frames);

                        e.Graphics.DrawImage(img, frames.X + FrameSize - 14, frames.Y + 2, 10, 10);

                    }
                    else if (MainForm.animationEditor.animationComp.DrawFrame == SelectedDirection[i])
                    {
                        h1 = System.Drawing.Color.FromArgb(255, 255, 237, 250);
                        hbackBrush = new SolidBrush(h1);
                        pen = new Pen(System.Drawing.Color.FromArgb(51, 200, 255), 3);
                        e.Graphics.FillRectangle(hbackBrush, frames);
                        e.Graphics.DrawString(SelectedDirection[i].TimeElapse.ToString(), font, new SolidBrush(System.Drawing.Color.Black), frames.X + frameWidth / 2 - 14, frames.Height / 4, StringFormat.GenericDefault);
                        e.Graphics.DrawRectangle(pen, frames);

                        e.Graphics.DrawImage(img, frames.X + FrameSize - 14, frames.Y + 2, 10, 10);

                    }
                }
                if (!movementFound)
                {
                    if (MousePosition.X < xFrame && !movementFound && IsMouseDown)
                    {
                        MouseOverFrame = numberOfFrames;
                        movementRect = new Rectangle(xFrame - 4, 0, 8, frames.Height);
                        movementFound = true;
                    }
                }
                if (movementFound && (Math.Abs(MouseDownPosition.X - MousePosition.X) > 6 || Math.Abs(MouseDownPosition.Y - MousePosition.Y) > 6))
                {
                    hbackBrush = new SolidBrush(System.Drawing.Color.FromArgb(255, 206, 237, 250));
                    e.Graphics.FillRectangle(hbackBrush, movementRect);
                    pen = new Pen(System.Drawing.Color.FromArgb(51, 153, 255), 2);
                    e.Graphics.DrawRectangle(pen, movementRect);
                }
            }
            //base.OnPaintBackground(e);
        }

        bool IsMouseDown = false;
        Point MousePosition;
        Point MouseDownPosition;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownPosition = e.Location;
                IsMouseDown = true;

                int numberOfFrames = SelectedDirection.Count;
                int totalFrames = 0, frameWidth = 0, xFrame = 0;
                int width = this.Width;
                System.Drawing.Rectangle frames;
                // Add Number of frames
                totalFrames = MainForm.animationEditor.TimeLapse;
                for (int i = MainForm.animationEditor.scrollFrame.Value; i < MainForm.animationEditor.scrollFrame.Value + (this.Width / FrameSize) && i < numberOfFrames; i++)
                {
                    //frameWidth = (int)(((float)SelectedDirection[i].TimeElapse / (float)totalFrames) * (float)width);
                    frameWidth = FrameSize;
                    frames = new System.Drawing.Rectangle(xFrame, 0, frameWidth - 2, this.Height - 2);
                    xFrame += frameWidth;

                    if (MainForm.animationEditor.OriginalFrame == i)
                    {
                        Rectangle removeRect = new Rectangle(frames.X + FrameSize - 14, frames.Y + 2, 10, 10);

                        if (removeRect.Contains(e.Location))
                        {
                            Delete(i, frames);
                            IsMouseDown = false;
                            break;
                        }
                    }
                    else if (SelectedFrame == SelectedDirection[i])
                    {
                        Rectangle removeRect = new Rectangle(frames.X + FrameSize - 14, frames.Y + 2, 10, 10);

                        if (removeRect.Contains(e.Location))
                        {
                            Delete(i, frames);
                            IsMouseDown = false;
                            break;
                        }
                    }

                    if (frames.Contains(e.Location))
                    {
                        MainForm.animationEditor.SetupFrame(i, false);
                        MainForm.animationEditor.SetOriginalFrame();
                        break;
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (IsMouseDown)
            {
                if (MouseOverFrame != MainForm.animationEditor.OriginalFrame && SelectedDirection.Count > MainForm.animationEditor.OriginalFrame)
                {
                    if (MouseOverFrame > MainForm.animationEditor.OriginalFrame) MouseOverFrame--;
                    if (MouseOverFrame == -1) MouseOverFrame = 0;
                    // Frame Moved
                    AnimationFrame f = SelectedDirection[MainForm.animationEditor.OriginalFrame];
                    SelectedDirection.RemoveAt(MainForm.animationEditor.OriginalFrame);
                    SelectedDirection.Insert(MouseOverFrame, f);
                    MainForm.animationEditor.OriginalFrame = MouseOverFrame;
                    MainForm.animationEditor.SetupFrame(MouseOverFrame, true);
                }
            }
            IsMouseDown = false;
            Invalidate();
        }

        private void Delete(int i, Rectangle frame)
        {
            ConfirmRemoveDialog dialog = new ConfirmRemoveDialog();
            Point p = new Point(frame.X - (dialog.Width / 4), frame.Y - dialog.Height);
            dialog.Location = this.PointToScreen(p);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedDirection.RemoveAt(i);
                if (MainForm.animationEditor.OriginalFrame == i)
                {
                    if (i - 1 > 0)
                    {
                        MainForm.animationEditor.SetupFrame(i - 1, false);
                        MainForm.animationEditor.SetOriginalFrame();
                        MainForm.animationEditor.UpdateScrollBar();
                    }
                    else if (i < SelectedDirection.Count)
                    {
                        MainForm.animationEditor.SetupFrame(i, false);
                        MainForm.animationEditor.SetOriginalFrame();
                        MainForm.animationEditor.UpdateScrollBar();
                    }
                    else
                    {
                        MainForm.animationEditor.SetupFrame(null, false);
                        MainForm.animationEditor.UpdateScrollBar();
                    }
                }
                else
                {
                    MainForm.animationEditor.SetOldFrame();
                    MainForm.animationEditor.UpdateScrollBar();
                }
                Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            MainForm.animationEditor.SetOriginalFrame();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            MainForm.animationEditor.SetOldFrame();
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MousePosition = e.Location;
            if (IsMouseDown)
            {
                MouseOverFrame = -1;
                int numberOfFrames = SelectedDirection.Count;
                int totalFrames = 0, frameWidth = 0, xFrame = 0;
                int width = this.Width;
                // Add Number of frames
                totalFrames = MainForm.animationEditor.TimeLapse;
                for (int i = MainForm.animationEditor.scrollFrame.Value; i < MainForm.animationEditor.scrollFrame.Value + (this.Width / FrameSize) && i < numberOfFrames; i++)
                {
                    //frameWidth = (int)(((float)SelectedDirection[i].TimeElapse / (float)totalFrames) * (float)width);
                    frameWidth = FrameSize;

                    if ((((xFrame <= e.Location.X) && (e.Location.X < (xFrame + frameWidth - 2))) && (0 <= e.Location.Y)) && (e.Location.Y < (0 + this.Height - 2)))
                    {
                        MouseOverFrame = i;
                        MouseOverRect.X = xFrame;
                        MouseOverRect.Y = 0;
                        MouseOverRect.Width = frameWidth - 2;
                        MouseOverRect.Height = this.Height - 2;
                    }
                    xFrame += frameWidth;
                }
                Invalidate();
            }
            else
            {
                MouseOverFrame = -1;
                int numberOfFrames = SelectedDirection.Count;
                int totalFrames = 0, frameWidth = 0, xFrame = 0;
                int width = this.Width;
                // Add Number of frames
                totalFrames = MainForm.animationEditor.TimeLapse;
                for (int i = MainForm.animationEditor.scrollFrame.Value; i < MainForm.animationEditor.scrollFrame.Value + (this.Width / FrameSize) && i < numberOfFrames; i++)
                {
                    //frameWidth = (int)(((float)SelectedDirection[i].TimeElapse / (float)totalFrames) * (float)width);
                    frameWidth = FrameSize;

                    if ((((xFrame <= e.Location.X) && (e.Location.X < (xFrame + frameWidth - 2))) && (0 <= e.Location.Y)) && (e.Location.Y < (0 + this.Height - 2)))
                    {
                        MouseOverFrame = i;
                        MouseOverRect.X = xFrame;
                        MouseOverRect.Y = 0;
                        MouseOverRect.Width = frameWidth - 2;
                        MouseOverRect.Height = this.Height - 2;

                        if (MainForm.animationEditor.frameIndex != i)
                        {
                            MainForm.animationEditor.SetupDrawFrame(i);
                            Invalidate();
                            break;
                        }
                        else
                        {
                            if (
                               MainForm.animationEditor.animationComp.DrawFrame != null)
                            {
                                MainForm.animationEditor.animationComp.DrawFrame = null;
                                Invalidate();
                            }
                            break;
                        }
                    }
                    xFrame += frameWidth;
                }
            }
        }

        int MouseOverFrame = -1;
        Rectangle MouseOverRect = new Rectangle();

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MouseOverFrame > -1 && MouseOverFrame < SelectedDirection.Count)
            {
                AnimationFrame f = Global.Duplicate<AnimationFrame>(SelectedDirection[MouseOverFrame]);
                f.ID = Global.GetID(SelectedDirection);
                SelectedDirection.Insert(MouseOverFrame, f);
                Invalidate();
            }
        }

        private void copuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MouseOverFrame > -1 && MouseOverFrame < SelectedDirection.Count)
            {
                Global.Copy(SelectedDirection[MouseOverFrame]);
                Invalidate();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object obj = Global.PasteData();

            if (obj is AnimationFrame)
            {
                AnimationFrame f = (AnimationFrame)obj;
                f.ID = Global.GetID(SelectedDirection);
                if (MouseOverFrame < 0)
                    MouseOverFrame = SelectedDirection.Count;
                SelectedDirection.Insert(MouseOverFrame, f);

                MainForm.animationEditor.SetupFrame(MouseOverFrame, true);
                MainForm.animationEditor.OriginalFrame = MouseOverFrame;
                Invalidate();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MouseOverFrame > -1 && MouseOverFrame < SelectedDirection.Count)
            {
                Delete(MouseOverFrame, MouseOverRect);
            }
        }
    }
}
