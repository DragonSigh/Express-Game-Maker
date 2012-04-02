#region File Description
//-----------------------------------------------------------------------------
// SpinningTriangleControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace EGMGame.Controls
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, which allows it to
    /// render using a GraphicsDevice. This control shows how to draw animating
    /// 3D graphics inside a WinForms application. It hooks the Application.Idle
    /// event, using this to invalidate the control, which will cause the animation
    /// to constantly redraw.
    /// </summary>
    class RenderControl : GraphicsDeviceControl 
    {
        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {

        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            Global.ClearDevice(GraphicsDevice, Microsoft.Xna.Framework.Color.WhiteSmoke);
        }
    }
}

///// </summary>
//public partial class MainForm : Form
//{
//    ContentBuilder contentBuilder;
//    ContentManager contentManager;


//    /// <summary>
//    /// Constructs the main form.
//    /// </summary>
//    public MainForm()
//    {
//        InitializeComponent();

//        contentBuilder = new ContentBuilder();

//        contentManager = new ContentManager(modelViewerControl.Services,
//                                            contentBuilder.OutputDirectory);

//        /// Automatically bring up the "Load Model" dialog when we are first shown.
//        this.Shown += OpenMenuClicked;
//    }


//    /// <summary>
//    /// Event handler for the Exit menu option.
//    /// </summary>
//    void ExitMenuClicked(object sender, EventArgs e)
//    {
//        Close();
//    }


//    /// <summary>
//    /// Event handler for the Open menu option.
//    /// </summary>
//    void OpenMenuClicked(object sender, EventArgs e)
//    {
//        OpenFileDialog fileDialog = new OpenFileDialog();

//        // Default to the directory which contains our content files.
//        string assemblyLocation = Assembly.GetExecutingAssembly().Location;
//        string relativePath = Path.Combine(assemblyLocation, "../../../../Content");
//        string contentPath = Path.GetFullPath(relativePath);

//        fileDialog.InitialDirectory = contentPath;

//        fileDialog.Title = "Load Model";

//        fileDialog.Filter = "Model Files (*.fbx;*.x)|*.fbx;*.x|" +
//                            "FBX Files (*.fbx)|*.fbx|" +
//                            "X Files (*.x)|*.x|" +
//                            "All Files (*.*)|*.*";

//        if (fileDialog.ShowDialog() == DialogResult.OK)
//        {
//            LoadModel(fileDialog.FileName);
//        }
//    }


//    /// <summary>
//    /// Loads a new 3D model file into the ModelViewerControl.
//    /// </summary>
//    void LoadModel(string fileName)
//    {
//        Cursor = Cursors.WaitCursor;

//        // Unload any existing model.
//        modelViewerControl.Model = null;
//        contentManager.Unload();

//        // Tell the ContentBuilder what to build.
//        contentBuilder.Clear();
//        contentBuilder.Add(fileName, "Model", null, "ModelProcessor");

//        // Build this new model data.
//        string buildError = contentBuilder.Build();

//        if (string.IsNullOrEmpty(buildError))
//        {
//            // If the build succeeded, use the ContentManager to
//            // load the temporary .xnb file that we just created.
//            modelViewerControl.Model = contentManager.Load<Model>("Model");
//        }
//        else
//        {
//            // If the build failed, display an error message.
//            MessageBox.Show(buildError, "Error");
//        }

//        Cursor = Cursors.Arrow;
//    }