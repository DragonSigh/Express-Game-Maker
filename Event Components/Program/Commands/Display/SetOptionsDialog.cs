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

namespace EGMGame.Controls.EventControls.EventDialogs.CommandDialogs
{
    public partial class SetOptionsDialog : Form
    {
        public List<EventProgramData> Programs
        {
            get { return programs; }
            set { programs = value; if (action == null)  Setup(); }
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
            set { selEvent = value; }
        }
        IEvent selEvent;

        public EventProgramData ProgramData
        {
            get { return action; }
            set { SetupAction(value); }
        }
        EventProgramData action;

        List<object> list;

        public SetOptionsDialog()
        {
            InitializeComponent();

            cbText.RefreshList(false);
            list = new List<object>();

            cbMessage.Repopulate();
            cbMessage.TextChangeEvent = new EventHandler(TextChanged);
        }

        internal void Setup()
        {
            action = new EventProgramData();
            action.ID = Global.GetProgramID(Programs);
            action.ProgramCategory = ProgramCategory.Display;
            action.Code = 14;
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

            list = new List<object>((List<object>)action.Value[0]);

            for (int i = 0; i < list.Count; i++)
            {
                listOptions.Items.Add("Option " + i.ToString());
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            action.Value[0] = list;

            action.GetName(SelectedEvent, selectedPage);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        bool allowChange = true;
        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            if (!allowChange)
                return;

            cbText.Enabled = rbText.Checked;
            cbMessage.Enabled = !rbText.Checked;

            if (listOptions.SelectedIndex > -1)
            {
                if (cbMessage.Enabled)
                {
                    list[listOptions.SelectedIndex] = "";
                }
                else if (cbText.Enabled)
                {
                    list[listOptions.SelectedIndex] = 0;
                }
                SetupData(list[listOptions.SelectedIndex]);
            }
        }

        private void SetupData(object value)
        {
            allowChange = false;
            if (value == null)
            {
                impactGroupBox3.Enabled = false;
            }
            else if (value is int)
            {
                impactGroupBox3.Enabled = true;
                rbCustom.Checked = false;
                rbText.Checked = true;
                cbText.Enabled = true;
                cbMessage.Enabled = false;
                cbText.Select((int)value);
                cbMessage.Text = "";
            }
            else if (value is string)
            {
                impactGroupBox3.Enabled = true;
                rbCustom.Checked = true;
                rbText.Checked = false;

                cbText.Enabled = false;
                cbMessage.Enabled = true;
                
                cbMessage.Text = value.ToString();
            }
            allowChange = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            list.Add(0);
            listOptions.Items.Add("Option " + listOptions.Items.Count);
            listOptions.SelectedIndex = listOptions.Items.Count - 1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listOptions.SelectedIndex > -1)
            {
                list.RemoveAt(listOptions.SelectedIndex);
                listOptions.Items.RemoveAt(listOptions.SelectedIndex);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void listOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listOptions.SelectedIndex > -1)
                SetupData(list[listOptions.SelectedIndex]);
            else
                SetupData(null);
        }

        private void cbText_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allowChange)
                return;
            if (listOptions.SelectedIndex > -1)
            {

                list[listOptions.SelectedIndex] = cbText.Data().ID;
            }
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if (!allowChange)
                return;
            if (listOptions.SelectedIndex > -1)
            {
                list[listOptions.SelectedIndex] = cbMessage.Text;
            }
        }

    }
}
