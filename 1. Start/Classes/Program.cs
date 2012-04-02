/* -----------------------------
 * Program - Program Main
 * -----------------------------
 * Purpose:             This is the access point.
 * Most Used By:        None
 * Associated Files:    None
 * Modify:              When you want to perform a function that needs to be done before the program starts.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Management;
using IWshRuntimeLibrary;

namespace EGMGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            MainForm main = new MainForm();

            // Load Project
            if (args.Length > 0)
                MainForm.LoadPath = args[0];


            if (MainForm.IsHigherThenXP)
            {
                //Add the event handler
                ApplicationRecovery.OnApplicationCrash += new ApplicationRecovery.ApplicationCrashHandler(main.ApplicationRecovery_OnApplicationCrash);

                //Let Windows Vista know that your application wants notification when it crashes.
                ApplicationRecovery.RegisterForRestart();
            }

            if (System.IO.File.Exists(System.IO.Path.Combine(Application.StartupPath, "Config.xml")))
                MainForm.Configuration = EGMGame.Library.Marshal.LoadData<Config>(System.IO.Path.Combine(Application.StartupPath, "Config.xml"));
            else
                Config.Save();

            if (MainForm.IsVista && !IsPlatformUpdateInstalled && !MainForm.Configuration.PlatformerUpdateWarned)
            {
                MainForm.Configuration.PlatformerUpdateWarned = true;
                MessageBox.Show("Your computer does not have the Platform Update for Windows Vista (KB971644). \nThis update enables EGM to work at its optimum level, as it is required for the ribbon menu to work. \nYou may continue to use the application without this update and the ribbon will be disabled, but it is recommended you download this update using the Windows Update service.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(main);

            main.MainForm_FormClosed(null, null);
        }

        static string hotfixID = "960362";
        public static bool IsPlatformUpdateInstalled
        {
            get
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "select * from Win32_QuickFixEngineering where HotFixID = 'Q" + hotfixID + "' OR HotFixID = 'KB" + hotfixID + "'");

                foreach (ManagementObject share in searcher.Get())
                {
                    if (share.Properties.Count <= 0)
                        return false;
                    else
                        return true;
                }
                return false;
            }
        }
    }
}
