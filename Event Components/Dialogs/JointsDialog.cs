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
using EGMGame.Controls;

namespace EGMGame
{
    public partial class JointsDialog : Form
    {
        EventData Event; EventPageData EventPage;
        List<AttachmentJoint> Attachments;

        AttachmentJoint Attachment { get { return addRemoveList.Data<AttachmentJoint>(); } }

        bool allowChange = true;

        public JointsDialog()
        {
            InitializeComponent();

        }
        public JointsDialog(EventPageData eventPage, EventData ev)
        {
            InitializeComponent();

            EventPage = eventPage;
            Event = ev;
            Attachments = Global.Duplicate<List<AttachmentJoint>>(eventPage.Attachments);
            addRemoveList.SetupList(Attachments, typeof(AttachmentJoint));
            cbAttachment.RefreshList(false);
        }


        private void addRemoveList_AddItem(object sender, AddRemoveListEventArgs ca)
        {
            // Add New Attachment
            AttachmentJoint a = new AttachmentJoint();
            a.Name = Global.GetName("Attachment", Attachments);
            a.ID = Global.GetID(Attachments);
            Attachments.Add(a);

            // Add Lists
            addRemoveList.AddNode(a);

        }

        private void addRemoveList_RemoveItem(object sender, AddRemoveListEventArgs ca)
        {
            AttachmentJoint act = addRemoveList.Data<AttachmentJoint>();
            Attachments.Remove(act);

            addRemoveList.RemoveSelectedNode();
            if (addRemoveList.Data().ID > -1)
                Setup(addRemoveList.Data<AttachmentJoint>());
            else
                Setup(null);
        }

        private void addRemoveList_SelectItem(object sender, AddRemoveListEventArgs ca)
        {
            if (addRemoveList.Data().ID > -1)
                Setup(Attachments[ca.Index]);
            else
                Setup(null);
        }

        private void Setup(AttachmentJoint data)
        {
            allowChange = false;
            if (data != null)
            {
                cbType.Enabled = cbAttachment.Enabled = true;
                cbAttachment.Select(data.AttachmentID);
                cbType.SelectedIndex = -1;
                cbType.SelectedIndex = (int)data.Type;
            }
            else
            {
                cbType.Enabled = cbAttachment.Enabled = false;
                boxRevolute.Visible = boxLine.Visible = false;
            }
            allowChange = true;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxDistance.Visible = boxRevolute.Visible = boxLine.Visible = false;
            if (cbType.SelectedIndex > -1)
            {
                Attachment.Type = (AttachmentType)cbType.SelectedIndex;
                switch (cbType.SelectedIndex)
                {
                    case 0: // Revolute
                        boxRevolute.Visible = true;
                        nudRevAJPX.Value = (decimal)Attachment.Vectors[0].X;
                        nudRevAJPY.Value = (decimal)Attachment.Vectors[0].Y;
                        nudRevOJPX.Value = (decimal)Attachment.Vectors[1].X;
                        nudRevOJPY.Value = (decimal)Attachment.Vectors[1].Y;
                        chkRevCollide.Checked = Attachment.Booleans[0];
                        chkRevEnableMotor.Checked = Attachment.Booleans[1];
                        chkRevAngleLimit.Checked = Attachment.Booleans[2];
                        chkRevSensor.Checked = Attachment.Booleans[3];
                        chkRevAutoCorrectPos.Checked = Attachment.Booleans[4];
                        chkRevSyncDir.Checked = Attachment.Booleans[5];
                        nudRevMotSpeed.Value = (decimal)Attachment.Numbers[0];
                        nudRevMotTorq.Value = (decimal)Attachment.Numbers[1];
                        nudRevUpLim.Value = (decimal)Attachment.Numbers[2];
                        nudRevLowLim.Value = (decimal)Attachment.Numbers[3];
                        break;
                    case 1: // Line
                        boxLine.Visible = true;
                        nudLineAJPX.Value = (decimal)Attachment.Vectors[0].X;
                        nudLineAJPY.Value = (decimal)Attachment.Vectors[0].Y;
                        nudLineAxisX.Value = (decimal)Attachment.Vectors[1].X;
                        nudLineAxisY.Value = (decimal)Attachment.Vectors[1].Y;
                        chkLineCollide.Checked = Attachment.Booleans[0];
                        chkLineEnableMotor.Checked = Attachment.Booleans[1];
                        chkLineSensor.Checked = Attachment.Booleans[2];
                        chkLineSyncPos.Checked = Attachment.Booleans[3];
                        chkLineSyncDirection.Checked = Attachment.Booleans[4];
                        nudLineMSpeed.Value = (decimal)Attachment.Numbers[0];
                        nudLineTorque.Value = (decimal)Attachment.Numbers[1];
                        nudLineDampingRatio.Value = (decimal)Attachment.Numbers[2];
                        nudLineFreq.Value = (decimal)Attachment.Numbers[3];
                        break;
                    case 2: // Distance
                        boxDistance.Visible = true;
                        nudDisAJPX.Value = (decimal)Attachment.Vectors[0].X;
                        nudDisAJPY.Value = (decimal)Attachment.Vectors[0].Y;
                        nudDisOJPX.Value = (decimal)Attachment.Vectors[1].X;
                        nudDisOJPY.Value = (decimal)Attachment.Vectors[1].Y;
                        chkDisCollide.Checked = Attachment.Booleans[0];
                        chkDisSensor.Checked = Attachment.Booleans[1];
                        chkDisSyncPos.Checked = Attachment.Booleans[2];
                        chkDisSyncDir.Checked = Attachment.Booleans[3];
                        nudDisDistance.Value = (decimal)Attachment.Numbers[0];
                        nudDisBreakpoint.Value = (decimal)Attachment.Numbers[1];
                        nudDisDampingRatio.Value = Math.Max(nudDisDampingRatio.Minimum, Math.Min((decimal)Attachment.Numbers[2], nudDisDampingRatio.Maximum));
                        nudDisFreq.Value = Math.Max(nudDisFreq.Minimum, Math.Min((decimal)Attachment.Numbers[3], nudDisFreq.Maximum));
                        break;
                }
            }
        }

        private void cbAttachment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowChange)
                Attachment.AttachmentID = cbAttachment.Data().ID;
        }

        #region Revolute Joint

        private void nudRevAJPX_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[0].X = (float)((NumericUpDown)sender).Value;
        }

        private void nudRevAJPY_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[0].Y = (float)((NumericUpDown)sender).Value;
        }

        private void nudRevOJPX_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[1].X = (float)((NumericUpDown)sender).Value;
        }

        private void nudRevOJPY_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[1].Y = (float)((NumericUpDown)sender).Value;
        }

        private void nudRevMotSpeed_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[0] = (float)((NumericUpDown)sender).Value;
        }

        private void nudRevMotTorq_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[1] = (float)((NumericUpDown)sender).Value;
        }

        private void nudRevUpLim_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[2] = (float)((NumericUpDown)sender).Value;
        }

        private void nudRevLowLim_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[3] = (float)((NumericUpDown)sender).Value;
        }

        private void chkRevCollide_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[0] = ((CheckBox)sender).Checked;
        }

        private void chkRevEnableMotor_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[1] = ((CheckBox)sender).Checked;
        }

        private void chkRevAngleLimit_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[2] = ((CheckBox)sender).Checked;
        }

        private void chkRevSensor_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[3] = ((CheckBox)sender).Checked;
        }

        private void chkRevAutoCorrectPos_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[4] = ((CheckBox)sender).Checked;
        }

        private void chkRevSyncDir_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[5] = ((CheckBox)sender).Checked;
        }
        #endregion

        #region Line
        private void nudLineAJPX_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[0].X = (float)((NumericUpDown)sender).Value;
        }

        private void nudLineAJPY_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[0].Y = (float)((NumericUpDown)sender).Value;
        }

        private void nudLineAxisX_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[1].X = (float)((NumericUpDown)sender).Value;
        }

        private void nudLineAxisY_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[1].Y = (float)((NumericUpDown)sender).Value;
        }

        private void nudLineMSpeed_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[0] = (float)((NumericUpDown)sender).Value;
        }

        private void nudLineTorque_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[1] = (float)((NumericUpDown)sender).Value;
        }

        private void nudLineDampingRatio_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[2] = (float)((NumericUpDown)sender).Value;
        }

        private void nudLineFreq_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[3] = (float)((NumericUpDown)sender).Value;
        }

        private void chkLineCollide_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[0] = ((CheckBox)sender).Checked;
        }

        private void chkLineEnableMotor_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[1] = ((CheckBox)sender).Checked;
        }

        private void chkLineSensor_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[2] = ((CheckBox)sender).Checked;
        }

        private void chkLineSyncPos_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[3] = ((CheckBox)sender).Checked;
        }

        private void chkLineSyncDirection_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[4] = ((CheckBox)sender).Checked;
        }
        #endregion

        #region Distance

        private void nudDisDistance_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[0] = (float)((NumericUpDown)sender).Value;
        }

        private void nudDisBreakpoint_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[1] = (float)((NumericUpDown)sender).Value;
        }

        private void nudDisFreq_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[2] = (float)((NumericUpDown)sender).Value;
        }

        private void nudDisDampingRatio_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Numbers[3] = (float)((NumericUpDown)sender).Value;
        }

        private void nudDisOJPY_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[1].Y = (float)((NumericUpDown)sender).Value;
        }

        private void nudDisOJPX_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[1].X = (float)((NumericUpDown)sender).Value;
        }

        private void nudDisAJPY_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[0].Y = (float)((NumericUpDown)sender).Value;
        }

        private void nudDisAJPX_ValueChanged(object sender, EventArgs e)
        {
            Attachment.Vectors[0].X = (float)((NumericUpDown)sender).Value;
        }

        private void chkDisCollide_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[0] = ((CheckBox)sender).Checked;
        }

        private void chkDisSensor_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[1] = ((CheckBox)sender).Checked;
        }

        private void chkDisSyncPos_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[2] = ((CheckBox)sender).Checked;
        }

        private void chkDisSyncDir_CheckedChanged(object sender, EventArgs e)
        {
            Attachment.Booleans[3] = ((CheckBox)sender).Checked;
        }
        #endregion

        private void okBtn_Click(object sender, EventArgs e)
        {

            EventPage.Attachments = Attachments;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
