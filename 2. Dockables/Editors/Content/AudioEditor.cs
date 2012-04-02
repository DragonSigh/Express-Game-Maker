using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using GenericUndoRedo;
using EGMGame.Controls;
using EGMGame.Docking.Explorers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Audio;
using System.Threading;
using NAudio.Wave;

namespace EGMGame.Docking.Editors
{
    public partial class AudioEditor : DockContent, IHistory, IEditor
    {
        IWavePlayer waveOut;
        string fileName = null;
        WaveStream mainOutputStream;
        WaveChannel32 volumeStream;


        public ContentManager contentManager;
        double tickTime = 0;
        // Content variables
        public AudioData SelectedAudioEffect
        {
            get
            {
                if (!SelectedData()) return null;
                return GameData.Audios[addRemoveList.SelectedID];
            }
        }

        bool allowChange = true;

        public AudioEditor()
        {
            MainForm.AudioHistory[this] = new GenericUndoRedo.UndoRedoHistory<GenericUndoRedo.IHistory>(this);
            InitializeComponent();
            dockContextMenu1.owner = this;
            this.TabPageContextMenuStrip = dockContextMenu1;
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            // Start Thread Loop
            CheckForIllegalCrossThreadCalls = false;
        }

        private void AudioEditor_Activated(object sender, EventArgs e)
        {
            // Set History To This
            MainForm.HistoryExplorer.SelectedHistory = MainForm.AudioHistory[this];
        }

        private void AudioEditor_Shown(object sender, EventArgs e)
        {
            SetupList();
        }

        public void SetupList()
        {
            addRemoveList.SetupList(GameData.Audios, typeof(AudioData));
        }

        #region History Events
        /// <summary>
        /// Data added
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataAdded(IGameDataAddedHist hist, IGameData data)
        {
            GameData.Audios.Add(data.ID, (AudioData)data);
            addRemoveList.AddNode(data);

            Global.CBAudio();
        }
        /// <summary>
        /// Data removed
        /// </summary>
        /// <param name="hist"></param>
        /// <param name="data"></param>
        internal void DataRemoved(IGameDataRemovedHist hist, IGameData data)
        {
            GameData.Audios.Remove(data.ID);

            addRemoveList.RemoveNode(data);

            Global.CBAudio();
        }
        #endregion
        #region List Events
        private void addRemoveList_AddItem(object sender, EGMGame.Controls.AddRemoveListEventArgs ca)
        {
            try
            {
                AudioData a = new AudioData();
                a.Name = Global.GetName("Sound", GameData.Audios);
                a.ID = Global.GetID(GameData.Audios);
                a.Category = ca.Category;
                GameData.Audios.Add(a.ID, a);
                int index = a.ID;
                // History
                MainForm.AudioHistory[this].Do(new IGameDataAddedHist(a, new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                addRemoveList.AddNode(a);

                Global.CBAudio();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "4x001");
            }
        }

        private void addRemoveList_RemoveItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (addRemoveList.SelectedIndex >= 0 && GameData.Audios.ContainsKey(addRemoveList.SelectedID))
                {
                    // History
                    MainForm.AudioHistory[this].Do(new IGameDataRemovedHist(addRemoveList.Data(), new DataAddDelegate(DataAdded), new DataRemoveDelegate(DataRemoved)));

                    GameData.Audios.Remove(addRemoveList.SelectedID);
                    // 
                    addRemoveList.RemoveSelectedNode();
                    if (GameData.Audios.ContainsKey(addRemoveList.SelectedID))
                        SetupProperty(GameData.Audios[addRemoveList.SelectedID]);
                    else
                        SetupProperty(null);

                    Global.CBAudio();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "4x002");
            }
        }

        private void addRemoveList_SelectItem(object sender, EGMGame.Controls.AddRemoveListEventArgs e)
        {
            try
            {
                if (e.Index >= 0 && GameData.Audios.ContainsKey(e.ID))
                {
                    SetupProperty(GameData.Audios[e.ID]);
                }
                else
                {
                    SetupProperty(null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "4x003");
            }
        }
        #endregion
        /// <summary>
        /// Setup Property
        /// </summary>
        /// <param name="audioEffectData"></param>
        private void SetupProperty(AudioData obj)
        {
            if (obj != null)
            {
                allowChange = false;
                groupBox2.Enabled = true;
                groupBox4.Enabled = true;
                // File Name
                if (obj.FileName != "")
                {
                    MaterialData m1 = Global.GetData<MaterialData>(obj.MaterialId, GameData.Materials);
                    if (m1 != null)
                        fileNameTxt.Text = m1.Name;
                    else
                        fileNameTxt.Text = "MATERIAL NOT FOUND!";
                }
                else
                    fileNameTxt.Text = "Drag and drop Audio here!";
                infiniteBtn.Checked = obj.Loop;
                volumeBar.Value = (int)obj.Volume;
                volumeBox.Value = (decimal)obj.Volume;
                pitchBar.Value = (int)obj.Pitch;
                pitchBox.Value = (decimal)obj.Pitch;
                panBar.Value = (int)obj.Pan;
                panBox.Value = (decimal)obj.Pan;
                fadeInBox.Value = (decimal)obj.FadeIn;
                fadeOutBox.Value = (decimal)obj.FadeOut;
                afterBtn.Checked = SelectedAudioEffect.FadeAfter;
                durationlb.Text = "00:00:00.00";
                // Set Sound
                MaterialData m = Global.GetData<MaterialData>(GameData.Audios[addRemoveList.SelectedID].MaterialId, GameData.Materials);
                if (m != null)
                {
                    fileName = Global.Project.Location + @"\" + m.FileName;
                    if (!Global.ImportingAudio)
                    {
                        CloseWaveOut();

                        SoundEffect curSound = Loader.SoundEffect(MaterialExplorer.contentBuilder, contentManager, m.ID);

                        if (curSound != null)
                            durationlb.Text = curSound.Duration.ToString();
                    }
                    else
                    {
                        SetupAudio();
                    }
                }
                else
                {
                    CloseWaveOut();
                }
                allowChange = true;
            }
            else
            {
                CloseWaveOut();
                fileNameTxt.Text = "Drag and drop Audio here!";
                groupBox2.Enabled = false;
                groupBox4.Enabled = false;
                durationlb.Text = "00:00:00.00";
                timer.Text = "0";
            }
        }
        private void SetupAudio()
        {
            try
            {
                CreateWaveOut();
            }
            catch (Exception driverCreateException)
            {
                MessageBox.Show(String.Format("{0}", driverCreateException.Message));
                return;
            }

            try
            {
                mainOutputStream = CreateInputStream(fileName);
            }
            catch (Exception createException)
            {
                MessageBox.Show(String.Format("{0}", createException.Message), "Error Loading File");
                return;
            }

            durationlb.Text = String.Format("{0:00}:{1:00}", (int)mainOutputStream.TotalTime.TotalMinutes,
                mainOutputStream.TotalTime.Seconds);


            try
            {
                waveOut.Init(mainOutputStream);
            }
            catch (Exception initException)
            {
                MessageBox.Show(String.Format("{0}", initException.Message), "Error Initializing Output");
                return;
            }

        }

        private WaveStream CreateInputStream(string fileName)
        {
            WaveChannel32 inputStream;
            if (fileName.EndsWith(".wav"))
            {
                WaveStream readerStream = new WaveFileReader(fileName);
                if (readerStream.WaveFormat.Encoding != WaveFormatEncoding.Pcm)
                {
                    readerStream = WaveFormatConversionStream.CreatePcmStream(readerStream);
                    readerStream = new BlockAlignReductionStream(readerStream);
                }
                if (readerStream.WaveFormat.BitsPerSample != 16)
                {
                    var format = new WaveFormat(readerStream.WaveFormat.SampleRate,
                        16, readerStream.WaveFormat.Channels);
                    readerStream = new WaveFormatConversionStream(format, readerStream);
                }
                inputStream = new WaveChannel32(readerStream);
            }
            else if (fileName.EndsWith(".mp3"))
            {
                WaveStream mp3Reader = new Mp3FileReader(fileName);
                //WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(mp3Reader);
                //WaveStream blockAlignedStream = new BlockAlignReductionStream(mp3Reader);
                inputStream = new WaveChannel32(mp3Reader);
            }
            else
            {
                throw new InvalidOperationException("Unsupported extension");
            }
            // we are not going into a mixer so we don't need to zero pad
            //((WaveChannel32)inputStream).PadWithZeroes = false;
            volumeStream = inputStream;
            var meteringStream = new MeteringStream(inputStream, inputStream.WaveFormat.SampleRate / 10);
            meteringStream.StreamVolume += new EventHandler<StreamVolumeEventArgs>(meteringStream_StreamVolume);

            return meteringStream;
        }

        void meteringStream_StreamVolume(object sender, StreamVolumeEventArgs e)
        {
            //volumeMeter1.Amplitude = e.MaxSampleValues[0];
            //waveformPainter1.AddMax(e.MaxSampleValues[0]);
            //if (e.MaxSampleValues.Length > 1)
            //{
            //    volumeMeter2.Amplitude = e.MaxSampleValues[1];
            //    waveformPainter2.AddMax(e.MaxSampleValues[1]);
            //}
        }

        private void CreateWaveOut()
        {
            CloseWaveOut();
            int latency = 300;
            waveOut = new DirectSoundOut(latency);
        }

        private void CloseWaveOut()
        {
            if (waveOut != null)
            {
                waveOut.Stop();
            }
            if (mainOutputStream != null)
            {
                // this one really closes the file and ACM conversion
                volumeStream.Close();
                volumeStream = null;
                // this one does the metering stream
                mainOutputStream.Close();
                mainOutputStream = null;
            }
            if (waveOut != null)
            {
                waveOut.Dispose();
                waveOut = null;
            }
        }

        private bool SelectedData()
        {
            return (addRemoveList.SelectedIndex >= 0 && GameData.Audios.ContainsKey(addRemoveList.SelectedID));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (waveOut != null && mainOutputStream != null)
            {
                TimeSpan currentTime = mainOutputStream.CurrentTime;
                if (mainOutputStream.Position >= mainOutputStream.Length)
                {
                    if (SelectedAudioEffect.Loop)
                        waveOut.Play();
                    else
                        waveOut.Stop();
                }
                else
                {
                    timer.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes,
                        currentTime.Seconds);
                }
            }
        }

        private void fileNameTxt_DragDrop(object sender, DragEventArgs e)
        {
            if (addRemoveList.SelectedIndex >= 0 && GameData.Audios.ContainsKey(addRemoveList.Data().ID))
            {
                // Check Format
                try
                {
                    if (e.Data.GetDataPresent(typeof(TreeNode)))
                    {
                        TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                        MaterialData m = MainForm.materialExplorer.Data();

                        if (m != null)
                        {
                            GameData.Audios[addRemoveList.SelectedID].MaterialId = m.ID;
                            SetupProperty(GameData.Audios[addRemoveList.SelectedID]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "4x004");
                }
            }
        }

        private void fileNameTxt_DragEnter(object sender, DragEventArgs e)
        {
            if (addRemoveList.SelectedIndex >= 0 && GameData.Audios.ContainsKey(addRemoveList.Data().ID))
            {
                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                    if (node.Parent != null)
                    {
                        MaterialData m = MainForm.materialExplorer.Data();
                        if (m != null)
                        {
                            FileInfo file = new FileInfo(Path.Combine(Global.Project.Location, m.FileName));
                            string ext = file.Extension.ToLower();
                            if (m.DataType == MaterialDataType.Sound)
                                e.Effect = DragDropEffects.Copy;
                        }
                    }
                }
            }
        }

        #region IHistory Members

        public string GetActionName()
        {
            return "";
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            if (SelectedData())
            {
                MaterialData m = Global.GetData<MaterialData>(GameData.Audios[addRemoveList.SelectedID].MaterialId, GameData.Materials);
                if (m != null)
                {
                    if (Global.ImportingAudio)
                    {
                        fileName = Global.Project.Location + @"\" + m.FileName;
                        if (waveOut != null)
                        {
                            if (waveOut.PlaybackState == PlaybackState.Playing)
                            {
                                return;
                            }
                            else if (waveOut.PlaybackState == PlaybackState.Paused)
                            {
                                waveOut.Play();
                                return;
                            }
                        }
                        SetupAudio();
                        // not doing Volume on IWavePlayer any more
                        volumeStream.Volume = volumeBar.Value / 100f;
                        waveOut.Play();
                    }
                    else
                    {
                        CloseWaveOut();

                        SoundEffect curSound = Loader.SoundEffect(MaterialExplorer.contentBuilder, MainForm.audioEditor.contentManager, m.ID);

                        if (curSound != null)
                        {
                            Global.systemAudioProcessor.Stop();
                            Global.systemAudioProcessor.EndThread();
                            Global.systemAudioProcessor.Set(curSound, addRemoveList.Data<AudioData>());
                            Global.systemAudioProcessor.Play();
                            Global.systemAudioProcessor.StartThread();
                        }
                    }
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (SelectedData())
            {

                if (waveOut != null)
                    waveOut.Pause();
                if (!Global.ImportingAudio)
                    Global.systemAudioProcessor.Pause();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (SelectedData())
            {
                if (waveOut != null)
                    waveOut.Stop();

                if (!Global.ImportingAudio)
                    Global.systemAudioProcessor.Stop();
                if (!Global.ImportingAudio)
                    Global.systemAudioProcessor.EndThread();
            }
        }

        //Resume
        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectedData())
            {
                if (waveOut != null)
                    waveOut.Play();
                if (!Global.ImportingAudio)
                    Global.systemAudioProcessor.Resume();
            }
        }

        private void infiniteBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedData())
            {
                SelectedAudioEffect.Loop = infiniteBtn.Checked;

                //if (allowChange)
                Global.systemAudioProcessor.Loop = infiniteBtn.Checked;
            }
        }

        private void volumeBar_ValueChanged(object sender, decimal value)
        {
            if (SelectedData() && allowChange)
            {
                allowChange = false;
                volumeBox.Value = (decimal)volumeBar.Value;
                SelectedAudioEffect.Volume = (float)volumeBox.Value;
                Global.systemAudioProcessor.Volume = SelectedAudioEffect.Volume / 100f;
                if (waveOut != null)
                    volumeStream.Volume = (float)SelectedAudioEffect.Volume / 100f;
                allowChange = true;
            }
        }

        private void volumeBox_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedData() && allowChange)
            {
                allowChange = false;
                volumeBar.Value = (int)volumeBox.Value;
                SelectedAudioEffect.Volume = (float)volumeBox.Value;
                Global.systemAudioProcessor.Volume = SelectedAudioEffect.Volume / 100f;
                if (waveOut != null)
                    volumeStream.Volume = (float)SelectedAudioEffect.Volume / 100f;

                allowChange = true;
            }
        }

        private void pitchBar_ValueChanged(object sender, decimal value)
        {
            if (SelectedData() && allowChange)
            {
                allowChange = false;
                pitchBox.Value = (decimal)pitchBar.Value;
                SelectedAudioEffect.Pitch = (float)pitchBox.Value;

                Global.systemAudioProcessor.Pitch = SelectedAudioEffect.Pitch / 100f;
                allowChange = true;
            }
        }

        private void pitchBox_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedData() && allowChange)
            {
                allowChange = false;
                pitchBar.Value = (int)pitchBox.Value;
                SelectedAudioEffect.Pitch = (float)pitchBox.Value;
                Global.systemAudioProcessor.Pitch = SelectedAudioEffect.Pitch / 100f;
                allowChange = true;
            }
        }

        private void panBar_ValueChanged(object sender, decimal value)
        {
            if (SelectedData() && allowChange)
            {
                allowChange = false;
                panBox.Value = (decimal)panBar.Value;
                SelectedAudioEffect.Pan = (float)panBox.Value;

                Global.systemAudioProcessor.Pan = SelectedAudioEffect.Pan / 100f;
                allowChange = true;
            }
        }

        private void panBox_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedData() && allowChange)
            {
                allowChange = false;
                panBar.Value = (int)panBox.Value;
                SelectedAudioEffect.Pan = (float)panBox.Value;
                Global.systemAudioProcessor.Pan = SelectedAudioEffect.Pan / 100f;
                allowChange = true;
            }
        }

        private void fadeInBox_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedData() && allowChange)
            {
                SelectedAudioEffect.FadeIn = (float)fadeInBox.Value;
            }
        }

        private void fadeOutBox_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedData() && allowChange)
            {
                SelectedAudioEffect.FadeOut = (float)fadeOutBox.Value;
            }
        }

        private void afterBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedData() && allowChange)
            {
                SelectedAudioEffect.FadeAfter = afterBtn.Checked;
            }
        }

        private void AudioEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.systemAudioProcessor.EndThreadFinal();
            CloseWaveOut();
        }

        internal void EndThread()
        {
            if (Global.systemAudioProcessor != null)
                Global.systemAudioProcessor.EndThreadFinal();
        }

        internal void ResetProject()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);
            SetupList();
        }

        internal void Unload()
        {
            contentManager = new ContentManager(graphicsControl.Services, MaterialExplorer.contentBuilder.OutputDirectory);

        }

    }
}
