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
    public partial class SourceMoved : Form
    {
        string Path;
        ArrayList Files;
        ArrayList MoveTo;

        Project project;

        public SourceMoved()
        {
            InitializeComponent();
        }

        public void Setup(ArrayList moveList, ArrayList moveTo, string path, Project _project)
        {
            Path = path;
            Files = moveList;
            MoveTo = moveTo;

            foreach (string newfile in moveList)
            {
                listFiles.Items.Add(newfile);
            }
            listFiles.SelectedIndex = 0;

            project = _project;
        }

        private void btnAddAllFiles_Click(object sender, EventArgs e)
        {
            foreach (string newfile in Files)
            {

            }
            this.Close();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            string newfile = (string)Files[listFiles.SelectedIndex];

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
