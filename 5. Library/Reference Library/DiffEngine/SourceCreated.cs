using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using EGMGame.Library;

namespace EGMGame.DiffEngine
{
    public partial class SourceCreated : Form
    {
        string Path;
        ArrayList Files;
        Project project;

        public SourceCreated()
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

        private void btnAddAllFiles_Click(object sender, EventArgs e)
        {
            foreach (string newfile in Files)
            {
                if (!File.Exists(Path + @"\" + newfile.Replace(Application.StartupPath, "")))
                {
                    File.Copy(newfile, Path + @"\" + newfile.Replace(Application.StartupPath, ""));

                    string f = newfile.Replace(Application.StartupPath, "");
                    project.SourceFiles.Add(new SourceFile(f));
                }
            }
            this.Close();
        }

        private void btnAddSelectedFile_Click(object sender, EventArgs e)
        {
            string newfile = (string)Files[listFiles.SelectedIndex];

            if (!File.Exists(Path + @"\" + newfile.Replace(Application.StartupPath, "")))
            {
                File.Copy(newfile, Path + @"\" + newfile.Replace(Application.StartupPath, ""));
                string f = newfile.Replace(Application.StartupPath, "");
                project.SourceFiles.Add(new SourceFile(f));
            }
            Files.RemoveAt(listFiles.SelectedIndex);
            listFiles.Items.RemoveAt(listFiles.SelectedIndex);

            if (Files.Count == 0)
                this.Close();
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
