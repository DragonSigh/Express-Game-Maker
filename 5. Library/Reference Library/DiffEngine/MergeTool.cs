using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DifferenceEngine;
using System.Collections;
using System.IO;

namespace EGMGame.DiffEngine
{
    public partial class MergeTool : Form
    {

        string SourceFile;
        string NewFile;
        List<int> problemLines;

        public MergeTool()
        {
            InitializeComponent();

            txtSource.ConfigurationManager.Language = "cs";
            txtSource.Margins[0].Width = 30;


            txtTarget.ConfigurationManager.Language = "cs";
            txtTarget.Margins[0].Width = 30;
            txtTarget.AutoComplete.AutomaticLengthEntered = true;
            txtTarget.AutoComplete.AutoHide = true;
            txtTarget.AutoComplete.IsCaseSensitive = false;
        }
        /// <summary>
        /// Setup Source and New File
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="dFile"></param>
        public void Setup(string sFile, string dFile)
        {
            SourceFile = sFile;
            NewFile = dFile;
            DiffList_TextFile sLF = null;
            DiffList_TextFile dLF = null;
            try
            {
                sLF = new DiffList_TextFile(sFile);
                dLF = new DiffList_TextFile(dFile);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "File Error");
                return;
            }

            try
            {
                double time = 0;
                DifferenceEngine.DiffEngine de = new DifferenceEngine.DiffEngine();
                time = de.ProcessDiff(sLF, dLF, DiffEngineLevel.SlowPerfect);

                ArrayList rep = de.DiffReport();
                Setup(sLF, dLF, rep, time);
            }
            catch (Exception ex)
            {
                string tmp = string.Format("{0}{1}{1}***STACK***{1}{2}",
                    ex.Message,
                    Environment.NewLine,
                    ex.StackTrace);
                MessageBox.Show(tmp, "Compare Error");
                return;
            }
        }
        public void Refresh(string stext, string ftext)
        {
            DiffList_TextFile sLF = null;
            DiffList_TextFile dLF = null;
            try
            {
                sLF = new DiffList_TextFile(SourceFile);
                dLF = DiffList_TextFile.FromText(ftext);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "File Error");
                return;
            }

            try
            {
                double time = 0;
                DifferenceEngine.DiffEngine de = new DifferenceEngine.DiffEngine();
                time = de.ProcessDiff(sLF, dLF, DiffEngineLevel.SlowPerfect);

                ArrayList rep = de.DiffReport();
                Setup(sLF, dLF, rep, time);
            }
            catch (Exception ex)
            {
                string tmp = string.Format("{0}{1}{1}***STACK***{1}{2}",
                    ex.Message,
                    Environment.NewLine,
                    ex.StackTrace);
                MessageBox.Show(tmp, "Compare Error");
                return;
            }
        }
        /// <summary>
        /// Setup results
        /// </summary>
        /// <param name="sLF"></param>
        /// <param name="dLF"></param>
        /// <param name="rep"></param>
        /// <param name="time"></param>
        private void Setup(DiffList_TextFile source, DiffList_TextFile destination, ArrayList DiffLines, double seconds)
        {
            allowChange = false;
            int cnt = 1;
            int i;
            txtSource.IsReadOnly = false;
            txtSource.Markers.DeleteAll();
            txtTarget.Markers.DeleteAll();
            txtSource.Text = "";
            txtTarget.Text = "";
            txtSource.Scrolling.ScrollBars = ScrollBars.Horizontal;
            problemLines = new List<int>();
            bool problem = false;
            string nextLine = "";
            foreach (DiffResultSpan drs in DiffLines)
            {
                switch (drs.Status)
                {
                    case DiffResultSpanStatus.DeleteSource:
                        for (i = 0; i < drs.Length; i++)
                        {
                            txtSource.Text += nextLine + ((DifferenceEngine.TextLine)source.GetByIndex(drs.SourceIndex + i)).Line;
                            txtTarget.Text += nextLine;

                            cnt++;

                            if (!problem)
                                problemLines.Add(cnt);
                            else
                                problemLines.Add(-1);
                            problem = true;
                            nextLine = "\n";
                        }

                        break;
                    case DiffResultSpanStatus.NoChange:
                        for (i = 0; i < drs.Length; i++)
                        {
                            txtSource.Text += nextLine + ((DifferenceEngine.TextLine)source.GetByIndex(drs.SourceIndex + i)).Line;
                            txtTarget.Text += nextLine + ((DifferenceEngine.TextLine)destination.GetByIndex(drs.DestIndex + i)).Line;

                            cnt++;
                            problem = false;
                            problemLines.Add(-1);
                            nextLine = "\n";
                        }

                        break;
                    case DiffResultSpanStatus.AddDestination:
                        for (i = 0; i < drs.Length; i++)
                        {
                            txtSource.Text += nextLine;
                            txtTarget.Text += nextLine + ((DifferenceEngine.TextLine)destination.GetByIndex(drs.DestIndex + i)).Line;

                            cnt++;
                            if (!problem)
                                problemLines.Add(cnt);
                            else
                                problemLines.Add(-1);

                            problem = true;
                            nextLine = "\n";
                        }

                        break;
                    case DiffResultSpanStatus.Replace:
                        for (i = 0; i < drs.Length; i++)
                        {
                            txtSource.Text += nextLine + ((DifferenceEngine.TextLine)source.GetByIndex(drs.SourceIndex + i)).Line;
                            txtTarget.Text += nextLine + ((DifferenceEngine.TextLine)destination.GetByIndex(drs.DestIndex + i)).Line;

                            ScintillaNet.Marker marker = txtSource.Markers[0];
                            marker.Symbol = ScintillaNet.MarkerSymbol.Background;
                            marker.BackColor = Color.LightGray;
                            txtSource.NativeInterface.MarkerAdd(cnt, marker.Number);

                            cnt++;
                            if (!problem)
                                problemLines.Add(cnt);
                            else
                                problemLines.Add(-1);
                            problem = true;

                            nextLine = "\n";
                        }

                        break;
                }

            }


            #region Color
            cnt = 0;
            foreach (DiffResultSpan drs in DiffLines)
            {
                switch (drs.Status)
                {
                    case DiffResultSpanStatus.DeleteSource:
                        for (i = 0; i < drs.Length; i++)
                        {
                            txtSource.Markers[0].Symbol = ScintillaNet.MarkerSymbol.Background;
                            txtSource.Markers[0].BackColor = Color.Red;
                            txtSource.NativeInterface.MarkerAdd(cnt, txtSource.Markers[0].Number);

                            txtTarget.Markers[0].Symbol = ScintillaNet.MarkerSymbol.Background;
                            txtTarget.Markers[0].BackColor = Color.LightGray;
                            txtTarget.NativeInterface.MarkerAdd(cnt, txtTarget.Markers[0].Number);

                            cnt++;
                        }

                        break;
                    case DiffResultSpanStatus.NoChange:
                        for (i = 0; i < drs.Length; i++)
                        {
                            cnt++;
                        }

                        break;
                    case DiffResultSpanStatus.AddDestination:
                        for (i = 0; i < drs.Length; i++)
                        {
                            txtSource.Markers[0].Symbol = ScintillaNet.MarkerSymbol.Background;
                            txtSource.Markers[0].BackColor = Color.LightGray;
                            txtSource.NativeInterface.MarkerAdd(cnt, txtSource.Markers[0].Number);

                            txtTarget.Markers[0].Symbol = ScintillaNet.MarkerSymbol.Background;
                            txtTarget.Markers[0].BackColor = Color.LightGreen;
                            txtTarget.NativeInterface.MarkerAdd(cnt, txtTarget.Markers[0].Number);
                            cnt++;
                        }

                        break;
                    case DiffResultSpanStatus.Replace:
                        for (i = 0; i < drs.Length; i++)
                        {
                            txtSource.Markers[0].Symbol = ScintillaNet.MarkerSymbol.Background;
                            txtSource.Markers[0].BackColor = Color.Red;
                            txtSource.NativeInterface.MarkerAdd(cnt, txtSource.Markers[0].Number);

                            txtTarget.Markers[0].Symbol = ScintillaNet.MarkerSymbol.Background;
                            txtTarget.Markers[0].BackColor = Color.LightGreen;
                            txtTarget.NativeInterface.MarkerAdd(cnt, txtTarget.Markers[0].Number);
                            cnt++;
                        }

                        break;
                }

            }
            #endregion
            txtSource.IsReadOnly = true;
            allowChange = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (txtSource.Lines.Current.Number > 0)
            {
                for (int i = txtSource.Lines.Current.Number - 1; i > -1; i--)
                {
                    if (problemLines[i] > -1)
                    {
                        txtSource.Caret.LineNumber = i;
                        txtSource.Scrolling.ScrollToCaret();

                        txtTarget.Caret.LineNumber = i;
                        txtTarget.Scrolling.ScrollToCaret();
                        break;
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (txtSource.Lines.Current.Number < problemLines.Count)
            {
                for (int i = txtSource.Lines.Current.Number + 1; i < problemLines.Count; i++)
                {
                    if (problemLines[i] > -1)
                    {
                        txtSource.Caret.LineNumber = i;
                        txtSource.Scrolling.ScrollToCaret();

                        txtTarget.Caret.LineNumber = i;
                        txtTarget.Scrolling.ScrollToCaret();
                        break;
                    }
                }
            }
        }

        private void btnEditLine_Click(object sender, EventArgs e)
        {

        }

        private void btnReplaceLine_Click(object sender, EventArgs e)
        {

        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are your sure you would like to replace all the files?\nAny changes you made to them will be lost.", "Express Game Maker", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                File.Copy(SourceFile, NewFile, true);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }


        private const uint WM_SCROLL = 276; // Horizontal scroll
        private const uint WM_VSCROLL = 277; // Vertical scroll
        private const uint SB_LINEUP = 0; // Scrolls one line up
        private const int SB_LINELEFT = 0;// Scrolls one cell left
        private const int SB_LINEDOWN = 1; // Scrolls one line down
        private const int SB_LINERIGHT = 1;// Scrolls one cell right
        private const int SB_PAGEUP = 2; // Scrolls one page up
        private const int SB_PAGELEFT = 2;// Scrolls one page left
        private const int SB_PAGEDOWN = 3; // Scrolls one page down
        private const int SB_PAGERIGTH = 3; // Scrolls one page right
        private const int SB_PAGETOP = 6; // Scrolls to the upper left
        private const int SB_LEFT = 6; // Scrolls to the left
        private const int SB_PAGEBOTTOM = 7; // Scrolls to the upper right
        private const int SB_RIGHT = 7; // Scrolls to the right
        private const int SB_ENDSCROLL = 8; // Ends scroll

        bool allowScroll = true;
        private void txtTarget_Scroll(object sender, ScrollEventArgs e)
        {
            if (!allowScroll) return;
            allowScroll = false;
            switch (e.ScrollOrientation)
            {
                case ScrollOrientation.HorizontalScroll:
                    break;
                case ScrollOrientation.VerticalScroll:
                    txtSource.NativeInterface.LineScroll(0, e.NewValue - e.OldValue);
                    break;
            }
            allowScroll = true;
        }

        private void txtSource_Scroll(object sender, ScrollEventArgs e)
        {
            if (!allowScroll) return;
            allowScroll = false;
            switch (e.ScrollOrientation)
            {
                case ScrollOrientation.HorizontalScroll:

                    break;
                case ScrollOrientation.VerticalScroll:
                    txtTarget.NativeInterface.LineScroll(0, e.NewValue - e.OldValue);
                    break;
            }
            allowScroll = true;
        }

        bool allowChange;
        private void txtTarget_TextChanged(object sender, EventArgs e)
        {
            if (allowChange)
            {
                btnRefresh.Text = "Refresh";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh(txtSource.Text, txtTarget.Text);
            btnRefresh.Text = "";
        }

        bool close = false;
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to finish editing? You will not be able to edit again and any unsaved changes will be lost!", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                close = true;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void MergeTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!close)
            {
                if (MessageBox.Show("Are you sure you would like to close? Any unsaved changes will be lost!", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter targetFile = new StreamWriter(NewFile))
            {
                targetFile.Write(txtTarget.Text);
                targetFile.Close();
            }
        }


        private void moveToTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (problemLines[txtSource.Lines.Current.Number] > -1 || txtSource.Lines.Current.GetMarkers().Count > 0)
            {
                int index = txtSource.Lines.Current.Number;
                for (int i = txtSource.Lines.Current.Number; i > -1; i--)
                {
                    if (problemLines[i] == -1 && txtSource.Lines[i].GetMarkers().Count == 0)
                        break;
                    index = i;
                }

                int breakIndex = txtSource.Lines.Current.Number;
                for (int i = index; i < problemLines.Count; i++)
                {
                    if (problemLines[i] == -1 && txtSource.Lines[i].GetMarkers().Count == 0)
                        break;
                    breakIndex = i;
                }

                for (int i = index; i <= breakIndex; i++)
                {
                    txtTarget.Lines[i].Text = txtSource.Lines[i].Text.Replace("\n","");
                    txtTarget.Lines[i].DeleteAllMarkers();
                    txtSource.Lines[i].DeleteAllMarkers();
                    problemLines[i] = -1;
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSource.NativeInterface.Copy();

            txtTarget.Text = "tesT";
        }

        private void txtTarget_TextDeleted(object sender, ScintillaNet.TextModifiedEventArgs e)
        {
            if (allowChange && !string.IsNullOrEmpty(e.Text) && e.LinesAddedCount < 0)
            {
                delPosition = e.Position;
                deleted = Math.Abs(e.LinesAddedCount);
            }
        }

        int deleted;
        int delPosition;
        private void txtTarget_KeyUp(object sender, KeyEventArgs e)
        {
            if (deleted > 0)
            {
                for (int i = 0; i < deleted; i++)
                {
                    txtTarget.InsertText(delPosition, "\n");
                }
                deleted = 0;
            }
        }
    }
}
