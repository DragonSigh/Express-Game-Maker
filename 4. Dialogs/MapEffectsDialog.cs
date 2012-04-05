//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Library;
using EGMGame.EventControls.EventDialogs.CommandDialogs;

namespace EGMGame.Dialogs
{
    public partial class MapEffectsDialog : Form
    {
        MapData Map;

        EventProgramData bgm;
        EventProgramData bgs;
        EventProgramData tint;
        EventProgramData fog;

        public MapEffectsDialog()
        {
            InitializeComponent();
        }

        public void Setup(MapData map)
        {
            Map = map;

            chkBGM.Checked = Map.EnableBGM;
            chkBGS.Checked = Map.EnableBGS;
            chkTint.Checked = Map.EnableTint;
            chkFog.Checked = Map.EnableFog;

            bgm = Map.BGM;
            bgs = Map.BGS;
            tint = Map.Tint;
            fog = Map.Fog;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {

            Map.EnableBGM = chkBGM.Checked;
            Map.EnableBGS = chkBGS.Checked;
            Map.EnableTint = chkTint.Checked;
            Map.EnableFog = chkFog.Checked;

            Map.BGM = bgm;
            Map.BGS = bgs;
            Map.Tint = tint;
            Map.Fog = fog;

            MainForm.NeedSave = true;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playAudioBtn_Click(object sender, EventArgs e)
        {
            AudioPlayDialog dialog = new AudioPlayDialog();
            dialog.Programs = null;
            dialog.SelectedPage = null;
            dialog.SelectedEvent = null;
            if (bgm != null)
                dialog.ProgramData = bgm;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                bgm = dialog.ProgramData;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AudioPlayDialog dialog = new AudioPlayDialog();
            dialog.Programs = null;
            dialog.SelectedPage = null;
            dialog.SelectedEvent = null;
            if (bgs != null)
                dialog.ProgramData = bgs;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                bgs = dialog.ProgramData;
            }
        }

        private void tintScreenBtn_Click(object sender, EventArgs e)
        {
            TintEventDialog dialog = new TintEventDialog();
            dialog.Programs = null;
            dialog.SelectedPage = null;
            dialog.SelectedEvent = null;
            if (tint != null)
                dialog.ProgramData = tint;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tint = dialog.ProgramData;
            }
        }

        private void btnEditFog_Click(object sender, EventArgs e)
        {
            EditFogDialog dialog = new EditFogDialog();
            dialog.Programs = null;
            dialog.SelectedPage = null;
            dialog.SelectedEvent = null;
            if (fog != null)
                dialog.ProgramData = fog;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                fog = dialog.ProgramData;
            }
        }

        private void chkBGM_CheckedChanged(object sender, EventArgs e)
        {
            playAudioBtn.Enabled = chkBGM.Checked;
        }

        private void chkBGS_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = chkBGS.Checked;
        }

        private void chkTint_CheckedChanged(object sender, EventArgs e)
        {
            tintScreenBtn.Enabled = chkTint.Checked;
        }

        private void chkFog_CheckedChanged(object sender, EventArgs e)
        {
            btnEditFog.Enabled = chkFog.Checked;
        }
    }
}
