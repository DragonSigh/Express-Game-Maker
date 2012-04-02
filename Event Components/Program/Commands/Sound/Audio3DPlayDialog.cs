using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs.SoundDialogs
{
    public partial class Audio3DPlayDialog : Form
    {
        public Audio3DPlayDialog()
        {
            InitializeComponent();
            SetupSoundEffects();
        }
        public IEvent SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value;
                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    cbEmitter.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    cbEmitter.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
                if (selectedEvent == null || selectedEvent is GlobalEventData)
                    cbListener.RefreshList(true, false, false);
                else if (selectedEvent is EventData)
                    cbListener.RefreshList(true, (selectedEvent.MapID > -1), (selectedEvent.MapID < 0));
            }
        }
        IEvent selectedEvent;

        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; }
        }
        EventPageData selectedPage;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; Setup(); }
        }
        List<EventProgramData> programs;

        /// <summary>
        /// Setup Sound Effects
        /// </summary>
        private void SetupSoundEffects()
        {
            // Clear List
            seList.SetupList(GameData.Audios, typeof(AudioData));

            if (seList.Count > 0)
            {
                impactGroupBox2.Enabled = true;
                groupBox4.Enabled = true;
                seList.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Setup
        /// </summary>
        internal void Setup()
        {
            
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Audio;
            action.Code = 5;
        }
        /// <summary>
        /// Setup action
        /// </summary>
        /// <param name="a"></param>
        private void SetupAction(EventProgramData a)
        {
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;
            // Setup Data
            if (seList.Count > 0)
            {
                seList.Select((int)action.Value[0]);
            }
            numberBox.Value = (decimal)(int)action.Value[1];
            panBox.Value = (decimal)(float)action.Value[2];
            pitchBox.Value = (decimal)(float)action.Value[3];
            volumeBox.Value = (decimal)(float)action.Value[4];
            infiniteBtn.Checked = (bool)action.Value[5];
            cbEmitter.Select((int)action.Value[6]);
            cbListener.Select((int)action.Value[7]);
        }
        /// <summary>
        /// Play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testBtn_Click(object sender, EventArgs e)
        {
            if (seList.SelectedIndex > -1 && seList.SelectedIndex < seList.Count)
            {
                AudioSettings settings = new AudioSettings(0,0, false, (float)panBox.Value, (float)pitchBox.Value, (float)volumeBox.Value, infiniteBtn.Checked);

                Global.PlaySoundEffect(GameData.Audios[seList.SelectedID], settings);
            }
        }
        /// <summary>
        /// Pause 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            Global.PauseAudio();
        }
        /// <summary>
        /// Resume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResume_Click(object sender, EventArgs e)
        {
            Global.ResumeAudio();
        }
        /// <summary>
        /// Stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            Global.StopAudio();
        }
        /// <summary>
        /// Close Dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (seList.SelectedIndex > -1 && seList.SelectedIndex < seList.Count)
            {
                // Assign Values
                action.Value[0] = seList.SelectedID;
                action.Value[1] = (int)numberBox.Value;
                action.Value[2] = (float)panBox.Value;
                action.Value[3] = (float)pitchBox.Value;
                action.Value[4] = (float)volumeBox.Value;
                action.Value[5] = infiniteBtn.Checked;
                action.Value[6] = cbEmitter.Data().ID;
                action.Value[7] = cbListener.Data().ID;
                action.Name = "Play 3D Audio [" + GameData.Audios[seList.SelectedID].Name + "] Channel [" + numberBox.Value.ToString() + "]";
                action.GetName(selectedEvent, selectedPage);
                // Close
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
        /// <summary>
        /// Cancel Dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void volumeBar_ValueChanged(object sender, decimal value)
        {
            if (volumeBar.Value != volumeBox.Value)
            {
                volumeBox.Value = (decimal)volumeBar.Value;
            }
        }

        private void pitchBar_ValueChanged(object sender, decimal value)
        {
            if (pitchBar.Value != pitchBox.Value)
            {
                pitchBox.Value = (decimal)pitchBar.Value;
            }
        }

        private void panBar_ValueChanged(object sender, decimal value)
        {

            if (panBar.Value != panBox.Value)
            {
                panBox.Value = (decimal)panBar.Value;
            }
        }

        private void volumeBox_ValueChanged(object sender, EventArgs e)
        {
            if (volumeBar.Value != volumeBox.Value)
            {
                volumeBar.Value = (int)volumeBox.Value;
            }
        }

        private void pitchBox_ValueChanged(object sender, EventArgs e)
        {
            if (pitchBar.Value != pitchBox.Value)
            {
                pitchBar.Value = (int)pitchBox.Value;
            }
        }

        private void panBox_ValueChanged(object sender, EventArgs e)
        {
            if (panBar.Value != panBox.Value)
            {
                panBar.Value = (int)panBox.Value;
            }

        }
        /// <summary>
        /// Apply default settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultBtn_Click(object sender, EventArgs e)
        {
            if (seList.SelectedIndex > -1 && seList.SelectedIndex < seList.Count)
            {
                panBox.Value = (decimal)GameData.Audios[seList.SelectedID].Pan;
                pitchBox.Value = (decimal)GameData.Audios[seList.SelectedID].Pitch;
                volumeBox.Value = (decimal)GameData.Audios[seList.SelectedID].Volume;
                infiniteBtn.Checked = GameData.Audios[seList.SelectedID].Loop;
            }
        }
    }
}
