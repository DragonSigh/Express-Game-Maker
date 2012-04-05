//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EGMGame.Controls.UI
{
    public partial class SourceControl : UserControl
    {
        public string Source, _Path, _Name;
        public bool NeedSave = false;
        string tempName;

        public SourceControl()
        {
            InitializeComponent();

            scintilla.ConfigurationManager.Language = "cs";
            scintilla.Margins[0].Width = 40;
            //scintilla.AutoComplete.AutomaticLengthEntered = true;
            //scintilla.AutoComplete.AutoHide = true;
            //scintilla.AutoComplete.IsCaseSensitive = false;

            scintilla.AutoComplete.List = new List<string>() 
            {
                "abstract event","new","struct",
                "as","explicit","null","switch",
                "base","extern","object","this",
                "bool","false","operator","throw",
                "break","finally","out","true",
                "byte","fixed","override","try",
                "case","float","params","typeof",
                "catch","for","private","uint",
                "char","foreach","protected","ulong",
                "checked","goto","public","unchecked",
                "class","if","readonly","unsafe",
                "const","implicit","ref","ushort",
                "continue","in","return","using",
                "decimal","int","sbyte","virtual",
                "default","interface","sealed","volatile",
                "delegate","internal","short","void",
                "do","is","sizeof","while",
                "double","lock","stackalloc",
                "else","long","static",
                "enum","namespace","string"
            };
            scintilla.AutoComplete.List.Sort();

            scintilla.NativeInterface.SetProperty("fold.comment", "1");
            scintilla.NativeInterface.SetProperty("fold.preprocessor", "1");
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            scintilla.UndoRedo.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            scintilla.UndoRedo.Redo();
        }

        private void scintilla_TextChanged(object sender, EventArgs e)
        {
            btnUndo.Enabled = scintilla.UndoRedo.CanUndo;
            btnRedo.Enabled = scintilla.UndoRedo.CanRedo;

            if (btnUndo.Enabled || btnRedo.Enabled)
            {
                btnSaveDocumant.Text = "Needs Save";
                NeedSave = true;
                ((TabPage)this.Parent).Text = _Name + "*";
            }
            else
            {
                btnSaveDocumant.Text = "";

                ((TabPage)this.Parent).Text = _Name + "";
            }
        }

        private void foldAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.NativeInterface.Colourise(0, -1);

            int maxLine = scintilla.NativeInterface.GetLineCount();
            bool expanding = true;
            for (int lineSeek = 0; lineSeek < maxLine; lineSeek++)
            {
                if ((scintilla.NativeInterface.GetFoldLevel(lineSeek) & ScintillaNet.Constants.SC_FOLDLEVELHEADERFLAG) > 0)
                {
                    expanding = !scintilla.NativeInterface.GetFoldExpanded(lineSeek);
                    break;
                }
            }

            for (int line = 0; line < maxLine; line++)
            {
                uint level = scintilla.NativeInterface.GetFoldLevel(line);
                if ((level & ScintillaNet.Constants.SC_FOLDLEVELHEADERFLAG) > 0 &&
                    (ScintillaNet.Constants.SC_FOLDLEVELBASE == (level & ScintillaNet.Constants.SC_FOLDLEVELNUMBERMASK))
                    )
                {
                    if (expanding)
                    {
                        scintilla.NativeInterface.SetFoldExpanded(line, true);
                        ExpandCollapseFold(ref line, true, false, 0, (int)level);
                        line--;
                    }
                    else
                    {
                        int lineMaxSubord = scintilla.NativeInterface.GetLastChild(line, -1);
                        scintilla.NativeInterface.SetFoldExpanded(line, false);
                        if (lineMaxSubord > line)
                        {
                            scintilla.NativeInterface.HideLines(line + 1, lineMaxSubord);
                        }
                    }
                }
            }
        }

        private void foldCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.Lines.Current.ToggleFoldExpanded();
        }

        private void ExpandCollapseFold(ref int line, bool doExpand, bool force, int visLevels, int level)
        {
            int lineMaxSubord = scintilla.NativeInterface.GetLastChild(line, (int)(level & ScintillaNet.Constants.SC_FOLDLEVELNUMBERMASK));
            line++;

            while (line <= lineMaxSubord)
            {
                if (force)
                {
                    if (visLevels > 0)
                    {
                        scintilla.NativeInterface.ShowLines(line, line);
                    }
                    else
                    {
                        scintilla.NativeInterface.HideLines(line, line);
                    }
                }
                else
                {
                    if (doExpand)
                    {
                        scintilla.NativeInterface.ShowLines(line, line);
                    }
                }

                int levelLine = level;
                if (levelLine == -1)
                {
                    levelLine = (int)scintilla.NativeInterface.GetFoldLevel(line);
                }

                if ((levelLine & ScintillaNet.Constants.SC_FOLDLEVELHEADERFLAG) > 0)
                {
                    if (force)
                    {
                        if (visLevels > 1)
                        {
                            scintilla.NativeInterface.SetFoldExpanded(line, true);
                        }
                        else
                        {
                            scintilla.NativeInterface.SetFoldExpanded(line, false);
                        }

                        ExpandCollapseFold(ref line, doExpand, force, visLevels - 1, -1);
                    }
                    else
                    {
                        if (doExpand)
                        {
                            if (!scintilla.NativeInterface.GetFoldExpanded(line))
                            {
                                scintilla.NativeInterface.SetFoldExpanded(line, true);
                            }
                            ExpandCollapseFold(ref line, true, force, visLevels - 1, -1);
                        }
                        else
                        {
                            ExpandCollapseFold(ref line, false, force, visLevels - 1, -1);
                        }
                    }
                }
                else
                {
                    line++;
                }
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.FindReplace.ShowFind();
        }

        private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.FindReplace.ShowReplace();
        }
        private void btnSaveDocumant_Click(object sender, EventArgs e)
        {
            Save();
        }

        internal void Setup(string source, string path, string name)
        {
            scintilla.Text = Source = source;
            _Path = path;
            _Name = name;
            scintilla.UndoRedo.EmptyUndoBuffer();
            btnSaveDocumant.Text = ""; NeedSave = false;


        }

        internal void GoTo(int line, int col, string description)
        {
            line -= 1;
            scintilla.Caret.LineNumber = line;
            scintilla.GoTo.Line(line);
        }

        internal string SaveTemp()
        {
            if (String.IsNullOrEmpty(tempName))
            {
                tempName = Path.GetTempPath();
                tempName += _Path.Replace(Global.Project.Location, "");
            }
            string dir = Path.GetDirectoryName(tempName);
            Directory.CreateDirectory(dir);
            using (StreamWriter versionFile = new StreamWriter(tempName))
            {
                versionFile.Write(scintilla.Text);
                versionFile.Close();
            }

            return tempName;
        }

        internal void Save()
        {
            using (StreamWriter versionFile = new StreamWriter(_Path))
            {
                versionFile.Write(scintilla.Text);
                versionFile.Close();
            }
            NeedSave = false;
            btnSaveDocumant.Text = "";
            ((TabPage)this.Parent).Text = _Name + "";
        }

        internal void AddErrorWarning(int line, int col, string type)
        {
            ScintillaNet.Marker marker;
            switch (type)
            {
                case "warning":
                    marker = scintilla.Markers[0];
                    marker.Symbol = ScintillaNet.MarkerSymbol.ShortArrow;
                    marker.BackColor = Color.Yellow;
                    scintilla.NativeInterface.MarkerAdd(line - 1, marker.Number);
                    break;
                case "error":
                    marker = scintilla.Markers[0];
                    marker.Symbol = ScintillaNet.MarkerSymbol.ShortArrow;
                    marker.BackColor = Color.Red;
                    scintilla.NativeInterface.MarkerAdd(line - 1, marker.Number);
                    break;
            }
        }

        internal void ClearErrorWarnings()
        {
            scintilla.Markers.DeleteAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.UndoRedo.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.UndoRedo.Redo(); 
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.Clipboard.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.Clipboard.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.Clipboard.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scintilla.Selection.SelectAll();
        }
    }
}
