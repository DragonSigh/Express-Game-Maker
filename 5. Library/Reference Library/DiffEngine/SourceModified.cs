using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EGMGame.Library;
using System.IO;

namespace EGMGame.DiffEngine
{
    public partial class SourceModified : Form
    {
        string Path;
        ArrayList Files;
        Project project;

        public SourceModified()
        {
            InitializeComponent();
        }
        public void Setup(ArrayList files, string path, Project _project)
        {
            Path = path;
            Files = files;

            foreach (string newfile in files)
            {
                listFiles.Items.Add(newfile.Replace(Application.StartupPath, ""));
            }
            listFiles.SelectedIndex = 0;

            project = _project;
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are your sure you would like to replace all the files?\nAny changes you made to them will be lost.", "Express Game Maker", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (string newfile in Files)
                {
                    File.Copy(newfile, Path + @"\" + newfile.Replace(Application.StartupPath, ""), true);
                }
                this.Close();
            }
        }

        private void btnReplaceSelected_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are your sure you would like to replace selected file?\nAny changes you made to it will be lost.", "Express Game Maker", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string newfile = (string)Files[listFiles.SelectedIndex];

                File.Copy(newfile, Path + @"\" + newfile.Replace(Application.StartupPath, ""), true);
                Files.RemoveAt(listFiles.SelectedIndex);
                listFiles.Items.RemoveAt(listFiles.SelectedIndex);

                if (Files.Count == 0)
                    this.Close();
            }
        }

        private void btnMergeFile_Click(object sender, EventArgs e)
        {
            string newfile = (string)Files[listFiles.SelectedIndex];
            string oldfile = Path + @"\" + newfile.Replace(Application.StartupPath, "");

            MergeTool dialog = new MergeTool();
            dialog.Setup(newfile, oldfile);

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Files.RemoveAt(listFiles.SelectedIndex);
                listFiles.Items.RemoveAt(listFiles.SelectedIndex);
                if (Files.Count == 0)
                    this.Close();
            }
        }

        private void btnSkipThisStep_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to skip this step?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
