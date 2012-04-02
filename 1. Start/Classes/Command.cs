/* -----------------------------
 * CMD - Commands
 * -----------------------------
 * Purpose:             This class holds static commands that could be used by any other class. Access with class name CMD.
 * Most Used By:        N/A
 * Associated Files:    N/A
 * Modify:              If you want to add a shared command that could be useful through out the editor.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using EGMGame.Library;
using EGMGame.Docking.Database;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace EGMGame
{
    internal class CMD
    {
        internal static string TextCode(string lang)
        {
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                if (ci.EnglishName == lang)
                    return @"\Texts." + ci.TwoLetterISOLanguageName;
            }
            return @"\Texts.en";
        }

        internal static void CloseAllButThis(DockContent _this)
        {
            foreach (DockContent dock in MainForm.Instance.dockPanel.Documents)
            {
                if (dock.DockState == DockState.Document && dock != _this)
                {
                    dock.Hide();
                }
            }
        }

        internal static void RemoveDataEditor(Data data)
        {
            foreach (DataEditor editor in MainForm.dataEditors)
            {
                if (editor.ParentData == data)
                {
                    editor.Close();
                    break;
                }
            }
            MainForm.Instance.FillDatabases();
        }

        public static bool CheckIfDataEditorShown(Data data)
        {
            try
            {
                foreach (DataEditor editor in MainForm.dataEditors)
                {
                    if (editor.ParentData == data)
                    {
                        editor.Show();
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x028");
            }
            return false;
        }

        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
    }
}
