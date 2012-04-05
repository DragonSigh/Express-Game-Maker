//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using EGMGame.Library;
using EGMGame.Controls;
using System.Collections;
using Microsoft.Xna.Framework;
using GenericUndoRedo;
using System.IO;
using EGMGame.Dialogs;
using EGMGame.Controls.UI;

namespace EGMGame.Docking.Editors
{
    public partial class AnimationEditor : DockContent, IHistory, IEditor
    {

        #region "Fields"
        internal AnimationData SelectedAnimation
        {
            get
            {
                if (GameData.Animations.ContainsKey(animationsList.SelectedID))
                {
                    return GameData.Animations[animationsList.SelectedID];
                }
                else
                    return null;
            }
        }
        internal AnimationAction SelectedAction
        {
            get
            {
                if (SelectedAnimation != null && actionsList.Data().ID > -1)
                {
                    return actionsList.Data<AnimationAction>();
                }
                else
                    return null;
            }
        }

        internal List<AnimationFrame> SelectedDirection
        {
            get
            {
                if (SelectedAction != null && SelectedAction.Directions[directionIndex] != null)
                    return SelectedAction.Directions[directionIndex];
                else
                    return null;
            }
        }
        int directionIndex;

        internal AnimationFrame SelectedFrame
        {
            get
            {
                if (SelectedDirection != null && frameIndex < SelectedDirection.Count)
                    return SelectedDirection[frameIndex];
                else
                    return null;
            }
        }

        public int frameIndex;

        internal AnimationSprite SelectedSprite
        {
            get
            {
                return selSprite;
            }
        }
        internal AnimationSprite selSprite;

        public PhysicsPin SelectedPin;

        public AnimationParticle SelectedParticle;
        #endregion

        bool allowChange = true;

        public AnimationEditor()
        {
            try
            {
                InitializeComponent();
                dockContextMenu1.owner = this;
                this.TabPageContextMenuStrip = dockContextMenu1;
                this.KeyPreview = true;
                // Directions
                directionIndex = 0;
                cbParticles.RefreshList(false);
                SetupSE();
                // Setup History
                MainForm.AnimationHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);

                this.DoubleBuffered = true;

                //desc.Visible = (MainForm.Configuration.AnimationTips);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x005");
            }
        }
        /// <summary>
        /// Activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.AnimationHistory[this];
            // Setup All Lists
            if (animationsList.Nodes.Count == 0)
                SetupList();
        }

        #region Property

        public void SetupList()
        {
            // Animations
            animationsList.SetupList(GameData.Animations, typeof(AnimationData));
            animationsList.SelectFirst();
            SetupSE();
            SetupProperty(SelectedAnimation);
        }

        private void SetupProperty(AnimationData data)
        {
            if (data != null)
            {
                animationComp.ResetAnimation();
                actionsList.SetupList(data.Actions, typeof(AnimationAction));
                actionsList.SelectFirst();
                SetupAction(SelectedAction);
            }
            else
            {
                animationComp.ResetAnimation();
                actionsList.Clear(true); panelFrame.Enabled = false; scrollFrame.Enabled = false;
                btnAddFrame.Enabled = false;
                actionPanel.Enabled = false;
                actionPanel.Enabled = false;
                framePanel.Enabled = false;
                spritePanel.Enabled = false;
                animationComp.Enabled = false;
                animationComp.SelectedFrame = null;
            }
        }

        private void SetupAction(AnimationAction data)
        {
            if (data != null)
            {
                if (SelectedAction.Directions.Count != 8)
                {
                    while (SelectedAction.Directions.Count != 8)
                    {
                        SelectedAction.Directions.Add(new List<AnimationFrame>());
                    }
                }
                animationComp.ResetAnimation();
                panelFrame.Enabled = true;
                btnAddFrame.Enabled = true;
                actionPanel.Enabled = true;
                actionPanel.Enabled = true;
                allowChange = false;
                canvasH.Value = (decimal)data.CanvasSize.Y;
                canvasW.Value = (decimal)data.CanvasSize.X;
                loopsBox.Value = (decimal)data.LoopCount;
                canvasH.OnChange = false;
                canvasW.OnChange = false;
                loopsBox.OnChange = false;
                infLoopBtn.Checked = data.InfiniteLoop;
                loopsBox.Enabled = !infLoopBtn.Checked;
                allowChange = true;
                TimeLapse = 0;
                for (int j = 0; j < SelectedDirection.Count; j++)
                    TimeLapse += SelectedDirection[j].TimeElapse;
                panelDirections.Enabled = true; panelFrame.Enabled = true;
                SetupDirection(directionIndex);
            }
            else
            {
                canvasH.Value = 0;
                canvasW.Value = 0;
                loopsBox.Value = 0;
                canvasH.OnChange = false;
                canvasW.OnChange = false;
                loopsBox.OnChange = false;
                infLoopBtn.Checked = false;
                panelDirections.Enabled = false; panelFrame.Enabled = false; scrollFrame.Enabled = false;
                btnAddFrame.Enabled = false;
                actionPanel.Enabled = false;
                framePanel.Enabled = false;
                spritePanel.Enabled = false;
                animationComp.Enabled = false;
                animationComp.SelectedFrame = null;
            }
        }

        public int TimeLapse = 1;
        private void SetupDirection(int i)
        {
            if (i < 8 && i > -1)
            {
                animationComp.ResetAnimation();
                if (SelectedAction.Directions.Count != 8)
                {
                    while (SelectedAction.Directions.Count != 8)
                    {
                        SelectedAction.Directions.Add(new List<AnimationFrame>());
                    }
                }
                if (SelectedAction.Directions[i] == null)
                    SelectedAction.Directions[i] = new List<AnimationFrame>();

                directionIndex = i;

                TimeLapse = 0;
                for (int j = 0; j < SelectedDirection.Count; j++)
                    TimeLapse += SelectedDirection[j].TimeElapse;

                SetupFrame(0, true);

                UpdateScrollBar();

            }
        }

        internal void SetupFrame(int i, bool showPage)
        {
            if (SelectedAction.Directions.Count != 8)
            {
                while (SelectedAction.Directions.Count != 8)
                {
                    SelectedAction.Directions.Add(new List<AnimationFrame>());
                }
            }
            if (SelectedDirection != null && i < SelectedDirection.Count)
            {
                frameIndex = i;

                //SetupSprite(null);

                SetupFrame(SelectedFrame, showPage);

                panelFrame.Invalidate();

            }
            else
            {
                //SetupSprite(null);
                animationComp.SelectedFrame = null;
            }
        }


        internal void SetupDrawFrame(int i)
        {
            if (SelectedDirection != null && i < SelectedDirection.Count)
            {
                AnimationFrame f = SelectedDirection[i];
                animationComp.DrawFrame = f;
            }
            else
                animationComp.DrawFrame = null;
        }

        internal void SetupFrame(AnimationFrame data, bool showPage)
        {
            if (data != null)
            {
                framePanel.Enabled = true;
                allowChange = false;

                chFlash.Checked = data.FlashScreen;
                chShake.Checked = data.ShakeScreen;
                timeBox.Value = (decimal)data.TimeElapse;
                timeBox.OnChange = false;
                seBtn.Checked = data.PlaySE;
                //SetupSE();
                seList.Select(data.SoundEffectID);
                animationComp.Enabled = true;
                animationComp.SelectedAction = SelectedAction;
                animationComp.SelectedDirection = SelectedDirection;
                animationComp.SelectedFrame = data;
                if (frameIndex > 0)
                    animationComp.PreviousFrame = SelectedDirection[frameIndex - 1];
                else
                    animationComp.PreviousFrame = null;
                allowChange = true;
                if (animationComp.SelectedData != null && animationComp.SelectedData is AnimationSprite)
                {
                    //SetupSprite((AnimationSprite)animationComp.SelectedData);
                }

                if (showPage)
                    if (SelectedFrame.Sprites.Count > 0)
                    { selSprite = SelectedFrame.Sprites[0]; }
                    else
                    { selSprite = null; }
                if (showPage)
                    SetupSprite(selSprite);
                if (selSprite == null)
                    spritePanel.Enabled = false;

                if (showPage)
                    tabControl1.SelectedTab = framePage;
            }
            else
            {
                framePanel.Enabled = false;
                spritePanel.Enabled = false;
                animationComp.Enabled = false;
                animationComp.SelectedFrame = null;
                panelFrame.Invalidate();
            }
        }

        private void SetupSE()
        {
            seList.RefreshList(false);
        }

        public void SetupSprite(AnimationSprite data)
        {
            selSprite = data;
            if (data != null)
            {
                allowChange = false;
                spritePanel.Enabled = true;
                scaleX.Value = (decimal)data.Scale.X;
                scaleY.Value = (decimal)data.Scale.Y;
                rotateBox.Value = (decimal)data.Rotation;
                scaleX.OnChange = false;
                scaleY.OnChange = false;
                rotateBox.OnChange = false;
                hFlipBtn.Checked = data.HorizontalFlip;
                vFlipBtn.Checked = data.VerticalFlip;
                nudOriginX.Value = (decimal)data.OriginOffset.X;
                nudOriginY.Value = (decimal)data.OriginOffset.Y;
                tintColorPicker.SelectedItem = System.Drawing.Color.FromArgb(data.Tint.A, data.Tint.R, data.Tint.G, data.Tint.B);
                chTorqueSync.Checked = data.TorqueSync;
                allowChange = true;
            }
            else
            {
                scaleX.Value = 1m;
                scaleY.Value = 1m;
                rotateBox.Value = 0;
                scaleX.OnChange = false;
                scaleY.OnChange = false;
                rotateBox.OnChange = false;
                spritePanel.Enabled = false;
            }
        }

        internal void SetupPin(PhysicsPin data)
        {
            SelectedPin = data;
            if (data != null)
            {
                allowChange = false;
                panelPin.Enabled = true;
                chkEnableMotor.Checked = data.EnableMotor;
                nudMotorSpeed.Value = (decimal)data.MotorSpeed;
                nudMotorTorque.Value = (decimal)data.MotorTorque;

                allowChange = true;
            }
            else
            {
                allowChange = false;
                panelPin.Enabled = false;
                allowChange = true;
            }
        }

        internal void SetupParticle(AnimationParticle data)
        {
            SelectedParticle = data;
            if (data != null)
            {
                allowChange = false;
                panelParticle.Enabled = true;

                cbParticles.Select(data.Particle);
                chkParticleAngularSync.Checked = SelectedParticle.AngularSync;

                allowChange = true;
            }
            else
            {
                allowChange = false;
                panelParticle.Enabled = false;
                allowChange = true;
            }
        }
        #endregion

        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Animations.Add(data.ID, (AnimationData)data);
            animationsList.AddNode(data);

            Global.CBAnimations();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Animations.Remove(data.ID);

            animationsList.RemoveNode(data);

            Global.CBAnimations();
        }
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataActionAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((AnimationData)hist.Parent).Actions.Add((AnimationAction)data);

            if (SelectedAnimation == ((AnimationData)hist.Parent))
            {
                actionsList.AddNode(data);
            }
            Global.CBActions(((AnimationData)hist.Parent));
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataActionRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((AnimationData)hist.Parent).Actions.Remove((AnimationAction)data);

            if (SelectedAnimation == ((AnimationData)hist.Parent))
            {
                actionsList.RemoveNode(data);
            }
            Global.CBActions(((AnimationData)hist.Parent));
        }
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataFrameAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((List<AnimationFrame>)hist.Collection).Insert(hist.Index, (AnimationFrame)data);

            panelFrame.Invalidate();
            //if (SelectedDirection == (List<AnimationFrame>)hist.Collection)
            //    framesList.AddNode(data);
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataFrameRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((List<AnimationFrame>)hist.Collection).Remove((AnimationFrame)data);

            panelFrame.Invalidate();
            //if (SelectedDirection == (List<AnimationFrame>)hist.Collection)
            //    framesList.RemoveNode(data);
        }
        /// <summary>
        /// Data Changed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataFrameChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            if (SelectedFrame == data)
            {
                SetupFrame((AnimationFrame)data, false);
            }
        }
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataSpriteAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((List<AnimationSprite>)hist.Collection).Insert(hist.Index, (AnimationSprite)data);
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataSpriteRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((List<AnimationSprite>)hist.Collection).Remove((AnimationSprite)data);
        }
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataAnchorAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((List<AnimationAnchor>)hist.Collection).Insert(hist.Index, (AnimationAnchor)data);
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataAnchorRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((List<AnimationAnchor>)hist.Collection).Remove((AnimationAnchor)data);
        }
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataPinAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((List<PhysicsPin>)hist.Collection).Insert(hist.Index, (PhysicsPin)data);
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataPinRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((List<PhysicsPin>)hist.Collection).Remove((PhysicsPin)data);
        }
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataParticleAdded(IGameDataAddedHist hist, IGameData data)
        {
            ((List<AnimationParticle>)hist.Collection).Insert(hist.Index, (AnimationParticle)data);
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataParticleRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            ((List<AnimationParticle>)hist.Collection).Remove((AnimationParticle)data);
        }
        #endregion

        #region List Events
        private void animationsList_AddItem(object sender, AddRemoveListEventArgs e)
        {
            try
            {
                // Add New Animation
                AnimationData a = new AnimationData();
                a.Name = Global.GetName("Animation", GameData.Animations);
                a.ID = Global.GetID(GameData.Animations);
                a.Category = e.Category;

                GameData.Animations.Add(a.ID, a);

                MainForm.AnimationHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                animationsList.AddNode(a);

                Global.CBAnimations();

                lblDirections.Text = "Add an " + '"' + "Action" + '"' + ".\nAn Action is a set of grouped direction\nbased frames.";


            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x004");
            }
        }

        private void animationsList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            try
            {
                // Get Items
                if (SelectedAnimation != null)
                {
                    AnimationData ani = SelectedAnimation;
                    // Remove Animation
                    int index = ani.ID;
                    GameData.Animations.Remove(ani.ID);

                    // History
                    MainForm.AnimationHistory[this].Do(new IGameDataRemovedHist(animationsList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    // Setuplist
                    animationsList.RemoveSelectedNode();
                    // Setup Actions
                    SetupProperty(SelectedAnimation);

                    Global.CBAnimations();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x006");
            }
        }

        private void animationsList_SelectItem(object sender, AddRemoveListEventArgs e)
        {
            if (e.Index > -1 && GameData.Animations.ContainsKey(e.ID))
            {
                SetupProperty(SelectedAnimation);
            }
            else
            {
                SetupProperty(null);
            }
        }

        private void actionsList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            try
            {
                if (SelectedAnimation != null)
                {
                    // Add New Animation
                    AnimationAction a = new AnimationAction();
                    a.Name = Global.GetName("Action", SelectedAnimation.Actions);
                    a.ID = Global.GetID(SelectedAnimation.Actions);
                    SelectedAnimation.Actions.Add(a);
                    // History
                    int index = a.ID;
                    // History
                    MainForm.AnimationHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataActionAdded), new DataRemoveDelegate(DataActionRemoved), SelectedAnimation));
                    // Add Lists
                    actionsList.AddNode(a);

                    a.Directions = new List<List<AnimationFrame>>()
                    {
                        new List<AnimationFrame>(),
                        new List<AnimationFrame>(),
                        new List<AnimationFrame>(),
                        new List<AnimationFrame>(),
                        new List<AnimationFrame>(),
                        new List<AnimationFrame>(),
                        new List<AnimationFrame>(),
                        new List<AnimationFrame>()
                    };
                    // Setup
                    //SetupAction(a);

                    Global.CBActions(SelectedAnimation);


                    lblDirections.Text = "Add an " + '"' + "Action" + '"' + ".\nAn Action is a set of grouped direction\nbased frames.";
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x007");
            }
        }

        private void actionsList_RemoveItem(object sender, AddRemoveListEventArgs e)
        {

            try
            {
                if (SelectedAction != null)
                {
                    AnimationAction act = SelectedAction;
                    // Remove Animation
                    int index = act.ID;
                    SelectedAnimation.Actions.Remove(act);

                    // History
                    MainForm.AnimationHistory[this].Do(new IGameDataRemovedHist(act, new DataAddDelegate(DataActionAdded), new DataRemoveDelegate(DataActionRemoved), SelectedAnimation));

                    actionsList.RemoveSelectedNode();
                    // Setup Directions
                    SetupAction(SelectedAction);

                    Global.CBActions(SelectedAnimation);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x011");
            }
        }

        private void actionsList_SelectItem(object sender, AddRemoveListEventArgs e)
        {
            try
            {
                if (SelectedAnimation != null && e.Index > -1 && SelectedAnimation.Actions.Count > e.Index)
                {
                    SetupAction(SelectedAction);
                }
                else
                {
                    SetupAction(null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x010");
            }
        }

        private void directionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                SetupFrame(directionIndex, false);
        }

        private void framesList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            try
            {
                if (SelectedDirection != null)
                {
                    AnimationFrame lastFrame = null;
                    if (SelectedDirection.Count > 0)
                        lastFrame = SelectedDirection[frameIndex - 1];
                    // Add New Animation
                    AnimationFrame a = new AnimationFrame();
                    a.ID = Global.GetID(SelectedDirection);
                    if (lastFrame != null)
                        a.TimeElapse = lastFrame.TimeElapse;
                    a.Name = a.TimeElapse.ToString() + " Frames";
                    SelectedDirection.Add(a);
                    int index = SelectedDirection.IndexOf(a);

                    // History
                    MainForm.AnimationHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataFrameAdded), new DataRemoveDelegate(DataFrameRemoved), SelectedDirection, index));

                    SelectFrame(++frameIndex);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x008");
            }
        }

        private void framesList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            try
            {
                // Get Items
                if (SelectedFrame != null)
                {
                    // Remove Animation
                    int index = SelectedDirection.IndexOf(SelectedFrame);

                    // History
                    MainForm.AnimationHistory[this].Do(new IGameDataRemovedHist(SelectedFrame, new DataAddDelegate(DataFrameAdded), new DataRemoveDelegate(DataFrameRemoved), SelectedDirection, index));

                    SelectedDirection.Remove(SelectedFrame);

                    panelFrame.Invalidate();
                    // Setup Frames
                    SetupFrame(SelectedFrame, true);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "3x009");
            }
        }

        private void framesList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            SetupFrame(SelectedFrame, true);
        }
        #endregion

        private void canvasW_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedAction != null)
            {
                SelectedAction.CanvasSize = new Vector2((float)canvasW.Value, (float)canvasH.Value);
            }
        }

        private void canvasH_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedAction != null)
            {
                SelectedAction.CanvasSize = new Vector2((float)canvasW.Value, (float)canvasH.Value);
            }
        }

        private void loopsBox_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedAction != null)
            {
                SelectedAction.LoopCount = (int)loopsBox.Value;
            }
        }

        private void infLoopBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedAction != null)
            {
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedAction, new DataPropertyDelegate(ActionPropertyChanged))); SelectedAction.InfiniteLoop = infLoopBtn.Checked;
            }
            loopsBox.Enabled = !infLoopBtn.Checked;
        }

        private void timeBox_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedFrame == null) return;
            SelectedFrame.TimeElapse = (int)timeBox.Value;
            SelectedFrame.Name = SelectedFrame.TimeElapse + " Frames";

            panelFrame.Invalidate();
            // Rename list
            //int i = 0;
            //foreach (TreeNode node in framesList.listBox.Nodes)
            //{
            //    if (i == frameIndex)
            //    {
            //        node.Name = SelectedFrame.Name; break;
            //    }
            //    i++;
            //}
        }

        private void seBtn_CheckedChanged(object sender, EventArgs e)
        {
            seList.Enabled = seBtn.Checked;
            if (!allowChange) return;
            if (SelectedFrame == null) return;
            MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedFrame, new DataPropertyDelegate(FramePropertyChanged)));
            SelectedFrame.PlaySE = seBtn.Checked;
        }

        private void seList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedFrame == null) return;
            if (seList.Data().ID > -10)
            {
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedFrame, new DataPropertyDelegate(FramePropertyChanged)));
                SelectedFrame.SoundEffectID = seList.Data().ID;
            }
        }

        private void hFlipBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedSprite == null) return;
            MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedSprite, new DataPropertyDelegate(SpritePropertyChanged)));
            SelectedSprite.HorizontalFlip = hFlipBtn.Checked;
        }

        private void vFlipBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedSprite == null) return;
            MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedSprite, new DataPropertyDelegate(SpritePropertyChanged)));
            SelectedSprite.VerticalFlip = vFlipBtn.Checked;
        }

        private void scaleX_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedSprite == null) return;
            SelectedSprite.Scale = new Vector2((float)scaleX.Value, (float)scaleY.Value);
        }

        private void scaleY_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedSprite == null) return;
            SelectedSprite.Scale = new Vector2((float)scaleX.Value, (float)scaleY.Value);
        }

        private void rotateBox_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedSprite == null) return;
            SelectedSprite.Rotation = (float)rotateBox.Value;
        }

        private void colorPicker1_ColorSelectedEvent(System.Drawing.Color e)
        {
            if (!allowChange) return;
            if (SelectedSprite == null) return;
            if (tintColorPicker.DroppedDown)
            {
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedSprite, new DataPropertyDelegate(SpritePropertyChanged)));
                Microsoft.Xna.Framework.Color c = new Microsoft.Xna.Framework.Color((tintColorPicker.SelectedItem.R), (tintColorPicker.SelectedItem.G), (tintColorPicker.SelectedItem.B), (tintColorPicker.SelectedItem.A));
                SelectedSprite.Tint = c;
            }
        }

        private void animationComp_ItemAdded(object sender, AnimationComponent.ItemAddedEventArgs ca)
        {
            selSprite = (AnimationSprite)ca.Item;
            SetupSprite(selSprite);
        }

        private void animationComp_ItemRemoved(object sender, AnimationComponent.ItemRemovedEventArgs ca)
        {
            selSprite = null;
            SetupSprite(null);
        }

        private void animationComp_SelectedItemChange(object sender, AnimationComponent.SelectedItemEventArgs ca)
        {
            selSprite = (AnimationSprite)ca.Item;
            SetupSprite(selSprite);
        }

        private void animationComp_Updated(object sender)
        {
            if (selSprite != null)
            {
                AnimationSprite data = selSprite;
                allowChange = false;
                scaleX.Value = (decimal)data.Scale.X;
                scaleY.Value = (decimal)data.Scale.Y;
                rotateBox.Value = (decimal)data.Rotation;
                allowChange = true;
            }
        }

        internal void spriteTblBtn_Click(object sender, EventArgs e)
        {
            if (SelectedSprite != null)
            {
                SpriteGridDialog dialog = new SpriteGridDialog();
                dialog.SelectedSprite = SelectedSprite;
                dialog.ShowDialog();
            }
        }
        /// <summary>
        /// On Paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void shakeScreenBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void displayFlashBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void tintScreenColorPicker_ColorSelectedEvent(System.Drawing.Color e)
        {
            if (!allowChange) return;
            if (SelectedFrame == null) return;
            //SelectedFrame.TintColor = tintScreenColorPicker.col
        }

        private void shakeValue_ValueChanged(object sender, EventArgs e)
        {
        }
        FromSpriteSheetDialog _fromSpriteSheetDialog;
        private void btnGenSprite_Click(object sender, EventArgs e)
        {
            if (SelectedAction != null)
            {
                if (_fromSpriteSheetDialog == null)
                    _fromSpriteSheetDialog = new FromSpriteSheetDialog();
                _fromSpriteSheetDialog.Action = SelectedAction;
                _fromSpriteSheetDialog.ShowDialog();
                if (_fromSpriteSheetDialog.IsOk)
                {

                    if (SelectedAction.Directions[0].Count > 0)
                    {
                        if (SelectedAction.Directions[0][0].Sprites.Count > 0 && SelectedAction.Directions[0][0].Sprites[0] != null)
                            SelectedAction.CanvasSize = new Vector2(SelectedAction.Directions[0][0].Sprites[0].DisplayRect.Width, SelectedAction.Directions[0][0].Sprites[0].DisplayRect.Height);
                    }
                    SetupAction(SelectedAction);
                    int j = directionIndex;
                    for (int i = 0; i < 8; i++)
                        directionIndex = i;
                    directionIndex = j;
                }
            }
        }

        private void btnFlash_Click(object sender, EventArgs e)
        {
            if (SelectedFrame != null)
            {
                tintColorPicker.ColorSelectedEvent -= colorPicker1_ColorSelectedEvent;
                FlashFrameDialog dialog = new FlashFrameDialog();
                dialog.Setup(SelectedFrame);
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                } this.tintColorPicker.ColorSelectedEvent += new EGMGame.ColorPickerCombobox.ColorSelectedHandler(this.colorPicker1_ColorSelectedEvent);

            }
        }

        private void btnShake_Click(object sender, EventArgs e)
        {
            if (SelectedFrame != null)
            {
                ShakeFrameDialog dialog = new ShakeFrameDialog();
                dialog.Setup(SelectedFrame);
                if (dialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void chFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedFrame != null)
            {
                if (allowChange)
                {
                    MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedFrame, new DataPropertyDelegate(FramePropertyChanged)));

                    SelectedFrame.FlashScreen = chFlash.Checked;

                }
                btnFlash.Enabled = chFlash.Checked;
            }
        }

        private void chShake_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedFrame != null)
            {
                if (allowChange)
                {
                    MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedFrame, new DataPropertyDelegate(FramePropertyChanged)));
                    SelectedFrame.ShakeScreen = chShake.Checked;
                }
                btnShake.Enabled = chShake.Checked;
            }
        }

        #region History
        bool undoRedoChange = true;
        private void ActionPropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            undoRedoChange = false;
            if (SelectedAction == data)
            {
                SetupAction((AnimationAction)data);
            }
            undoRedoChange = true;
        }
        private void FramePropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            undoRedoChange = false;
            if (SelectedFrame == data)
            {
                SetupFrame((AnimationFrame)data, false);
            }

            undoRedoChange = true;
        }
        private void SpritePropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            undoRedoChange = false;
            if (SelectedSprite == data)
            {
                SetupSprite((AnimationSprite)data);
            }
            undoRedoChange = true;
        }
        private void PinPropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            undoRedoChange = false;
            if (SelectedPin == data)
            {
                SetupPin((PhysicsPin)data);
            }
            undoRedoChange = true;
        }
        private void ParticlePropertyChanged(IGameDataChangePropertyHist hist, IGameData data)
        {
            undoRedoChange = false;
            if (SelectedParticle == data)
            {
                SetupParticle((AnimationParticle)data);
            }
            undoRedoChange = true;
        }
        #endregion

        private void canvasW_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (!allowChange) return;
            if (SelectedAction == null) return;

            if (canvasW.OnChange)
            {
                float newValue = SelectedAction.CanvasSize.X;
                SelectedAction.CanvasSize = new Vector2((float)canvasW.OldValue, SelectedAction.CanvasSize.Y);
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedAction, new DataPropertyDelegate(ActionPropertyChanged)));
                SelectedAction.CanvasSize = new Vector2(newValue, SelectedAction.CanvasSize.Y);
                canvasW.OnChange = false;
            }
        }

        private void canvasH_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (!allowChange) return;
            if (SelectedAction == null) return;

            if (canvasH.OnChange)
            {
                float newValue = SelectedAction.CanvasSize.Y;
                SelectedAction.CanvasSize = new Vector2(SelectedAction.CanvasSize.X, (float)canvasH.OldValue);
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedAction, new DataPropertyDelegate(ActionPropertyChanged)));
                SelectedAction.CanvasSize = new Vector2(SelectedAction.CanvasSize.X, newValue);
                canvasH.OnChange = false;
            }
        }

        private void loopsBox_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (!allowChange) return;
            if (SelectedAction == null) return;

            CustomUpDown nud = loopsBox;

            if (nud.OnChange)
            {
                float newValue = SelectedAction.LoopCount;
                SelectedAction.LoopCount = (int)nud.OldValue;
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedAction, new DataPropertyDelegate(ActionPropertyChanged)));
                SelectedAction.LoopCount = (int)newValue;
                nud.OnChange = false;
            }
        }

        private void timeBox_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (!allowChange) return;
            if (SelectedFrame == null) return;

            CustomUpDown nud = timeBox;

            if (nud.OnChange)
            {
                float newValue = SelectedFrame.TimeElapse;
                SelectedFrame.TimeElapse = (int)nud.OldValue;
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedFrame, new DataPropertyDelegate(FramePropertyChanged)));
                SelectedFrame.TimeElapse = (int)newValue;
                nud.OnChange = false;
            }
        }

        private void rotateBox_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (!allowChange) return;
            if (SelectedSprite == null) return;

            CustomUpDown nud = rotateBox;

            if (nud.OnChange)
            {
                float newValue = SelectedSprite.Rotation;
                SelectedSprite.Rotation = (int)nud.OldValue;
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedSprite, new DataPropertyDelegate(SpritePropertyChanged)));
                SelectedSprite.Rotation = (int)newValue;
                nud.OnChange = false;
            }
        }


        private void scaleX_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (!allowChange) return;
            if (SelectedSprite == null) return;

            CustomUpDown nud = scaleX;

            if (nud.OnChange)
            {
                float newValue = SelectedSprite.Scale.X;
                SelectedSprite.Scale = new Vector2((float)nud.OldValue, SelectedSprite.Scale.Y);
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedSprite, new DataPropertyDelegate(SpritePropertyChanged)));
                SelectedSprite.Scale = new Vector2((float)newValue, SelectedSprite.Scale.Y);
                nud.OnChange = false;
            }
        }

        private void scaleY_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (!allowChange) return;
            if (SelectedSprite == null) return;

            CustomUpDown nud = scaleY;

            if (nud.OnChange)
            {
                float newValue = SelectedSprite.Scale.Y;
                SelectedSprite.Scale = new Vector2(SelectedSprite.Scale.X, (float)nud.OldValue);
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedSprite, new DataPropertyDelegate(SpritePropertyChanged)));
                SelectedSprite.Scale = new Vector2(SelectedSprite.Scale.X, (float)newValue);
                nud.OnChange = false;
            }
        }

        private void chTorqueSync_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedSprite == null) return;
            MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedSprite, new DataPropertyDelegate(SpritePropertyChanged)));
            SelectedSprite.TorqueSync = chTorqueSync.Checked;
        }

        private void chkEnableMotor_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedPin == null) return;
            MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedPin, new DataPropertyDelegate(PinPropertyChanged)));
            SelectedPin.EnableMotor = chkEnableMotor.Checked;

        }

        private void nudMotorSpeed_Validated_1(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (!allowChange) return;
            if (SelectedPin == null) return;

            CustomUpDown nud = nudMotorSpeed;

            if (nud.OnChange)
            {
                float newValue = SelectedPin.MotorSpeed;
                SelectedPin.MotorSpeed = (float)nud.OldValue;
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedSprite, new DataPropertyDelegate(PinPropertyChanged)));
                SelectedPin.MotorSpeed = (float)newValue;
                nud.OnChange = false;
            }
        }

        private void nudMotorTorque_Validated(object sender, EventArgs e)
        {
            if (!undoRedoChange) return;
            if (!allowChange) return;
            if (SelectedPin == null) return;

            CustomUpDown nud = nudMotorTorque;

            if (nud.OnChange)
            {
                float newValue = SelectedPin.MotorTorque;
                SelectedPin.MotorTorque = (float)nud.OldValue;
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedSprite, new DataPropertyDelegate(PinPropertyChanged)));
                SelectedPin.MotorTorque = (float)newValue;
                nud.OnChange = false;
            }
        }

        private void cbParticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedParticle == null) return;
            MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedParticle, new DataPropertyDelegate(ParticlePropertyChanged)));

            SelectedParticle.Particle = cbParticles.Data().ID;
        }

        private void chkParticleAngularSync_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedParticle == null) return;
            MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedParticle, new DataPropertyDelegate(ParticlePropertyChanged)));

            SelectedParticle.AngularSync = chkParticleAngularSync.Checked;
        }

        internal void ResetProject()
        {
            Unload();
            SetupList();
        }

        internal void AddAnimation(AnimationData a)
        {
            GameData.Animations.Add(a.ID, a);
            MainForm.AnimationHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));
            animationsList.AddNode(a);
            Global.CBAnimations();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedAction != null)
            {
                MainForm.AnimationHistory[this].Do(new IGameDataChangePropertyHist(SelectedAction, new DataPropertyDelegate(ActionPropertyChanged)));
                SelectedAction.ShowOnScreen = chkShowOnScreen.Checked;
            }
        }

        internal void Unload()
        {
            animationComp.ResetContentManager();
            if (_fromSpriteSheetForDirDialog != null)
                _fromSpriteSheetForDirDialog.ResetContentManager();
        }
        FromSpriteSheetForDirDialog _fromSpriteSheetForDirDialog;
        private void btnFromGridForDir_Click(object sender, EventArgs e)
        {
            if (SelectedAction != null)
            {
                if (_fromSpriteSheetForDirDialog == null)
                    _fromSpriteSheetForDirDialog = new FromSpriteSheetForDirDialog();
                _fromSpriteSheetForDirDialog.Action = SelectedAction;
                _fromSpriteSheetForDirDialog.Direction = directionIndex;
                _fromSpriteSheetForDirDialog.ShowDialog();
                if (_fromSpriteSheetForDirDialog.IsOk)
                {
                    //if (SelectedAction.Directions[directionIndex].Count > 0)
                    //{
                    //if (SelectedAction.Directions[directionIndex][0].Sprites.Count > 0 && SelectedAction.Directions[directionIndex][0].Sprites[0] != null)
                    // SelectedAction.CanvasSize = new Vector2(SelectedAction.Directions[directionIndex][0].Sprites[0].DisplayRect.Width, SelectedAction.Directions[directionIndex][0].Sprites[0].DisplayRect.Height);
                    //}
                    SetupAction(SelectedAction);
                    int j = directionIndex;
                    for (int i = 0; i < 8; i++)
                        directionIndex = i;
                    directionIndex = j;
                }
            }
        }
        #region Descriptions
        private void AnimationEditor_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "Hover over an item to see its description.\n\nDouble click question mark to hide/show this info.";
            pic.Image = global::EGMGame.Properties.Resources.question;
        }

        private void animationsList_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "Add an animaton. An Animation can group related Actions. For example, a player Animation can contain the Idle, Walk, and Attack Actions.";
        }

        private void actionsList_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "Add an action. Actions contain 8 Directions, collision information and canvas size.";
        }

        private void directionsList_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "Select a direction and create frames for that direction. You do not have to use every direction.";

        }

        private void btnFromGridForDir_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "Create frames from a spritesheet for the selected direction.";
        }

        private void framesList_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "Frames hold sprites. Each frame lasts for an amount of time (in frames per second) set by you.";
        }

        private void chkShowOnScreen_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "Shows the animation on screen rather then on map.";
        }

        private void infLoopBtn_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "Infinitely loops the Action.";
        }

        private void btnGenSprite_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "Generates the content of an Action from a spritesheet.";
        }

        private void btnFlash_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "";
        }

        private void btnShake_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "";
        }

        private void chTorqueSync_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "";
        }

        private void chkEnableMotor_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "";
        }

        private void chkParticleAngularSync_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "";
        }

        private void animationComp_MouseEnter(object sender, EventArgs e)
        {
            desc.Text = "See the Animation Editor tutorial or check the manual for more info.";
        }
        #endregion

        private void desc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            desc.Visible = (!desc.Visible);
            MainForm.Configuration.AnimationTips = desc.Visible;
        }

        private void nudOriginX_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedSprite == null) return;
            SelectedSprite.OriginOffset.X = (float)nudOriginX.Value;
        }

        private void nudOriginY_ValueChanged(object sender, EventArgs e)
        {
            if (!allowChange) return;
            if (SelectedSprite == null) return;
            SelectedSprite.OriginOffset.Y = (float)nudOriginY.Value;
        }

        private void btnSelectOrigin_Click(object sender, EventArgs e)
        {
            if (SelectedSprite != null)
            {
                animationComp.SelectOrigin = true;
            }
        }

        internal void SelectSprite()
        {
            tabControl1.SelectedTab = spritePage;
            animationComp.Focus();
        }

        #region Frame Controls
        private void btnAddFrame_Click(object sender, EventArgs e)
        {
            if (SelectedDirection != null)
            {
                AnimationFrame lastFrame = null;
                if (SelectedDirection.Count > 0)
                    lastFrame = SelectedDirection[SelectedDirection.Count - 1];
                // Add New Animation
                AnimationFrame a = new AnimationFrame();
                a.ID = Global.GetID(SelectedDirection);
                if (lastFrame != null)
                    a.TimeElapse = lastFrame.TimeElapse;
                a.Name = a.TimeElapse.ToString() + " Frames";
                SelectedDirection.Add(a);
                int index = SelectedDirection.IndexOf(a);

                // History
                MainForm.AnimationHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataFrameAdded), new DataRemoveDelegate(DataFrameRemoved), SelectedDirection, index));

                TimeLapse = 0;
                for (int j = 0; j < SelectedDirection.Count; j++)
                    TimeLapse += SelectedDirection[j].TimeElapse;

                UpdateScrollBar();

                SelectFrame(index);

                panelFrame.Invalidate();

            }
        }


        private void btnUp_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                SetupDirection(0);
        }

        private void btnDown_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                SetupDirection(1);
        }

        private void btnLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                SetupDirection(2);
        }

        private void btnRight_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                SetupDirection(3);
        }

        private void btnLeftUp_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                SetupDirection(4);
        }

        private void btnRightUp_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                SetupDirection(5);
        }

        private void btnLeftDown_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                SetupDirection(6);
        }

        private void btnRightDown_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedAction != null)
                SetupDirection(7);
        }
        #endregion


        internal void SelectFrame(int p)
        {
            if (SelectedDirection != null && p < SelectedDirection.Count)
            {
                SetupFrame(p, true);
            }
        }

        internal int OriginalFrame = 0;
        internal void SetOriginalFrame()
        {
            OriginalFrame = frameIndex;
        }

        internal void SetOldFrame()
        {
            animationComp.DrawFrame = null;
            if (OriginalFrame != frameIndex)
                SetupFrame(OriginalFrame, false);
        }

        internal void UpdateScrollBar()
        {
            if (SelectedDirection != null && SelectedDirection.Count - (panelFrame.Width / FramePanel.FrameSize) > 0)
            {
                scrollFrame.Maximum = SelectedDirection.Count - (panelFrame.Width / FramePanel.FrameSize);
                scrollFrame.LargeChange = 1;
                scrollFrame.SmallChange = 1;
                scrollFrame.Value = 0;
                scrollFrame.Enabled = true;
                panelFrame.Invalidate();
            }
            else
            {
                scrollFrame.Value = 0;
                scrollFrame.Enabled = false;
                panelFrame.Invalidate();
            }
        }

        private void scrollFrame_Scroll(object sender, ScrollEventArgs e)
        {
            panelFrame.Invalidate();
        }

        private void actionsList_MoveItem(object sender, AddRemoveListEventArgs ca)
        {
            if (SelectedAnimation != null)
            {
            }
        }

        private void animationComp_KeyDown(object sender, KeyEventArgs e)
        {

        }

    }
}
