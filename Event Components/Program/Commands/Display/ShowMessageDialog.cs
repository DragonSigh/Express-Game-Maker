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
using Microsoft.Xna.Framework;
using EGMGame.Dialogs;

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class ShowMessageDialog : Form
    {
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set
            {
                programs = value; if (action == null) Setup();
            }
        }
        List<EventProgramData> programs;

        public EventPageData SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; Setup(); }
        }
        EventPageData selectedPage;

        public IEvent SelectedEvent
        {
            get { return selEvent; }
            set
            {
                selEvent = value;
                if (selEvent == null || selEvent is GlobalEventData)
                    cbEvents.RefreshList(true, false, false);
                else if (selEvent is EventData)
                    cbEvents.RefreshList(true, (selEvent.MapID > -1), (selEvent.MapID < 0));
            }
        }
        IEvent selEvent;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;

        public ShowMessageDialog()
        {
            InitializeComponent();
            cbDock.SelectedIndex = 0;
            cbText.RefreshList(false);
            cbSizeType.SelectedIndex = 0;
            cbPosType.SelectedIndex = 0;
            
            cbMenu.RefreshList(false);
            cbMessage.Repopulate();
        }

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Display;
            action.Code = 1;
        }

        private void SetupAction(EventProgramData a)
        {
            action = new EventProgramData();
            action.ID = a.ID;
            action.Name = a.Name;
            action.ProgramCategory = a.ProgramCategory;
            action.Code = a.Code;
            //action.TypeCode = a.TypeCode;
            action.Value = (object[])a.Value.Clone();
            action.Enabled = a.Enabled;

            rbText.Checked = ((int)action.Value[0] == 0 ? true : false);
            rbCustom.Checked = ((int)action.Value[0] == 0 ? false : true);

            if ((int)action.Value[0] == 0) // Text
                cbText.Select((int)action.Value[1]);
            else // Message
                cbMessage.Text = action.Value[1].ToString();

            cbMenu.Select((int)action.Value[2]);

            cbSizeType.SelectedIndex = (int)action.Value[3];

            if ((int)action.Value[3] == 1)
            {
                widthBox.Value = (decimal)((Vector2)action.Value[4]).X;
                heightBox.Value = (decimal)((Vector2)action.Value[4]).Y;
            }
            cbPosType.SelectedIndex = (int)action.Value[5];

            switch ((int)action.Value[5])
            {
                case 0: // Dock
                    cbDock.SelectedIndex = (int)action.Value[6];

                    nudOffDockX.Value = (decimal)((Vector2)action.Value[7]).X;
                    nudOffDockY.Value = (decimal)((Vector2)action.Value[7]).Y;
                    break;
                case 1: // Screen
                    nudX.Value = (decimal)((Vector2)action.Value[6]).X;
                    nudY.Value = (decimal)((Vector2)action.Value[6]).Y;
                    break;
                case 2: // Event
                    cbEvents.Select((int)action.Value[6]);
                    nudOffXBox.Value = (decimal)((Vector2)action.Value[7]).X;
                    nudOffYBox.Value = (decimal)((Vector2)action.Value[7]).Y;
                    break;
            }

            chkWait.Checked = (bool)action.Value[8];
        }

        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            cbText.Enabled = rbText.Checked;
            cbMessage.Enabled = !rbText.Checked;
        }

        private void cbSizeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelSize.Visible = (cbSizeType.SelectedIndex == 1);
        }

        private void cbPosType_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDock.Visible = (cbPosType.SelectedIndex == 0);
            panelScreen.Visible = (cbPosType.SelectedIndex == 1);
            panelEvent.Visible = (cbPosType.SelectedIndex == 2);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = (rbText.Checked ? 0 : 1);

            if ((int)action.Value[0] == 0) // Text
                action.Value[1] = cbText.Data().ID;
            else // Message
                action.Value[1] = cbMessage.Text;

            action.Value[2] = cbMenu.Data().ID;

            action.Value[3] = cbSizeType.SelectedIndex;

            action.Value[4] = new Vector2((float)widthBox.Value, (float)heightBox.Value);

            action.Value[5] = cbPosType.SelectedIndex;

            switch ((int)action.Value[5])
            {
                case 0: // Dock
                    action.Value[6] = cbDock.SelectedIndex;
                    action.Value[7] = new Vector2((float)nudOffDockX.Value, (float)nudOffDockY.Value);
                    break;
                case 1: // Screen
                    action.Value[6] = -1;
                    action.Value[7] = new Vector2((float)nudX.Value, (float)nudY.Value);
                    break;
                case 2: // Event
                    action.Value[6] = cbEvents.Data().ID;
                    action.Value[7] = new Vector2((float)nudOffXBox.Value, (float)nudOffYBox.Value);
                    break;
            }
            action.Value[8] = chkWait.Checked;

            action.GetName(SelectedEvent, SelectedPage);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// Preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            EventProgramData data = new EventProgramData();
            data.Value[0] = (rbText.Checked ? 0 : 1);

            if ((int)data.Value[0] == 0) // Text
                data.Value[1] = cbText.Data().ID;
            else // Message
                data.Value[1] = cbMessage.Text;

            data.Value[2] = cbMenu.Data().ID;

            data.Value[3] = cbSizeType.SelectedIndex;

            data.Value[4] = new Vector2((float)widthBox.Value, (float)heightBox.Value);

            data.Value[5] = cbPosType.SelectedIndex;

            switch ((int)data.Value[5])
            {
                case 0: // Dock
                    data.Value[6] = cbDock.SelectedIndex;
                    data.Value[7] = new Vector2((float)nudOffDockX.Value, (float)nudOffDockY.Value);
                    break;
                case 1: // Screen
                    data.Value[6] = -1;
                    data.Value[7] = new Vector2((float)nudX.Value, (float)nudY.Value);
                    break;
                case 2: // Event
                    data.Value[6] = cbEvents.Data().ID;
                    data.Value[7] = new Vector2((float)nudOffXBox.Value, (float)nudOffYBox.Value);
                    break;
            }
            data.Value[8] = chkWait.Checked;

            MessagePreviewDialog dialog = new MessagePreviewDialog();
            dialog.Data = data;

            dialog.ShowDialog();
        }
    }
}
