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
    public partial class SourceDeleted : Form
    {
        string Path;
        ArrayList Files;

        Project project;

        public SourceDeleted()
        {
            InitializeComponent();
        }

        public void Setup(ArrayList moveList, string path, Project _project)
        {
            Path = path;
            Files = moveList;

            foreach (string newfile in moveList)
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
                if (File.Exists(Path + @"\" + newfile))
                {
                    File.Delete(Path + @"\" + newfile);

                    int count = project.SourceFiles.Count;
                    for (int i = 0; i < count; i++)
                    {
                        if (project.SourceFiles[i].Path == newfile)
                        {
                            project.SourceFiles.RemoveAt(i);
                            i--; count--;
                        }
                    }
                }
            }
            this.Close();
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            string newfile = (string)Files[listFiles.SelectedIndex];
            if (File.Exists(Path + @"\" + newfile))
            {
                File.Delete(Path + @"\" + newfile);
                int count = project.SourceFiles.Count;
                for (int i = 0; i < count; i++)
                {
                    if (project.SourceFiles[i].Path == newfile)
                    {
                        project.SourceFiles.RemoveAt(i);
                        i--; count--;
                    }
                }
                Files.RemoveAt(listFiles.SelectedIndex);
                listFiles.Items.RemoveAt(listFiles.SelectedIndex);
            }
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
