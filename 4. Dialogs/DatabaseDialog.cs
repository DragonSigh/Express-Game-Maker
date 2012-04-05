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

namespace EGMGame.Dialogs
{
    public partial class DatabaseDialog : Form
    {
        List<DataType> Types;
        public DatabaseDialog(List<DataType> types)
        {
            InitializeComponent();
            Types = types;
            databaseBox.RefreshList(false);
        }

        public void Setup(int databaseId, int dataId, int propertId)
        {
            databaseBox.Select(databaseId);
            dataBox.Select(dataId);
            propertyBox.Select(propertId);
        }

        private void databaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (databaseBox.Data().ID > -10)
            {
                dataBox.Enabled = true;
                dataBox.RefreshList(databaseBox.Data(), true);
            }
            else
            {
                dataBox.Enabled = false;
                dataBox.Items.Clear();
            }
        }

        private void dataBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataBox.Data().ID > -10)
            {
                propertyBox.Enabled = true;
                propertyBox.RefreshList(dataBox.Data(), true, Types);
            }
            else
            {
                propertyBox.Enabled = false;
                propertyBox.Items.Clear();
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
