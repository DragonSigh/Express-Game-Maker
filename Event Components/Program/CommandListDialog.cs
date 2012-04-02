using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs;
using EGMGame.EventControls.EventDialogs.CommandDialogs;
using EGMGame.EventControls.EventDialogs.CommandDialogs.DisplayDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.DataDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.ConditionDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.EventDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.PartyDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.HeroDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Screen_Dialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.Picture;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.DisplayDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.OtherDialogs;
using EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.SoundDialogs;

namespace EGMGame.Controls.EventControls.EventDialogs
{
    public partial class BehaviorListDialog : Form
    {
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value; }
        }
        IEvent selectedEvent;
        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; btnMenu.Visible = panelMenu.Visible = false; }
        }
        EventPageData selectedPage;
        public DialogResult ThisResult = DialogResult.Cancel;

        public EventProgramData SelectedAction
        {
            get { return selectedAction; }
            set
            {
                selectedAction = value;

                if (SelectedEvent is GlobalEventData)
                {
                    btnBattleConditions.Enabled = false;
                    btnUseItem.Enabled = false;
                    btnUseSkillMagic.Enabled = false;
                    btnForceUseSlot.Enabled = false;
                    btnSimulateAttack.Enabled = false;
                    btnAssignTarget.Enabled = false;
                    btnSelectTarget.Enabled = false;
                }

            }
        }
        EventProgramData selectedAction;

        public List<EventProgramData> Programs
        {
            get
            {
                if (selectedPage != null) programs = selectedPage.Programs;
                return programs;
            }
            set { programs = value; btnMenu.Visible = true; panelMenu.Visible = true; }
        }
        List<EventProgramData> programs;

        public BehaviorListDialog()
        {
            InitializeComponent();
            desc.Visible = MainForm.Configuration.EventCommandsTips;
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

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            if (selectedPage == null)
                return;
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelGraphics.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = true;
        }


        private void displayBtn_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = true;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelGraphics.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void condBtn_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = true;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelGraphics.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void loopsBtn_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = true;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelGraphics.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void effectsBtn_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = true;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelGraphics.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void databaseBtn_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = true;
            panelMap.Visible = false;
            panelGraphics.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void aiBtn_Click(object sender, EventArgs e)
        {
            if (selectedPage == null)
                return;
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = true;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void scnBtn_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = true;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void otherBtn_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = true;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelParticle.Visible = false;
            panelScreen.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }
        /// <summary>
        /// Memory Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMemory_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelGraphics.Visible = false;
            panelMemory.Visible = true;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }
        /// <summary>
        /// Graphics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGraphics_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = true;
            panelScreen.Visible = false;
            panelParticle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void screenBtn_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelHero.Visible = false;
            panelParty.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelParticle.Visible = false;
            panelScreen.Visible = true;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void btnParty_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelScreen.Visible = false;
            panelHero.Visible = false;
            panelParticle.Visible = false;
            panelParty.Visible = true;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void btnHero_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelPicture.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelScreen.Visible = false;
            panelParty.Visible = false;
            panelParticle.Visible = false;
            panelHero.Visible = true;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelScreen.Visible = false;
            panelParty.Visible = false;
            panelHero.Visible = false;
            panelParticle.Visible = false;
            panelPicture.Visible = true;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }


        private void btnParticles_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelScreen.Visible = false;
            panelParty.Visible = false;
            panelHero.Visible = false;
            panelPicture.Visible = false;
            panelParticle.Visible = true;
            panelBattle.Visible = false;
            panelAttachment.Visible = false;
        }

        private void battleBtn_Click(object sender, EventArgs e)
        {
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelScreen.Visible = false;
            panelParty.Visible = false;
            panelHero.Visible = false;
            panelPicture.Visible = false;
            panelParticle.Visible = false;
            panelMenu.Visible = false;
            panelBattle.Visible = true;
            panelAttachment.Visible = false;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            panelDisplay.Visible = false;
            panelConditions.Visible = false;
            panelEvent.Visible = false;
            panelSound.Visible = false;
            panelLoops.Visible = false;
            panelData.Visible = false;
            panelMap.Visible = false;
            panelOther.Visible = false;
            panelMemory.Visible = false;
            panelGraphics.Visible = false;
            panelScreen.Visible = false;
            panelParty.Visible = false;
            panelHero.Visible = false;
            panelPicture.Visible = false;
            panelParticle.Visible = false;
            panelBattle.Visible = false;
            panelMenu.Visible = true;
            panelAttachment.Visible = false;
        }

        #region Map
        private void transEventBtn_Click(object sender, EventArgs e)
        {
            TransferPlayerDialog dialog = new TransferPlayerDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnToggleMapLayer_Click(object sender, EventArgs e)
        {
            // Event Layer Dialog
            ToggleMapLayerDialog dialog = new ToggleMapLayerDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Camera Scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cameraBtn_Click(object sender, EventArgs e)
        {
            CameraSettingsDialog dialog = new CameraSettingsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        ///  Center Camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCamera_Click(object sender, EventArgs e)
        {
            CenterCameraDialog dialog = new CenterCameraDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Change fog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chngFogBtn_Click(object sender, EventArgs e)
        {
            EditFogDialog dialog = new EditFogDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Add Weather
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addWeathEffectsBtn_Click(object sender, EventArgs e)
        {
            EditWeatherDialog dialog = new EditWeatherDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Audio
        private void bgmBtn_Click(object sender, EventArgs e)
        {
            // BGM Controls dialog
            AudioPlayDialog dialog = new AudioPlayDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Control Audio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlAudio_Click(object sender, EventArgs e)
        {
            // Audio Controls dialog
            AudioControlsDialog dialog = new AudioControlsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Play List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playListBtn_Click(object sender, EventArgs e)
        {
            // BGM Controls dialog
            PlayListDialog dialog = new PlayListDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Control Playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlPlayListBtn_Click(object sender, EventArgs e)
        {
            // Audio Controls dialog
            PlaylistControls dialog = new PlaylistControls();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        private void btnCtrl3DAudi_Click(object sender, EventArgs e)
        {
            // BGM Controls dialog
            AudioCTRLDialog dialog = new AudioCTRLDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnPlay3DAudio_Click(object sender, EventArgs e)
        {
            // BGM Controls dialog
            Audio3DPlayDialog dialog = new Audio3DPlayDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Create Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createEventBtn_Click(object sender, EventArgs e)
        {
            AddEventDialog dialog = new AddEventDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Setup
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void changAniBtn_Click(object sender, EventArgs e)
        {
            ChangeAnimationDialog dialog = new ChangeAnimationDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Setup
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void movementBtn_Click(object sender, EventArgs e)
        {
            if (selectedPage != null)
            {
                ProgramMovementDialog dialog = new ProgramMovementDialog();
                dialog.SelectedEvent = SelectedEvent;
                dialog.SelectedPage = SelectedPage;

                EventProgramData data = new EventProgramData();
                data.ID = Global.GetProgramID(Programs);
                data.ProgramCategory = ProgramCategory.Movement;
                data.Code = 10;
                data.Value[4] = new List<EventProgramData>();

                dialog.Values = data.Value;
                dialog.Programs = (List<EventProgramData>)data.Value[4];
                dialog.IsProgramMovement = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    data.Value[4] = dialog.Programs;
                    data.Name = data.GetName(SelectedEvent, SelectedPage);
                    SelectedAction = data;
                    ThisResult= DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void exitBehaviorBtn_Click(object sender, EventArgs e)
        {
            // Exit Behavior
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Event;
            action.Code = 5;
            //action.TypeCode = 1;
            action.Name = "Exit Branch";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnChangeEventLayer_Click(object sender, EventArgs e)
        {
            // Event Layer Dialog
            EventLayerDialog dialog = new EventLayerDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnEditEventParticle_Click(object sender, EventArgs e)
        {
            // Event Layer Dialog
            EditEventParticle dialog = new EditEventParticle();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void deleteEvntBtn_Click(object sender, EventArgs e)
        {
            // Delete Event
            DeleteEventDialog dialog = new DeleteEventDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void activateGlobalEventBtn_Click(object sender, EventArgs e)
        {
            ActivateGlobalEventDialog dialog = new ActivateGlobalEventDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnSetEventLocation_Click(object sender, EventArgs e)
        {
            SetEventLocation dialog = new SetEventLocation();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnKnockback_Click(object sender, EventArgs e)
        {
            ApplyKnockbackFieldDialog dialog = new ApplyKnockbackFieldDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnEditEventParticle_Click_1(object sender, EventArgs e)
        {
            EditEventParticle dialog = new EditEventParticle();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Loop
        private void loopBtn_Click(object sender, EventArgs e)
        {
            // Loop Begin
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Loops;
            action.Code = 1;
            //action.TypeCode = 1;
            action.Name = "Loop Do";
            action.Branch = true;
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void breakloopBtn_Click(object sender, EventArgs e)
        {
            // Break Loop
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Loops;
            action.Code = 2;
            //action.TypeCode = 1;
            action.Name = "Break Loop";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void labelBtn_Click(object sender, EventArgs e)
        {
            // Go To Label Name
            LabelDialog dialog = new LabelDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void jumpToLabelBtn_Click(object sender, EventArgs e)
        {
            // Go To Label Name
            GoToLabelDialog dialog = new GoToLabelDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Other
        private void waitBtn_Click(object sender, EventArgs e)
        {
            // Wait Frames
            WaitDialog dialog = new WaitDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void timer_Click(object sender, EventArgs e)
        {
            TimerDialog dialog = new TimerDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void commentBtn_Click(object sender, EventArgs e)
        {
            // Delete Event
            CommentDialog dialog = new CommentDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnVibrateController_Click(object sender, EventArgs e)
        {
            VibrateControllerDialog dialog = new VibrateControllerDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnDeadzone_Click(object sender, EventArgs e)
        {
            ControllerDeadzoneDialog dialog = new ControllerDeadzoneDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }

        }

        private void memorizePlayersBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Other;
            action.Code = 7;
            action.Name = "Memorize Players";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void resetPlayersBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Other;
            action.Code = 8;
            action.Name = "Reset Players";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// Exit Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExitGame_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Other;
            action.Code = 10;
            action.Name = "Exit Game";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// Change Resolution
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeRes_Click(object sender, EventArgs e)
        {
            ChangeResDialog dialog = new ChangeResDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Toggle Ctrls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToggleCtrls_Click(object sender, EventArgs e)
        {
            ToggleControlsDialog dialog = new ToggleControlsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Lock Screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLockScreen_Click(object sender, EventArgs e)
        {
            LockScreenDialog dialog = new LockScreenDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Data
        private void chngSwitchCondBtn_Click(object sender, EventArgs e)
        { // Set to Bool, to Switch
            EditSwitchDialog dialog = new EditSwitchDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            dialog.Setup();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void chngVarValueBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            EditVariableDialog dialog = new EditVariableDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void chngLocalSwitchCondBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            LocalSwitchConditionDialog dialog = new LocalSwitchConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void chngLocalVarValueBtn_Click(object sender, EventArgs e)
        {

            // Set to Bool, to Switch
            EditVariableDialog dialog = new EditVariableDialog();
            dialog.IsLocal = true; dialog.Variables = selectedEvent.Variables;
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void chgDataValueBtn_Click(object sender, EventArgs e)
        {
            // Delete Event
            EditDatabaseValueDialog dialog = new EditDatabaseValueDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// Edit List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditList_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            EditListDialog dialog = new EditListDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void editStringBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            EditStringDialog dialog = new EditStringDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Display
        private void showMessageBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            ShowMessageDialog dialog = new ShowMessageDialog();
            dialog.Programs = Programs;
            dialog.SelectedEvent = SelectedEvent;
            dialog.SelectedPage = SelectedPage;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void showInputBtn_Click(object sender, EventArgs e)
        {

        }

        private void btnShowVideo_Click(object sender, EventArgs e)
        {
            ShowVideoDialog dialog = new ShowVideoDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnVideoControls_Click(object sender, EventArgs e)
        {
            VideoControlDialog dialog = new VideoControlDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void showAniBtn_Click(object sender, EventArgs e)
        {
            ShowAnimationDialog dialog = new ShowAnimationDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBtn_Click(object sender, EventArgs e)
        {
            // Show pictures dialog
            ShowPictureDialog dialog = new ShowPictureDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void erasePictureBtn_Click(object sender, EventArgs e)
        {
            // Erase pictures dialog
            ErasePictureDialog dialog = new ErasePictureDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnMovePic_Click(object sender, EventArgs e)
        {
            MovePictureDialog dialog = new MovePictureDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        private void btnRotatePic_Click(object sender, EventArgs e)
        {
            RotatePictureDialog dialog = new RotatePictureDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnScalePicture_Click(object sender, EventArgs e)
        {
            ScalePictureDialog dialog = new ScalePictureDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnTintPic_Click(object sender, EventArgs e)
        {
            TintPictureDialog dialog = new TintPictureDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void callMenuSceneBtn_Click(object sender, EventArgs e)
        {
            ShowMenuDialog dialog = new ShowMenuDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            ShowShopDialog dialog = new ShowShopDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeCursor_Click(object sender, EventArgs e)
        {
            ChangeCursorDialog dialog = new ChangeCursorDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        #endregion

        #region Conditions

        private void btnSwitchCondition_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            SwitchConditionDialog dialog = new SwitchConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnTimerCondition_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.ConditionDialogs.TimerConditionDialog dialog = new EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.ConditionDialogs.TimerConditionDialog();

            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnVariableCondition_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            VariableConditionDialog dialog = new VariableConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void listBranchBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            ListConditionDialog dialog = new ListConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnDatabaseCondition_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            DataConditionDialog dialog = new DataConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnMouseInputCondition_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            MouseConditionDialog dialog = new MouseConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnButtonInputCondition_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            ButtonInputConditionDialog dialog = new ButtonInputConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnEventCondition_Click(object sender, EventArgs e)
        {
            EventConditionDialog dialog = new EventConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void stringCondBtn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            StringCondition dialog = new StringCondition();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnOtherConditiosn_Click(object sender, EventArgs e)
        {
            // Set to Bool, to Switch
            OtherConditionDialog dialog = new OtherConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Close
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Graphics
        private void btnDrawLine_Click(object sender, EventArgs e)
        {

        }

        private void btnDrawRectangle_Click(object sender, EventArgs e)
        {

        }

        private void btnDrawCircle_Click(object sender, EventArgs e)
        {

        }

        private void btnDrawTriangle_Click(object sender, EventArgs e)
        {

        }


        private void btnBeginDraw_Click(object sender, EventArgs e)
        {
            BeginDrawDialog dialog = new BeginDrawDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnEndDraw_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Memory
        private void btnSaveState_Click(object sender, EventArgs e)
        {
            SaveStateDialog dialog = new SaveStateDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnLoadState_Click(object sender, EventArgs e)
        {
            LoadStateDialog dialog = new LoadStateDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Screen
        private void fadeOutBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Screen;
            action.Code = 1;
            action.Name = "Fadeout Screen";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void fadeInBtn_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Screen;
            action.Code = 2;
            action.Name = "Fadein Screen";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void tintScreenBtn_Click(object sender, EventArgs e)
        {
            TintEventDialog dialog = new TintEventDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void flashScreenBtn_Click(object sender, EventArgs e)
        {
            FlashScreenEventDialog dialog = new FlashScreenEventDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void shakeScreenEffect_Click(object sender, EventArgs e)
        {
            ShakeScreenEventDialog dialog = new ShakeScreenEventDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Party

        private void btnChangeParty_Click(object sender, EventArgs e)
        {
            ChangePartyMemberDialog dialog = new ChangePartyMemberDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnNextParty_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Party;
            action.Code = 2;
            action.Name = "Next Party Member";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnLastParty_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Party;
            action.Code = 3;
            action.Name = "Last Party Member";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnHealEntireParty_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Party;
            action.Code = 4;
            action.Name = "Heal Entire Party";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        #endregion

        #region Hero
        private void btnChangeItems_Click(object sender, EventArgs e)
        {
            ChangeItemsDialog dialog = new ChangeItemsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeEquipments_Click(object sender, EventArgs e)
        {
            ChangeEquipmentsDialog dialog = new ChangeEquipmentsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangePar_Click(object sender, EventArgs e)
        {
            ChangeParameterDialog dialog = new ChangeParameterDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            ChangeStateDialog dialog = new ChangeStateDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeSkill_Click(object sender, EventArgs e)
        {
            ChangeSkillDialog dialog = new ChangeSkillDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnMagic_Click(object sender, EventArgs e)
        {
            ChangeMagicDialog dialog = new ChangeMagicDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeEquip_Click(object sender, EventArgs e)
        {
            ChangeEquipmentDialog dialog = new ChangeEquipmentDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            ChangeNameDialog dialog = new ChangeNameDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnHealAll_Click(object sender, EventArgs e)
        {
            HealAllDialog dialog = new HealAllDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Particle
        private void btnShowParticle_Click(object sender, EventArgs e)
        {
            ShowParticleDialog dialog = new ShowParticleDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnEraseParticle_Click(object sender, EventArgs e)
        {
            EraseParticleDialog dialog = new EraseParticleDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnMoveParticle_Click(object sender, EventArgs e)
        {
            MoveParticleDialog dialog = new MoveParticleDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Battle
        private void btnPlayerCmnd_Click(object sender, EventArgs e)
        {
            PlayerCommandDialog dialog = new PlayerCommandDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnSimulateAttack_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Battle;
            action.Code = 5;
            action.Name = "Force Attack";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnUseSkillMagic_Click(object sender, EventArgs e)
        {
            UseSkillDialog dialog = new UseSkillDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnUseItem_Click(object sender, EventArgs e)
        {
            UseItemDialog dialog = new UseItemDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnSelectTarget_Click(object sender, EventArgs e)
        {
            TargetsDialog dialog = new TargetsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnCommandAllies_Click(object sender, EventArgs e)
        {
            ComandAlliesDialog dialog = new ComandAlliesDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnClearExpGained_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Battle;
            action.Code = 9;
            action.Name = "Clear Expereince Gained";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnBattleConditions_Click(object sender, EventArgs e)
        {
            BattleCondtionsDialog dialog = new BattleCondtionsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnAssignTarget_Click(object sender, EventArgs e)
        {
            AssigneAllyAsTargetDialog dialog = new AssigneAllyAsTargetDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        #endregion

        private void btnSetOptions_Click(object sender, EventArgs e)
        {
            SetOptionsDialog dialog = new SetOptionsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnRegion_Click(object sender, EventArgs e)
        {
            // Delete Event
            CommentDialog dialog = new CommentDialog();
            dialog.Text = "Region";
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;
                selectedAction.Branch = true;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnHeroConditions_Click(object sender, EventArgs e)
        {
            PartyConditionsDialog dialog = new PartyConditionsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnConditionSkillMagicItem_Click(object sender, EventArgs e)
        {
            ItemSkillConditionDialog dialog = new ItemSkillConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnUseItemM_Click(object sender, EventArgs e)
        {
            UseItemMDialog dialog = new UseItemMDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnUseSkillM_Click(object sender, EventArgs e)
        {
            UseSkillMDialog dialog = new UseSkillMDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnHotkeys_Click(object sender, EventArgs e)
        {
            HotKeysDialog dialog = new HotKeysDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeEquipment_Click(object sender, EventArgs e)
        {
            ChangeEquipmentPartyDialog dialog = new ChangeEquipmentPartyDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeEquipmentsVariable_Click(object sender, EventArgs e)
        {
            ChangeEquipmentsVariableDialog dialog = new ChangeEquipmentsVariableDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeItemsParty_Click(object sender, EventArgs e)
        {
            ChangeItemsVariableDialog dialog = new ChangeItemsVariableDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnForceUseSlot_Click(object sender, EventArgs e)
        {
            ForceUseSlotDialog dialog = new ForceUseSlotDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnGuideConditions_Click(object sender, EventArgs e)
        {
            GuideConditionDialog dialog = new GuideConditionDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnShowSignin_Click(object sender, EventArgs e)
        {
            ShowSigninDialog dialog = new ShowSigninDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnShowMarketPlace_Click(object sender, EventArgs e)
        {
            ShowMarketPlaceDialog dialog = new ShowMarketPlaceDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnShowParty_Click(object sender, EventArgs e)
        {
            ShowPartyDialog dialog = new ShowPartyDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnShowMessages_Click(object sender, EventArgs e)
        {
            ShowMessagesDialog dialog = new ShowMessagesDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnShowFriends_Click(object sender, EventArgs e)
        {
            ShowFriendsDialog dialog = new ShowFriendsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnShowStorageDevice_Click(object sender, EventArgs e)
        {
            ShowStorageDialog dialog = new ShowStorageDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnTrialMode_Click(object sender, EventArgs e)
        {
            // Simulate Trial Mode
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Guide;
            action.Code = 4;
            action.Name = "Simulate Trial Mode";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnXboxShowInput_Click(object sender, EventArgs e)
        {
            ShowInputDialog dialog = new ShowInputDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnChangeHeroAnimation_Click(object sender, EventArgs e)
        {
            ChangeHeroAnimationDialog dialog = new ChangeHeroAnimationDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Setup
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnEditEventSwitch_Click(object sender, EventArgs e)
        {
            EditEventSwitchesDialog dialog = new EditEventSwitchesDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Setup
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnLockPlayer_Click(object sender, EventArgs e)
        {
            // Simulate Trial Mode
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Event;
            action.Code = 10;
            action.Name = "Lock Player";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnLockGame_Click(object sender, EventArgs e)
        {
            // Simulate Trial Mode
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Event;
            action.Code = 11;
            action.Name = "Lock Game";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnReloadGame_Click(object sender, EventArgs e)
        {
            // Simulate Trial Mode
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Other;
            action.Code = 14;
            action.Name = "Reload Game";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        #region Description
        /// <summary>
        /// Default Desc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BehaviorListDialog_MouseEnter(object sender, EventArgs e)
        {
            pic.Image = global::EGMGame.Properties.Resources.question;
            desc.Text = "Hover over an item to see its description.\n\nDouble click question mark to hide/show this info.";
        }
        /// <summary>
        /// Categories Description
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategories_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Display":
                    desc.Text = "Contains commands for displaying Messages, Menus, Videos and Animations.";
                    break;
                case "Conditions":
                    desc.Text = "Contains <IF> conditions that allow for checking a condition before performing the commands in the condition's branch.";
                    break;
                case "Loops":
                    desc.Text = "Contains Loop and Go To Label commands.";
                    break;
                case "Data":
                    desc.Text = "Contains commands that allow editing Variables, Switches, Lists, Strings, Database and etc.";
                    break;
                case "Event":
                    desc.Text = "Contains Program Dynamics, Change Event Animation, Set Location, Lock Player and etc.";
                    break;
                case "Map":
                    desc.Text = "Contains Transfer Player, Toggle Layers, Scroll Camera and etc.";
                    break;
                case "Party":
                    desc.Text = "Contains commands that deal with party actions such as Next Party Member and Heal Party.";
                    break;
                case "Hero":
                    desc.Text = "Contains inventory commands and hero related commands such as Heal Hero, Change Parameter, and Change Hero's Animation.";
                    break;
                case "Screen":
                    desc.Text = "Contains screen effects such as Fade out/in, Tint, and Shake.";
                    break;
                case "Picture":
                    desc.Text = "Contains picture related commands such as Show, Erase, Move and Tint.";
                    break;
                case "Audio":
                    desc.Text = "Contains audio related commands including 3D audio.";
                    break;
                case "Guide":
                    desc.Text = "Contains Save, Load and xbox guide commands.";
                    break;
                case "Battle":
                    desc.Text = "Contains battle based commands that allow for custom eventing battle actions.";
                    break;
                case "Particles":
                    desc.Text = "Contians particle related commands such as Show, Erase and Move.";
                    break;
                case "Other":
                    desc.Text = "Contains commands that don't fit in other categories.";
                    break;
                case "Menu":
                    desc.Text = "Contains menu related commands.";
                    break;
                case "Graphics":
                    desc.Text = "Draw lines, circles and other shapes to the screen.";
                    break;
            }
            //toolTip.SetToolTip(btn, desc.Text);
        }
        /// <summary>
        /// Description for buttons in the display category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Show Message":
                    desc.Text = "Show messages using a menu. A menu is required.";
                    break;
                case "Show Menu":
                    desc.Text = "Show a menu.";
                    break;
                case "Close Menu":
                    desc.Text = "Close a menu. All menus with the same ID will be closed.";
                    break;
                case "Show Video":
                    desc.Text = "Show a video.";
                    break;
                case "Change Cursor":
                    desc.Text = "Change the cursor image.";
                    break;
                case "Set Options":
                    desc.Text = "Set options such as Yes/No for player. Use Show Message to display the options. A menu that supports options is required.";
                    break;
                case "Show Shop":
                    desc.Text = "Show shop allows you to select a menu and define items and equipments that will be sold in the shop. A menu that is a shop is required.";
                    break;
                case "Close HUD":
                    desc.Text = "Closes the last opened Heads-up Display.";
                    break;
                case "Show Animation":
                    desc.Text = "Shows an Animation at a positon determined by your, variables or event.";
                    break;
                case "Video Controls":
                    desc.Text = "Allows you to Play, Pause or Stop a video.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the event category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLockGame_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Edit Event Animation":
                    desc.Text = "Change the Event's animation. This won't work for the Player or an Enemy event.";
                    break;
                case "Change Event Particle":
                    desc.Text = "Change the Event's default particle.";
                    break;
                case "Program Dynamics":
                    desc.Text = "Program a movement path for an Event or modify its movement, animation, and physics based settings.";
                    break;
                case "Set Event Location":
                    desc.Text = "Set the Event's location instantly.";
                    break;
                case "Exit Branch":
                    desc.Text = "Exit the current condition or loop.";
                    break;
                case "Change Event Layer":
                    desc.Text = "Change which layer an Event is on.";
                    break;
                case "Activate Global Event":
                    desc.Text = "Activate a global event.";
                    break;
                case "Apply Knockback":
                    desc.Text = "Apply a knockback force with given settings and knockback events.";
                    break;
                case "Add Event":
                    desc.Text = "Create a new event in-game from an existing template event. Useful for shooters and RTS games.";
                    break;
                case "Delete Event":
                    desc.Text = "Delete an Event. Event will re-appear once the map resets if the event wasn't created in-game. To permenantly delete map events, use an Event Switch and switch to an empty page on that event.";
                    break;
                case "Lock Player":
                    desc.Text = "Lock the player until this Event stops processing.";
                    break;
                case "Lock Game":
                    desc.Text = "Lock the game until this Event stops processing. Same effect as auto-run.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the condition category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuideConditions_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Switch":
                    desc.Text = "Check a Switch state.";
                    break;
                case "Variable":
                    desc.Text = "Check a Variable value.";
                    break;
                case "String":
                    desc.Text = "Check a String value.";
                    break;
                case "List":
                    desc.Text = "Check if a List contains a certain value including constants, variables, random, item, equipment or skill.";
                    break;
                case "Database":
                    desc.Text = "Check a Database value.";
                    break;
                case "Event":
                    desc.Text = "Check Event conditions such as activation, movement, jump, position, and collision. If true, perform branching conditions";
                    break;
                case "Template Event":
                    desc.Text = "Check Template Event conditions such as activation, movement, jump, position, and collision. If true, perform branching conditions. Note that if there is more than one of the same Template Event on the map, only one of them will be used.";
                    break;
                case "Button Input":
                    desc.Text = "Check Button conditions. Supports both XBOX and Keyboard at the same time.";
                    break;
                case "Mouse Input":
                    desc.Text = "Check Mouse conditions.";
                    break;
                case "Item/Skill/Equip":
                    desc.Text = "Check Item/Skill/Equip conditions such as scope and usage. Useful for Menus.";
                    break;
                case "Party":
                    desc.Text = "Check Party condition such as a party member's database proper or collective inventory. Useful for checking health, items and etc.";
                    break;
                case "Timer":
                    desc.Text = "Check Timer value.";
                    break;
                case "Guide":
                    desc.Text = "Check Guide (XBOX) conditions such as if the game is in trial mode. Returns false if not on Xbox.";
                    break;
                case "Other":
                    desc.Text = "Check Other conditions that don't fit in any other category such as save/load existance, tile tag or which platform the game is on.";
                    break;
                case "Battle":
                    desc.Text = "Check Battle conditions. Useful for when eventing a battle system.";
                    break;
                case "Hero":
                    desc.Text = "Check Hero conditions such as if the hero has an item, skill, or equipment.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the data category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditEventSwitch_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Edit Switch":
                    desc.Text = "A Switch contains the true or false state.";
                    break;
                case "Edit Local Switch":
                    desc.Text = "A Local Switch contains the true or false state and is specific for this Event.";
                    break;
                case "Edit Variable":
                    desc.Text = "A Variable contains a number.";
                    break;
                case "Edit String":
                    desc.Text = "A String contains text.";
                    break;
                case "Edit Database Value":
                    desc.Text = "A Database can contain a string or a number.";
                    break;
                case "Edit Local Variable":
                    desc.Text = "A Local Variable contains a number and is specific for this Event.";
                    break;
                case "Edit List":
                    desc.Text = "A List contains numbers and by default, used for storing items and skills.";
                    break;
                case "Edit Event Switch":
                    desc.Text = "An Event Switch is a local switch that does not reset when the map resets.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the guide category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXboxShowInput_MouseEnter(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Save Game":
                    desc.Text = "Save the game's state in a file. The file index can be a constant or a variable.";
                    break;
                case "Load Game":
                    desc.Text = "Load a save game state. The file index can be a constant or a variable.";
                    break;
                case "Show Friends":
                    desc.Text = "Show Friends list (XBOX ONLY).";
                    break;
                case "Show Party":
                    desc.Text = "Show Party (XBOX ONLY).";
                    break;
                case "Show Input":
                    desc.Text = "Show Xbox Keyboard Input (XBOX ONLY).";
                    break;
                case "Test Trial Mode":
                    desc.Text = "Turn 'Trial Mode' on for testing purposes (XBOX ONLY).";
                    break;
                case "Show Storage\r\nDevice":
                    desc.Text = "Show Storage Device. Useful for selecting a save drive on XBOX (XBOX ONLY).";
                    break;
                case "Show Messages":
                    desc.Text = "Show an XBOX Guide message (XBOX ONLY).";
                    break;
                case "Show Marketplace":
                    desc.Text = "Go to the market place (XBOX ONLY).";
                    break;
                case "Show Sign In":
                    desc.Text = "Show profile sign in (XBOX ONLY).";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the battle category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForceUseSlot_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Command Ally":
                    desc.Text = "Command an ally to attack or defend.";
                    break;
                case "Assign Ally As\r\nTarget":
                    desc.Text = "Assign an party member as a target for this Event.";
                    break;
                case "Force Attack":
                    desc.Text = "Force this Event to attack.";
                    break;
                case "Use Item (Target)":
                    desc.Text = "Use an Item on a Target, Item conditions apply.";
                    break;
                case "Clear EXP Gained":
                    desc.Text = "Clear EXP Gained.";
                    break;
                case "Command Allies":
                    desc.Text = "Order the party members to perform an action such as Follow Player.";
                    break;
                case "Find Targets":
                    desc.Text = "Find targets that meet given conditions.";
                    break;
                case "Force Use Slot":
                    desc.Text = "Force use a slot. Useful for slot specific games such as shooters.";
                    break;
                case "Use Skill (Target)":
                    desc.Text = "Use a Skill on a Target, Skill conditions apply.";
                    break;
                case "Indestructible":
                    desc.Text = "Make this Event or a Party Member immortal.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the party category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeEquipment_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Change Party Member":
                    desc.Text = "Add or Remove a party member.";
                    break;
                case "Next Party Member":
                    desc.Text = "Make the next party member lead.";
                    break;
                case "Use Item":
                    desc.Text = "Use an Item that is a stored in a variable on a party member that is store in a variable from an inventory stored in a variable. Useful for Menu.";
                    break;
                case "Change Equipment":
                    desc.Text = "Change a party member's equipment. Useful for Menu.";
                    break;
                case "Change Items":
                    desc.Text = "Add or Remvoe an Item from a party member's inventory. Useful for Menu.";
                    break;
                case "Heal Entire Party":
                    desc.Text = "Heal the entire party.";
                    break;
                case "Last Party Member":
                    desc.Text = "Make the previous party member lead.";
                    break;
                case "Use Skill":
                    desc.Text = "Use a Skill that is  a stored in a variable on a party member that is store in a variable from an skillset stored in a variable. Useful for Menu.";
                    break;
                case "Change Equipments":
                    desc.Text = "Add or Remove an Equipment from a party member's inventory. Useful for Menu. ";
                    break;
                case "Show/Hide Party Members":
                    desc.Text = "Shows or hides party members on the map.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the hero category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeHeroAnimation_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Change Items":
                    desc.Text = "Add or Remove an Item from a List.";
                    break;
                case "Change Equipments":
                    desc.Text = "Add or Remove an Equipment from a List.";
                    break;
                case "Change Skill":
                    desc.Text = "Change a Hero's skill.";
                    break;
                case "Change Magic":
                    desc.Text = "Change a Hero's magic.";
                    break;
                case "Change Parameter":
                    desc.Text = "Change a Hero's parameter.";
                    break;
                case "Equip Equipment":
                    desc.Text = "Equip a Hero with an Equipment.";
                    break;
                case "Heal All":
                    desc.Text = "Heal Hero";
                    break;
                case "Change State":
                    desc.Text = "Add or Remove a Hero's state.";
                    break;
                case "Change Name":
                    desc.Text = "Change a Hero's Name.";
                    break;
                case "Change Animation":
                    desc.Text = "Change a Hero's Animation.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the screen category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoom_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Fadeout":
                    desc.Text = "Fadeout the screen to black.";
                    break;
                case "Fadein":
                    desc.Text = "Fadein the screen.";
                    break;
                case "Tint Screen":
                    desc.Text = "Tint the screen.";
                    break;
                case "Flash Screen":
                    desc.Text = "Flash a color on to the screen.";
                    break;
                case "Shake Screen":
                    desc.Text = "Shake the screen.";
                    break;
                case "Zoom":
                    desc.Text = "";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the picture category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTintPic_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Show Picture":
                    desc.Text = "Show a picture at any position.";
                    break;
                case "Move Picture":
                    desc.Text = "Move a picture to any position.";
                    break;
                case "Rotate Picture":
                    desc.Text = "Rotate a picture.";
                    break;
                case "Erase Picture":
                    desc.Text = "Erase a picture.";
                    break;
                case "Tint Picture":
                    desc.Text = "Tint a picture.";
                    break;
                case "Scale Picture":
                    desc.Text = "Scale a picture.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the particle category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveParticle_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Show Particle":
                    desc.Text = "Show a particle at any position.";
                    break;
                case "Move Particle":
                    desc.Text = "Move a particle to a position.";
                    break;
                case "Erase Particle":
                    desc.Text = "Erase a particle.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the other category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHotkeys_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Wait":
                    desc.Text = "Wait some frames until next command.";
                    break;
                case "Comment":
                    desc.Text = "Comments can be used to write descriptions or notes.";
                    break;
                case "Vibrate Controller":
                    desc.Text = "Vibrate the controller.";
                    break;
                case "Hotkeys":
                    desc.Text = "Set new skill or item hotkeys.";
                    break;
                case "Memorize Players":
                    desc.Text = "Memorizing players memorizes each player to their controllers.";
                    break;
                case "Reset Players":
                    desc.Text = "Resets memorized players.";
                    break;
                case "Change Screen Ratio":
                    desc.Text = "Change screen resolution. Useful for having multiple screen resolutions.";
                    break;
                case "Reload Game":
                    desc.Text = "Reload the game's data. Useful for starting a new game.";
                    break;
                case "Timer":
                    desc.Text = "A timer is useful for countdowns or to keep track of progress. You can have multiple timers by using different variables.";
                    break;
                case "Region":
                    desc.Text = "Region is similar to comment but allows for grouping commands. Useful for group of reusable commands.";
                    break;
                case "Controller Deadzone":
                    desc.Text = "Controll deadzone is for the Xbox controller's sticks. Allows for different value reports.";
                    break;
                case "Toggle Controls":
                    desc.Text = "Enable or Disable Player's controls.";
                    break;
                case "Lock Screen":
                    desc.Text = "Lock a certain area of the screen that the player can't travel outside of. Useful for shooters.";
                    break;
                case "Exit Game":
                    desc.Text = "Exit and close the game window.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the sound category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCtrl3DAudi_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Play Audio":
                    desc.Text = "Play an audio on any channel. Tip: Use Channel 0 for background music, Channel 1 for background sound effects, Channel 3 and up for general sound effects.";
                    break;
                case "Control Audio":
                    desc.Text = "Play, Pause, or Stop an audio channel.";
                    break;
                case "Playlist Controls":
                    desc.Text = "Setup a playlist that allows you to play audio in an order you set.";
                    break;
                case "Control Playlist":
                    desc.Text = "Play, Pause, or Stop a playlist channel.";
                    break;
                case "Play 3D Audio":
                    desc.Text = "Play a 3D audio on any channel.";
                    break;
                case "Control 3D Audio":
                    desc.Text = "Play, Pause, or Stop a 3D audio channel.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the loop category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoToLabel_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Loop Do":
                    desc.Text = "Loop Do loops the commands that it contains until the loop is exited.";
                    break;
                case "Break Loop":
                    desc.Text = "Exits the loop it is in.";
                    break;
                case "Label":
                    desc.Text = "Sets a marker which after processed can be backtraced to with Go To Label.";
                    break;
                case "Go To Label":
                    desc.Text = "Backtraces to a label.";
                    break;
            }
        }
        /// <summary>
        /// Description for buttons in the map category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCamera_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (desc.Visible) pic.Image = btn.Image;
            switch (btn.Text)
            {
                case "Transfer Player":
                    desc.Text = "Transfer a player to a new map or same map different position.";
                    break;
                case "Scroll Camera":
                    desc.Text = "Scroll the camera from its position.";
                    break;
                case "Scroll Camera To":
                    desc.Text = "Scroll the camera from any position to a set position.";
                    break;
                case "Edit Fog":
                    desc.Text = "Display a fog.";
                    break;
                case "Toggle Map Layer":
                    desc.Text = "Hide or Show a map layer.";
                    break;
                case "Center Camera":
                    desc.Text = "Center the camera back to the player.";
                    break;
                case "Edit Weather":
                    desc.Text = "Change the game's weather.";
                    break;
                case "Edit Gravity":
                    desc.Text = "Change the map's gravity.";
                    break;
                case "Gravity Points":
                    desc.Text = "Add or remove points on the map that have their own gravity. Useful for plantary gravity, traps, or even climbing.";
                    break;
            }
        }
        #endregion

        private void desc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            desc.Visible = (!desc.Visible);
            MainForm.Configuration.EventCommandsTips = desc.Visible;
        }

        private void toolTip_Popup(object sender, PopupEventArgs e)
        {
            e.Cancel = desc.Visible;
        }

        private void btnIndestructible_Click(object sender, EventArgs e)
        {
            IndestructibleDialog dialog = new IndestructibleDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Setup
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnCloseMenu_Click(object sender, EventArgs e)
        {
            CloseMenuDialog dialog = new CloseMenuDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Setup
                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnCloseHUD_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Display;
            action.Code = 16;
            action.Name = "Close HUD";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnScrollTo_Click(object sender, EventArgs e)
        {
            ScrollCameraToDialog dialog = new ScrollCameraToDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnWaitLoadSave_Click(object sender, EventArgs e)
        {
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Guide;
            action.Code = 12;
            action.Name = "Wait Save/Load To Finish";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnMenuConditions_Click(object sender, EventArgs e)
        {
            MenuConditionsDialog dialog = new MenuConditionsDialog();
            dialog.Programs = Programs;


            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void hideMenuBtn_Click(object sender, EventArgs e)
        {
            MenuVisibleStateDialog dialog = new MenuVisibleStateDialog();
            dialog.Programs = Programs;


            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void closeMenuBtn_Click(object sender, EventArgs e)
        {
            // Loop Begin
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Menu;
            action.Code = 0;
            action.Name = "Close Menu";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void highlightMenuBtn_Click(object sender, EventArgs e)
        {
            MenuHighlightDialog dialog = new MenuHighlightDialog();
            dialog.Programs = Programs;


            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void enableMenuBtn_Click(object sender, EventArgs e)
        {
            MenuEnableStateDialog dialog = new MenuEnableStateDialog();
            dialog.Programs = Programs;


            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }

        }

        private void btnHeroConditions_Click_1(object sender, EventArgs e)
        {
            HeroConditionsDialog dialog = new HeroConditionsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnShowHidePartyMEmber_Click(object sender, EventArgs e)
        {
            ShowHidePartyMemberDialog dialog = new ShowHidePartyMemberDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnGravity_Click(object sender, EventArgs e)
        {
            ChangeGravityDialog dialog = new ChangeGravityDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnReloadMap_Click(object sender, EventArgs e)
        {
            // Loop Begin
            EventProgramData action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Map;
            action.Code = 9;
            action.Name = "Reload Map";
            SelectedAction = action;
            ThisResult= DialogResult.OK;
            this.Close();
        }

        private void btnApplyEffectToMap_Click(object sender, EventArgs e)
        {
            ApplyEffectToMapDialog dialog = new ApplyEffectToMapDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnApplyEffectToEvent_Click(object sender, EventArgs e)
        {
            ApplyEffectToEventDialog dialog = new ApplyEffectToEventDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            ZoomDialog dialog = new ZoomDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult= DialogResult.OK;
                this.Close();
            }
        }

        private void BehaviorListDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void BehaviorListDialog_Shown(object sender, EventArgs e)
        {
            ThisResult = DialogResult.Cancel;
        }

        private void btnMoveMenu_Click(object sender, EventArgs e)
        {
            MoveMenuDialog dialog = new MoveMenuDialog();
            dialog.Programs = Programs;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnMenuProperty_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertRemove_Click(object sender, EventArgs e)
        {
            InsertMemberDialog dialog = new InsertMemberDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnRemovePartyMember_Click(object sender, EventArgs e)
        {
            RemoveMemberDialog dialog = new RemoveMemberDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnGravityPoints_Click(object sender, EventArgs e)
        {
            GravityPointsDialog dialog = new GravityPointsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnEventGravity_Click(object sender, EventArgs e)
        {
            GravityEventsDialog dialog = new GravityEventsDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                ThisResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnAttEditAnimation_Click(object sender, EventArgs e)
        {
            ChangeAttAnimationDialog dialog = new ChangeAttAnimationDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Setup
                ThisResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnAttProgramDynamics_Click(object sender, EventArgs e)
        {
            if (selectedPage != null)
            {
                ProgramMovementDialog dialog = new ProgramMovementDialog();
                dialog.SelectedEvent = SelectedEvent;
                dialog.SelectedPage = SelectedPage;
                dialog.IsAttachment = true;

                EventProgramData data = new EventProgramData();
                data.ID = Global.GetProgramID(Programs);
                data.ProgramCategory = ProgramCategory.Attachment;
                data.Code = 2;
                data.Value[4] = new List<EventProgramData>();

                dialog.Values = data.Value;
                dialog.Programs = (List<EventProgramData>)data.Value[4];
                dialog.IsProgramMovement = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    data.Value[4] = dialog.Programs;
                    data.Name = "Program Attachment Dynamics";
                    SelectedAction = data;
                    ThisResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnAttCondition_Click(object sender, EventArgs e)
        {

        }

        private void btnFireLaser_Click(object sender, EventArgs e)
        {

        }

        private void btnAttachEvent_Click(object sender, EventArgs e)
        {
            AttachCameraToEventDialog dialog = new AttachCameraToEventDialog();
            dialog.Programs = Programs;
            dialog.SelectedPage = SelectedPage;
            dialog.SelectedEvent = SelectedEvent;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedAction = dialog.ProgramData;

                // Setup
                ThisResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnTemplateEvent_Click(object sender, EventArgs e)
        {

        }

    }
}
