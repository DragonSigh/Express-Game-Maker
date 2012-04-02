using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EGMGame.Library;

namespace EGMGame.Dialogs
{
    public partial class MapDirectoryDialog : Form
    {

        public string FileName
        {
            get
            {
                return Path.Combine(Global.Project.Location, @"Maps\" + nameBox.Text); 
            }
            set { nameBox.Text = value; }
        }

        public MapDirectoryDialog()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            nameBox.Text = Path.ChangeExtension(nameBox.Text, Extensions.Scene);
            if (File.Exists(FileName))
            {
                if (DialogResult.Yes == MessageBox.Show("A  map with the same name already exits! Are you sure you want to override it?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        File.Create(FileName).Close();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    File.Create(FileName).Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    if (ex is System.ArgumentException)
                        MessageBox.Show(ex.Message, ex.Message);
                    else
                        Error.ShowLogError(ex, "26x001");
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(MainForm.BackgroundFill(this.Height), this.ClientRectangle);
        }
    }
}
