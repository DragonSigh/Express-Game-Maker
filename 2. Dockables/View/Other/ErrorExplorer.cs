using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using EGMGame.Library;
using System.IO;

namespace EGMGame.Docking.Explorers
{
    public partial class ErrorExplorer : DockContent
    {
        public ErrorExplorer()
        {
            InitializeComponent();

            ErrorCount = 0;
            listSource.SmallImageList = imageList;
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.ColorDepth = ColorDepth.Depth32Bit;
            this.imageList.Images.Add("cancel.png", global::EGMGame.Properties.Resources.cancel);
            this.imageList.Images.Add("warning.png", global::EGMGame.Properties.Resources.exclamation);

        }


        /// <summary>
        /// Source Error
        /// </summary>
        /// <param name="error"></param>
        internal void SetSourceError(string error)
        {
            ErrorCount = 0;
            if (this.DockPanel != null)
            {
                MainForm.sourceEditor.ClearErrorWarnings();
                try
                {
                    listSource.Items.Clear();
                }
                catch
                {
                }
                string[] lines = error.Split('\n');
                string[] line, pathNumber;
                string lineNumber, lineCol, description, code, path, type;
                for (int i = 0; i < lines.Length; i++)
                {
                    lineNumber = lineCol = description = code = path = type = "";
                    if (lines[i].Length > 0)
                    {
                        line = lines[i].Split(')');

                        if (line.Length > 1)
                        {
                            pathNumber = line[0].Split('(');
                            path = pathNumber[0];
                            if (path.ToLower().Contains(Path.GetTempPath().ToLower()))
                            {
                                path = Replace(path, Path.GetTempPath() + @"Source\", "", StringComparison.OrdinalIgnoreCase);
                            }
                            else
                                path = Replace(path, Global.Project.Location + @"\Source\", "", StringComparison.OrdinalIgnoreCase);
                            lineNumber = pathNumber[1].Split(',')[0];
                            lineCol = pathNumber[1].Split(',')[1];
                            description = line[1].Split(':')[2];
                            type = line[1].Split(':')[1].Split(' ')[1];
                            code = line[1].Split(':')[1].Split(' ')[2];
                        }
                        else
                        {
                            description = line[0];
                        }

                        ListViewItem item = new ListViewItem(type);
                        item.ImageKey = (type == "warning" ? "warning.png" : "cancel.png");
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = i.ToString() });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = description + ". Code: " + code });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = path });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = lineNumber });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = lineCol });
                        listSource.Items.Add(item);

                        MainForm.sourceEditor.SetErrorWarning(Global.Project.Location + @"\Source\" + path, lineNumber, lineCol, type);
                    }
                }

                ErrorCount = listSource.Items.Count;
            }
        }

        static public string Replace(string original, string pattern, string replacement, StringComparison comparisonType)
        {
            return Replace(original, pattern, replacement, comparisonType, -1);
        }

        static public string Replace(string original, string pattern, string replacement, StringComparison comparisonType, int stringBuilderInitialSize)
        {
            if (original == null)
            {
                return null;
            }

            if (String.IsNullOrEmpty(pattern))
            {
                return original;
            }


            int posCurrent = 0;
            int lenPattern = pattern.Length;
            int idxNext = original.IndexOf(pattern, comparisonType);
            StringBuilder result = new StringBuilder(stringBuilderInitialSize < 0 ? Math.Min(4096, original.Length) : stringBuilderInitialSize);

            while (idxNext >= 0)
            {
                result.Append(original, posCurrent, idxNext - posCurrent);
                result.Append(replacement);

                posCurrent = idxNext + lenPattern;

                idxNext = original.IndexOf(pattern, posCurrent, comparisonType);
            }

            result.Append(original, posCurrent, original.Length - posCurrent);

            return result.ToString();
        }
        /// <summary>
        /// Clear Source Error
        /// </summary>
        internal void ClearSourceError()
        {
            listSource.Items.Clear();
            MainForm.sourceEditor.ClearErrorWarnings();
            ErrorCount = 0;
        }

        private void listSource_DoubleClick(object sender, EventArgs e)
        {
            if (listSource.SelectedItems.Count > 0)
            {
                // Selected Item
                ListViewItem item = listSource.SelectedItems[0];
                if (item != null)
                {
                    string path; int line, col;
                    path = Global.Project.Location + @"\Source\" + item.SubItems[3].Text;
                    int.TryParse(item.SubItems[4].Text, out line);
                    int.TryParse(item.SubItems[5].Text, out col);
                    MainForm.sourceEditor.Open(path, line, col, item.SubItems[2].Text);
                }
            }
        }

        public int ErrorCount { get; set; }
    }
}
