﻿#region File Description
//-----------------------------------------------------------------------------
// ContentBuilder.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using EGMGame.Dialogs;
#endregion

namespace EGMGame.Controls
{
    /// <summary>
    /// This class wraps the MSBuild functionality needed to build XNA Framework
    /// content dynamically at runtime. It creates a temporary MSBuild project
    /// in memory, and adds whatever content files you choose to this project.
    /// It then builds the project, which will create compiled .xnb content files
    /// in a temporary directory. After the build finishes, you can use a regular
    /// ContentManager to load these temporary .xnb files in the usual way.
    /// </summary>
    public class ContentBuilder : IDisposable
    {
        #region Fields


        // What importers or processors should we load?
        const string xnaVersion = ", Version=4.0.0.0, PublicKeyToken=842cf8be1de50553";

        static string[] pipelineAssemblies =
        {
            "Microsoft.Xna.Framework.Content.Pipeline.AudioImporters" + xnaVersion,
            "Microsoft.Xna.Framework.Content.Pipeline.FBXImporter" + xnaVersion,
            "Microsoft.Xna.Framework.Content.Pipeline.XImporter" + xnaVersion,
            "Microsoft.Xna.Framework.Content.Pipeline.TextureImporter" + xnaVersion,
            "Microsoft.Xna.Framework.Content.Pipeline.EffectImporter" + xnaVersion,
            "Microsoft.Xna.Framework.Content.Pipeline.VideoImporters" + xnaVersion,
            "Microsoft.Xna.Framework.Content.Pipeline.XmlImporter" + xnaVersion

            
            // If you want to use custom importers or processors from
            // a Content Pipeline Extension Library, add them here.
            //
            // If your extension DLL is installed in the GAC, you should refer to it by assembly
            // name, eg. "MyPipelineExtension, Version=1.0.0.0, PublicKeyToken=1234567812345678".
            //
            // If the extension DLL is not in the GAC, you should refer to it by
            // file path, eg. "c:/MyProject/bin/MyPipelineExtension.dll".
        };

        // MSBuild objects used to dynamically build content.
        static Project buildProject;
        static ProjectRootElement projectRootElement;
        static BuildParameters buildParameters;
        static List<ProjectItem> projectItems = new List<ProjectItem>();
        static ErrorLogger errorLogger;


        // Temporary directories used by the content build.
        public string buildDirectory = "";
        string processDirectory;
        string baseDirectory;


        // Have we been disposed?
        bool isDisposed;


        public delegate void ProgressIsChanged(object sender, int progress, int maxProgress, string filename);
        public event ProgressIsChanged ProgressChanged;
        public delegate void ImportCompleted(string error);
        public event ImportCompleted ImportComplete;

        List<string> items = new List<string>();
        public static int MaxProgress = 0;
        public static int Progress = 0;
        #endregion

        #region Properties


        /// <summary>
        /// Gets the output directory, which will contain the generated .xnb files.
        /// </summary>
        public string OutputDirectory
        {
            get { return Path.Combine(buildDirectory, "Content"); }
        }


        #endregion

        #region Initialization


        /// <summary>
        /// Creates a new content builder.
        /// </summary>
        public ContentBuilder()
        {
            if (Global.Project != null)
            {
                CreateTempDirectory();
                CreateBuildProject();
            }
        }


        /// <summary>
        /// Finalizes the content builder.
        /// </summary>
        ~ContentBuilder()
        {
            Dispose(false);
        }


        /// <summary>
        /// Disposes the content builder when it is no longer required.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Implements the standard .NET IDisposable pattern.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                isDisposed = true;

                DeleteTempDirectory();
            }
        }


        #endregion

        #region MSBuild


        /// <summary>
        /// Creates a temporary MSBuild content project in memory.
        /// </summary>
        public void CreateBuildProject()
        {
            string projectPath = Path.Combine(buildDirectory, "content.contentproj");
            string outputPath = Path.Combine(buildDirectory, "");

            if (buildProject == null || buildProject.DirectoryPath != buildDirectory)
            {
                if (buildProject != null)
                    buildProject.ProjectCollection.UnloadAllProjects();
                // Create the build project.
                projectRootElement = ProjectRootElement.Create(projectPath);

                // Include the standard targets file that defines how to build XNA Framework content.
                projectRootElement.AddImport("$(MSBuildExtensionsPath)\\Microsoft\\XNA Game Studio\\" +
                                             "v4.0\\Microsoft.Xna.GameStudio.ContentPipeline.targets");

                buildProject = new Project(projectRootElement);

                buildProject.SetProperty("XnaPlatform", "Windows");
                buildProject.SetProperty("XnaProfile", "Reach");
                buildProject.SetProperty("XnaFrameworkVersion", "v4.0");
                buildProject.SetProperty("Configuration", "Release");
                buildProject.SetProperty("OutputPath", outputPath);

                // Register any custom importers or processors.
                foreach (string pipelineAssembly in pipelineAssemblies)
                {
                    buildProject.AddItem("Reference", pipelineAssembly);
                }

                // Hook up our custom error logger.
                errorLogger = new ErrorLogger();

                buildParameters = new BuildParameters(ProjectCollection.GlobalProjectCollection);
                buildParameters.Loggers = new ILogger[] { errorLogger };
                buildParameters.BuildThreadPriority = System.Threading.ThreadPriority.Highest;
            }
        }


        /// <summary>
        /// Adds a new content file to the MSBuild project. The importer and
        /// processor are optional: if you leave the importer null, it will
        /// be autodetected based on the file extension, and if you leave the
        /// processor null, data will be passed through without any processing.
        /// </summary>
        public void Add(string filename, string name, string importer, string processor)
        {
            ProjectItem item = buildProject.AddItem("Compile", filename)[0];

            item.SetMetadataValue("Link", Path.GetFileName(filename));
            item.SetMetadataValue("Name", name);

            if (!string.IsNullOrEmpty(importer))
                item.SetMetadataValue("Importer", importer);

            if (!string.IsNullOrEmpty(processor))
                item.SetMetadataValue("Processor", processor);

            projectItems.Add(item);

            items.Add(name);
        }


        /// <summary>
        /// Removes all content files from the MSBuild project.
        /// </summary>
        public void Clear()
        {
            //if (projectItems.Count > 0)
            //    buildProject.RemoveItems(projectItems);

            projectItems.Clear();
        }

        bool IsCompleted = false;
        /// <summary>
        /// Builds all the content files which have been added to the project,
        /// dynamically creating .xnb files in the OutputDirectory.
        /// Returns an error message if the build fails.
        /// </summary>
        public string Build()
        {
            // Clear any previous errors.
            errorLogger.Errors.Clear();

            MaxProgress = items.Count;
            Progress = 0;
            
#if DEBUG
            Stopwatch st = new Stopwatch();
            st.Start();
#endif

            IsCompleted = false;
            ThreadStart t = new ThreadStart(UpdateProgress);
            Thread thread = new Thread(t);
            thread.Priority = ThreadPriority.Lowest;
            thread.Start();

            if (ProgressChanged != null)
                ProgressChanged(this, Progress, MaxProgress, "Converting '" + items[0] + "'");

            buildProject.Build(errorLogger);

            thread.Abort();

            IsCompleted = true;

            if (errorLogger.Errors.Count > 0)
            {
                if (ImportComplete != null)
                    ImportComplete(string.Join("\n", errorLogger.Errors.ToArray()));
                return string.Join("\n", errorLogger.Errors.ToArray());
            }

#if DEBUG
            st.Stop();

            //MessageBox.Show(st.Elapsed.ToString());
#endif
            //// Create and submit a new asynchronous build request.
            //BuildManager.DefaultBuildManager.BeginBuild(buildParameters);


            //BuildRequestData request = new BuildRequestData(buildProject.CreateProjectInstance(), new string[0]);
            //BuildSubmission submission = BuildManager.DefaultBuildManager.PendBuildRequest(request);

            //submission.ExecuteAsync(null, null);

            //while (!submission.IsCompleted)
            //{
            //    int c = items.Count;
            //    for (int i = 0; i < c; i++)
            //    {
            //        if (File.Exists(Path.Combine(OutputDirectory, items[i] + ".xnb")))
            //        {
            //            Progress++;
            //            if (ProgressChanged != null)
            //                ProgressChanged(this, Progress, MaxProgress, (i + 1 < c ? "Converting '" + items[i + 1] + "'" : "Finishing..."));
            //            items.RemoveAt(i);
            //            c--;
            //            i--;
            //        }
            //    }
            //}
            //// Wait for the build to finish.
            ////submission.WaitHandle.WaitOne();

            //BuildManager.DefaultBuildManager.EndBuild();

            //// If the build failed, return an error string.
            //if (submission.BuildResult.OverallResult == BuildResultCode.Failure)
            //{
            //    if (ImportComplete != null)
            //        ImportComplete(string.Join("\n", errorLogger.Errors.ToArray()));
            //    return string.Join("\n", errorLogger.Errors.ToArray());
            //}


            if (Directory.Exists(Path.Combine(Global.Project.Location, "obj")))
            {
                Directory.Delete(Path.Combine(Global.Project.Location, "obj"), true);
            }
            if (File.Exists(Path.Combine(Global.Project.Location, "cachefile--targetpath.txt")))
            {
                File.Delete(Path.Combine(Global.Project.Location, "cachefile--targetpath.txt"));
            }
            if (ImportComplete != null)
                ImportComplete(null);
            return null;
        }

        void UpdateProgress()
        {
            while (!IsCompleted)
            {
                int c = items.Count;
                for (int i = 0; i < c; i++)
                {
                    if (File.Exists(Path.Combine(OutputDirectory, items[i] + ".xnb")))
                    {
                        Progress++;
                        if (ProgressChanged != null)
                            ProgressChanged(this, Progress, MaxProgress, (i + 1 < c ? "Converting '" + items[i + 1] + "'" : "Finishing..."));
                        items.RemoveAt(i);
                        c--;
                        i--;
                    }
                }
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Temp Directories


        /// <summary>
        /// Creates a temporary directory in which to build content.
        /// </summary>
        public void CreateTempDirectory()
        {
            // Start with a standard base name:
            //
            //  %temp%\WinFormsContentLoading.ContentBuilder

            baseDirectory = Path.Combine(Global.Project.Location, "");

            // Include our process ID, in case there is more than
            // one copy of the program running at the same time:
            //
            //  %temp%\WinFormsContentLoading.ContentBuilder\<ProcessId>

            int processId = Process.GetCurrentProcess().Id;

            processDirectory = Path.Combine(baseDirectory, processId.ToString());

            // Include a salt value, in case the program
            // creates more than one ContentBuilder instance:
            //
            //  %temp%\WinFormsContentLoading.ContentBuilder\<ProcessId>\<Salt>

            //directorySalt++;

            buildDirectory = baseDirectory;

            // Create our temporary directory.
            if (!Directory.Exists(buildDirectory))
                Directory.CreateDirectory(buildDirectory);

            //PurgeStaleTempDirectories();
        }


        /// <summary>
        /// Deletes our temporary directory when we are finished with it.
        /// </summary>
        void DeleteTempDirectory()
        {
            //Directory.Delete(buildDirectory, true);

            //// If there are no other instances of ContentBuilder still using their
            //// own temp directories, we can delete the process directory as well.
            //if (Directory.GetDirectories(processDirectory).Length == 0)
            //{
            //    Directory.Delete(processDirectory);

            //    // If there are no other copies of the program still using their
            //    // own temp directories, we can delete the base directory as well.
            //    if (Directory.GetDirectories(baseDirectory).Length == 0)
            //    {
            //        Directory.Delete(baseDirectory);
            //    }
            //}
        }


        /// <summary>
        /// Ideally, we want to delete our temp directory when we are finished using
        /// it. The DeleteTempDirectory method (called by whichever happens first out
        /// of Dispose or our finalizer) does exactly that. Trouble is, sometimes
        /// these cleanup methods may never execute. For instance if the program
        /// crashes, or is halted using the debugger, we never get a chance to do
        /// our deleting. The next time we start up, this method checks for any temp
        /// directories that were left over by previous runs which failed to shut
        /// down cleanly. This makes sure these orphaned directories will not just
        /// be left lying around forever.
        /// </summary>
        void PurgeStaleTempDirectories()
        {
            // Check all subdirectories of our base location.
            foreach (string directory in Directory.GetDirectories(baseDirectory))
            {
                // The subdirectory name is the ID of the process which created it.
                int processId;

                if (int.TryParse(Path.GetFileName(directory), out processId))
                {
                    try
                    {
                        // Is the creator process still running?
                        Process.GetProcessById(processId);
                    }
                    catch (ArgumentException)
                    {
                        // If the process is gone, we can delete its temp directory.
                        Directory.Delete(directory, true);
                    }
                }
            }
        }


        #endregion

        internal string BuildSlow()
        {
            // Clear any previous errors.
            errorLogger.Errors.Clear();

            // Create and submit a new asynchronous build request.
            buildParameters.BuildThreadPriority = System.Threading.ThreadPriority.BelowNormal;
            BuildManager.DefaultBuildManager.BeginBuild(buildParameters);

            BuildRequestData request = new BuildRequestData(buildProject.CreateProjectInstance(), new string[0]);
            BuildSubmission submission = BuildManager.DefaultBuildManager.PendBuildRequest(request);

            
            submission.ExecuteAsync(null, null);

            Progress++;
            if (ProgressChanged != null)
                ProgressChanged(this, Progress, MaxProgress, "Converting '" + items[0] + "'");

            while (!submission.IsCompleted)
            {
                int c = items.Count;
                for (int i = 0; i < c; i++)
                {
                    if (File.Exists(Path.Combine(OutputDirectory, items[i] + ".xnb")))
                    {
                        Progress++;
                        if (ProgressChanged != null)
                            ProgressChanged(this, Progress, MaxProgress, (i + 1 < items.Count ? "Converting '" + items[i + 1] + "'" : "Finishing..."));
                        items.RemoveAt(i);
                        c--;
                        i--;
                    }
                }
            }
            // Wait for the build to finish.
            //submission.WaitHandle.WaitOne();

            BuildManager.DefaultBuildManager.EndBuild();

            

            // If the build failed, return an error string.
            if (submission.BuildResult.OverallResult == BuildResultCode.Failure)
            {
                if (ImportComplete != null)
                    ImportComplete(string.Join("\n", errorLogger.Errors.ToArray()));
                return string.Join("\n", errorLogger.Errors.ToArray());
            }

            if (Directory.Exists(Path.Combine(Global.Project.Location, "obj")))
            {
                Directory.Delete(Path.Combine(Global.Project.Location, "obj"), true);
            }
            if (File.Exists(Path.Combine(Global.Project.Location, "cachefile--targetpath.txt")))
            {
                File.Delete(Path.Combine(Global.Project.Location, "cachefile--targetpath.txt"));
            }
            if (ImportComplete != null)
                ImportComplete(null);
            return null;
        }
    }
}
