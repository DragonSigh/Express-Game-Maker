using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGMGame.Docking.Homepage;
using EGMGame.Docking.Explorers;
using EGMGame.Library;
using EGMGame.Dialogs;
using EGMGame.Docking.Editors;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Collections;
using GenericUndoRedo;
using EGMGame.Docking.Database;
using EGMGame.Controls.EventControls.EventDialogs;
using EGMGame.Controls;
using System.Xml;
using Microsoft.Xna.Framework.Audio;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Diagnostics;
using EGMGame.Docking.Settings;
using Microsoft.Xna.Framework.Content;
using System.Drawing.Drawing2D;
using EGMGame.Docking.Editors.Database;
using RibbonLib;
using RibbonLib.Controls;
using RibbonLib.Interop;
using RibbonLib.Controls.Events;
using EGMGame;
using System.Globalization;
using EGMGame.DiffEngine;
using ICSharpCode.SharpZipLib.Zip;
using System.Threading;

namespace EGMGame
{
    public partial class MainForm : Form, IRibbonForm
    {
        #region Ribbon
        static int getOSArchitecture()
        {
            string pa = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return ((String.IsNullOrEmpty(pa) || String.Compare(pa, 0, "x86", 0, 3, true) == 0) ? 32 : 64);
        }

        public static bool IsHigherThenXP
        {
            get
            {
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                //Get Operating system information.
                OperatingSystem os = Environment.OSVersion;
                //Get version information about the os.
                Version vs = os.Version;

                //Variable to hold our return value
                string operatingSystem = "";

                if (os.Platform == PlatformID.Win32Windows)
                {
                    //This is a pre-NT version of Windows
                    switch (vs.Minor)
                    {
                        case 0:
                            operatingSystem = "95";
                            break;
                        case 10:
                            if (vs.Revision.ToString() == "2222A")
                                operatingSystem = "98SE";
                            else
                                operatingSystem = "98";
                            break;
                        case 90:
                            operatingSystem = "Me";
                            break;
                        default:
                            break;
                    }
                }
                else if (os.Platform == PlatformID.Win32NT)
                {
                    switch (vs.Major)
                    {
                        case 3:
                            operatingSystem = "NT 3.51";
                            break;
                        case 4:
                            operatingSystem = "NT 4.0";
                            break;
                        case 5:
                            if (vs.Minor == 0)
                                operatingSystem = "2000";
                            else
                                operatingSystem = "XP";
                            break;
                        case 6:
                            if (vs.Minor == 0)
                                operatingSystem = "Vista";
                            else
                                operatingSystem = "7";
                            break;
                        default:
                            break;
                    }
                }
                if (operatingSystem == "7" || (operatingSystem == "Vista" && Program.IsPlatformUpdateInstalled))
                    return true;
                else
                    return false;
                //Make sure we actually got something in our OS check
                //We don't want to just return " Service Pack 2" or " 32-bit"
                //That information is useless without the OS version.
                //if (operatingSystem != "")
                //{
                //    //Got something.  Let's prepend "Windows" and get more info.
                //    operatingSystem = "Windows " + operatingSystem;
                //    //See if there's a service pack installed.
                //    if (os.ServicePack != "")
                //    {
                //        //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                //        operatingSystem += " " + os.ServicePack;
                //    }
                //    //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //    operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
                //}
                ////Return the information we've gathered.
                //return operatingSystem;
            }
        }

        public static bool IsVista
        {
            get
            {
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                //Get Operating system information.
                OperatingSystem os = Environment.OSVersion;
                //Get version information about the os.
                Version vs = os.Version;

                //Variable to hold our return value
                string operatingSystem = "";

                if (os.Platform == PlatformID.Win32Windows)
                {
                    //This is a pre-NT version of Windows
                    switch (vs.Minor)
                    {
                        case 0:
                            operatingSystem = "95";
                            break;
                        case 10:
                            if (vs.Revision.ToString() == "2222A")
                                operatingSystem = "98SE";
                            else
                                operatingSystem = "98";
                            break;
                        case 90:
                            operatingSystem = "Me";
                            break;
                        default:
                            break;
                    }
                }
                else if (os.Platform == PlatformID.Win32NT)
                {
                    switch (vs.Major)
                    {
                        case 3:
                            operatingSystem = "NT 3.51";
                            break;
                        case 4:
                            operatingSystem = "NT 4.0";
                            break;
                        case 5:
                            if (vs.Minor == 0)
                                operatingSystem = "2000";
                            else
                                operatingSystem = "XP";
                            break;
                        case 6:
                            if (vs.Minor == 0)
                                operatingSystem = "Vista";
                            else
                                operatingSystem = "7";
                            break;
                        default:
                            break;
                    }
                }
                if (operatingSystem == "Vista")
                    return true;
                else
                    return false;
                //Make sure we actually got something in our OS check
                //We don't want to just return " Service Pack 2" or " 32-bit"
                //That information is useless without the OS version.
                //if (operatingSystem != "")
                //{
                //    //Got something.  Let's prepend "Windows" and get more info.
                //    operatingSystem = "Windows " + operatingSystem;
                //    //See if there's a service pack installed.
                //    if (os.ServicePack != "")
                //    {
                //        //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                //        operatingSystem += " " + os.ServicePack;
                //    }
                //    //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //    operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
                //}
                ////Return the information we've gathered.
                //return operatingSystem;
            }
        }
        public enum RibbonMarkupCommands : uint
        {
            cmdButtonNew = 1001,
            cmdButtonOpen = 1002,
            cmdButtonSave = 1003,
            cmdButtonExport = 1080,
            cmdButtonUndo = 1030,
            cmdButtonRedo = 1031,
            cmdButtonCut = 1032,
            cmdButtonCopy = 1033,
            cmdButtonPaste = 1034,
            cmdTabMain = 1101,
            cmdMapContext = 1401,
            cmdGroupFileActions = 1201,
            cmdQAT = 1301,
            cmdCustomizeQAT = 1302,
            cmdButtonPlay = 1004,
            cmdButtonAnimation = 1005,
            cmdButtonAudio = 1006,
            cmdButtonFont = 1007,
            cmdButtonMap = 1008,
            cmdButtonParticle = 1009,
            cmdButtonSkin = 1010,
            cmdButtonTileset = 1011,
            cmdButtonCombo = 1012,
            cmdButtonGlobalEv = 1013,
            cmdButtonList = 1014,
            cmdButtonMenu = 1015,
            cmdButtonPlayer = 1016,
            cmdButtonString = 1017,
            cmdButtonSwitches = 1018,
            cmdButtonText = 1019,
            cmdButtonVariable = 1020,
            cmdButtonEnemies = 1021,
            cmdButtonEquipment = 1022,
            cmdButtonHero = 1023,
            cmdButtonItem = 1024,
            cmdButtonProjectile = 1025,
            cmdButtonSkill = 1026,
            cmdButtonState = 1027,
            cmdButtonTempalateEvent = 1028,
            cmdProjectSettings = 1029,
            cmdEGMSettings = 1035,
            cmdExit = 1036,
            cmdHomePage = 1037,
            cmdMaterialExplporer = 1038,
            cmdTilesExplorer = 1040,
            cmdMapsExplorer = 1041,
            cmdLayersExplorer = 1042,
            cmdMapEventsExplorer = 1043,
            cmdEventsExplorer = 1044,
            cmdMenuPartsExplorer = 1045,
            cmdMenuPropertyExplorer = 1046,
            cmdHistoryExplorer = 1047,
            cmdEraserTool = 1048,
            cmdMapDrawingPencil = 1049,
            cmdMapDrawingRectangle = 1050,
            cmdMapDrawingFill = 1051,
            cmdMapDrawingEraseRect = 1075,
            cmdMapDrawingEraseFill = 1076,
            cmdMapSelectionPointer = 1052,
            cmdMapSelectionRectangle = 1053,
            cmdMapSelectionSelectAllLayers = 1054,
            cmdMapLayerUp = 1055,
            cmdMapLayerDown = 1056,
            cmdMapSize = 1058,
            cmdMapGridSize = 1059,
            cmdMapGravity = 1060,
            cmdMapEffects = 1061,
            cmdMapDimLayers = 1062,
            cmdMapShowGrid = 1063,
            cmdMapSnapToGrid = 1064,
            cmdMapShowCollision = 10642,
            cmdMapOtherAddMap = 1065,
            cmdMapOtherEvents = 1066,
            cmdMapOtherLayers = 1077,
            cmdItemSettings = 1067,
            cmdDatabase = 1068,
            cmdTutorials = 1069,
            cmdAbout = 1070,
            cmdSource = 1071,
            cmdReset = 1072,
            cmdError = 1073,
            cmdDatabases = 1074,
            cmdFeedback = 1081
        }

        private Ribbon _ribbon;
        private RibbonButton _buttonNew;
        private RibbonButton _buttonOpen;
        private RibbonButton _buttonSave;
        private RibbonButton _buttonExport;
        private Dictionary<string, RibbonButton> _ribbonButton = new Dictionary<string, RibbonButton>();
        public static Dictionary<string, RibbonToggleButton> _ribbonToggleButton = new Dictionary<string, RibbonToggleButton>();
        private RibbonTab _tabMain;
        private RibbonGroup _groupFileActions;
        private RibbonQuickAccessToolbar _ribbonQuickAccessToolbar;

        internal static RibbonTabGroup _tabMapContext;

        private Stream _stream;

        private void InitializeRibbon()
        {
            _ribbon = new Ribbon();
            _buttonNew = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonNew);
            _buttonOpen = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonOpen);
            _buttonSave = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonSave);
            _buttonExport = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonExport);
            _ribbonButton["undo"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonUndo);
            _ribbonButton["redo"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonRedo);
            _ribbonButton["play"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonPlay);
            _ribbonButton["animation"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonAnimation);
            _ribbonButton["audio"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonAudio);
            _ribbonButton["font"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonFont);
            _ribbonButton["map"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonMap);
            _ribbonButton["particle"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonParticle);
            _ribbonButton["skin"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonSkin);
            _ribbonButton["tileset"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonTileset);
            _ribbonButton["combo"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonCombo);
            _ribbonButton["globalEvent"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonGlobalEv);
            _ribbonButton["list"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonList);
            _ribbonButton["menu"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonMenu);
            _ribbonButton["player"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonPlayer);
            _ribbonButton["string"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonString);
            _ribbonButton["switches"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonSwitches);
            _ribbonButton["text"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonText);
            _ribbonButton["variable"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonVariable);
            _ribbonButton["enemies"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonEnemies);
            _ribbonButton["equipment"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonEquipment);
            _ribbonButton["hero"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonHero);
            _ribbonButton["items"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonItem);
            _ribbonButton["projectile"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonProjectile);
            _ribbonButton["skills"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonSkill);
            _ribbonButton["states"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonState);
            _ribbonButton["templateEvents"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdButtonTempalateEvent);
            _ribbonButton["projectsettings"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdProjectSettings);
            _ribbonButton["egmsettings"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdEGMSettings);
            _ribbonButton["exit"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdExit);
            _ribbonButton["homepage"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdHomePage);
            _ribbonButton["materialexplorer"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMaterialExplporer);

            _ribbonButton["mapsexplorer"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapsExplorer);
            _ribbonButton["eventsexplorer"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdEventsExplorer);
            _ribbonButton["menuparts"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMenuPartsExplorer);
            _ribbonButton["menuproperty"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMenuPropertyExplorer);
            _ribbonButton["history"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdHistoryExplorer);
            _ribbonButton["mapevents"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapEventsExplorer);
            _ribbonButton["tilesexplorer"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdTilesExplorer);
            _ribbonButton["layersexplorer"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdLayersExplorer);
            _ribbonButton["itemsettings"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdItemSettings);
            _ribbonButton["database"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdDatabase);
            _ribbonButton["databases"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdDatabases);
            _ribbonButton["tutorials"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdTutorials);
            _ribbonToggleButton["btnDrawEraser"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdEraserTool);
            _ribbonToggleButton["btnDrawPencil"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapDrawingPencil);
            _ribbonToggleButton["btnDrawRectangle"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapDrawingRectangle);
            _ribbonToggleButton["btnDrawFill"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapDrawingFill);
            _ribbonToggleButton["btnSelectionPointer"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapSelectionPointer);
            _ribbonToggleButton["btnSelectionRect"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapSelectionRectangle);
            _ribbonToggleButton["btnSelectionRectAll"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapSelectionSelectAllLayers);
            _ribbonButton["btnLayerUp"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapLayerUp);
            _ribbonButton["btnLayerDown"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapLayerDown);
            _ribbonButton["btnMapSize"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapSize);
            _ribbonButton["btnGridSize"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapGridSize);
            _ribbonButton["btnMapGravity"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapGravity);
            _ribbonButton["btnMapEffects"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapEffects);
            _ribbonToggleButton["btnMapDimLayer"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapDimLayers);
            _ribbonToggleButton["btnMapShowGrid"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapShowGrid);
            _ribbonToggleButton["btnMapSnapToGrid"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapSnapToGrid);
            _ribbonToggleButton["btnMapShowCollision"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapShowCollision);
            _ribbonButton["btnAddMap"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapOtherAddMap);
            _ribbonToggleButton["btnMapEvents"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapOtherEvents);
            _ribbonButton["btnAbout"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdAbout);
            _ribbonButton["btnSource"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdSource);
            _ribbonButton["btnReset"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdReset);
            _ribbonButton["btnError"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdError);
            _ribbonButton["btnFeedback"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdFeedback);
            _ribbonToggleButton["btnDrawEraseRect"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapDrawingEraseRect);
            _ribbonToggleButton["btnDrawEraseFill"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapDrawingEraseFill);
            _ribbonToggleButton["btnMapEnableLayer"] = new RibbonToggleButton(_ribbon, (uint)RibbonMarkupCommands.cmdMapOtherLayers);

            //_ribbonButton[""] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdProjectSettings);

            _tabMain = new RibbonTab(_ribbon, (uint)RibbonMarkupCommands.cmdTabMain);
            _groupFileActions = new RibbonGroup(_ribbon, (uint)RibbonMarkupCommands.cmdGroupFileActions);
            _ribbonQuickAccessToolbar = new RibbonQuickAccessToolbar(_ribbon,
                                                                     (uint)RibbonMarkupCommands.cmdQAT,
                                                                     (uint)RibbonMarkupCommands.cmdCustomizeQAT);

            _buttonNew.OnExecute += new OnExecuteEventHandler(_buttonNew_OnExecute);
            _buttonSave.OnExecute += new OnExecuteEventHandler(_buttonSave_OnExecute);
            _buttonOpen.OnExecute += new OnExecuteEventHandler(_buttonOpen_OnExecute);
            _buttonExport.OnExecute += new OnExecuteEventHandler(_buttonExport_OnExecute);
            _ribbonButton["undo"].OnExecute += new OnExecuteEventHandler(_buttonUndo_OnExecute);
            _ribbonButton["redo"].OnExecute += new OnExecuteEventHandler(_buttonRedo_OnExecute);
            _ribbonButton["play"].OnExecute += new OnExecuteEventHandler(_play_OnExecute);
            _ribbonButton["animation"].OnExecute += new OnExecuteEventHandler(_animation_OnExecute);
            _ribbonButton["audio"].OnExecute += new OnExecuteEventHandler(_audio_OnExecute);
            _ribbonButton["font"].OnExecute += new OnExecuteEventHandler(_font_OnExecute);
            _ribbonButton["map"].OnExecute += new OnExecuteEventHandler(_map_OnExecute);
            _ribbonButton["particle"].OnExecute += new OnExecuteEventHandler(_particle_OnExecute);
            _ribbonButton["skin"].OnExecute += new OnExecuteEventHandler(_skin_OnExecute);
            _ribbonButton["tileset"].OnExecute += new OnExecuteEventHandler(_tileset_OnExecute);
            _ribbonButton["combo"].OnExecute += new OnExecuteEventHandler(_combo_OnExecute);
            _ribbonButton["globalEvent"].OnExecute += new OnExecuteEventHandler(_globalEvent_OnExecute);
            _ribbonButton["list"].OnExecute += new OnExecuteEventHandler(_list_OnExecute);
            _ribbonButton["menu"].OnExecute += new OnExecuteEventHandler(_menu_OnExecute);
            _ribbonButton["player"].OnExecute += new OnExecuteEventHandler(_player_OnExecute);
            _ribbonButton["string"].OnExecute += new OnExecuteEventHandler(_string_OnExecute);
            _ribbonButton["switches"].OnExecute += new OnExecuteEventHandler(_switches_OnExecute);
            _ribbonButton["text"].OnExecute += new OnExecuteEventHandler(_text_OnExecute);
            _ribbonButton["variable"].OnExecute += new OnExecuteEventHandler(_variable_OnExecute);
            _ribbonButton["enemies"].OnExecute += new OnExecuteEventHandler(_enemies_OnExecute);
            _ribbonButton["equipment"].OnExecute += new OnExecuteEventHandler(_equipment_OnExecute);
            _ribbonButton["hero"].OnExecute += new OnExecuteEventHandler(_hero_OnExecute);
            _ribbonButton["projectile"].OnExecute += new OnExecuteEventHandler(_projectile_OnExecute);
            _ribbonButton["skills"].OnExecute += new OnExecuteEventHandler(_skills_OnExecute);
            _ribbonButton["states"].OnExecute += new OnExecuteEventHandler(_states_OnExecute);
            _ribbonButton["templateEvents"].OnExecute += new OnExecuteEventHandler(_templateEvents_OnExecute);
            _ribbonButton["items"].OnExecute += new OnExecuteEventHandler(_items_OnExecute);
            _ribbonButton["projectsettings"].OnExecute += new OnExecuteEventHandler(_projectSettings_OnExecute);
            _ribbonButton["egmsettings"].OnExecute += new OnExecuteEventHandler(_emgsettings_OnExecute);
            _ribbonButton["exit"].OnExecute += new OnExecuteEventHandler(_exit_OnExecute);
            _ribbonButton["homepage"].OnExecute += new OnExecuteEventHandler(_homepage_OnExecute);
            _ribbonButton["materialexplorer"].OnExecute += new OnExecuteEventHandler(_materialexplorer_OnExecute);
            _ribbonButton["mapsexplorer"].OnExecute += new OnExecuteEventHandler(_mapsexplorer_OnExecute);
            _ribbonButton["eventsexplorer"].OnExecute += new OnExecuteEventHandler(_eventsexplorer_OnExecute);
            _ribbonButton["menuparts"].OnExecute += new OnExecuteEventHandler(_menuparts_OnExecute);
            _ribbonButton["menuproperty"].OnExecute += new OnExecuteEventHandler(_menuproperty_OnExecute);
            _ribbonButton["history"].OnExecute += new OnExecuteEventHandler(_history_OnExecute);
            _ribbonButton["mapevents"].OnExecute += new OnExecuteEventHandler(_mapevents_OnExecute);
            _ribbonButton["tilesexplorer"].OnExecute += new OnExecuteEventHandler(_tilesexplorer_OnExecute);
            _ribbonButton["layersexplorer"].OnExecute += new OnExecuteEventHandler(_layersexplorer_OnExecute);
            _ribbonButton["itemsettings"].OnExecute += new OnExecuteEventHandler(_itemsettings_OnExecute);
            _ribbonButton["database"].OnExecute += new OnExecuteEventHandler(_database_OnExecute);
            _ribbonButton["databases"].OnExecute += new OnExecuteEventHandler(_databases_OnExecute);
            _ribbonButton["tutorials"].OnExecute += new OnExecuteEventHandler(_tutorials_OnExecute);
            _ribbonToggleButton["btnDrawEraser"].OnExecute += new OnExecuteEventHandler(_drawEraser_OnExecute);
            _ribbonToggleButton["btnDrawPencil"].OnExecute += new OnExecuteEventHandler(_drawPencil_OnExecute);
            _ribbonToggleButton["btnDrawRectangle"].OnExecute += new OnExecuteEventHandler(_drawRect_OnExecute);
            _ribbonToggleButton["btnDrawFill"].OnExecute += new OnExecuteEventHandler(_drawFill_OnExecute);
            _ribbonToggleButton["btnSelectionPointer"].OnExecute += new OnExecuteEventHandler(_selectPointer_OnExecute);
            _ribbonToggleButton["btnSelectionRect"].OnExecute += new OnExecuteEventHandler(_selectRect_OnExecute);
            _ribbonToggleButton["btnSelectionRectAll"].OnExecute += new OnExecuteEventHandler(_selectRectAll_OnExecute);
            _ribbonButton["btnLayerUp"].OnExecute += new OnExecuteEventHandler(_layerUp_OnExecute);
            _ribbonButton["btnLayerDown"].OnExecute += new OnExecuteEventHandler(_layerDown_OnExecute);
            _ribbonButton["btnMapSize"].OnExecute += new OnExecuteEventHandler(_mapSize_OnExecute);
            _ribbonButton["btnGridSize"].OnExecute += new OnExecuteEventHandler(_gridSize_OnExecute);
            _ribbonButton["btnMapGravity"].OnExecute += new OnExecuteEventHandler(_mapGravity_OnExecute);
            _ribbonButton["btnMapEffects"].OnExecute += new OnExecuteEventHandler(_mapEffects_OnExecute);
            _ribbonToggleButton["btnMapDimLayer"].OnExecute += new OnExecuteEventHandler(_mapDimLayer_OnExecute);
            _ribbonToggleButton["btnMapShowGrid"].OnExecute += new OnExecuteEventHandler(_mapShowGrid_OnExecute);
            _ribbonToggleButton["btnMapSnapToGrid"].OnExecute += new OnExecuteEventHandler(_mapSnaptoGrid_OnExecute);
            _ribbonToggleButton["btnMapShowCollision"].OnExecute += new OnExecuteEventHandler(_mapShowCollision_OnExecute);
            _ribbonButton["btnAddMap"].OnExecute += new OnExecuteEventHandler(_addMap_OnExecute);
            _ribbonToggleButton["btnMapEvents"].OnExecute += new OnExecuteEventHandler(_mapEvents_OnExecute);
            _ribbonButton["btnAbout"].OnExecute += new OnExecuteEventHandler(_about_OnExecute);
            _ribbonButton["btnSource"].OnExecute += new OnExecuteEventHandler(_source_OnExecute);
            _ribbonButton["btnReset"].OnExecute += new OnExecuteEventHandler(_reset_OnExecute);
            _ribbonButton["btnError"].OnExecute += new OnExecuteEventHandler(_error_OnExecute);
            _ribbonButton["btnFeedback"].OnExecute += new OnExecuteEventHandler(_feedback_OnExecute);
            _ribbonToggleButton["btnDrawEraseRect"].OnExecute += new OnExecuteEventHandler(_draweraserect_OnExecute);
            _ribbonToggleButton["btnDrawEraseFill"].OnExecute += new OnExecuteEventHandler(_drawerasefill_OnExecute);
            _ribbonToggleButton["btnMapEnableLayer"].OnExecute += new OnExecuteEventHandler(_enablelayer_OnExecute);

            _tabMapContext = new RibbonTabGroup(_ribbon, (uint)RibbonMarkupCommands.cmdMapContext);

            //itemSettingsToolStripMenuItem_Click(null, null);
            // register to the QAT customize button
            _ribbonQuickAccessToolbar.OnExecute += new OnExecuteEventHandler(_ribbonQuickAccessToolbar_OnExecute);

            //_ribbonButton["exit"].Enabled = false;
            //_ribbonButton["homepage"] = new RibbonButton(_ribbon, (uint)RibbonMarkupCommands.cmdHomePage);
            ///////////////////////////////
            _buttonExport.Enabled = false;
            _ribbonButton["undo"].Enabled = false;
            _ribbonButton["redo"].Enabled = false;
            _ribbonButton["play"].Enabled = false;
            _ribbonButton["animation"].Enabled = false;
            _ribbonButton["audio"].Enabled = false;
            _ribbonButton["font"].Enabled = false;
            _ribbonButton["map"].Enabled = false;
            _ribbonButton["particle"].Enabled = false;
            _ribbonButton["skin"].Enabled = false;
            _ribbonButton["tileset"].Enabled = false;
            _ribbonButton["combo"].Enabled = false;
            _ribbonButton["globalEvent"].Enabled = false;
            _ribbonButton["list"].Enabled = false;
            _ribbonButton["menu"].Enabled = false;
            _ribbonButton["player"].Enabled = false;
            _ribbonButton["string"].Enabled = false;
            _ribbonButton["switches"].Enabled = false;
            _ribbonButton["text"].Enabled = false;
            _ribbonButton["variable"].Enabled = false;
            _ribbonButton["enemies"].Enabled = false;
            _ribbonButton["equipment"].Enabled = false;
            _ribbonButton["hero"].Enabled = false;
            _ribbonButton["items"].Enabled = false;
            _ribbonButton["projectile"].Enabled = false;
            _ribbonButton["skills"].Enabled = false;
            _ribbonButton["states"].Enabled = false;
            _ribbonButton["templateEvents"].Enabled = false;
            _ribbonButton["projectsettings"].Enabled = false;
            _ribbonButton["egmsettings"].Enabled = false;
            _ribbonButton["materialexplorer"].Enabled = false;

            _ribbonButton["mapsexplorer"].Enabled = false;
            _ribbonButton["eventsexplorer"].Enabled = false;
            _ribbonButton["menuparts"].Enabled = false;
            _ribbonButton["menuproperty"].Enabled = false;
            _ribbonButton["history"].Enabled = false;
            _ribbonButton["mapevents"].Enabled = false;
            _ribbonButton["tilesexplorer"].Enabled = false;
            _ribbonButton["layersexplorer"].Enabled = false;
            _ribbonButton["itemsettings"].Enabled = false;
            _ribbonButton["database"].Enabled = false;
            _ribbonButton["databases"].Enabled = false;
            _ribbonButton["tutorials"].Enabled = false;
            _ribbonToggleButton["btnDrawEraser"].Enabled = false;
            _ribbonToggleButton["btnDrawPencil"].Enabled = false;
            _ribbonToggleButton["btnDrawRectangle"].Enabled = false;
            _ribbonToggleButton["btnDrawFill"].Enabled = false;
            _ribbonToggleButton["btnSelectionPointer"].Enabled = false;
            _ribbonToggleButton["btnSelectionRect"].Enabled = false;
            _ribbonToggleButton["btnSelectionRectAll"].Enabled = false;
            _ribbonButton["btnLayerUp"].Enabled = false;
            _ribbonButton["btnLayerDown"].Enabled = false;
            _ribbonButton["btnMapSize"].Enabled = false;
            _ribbonButton["btnGridSize"].Enabled = false;
            _ribbonButton["btnMapGravity"].Enabled = false;
            _ribbonButton["btnMapEffects"].Enabled = false;
            _ribbonToggleButton["btnMapDimLayer"].Enabled = false;
            _ribbonToggleButton["btnMapShowGrid"].Enabled = false;
            _ribbonToggleButton["btnMapSnapToGrid"].Enabled = false;
            _ribbonToggleButton["btnMapShowCollision"].Enabled = false;
            _ribbonButton["btnAddMap"].Enabled = false;
            _ribbonToggleButton["btnMapEvents"].Enabled = false;
            _ribbonButton["btnSource"].Enabled = false;
            _ribbonButton["btnReset"].Enabled = false;
            _ribbonButton["btnError"].Enabled = false;
            _ribbonToggleButton["btnDrawEraseRect"].Enabled = false;
            _ribbonToggleButton["btnDrawEraseFill"].Enabled = false;
            _ribbonToggleButton["btnMapEnableLayer"].Enabled = false;
        }
        #region Ribbon Events
        void _buttonNew_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            if (alphaPanel.Visible)
                return;
            // changing QAT commands list 
            IUICollection itemsSource = _ribbonQuickAccessToolbar.ItemsSource;
            itemsSource.Clear();
            itemsSource.Add(new GalleryCommandPropertySet() { CommandID = (uint)RibbonMarkupCommands.cmdButtonNew });
            itemsSource.Add(new GalleryCommandPropertySet() { CommandID = (uint)RibbonMarkupCommands.cmdButtonOpen });
            itemsSource.Add(new GalleryCommandPropertySet() { CommandID = (uint)RibbonMarkupCommands.cmdButtonSave });

            newToolStripMenuItem_Click(null, EventArgs.Empty);
        }

        void _buttonSave_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            // save ribbon QAT settings 
            //_stream = new MemoryStream();
            //_ribbon.SaveSettingsToStream(_stream);

            if (alphaPanel.Visible)
                return;
            saveToolStripButton_Click(null, EventArgs.Empty);
        }

        void _buttonOpen_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            if (alphaPanel.Visible)
                return;
            openToolStripButton_Click(null, EventArgs.Empty);
            if (_stream == null)
            {
                return;
            }

            // load ribbon QAT settings 
            _stream.Position = 0;
            _ribbon.LoadSettingsFromStream(_stream);
        }

        void _buttonExport_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            if (alphaPanel.Visible)
                return;
            exportAsTemplateToolStripMenuItem_Click(null, EventArgs.Empty);
        }

        void _buttonUndo_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            if (alphaPanel.Visible)
                return;
            undoBtn_Click(null, null);
        }

        void _buttonRedo_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            if (alphaPanel.Visible)
                return;
            redoBtn_Click(null, null);
        }


        void _ribbonQuickAccessToolbar_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            MessageBox.Show("Open customize commands dialog..");
        }


        void _play_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            playBtn_Click(null, EventArgs.Empty);
        }
        void _animation_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            animeBtn_Click(null, EventArgs.Empty);

            //tutorialExplorerToolStripMenuItem_Click(null, null);
        }
        void _audio_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            soundBtn_Click(null, EventArgs.Empty);
        }
        void _font_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            fontBtn_Click(null, EventArgs.Empty);
        }
        void _map_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            if (CurrentProject != null)
                _tabMapContext.ContextAvailable = ContextAvailability.Active;

            sceneBtn_ButtonClick(null, EventArgs.Empty);
        }
        void _particle_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            particleEditorBtn_Click(null, EventArgs.Empty);
        }
        void _skin_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            skinEditorBtn_Click(null, EventArgs.Empty);
        }
        void _tileset_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            tileBtn_Click(null, EventArgs.Empty);
        }
        void _combo_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            comboEditorToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        void _globalEvent_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            globalEventBtn_Click(null, EventArgs.Empty);
        }
        void _list_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            listEditorBtn_Click(null, EventArgs.Empty);
        }
        void _menu_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            menuEditorBtn_Click(null, EventArgs.Empty);
        }
        void _player_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            playerEditorBtn_Click(null, EventArgs.Empty);
        }
        void _string_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            stringEditorBtn_Click(null, EventArgs.Empty);
        }
        void _switches_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            switchesBtn_Click(null, EventArgs.Empty);
        }
        void _text_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            textBtn_Click(null, EventArgs.Empty);
        }
        void _variable_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            variablesBtn_Click(null, EventArgs.Empty);
        }
        void _enemies_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            toolStripButton2_Click(null, EventArgs.Empty);
        }
        void _equipment_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            equipmentsEditorBtn_Click(null, EventArgs.Empty);
        }
        void _hero_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            toolStripButton1_Click(null, EventArgs.Empty);
        }
        void _projectile_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            projectileEditorToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        void _skills_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            skillsEditorBtn_Click(null, EventArgs.Empty);
        }
        void _states_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            statesEditorToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        void _templateEvents_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            eventBtn_Click(null, EventArgs.Empty);
        }
        void _items_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            itemsEditorBtn_Click(null, EventArgs.Empty);
        }
        void _projectSettings_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            settingsBtn_Click(null, null);
        }
        void _emgsettings_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
        }
        void _exit_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            this.BeginInvoke(new MethodInvoker(this.Close));
        }
        void _homepage_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            homepageToolStripMenuItem_Click(null, null);
        }
        void _layersexplorer_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            layersExplorerToolStripMenuItem_Click(null, null);
        }

        void _materialexplorer_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            materialExplorerToolStripMenuItem_Click(null, null);
        }
        void _mapsexplorer_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapsExplorerToolStripMenuItem_Click(null, null);

        }
        void _eventsexplorer_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            templateEventsExplorerToolStripMenuItem_Click(null, null);
        }
        void _menuparts_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            menuPartsExplorerToolStripMenuItem_Click(null, null);

        }
        void _menuproperty_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {

            menuBattlePropertyExplorerToolStripMenuItem_Click(null, null);


        }
        void _history_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            historyExplorerToolStripMenuItem_Click(null, null);
        }
        void _mapevents_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEventsExplorerToolStripMenuItem_Click(null, null);
        }
        void _tilesexplorer_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            tilesExplorerToolStripMenuItem_Click(null, null);
        }

        void _itemsettings_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            itemSettingsToolStripMenuItem_Click(null, null);
        }

        void _database_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            databaseBtn_Click(null, null);
        }

        void _databases_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            if (CurrentProject != null && !alphaPanel.Visible)
                databaseExplorer.Show(dockPanel);
        }

        public void FillDatabases()
        {
            if (CurrentProject != null)
            {
                databaseExplorer.SetupList();
            }
        }

        void database_selected(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {

        }

        void _tutorials_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            tutorialExplorerToolStripMenuItem_Click(null, null);
        }

        void _drawEraser_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.eraserToolStripMenuItem_Click(_ribbonToggleButton["btnDrawEraser"].BooleanValue);
        }

        void _drawPencil_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.pencilToolStripMenuItem_Click(_ribbonToggleButton["btnDrawPencil"].BooleanValue);
        }

        void _drawRect_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.tsbRectangle_Click(_ribbonToggleButton["btnDrawRectangle"].BooleanValue);
        }

        void _drawFill_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.tsbFill_Click(_ribbonToggleButton["btnDrawFill"].BooleanValue);
        }


        void _draweraserect_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.tsbEraseRect_Click(_ribbonToggleButton["btnDrawEraseRect"].BooleanValue);
        }
        void _drawerasefill_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.tsbEraseFill_Click(_ribbonToggleButton["btnDrawEraseFill"].BooleanValue);
        }
        void _enablelayer_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.tsbEnableLayer_Click(_ribbonToggleButton["btnMapEnableLayer"].BooleanValue);
        }

        void _selectPointer_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.cursorToolStripMenuItem_Click(_ribbonToggleButton["btnSelectionPointer"].BooleanValue);
        }

        void _selectRect_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.btnSelect_Click(_ribbonToggleButton["btnSelectionRect"].BooleanValue);
        }

        void _selectRectAll_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.btnLayeredSelect_Click(_ribbonToggleButton["btnSelectionRectAll"].BooleanValue);
        }

        void _layerUp_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.tsbSwapLayerUp_Click(null, null);
        }

        void _layerDown_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.tsbSwapLayerDown_Click(null, null);
        }

        void _LayerBackground_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.btnBG_Click(null, null);
        }
        void _LayerSettings_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.layersettingsToolStripMenuItem_Click(null, null);
        }

        void _mapSize_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.btnMapSize_Click(null, null);
        }

        void _gridSize_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.gridSizeToolStripMenuItem_Click(null, null);
        }

        void _mapGravity_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.gravityToolStripMenuItem_Click(null, null);
        }

        void _mapEffects_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.effectsToolStripMenuItem_Click(null, null);
        }

        void _mapDimLayer_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.btnDimLayer_Click(_ribbonToggleButton["btnMapDimLayer"].BooleanValue);
        }

        void _mapShowGrid_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.showGridToolStripMenuItem_CheckedChanged(_ribbonToggleButton["btnMapShowGrid"].BooleanValue);
        }

        void _mapShowCollision_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.btnShowCollision_CheckedChanged(_ribbonToggleButton["btnMapShowCollision"].BooleanValue);
        }

        void _mapSnaptoGrid_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.snapToGridToolStripMenuItem_CheckedChanged(_ribbonToggleButton["btnMapSnapToGrid"].BooleanValue);
        }

        void _addMap_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            MainForm.Instance.addNewMapToolStripMenuItem_Click(null, null);
        }

        void _mapEvents_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            mapEditor.mapEditor2.eventBtn_CheckedChanged(_ribbonToggleButton["btnMapEvents"].BooleanValue);
        }

        void _about_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            aboutToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        void _source_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            sourceEditorToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        void _reset_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            resetWorkspaceToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        void _error_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            errorExplorerToolStripMenuItem_Click(null, EventArgs.Empty);
        }

        void _feedback_OnExecute(PropertyKeyRef key, PropVariantRef currentValue, IUISimplePropertySet commandExecutionProperties)
        {
            feedbackToolStripMenuItem_Click(null, EventArgs.Empty);
        }
        #endregion
        #region IRibbonForm Members

        public IntPtr WindowHandle
        {
            get
            {
                return this.Handle;
            }
        }

        public void RibbonHeightUpdated(int newHeight)
        {
            this.ribbonPanel.Height = newHeight;
        }

        #endregion
        #endregion

        #region Editor/Explorer Fields
        public HomePage homePage;
        //public LoadDialog loadDialog = new LoadDialog();
        public static MaterialExplorer materialExplorer;
        public static FeedbackPanel feedbackPanel;
        public static SourceEditor sourceEditor;
        public static MapsExplorer mapsExplorer;
        public static DatabaseExplorer databaseExplorer;
        public static MapEventsExplorer mapEventsExplorer;
        public static EventExplorer eventsExplorer;
        public static LayersExplorer layersExplorer;
        public static TilesExplorer tilesExplorer;
        public static MenuPartsExplorer menuPartsExplorer;
        public static ObjectPropertyExplorer menuPropertyExplorer;
        public static SettingsForm settingsForm;
        public static TilesetEditor tilesetEditor;
        public static TextEditor textEditor;
        public static AnimationEditor animationEditor;
        public static AudioEditor audioEditor;
        public ComboEditor comboEdtor;
        public static FontEditor fontEditor;
        public static ItemEditor itemEditor;
        public static EquipmentEditor equipmentEditor;
        public static SkillsEditor skillsEditor;
        public static StatesEditor statesEditor;
        public static HeroEditor heroEditor;
        public static EnemiesEditor enemyEditor;
        public static MenuEditor menuEditor;
        public static MapEditor mapEditor;
        public static EventEditor eventEditor;
        public static PlayerEditor playerEditor;
        public static GlobalEventEditor globalEventEditor;
        public static DatabaseEditor databaseEditor;
        public static VariablesEditor variablesEditor;
        public static StringEditor stringsEditor;
        public static SwitchesEditor switchesEditor;
        public static ListEditor listEditor;
        public static ParticleEditor particleEditor;
        public static SkinEditor skinEditor;
        public static StringEditor stringEditor;
        public static ProjectileEditor projectileEditor;
        public static MaterialPreviewDock materialPreview;
        public static ItemSettingsForm itemSettings;
        public static ErrorExplorer errorExplorer;
        public static TutorialExplorer tutorialExplorer;
        #endregion

        #region History Fields
        public static HistoryExplorer HistoryExplorer;
        public static Dictionary<AnimationEditor, UndoRedoHistory<IHistory>> AnimationHistory = new Dictionary<AnimationEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<AudioEditor, UndoRedoHistory<IHistory>> AudioHistory = new Dictionary<AudioEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<ListEditor, UndoRedoHistory<IHistory>> ListHistory = new Dictionary<ListEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<FontEditor, UndoRedoHistory<IHistory>> FontHistory = new Dictionary<FontEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<TextEditor, UndoRedoHistory<IHistory>> TextHistory = new Dictionary<TextEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<TilesetEditor, UndoRedoHistory<IHistory>> TilesetHistory = new Dictionary<TilesetEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<EventEditor, UndoRedoHistory<IHistory>> EventHistory = new Dictionary<EventEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<GlobalEventEditor, UndoRedoHistory<IHistory>> GlobalEventHistory = new Dictionary<GlobalEventEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<DatabaseEditor, UndoRedoHistory<IHistory>> DatabaseHistory = new Dictionary<DatabaseEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<DataEditor, UndoRedoHistory<IHistory>> DataHistory = new Dictionary<DataEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<VariablesEditor, UndoRedoHistory<IHistory>> VariablesHistory = new Dictionary<VariablesEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<StringEditor, UndoRedoHistory<IHistory>> StringsHistory = new Dictionary<StringEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<SwitchesEditor, UndoRedoHistory<IHistory>> SwitchesHistory = new Dictionary<SwitchesEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<MenuViewer, UndoRedoHistory<IHistory>> MenuEditorHistory = new Dictionary<MenuViewer, UndoRedoHistory<IHistory>>();
        public static Dictionary<MapViewer, UndoRedoHistory<IHistory>> MapEditorHistory = new Dictionary<MapViewer, UndoRedoHistory<IHistory>>();
        public static Dictionary<ParticleEditor, UndoRedoHistory<IHistory>> ParticleHistory = new Dictionary<ParticleEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<SkinEditor, UndoRedoHistory<IHistory>> SkinHistory = new Dictionary<SkinEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<StringEditor, UndoRedoHistory<IHistory>> StringHistory = new Dictionary<StringEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<ComboEditor, UndoRedoHistory<IHistory>> CombosHistory = new Dictionary<ComboEditor, UndoRedoHistory<IHistory>>();

        public static Dictionary<PlayerEditor, UndoRedoHistory<IHistory>> PlayerHistory = new Dictionary<PlayerEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<HeroEditor, UndoRedoHistory<IHistory>> HeroHistory = new Dictionary<HeroEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<EnemiesEditor, UndoRedoHistory<IHistory>> EnemyHistory = new Dictionary<EnemiesEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<EquipmentEditor, UndoRedoHistory<IHistory>> EquipmentHistory = new Dictionary<EquipmentEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<SkillsEditor, UndoRedoHistory<IHistory>> SkillsHistory = new Dictionary<SkillsEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<StatesEditor, UndoRedoHistory<IHistory>> StatesHistory = new Dictionary<StatesEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<ItemEditor, UndoRedoHistory<IHistory>> ItemHistory = new Dictionary<ItemEditor, UndoRedoHistory<IHistory>>();
        public static Dictionary<ProjectileEditor, UndoRedoHistory<IHistory>> ProjectileHistory = new Dictionary<ProjectileEditor, UndoRedoHistory<IHistory>>();

        #endregion

        #region Fields
        public static MainForm Instance;
        public static string TemplateContent = "";
        public static bool IsLoadingProject = false;
        public static BehaviorListDialog CommandDialog;

        public static int LoadProgress = 0;
        public static string LoadPath = "";

        public static EGMGame.Dialogs.ChooseMaterialDialog chooseMaterialDialog;

        public static Project CurrentProject;
        public static bool NeedSave;
        public static MapData SelectedMap
        {
            get { return selMap; }
            set { selMap = value; mapEventsExplorer.SetupList(); }
        }
        static MapData selMap;

        public static List<int> dataEditorIDs = new List<int>();
        public static List<DataEditor> dataEditors = new List<DataEditor>();


        internal static Config Configuration = new Config();

        internal static TileViewer TilesetViewer
        {
            get
            {
                if (tilesExplorer == null) return null;
                return tilesExplorer.tileViewer;
            }
        }

        internal static ToolStripComboBox CBTileset
        {
            get { return tilesExplorer.cbTileset; }
        }

        internal static LinearGradientBrush BackgroundFill(int height)
        {
            try
            {
                return new LinearGradientBrush(
                       new System.Drawing.Point(0, 0),
                       new System.Drawing.Point(0, height),
                       System.Drawing.Color.FromArgb(255, 255, 255),
                       System.Drawing.Color.FromArgb(240, 240, 240)
                       );
            }
            catch
            {
            }
            return new LinearGradientBrush(
                   new System.Drawing.Point(0, 0),
                   new System.Drawing.Point(0, 10),
                   System.Drawing.Color.FromArgb(255, 255, 255),
                   System.Drawing.Color.FromArgb(240, 240, 240)
                   );
        }

        DeserializeDockContent m_deserializeDockContent;
        TestPlayDialog testPlayDialog;
        LoadDialog loadDialog;

        string EnginePath = @"C:\EGMGame";
        #endregion

        public MainForm()
        {
            // Initialize DRM Systems
            try
            {

                if (!Directory.Exists(Path.Combine(Application.StartupPath, "Crash Recovery")))
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Crash Recovery"));
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x001");
            }
            try
            {
                Instance = this;
                InitializeComponent();

                try
                {
                    if (IsHigherThenXP)
                        InitializeRibbon();
                    else
                    {
                        ribbonPanel.Visible = false;
                        menuStrip.Visible = true;
                        editorsToolStrip.Visible = true;
                        toolStrip.Visible = true;
                        toolStrip.SendToBack();
                        menuStrip.SendToBack();
                    }
                }
                catch
                {
                    ribbonPanel.Visible = false;
                    menuStrip.Visible = true;
                    editorsToolStrip.Visible = true;
                    toolStrip.Visible = true;
                    toolStrip.SendToBack();
                    menuStrip.SendToBack();
                }
                // Change renderers for toolstrips
                menuStrip.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
                toolStrip.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();
                editorsToolStrip.Renderer = new EGMGame.Controls.ImpactUI.ImpactToolstripRenderer();

                m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
                alphaPanel.BringToFront();

                bgBackupSave.RunWorkerAsync();

                splashWorker.RunWorkerAsync();

                keyTimer.Start();
#if BETA
                this.Text = "Express Game Maker Beta";
#endif


            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x002");
            }

        }

        #region Form Events
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Recovery Data
            RecoverData();

            // Load Path
            if (!string.IsNullOrEmpty(LoadPath))
            {
                FileInfo file = new FileInfo(MainForm.LoadPath);

                if (file.Exists && file.Extension.ToLower() == Extensions.Project.ToLower())
                    LoadProject(file.FullName, false);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            alphaPanel.Size = this.Size;
        }

        internal void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (audioEditor != null)
                audioEditor.EndThread();
            // Destroy Ribbon
            if (IsHigherThenXP && _ribbon != null)
                _ribbon.DestroyFramework();
            // Upload Error Log
            Error.UploadFile();
        }
        #endregion  

        #region Setup
        /// <summary>
        /// Called when the main form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Set up ribbon.
                if (IsHigherThenXP)
                    _ribbon.InitFramework(this);

                // Set up main docks.

                SetUpInitDocks();

#if !DEBUG
                alphaPanel.BringToFront();
                alphaPanel.Visible = true;
                alphaPanel.Location = new Point(0, 0);
                alphaPanel.Size = this.Size;
                if (!InitializeDRM())
                {
                    alphaPanel.Visible = false;
                    Application.Exit();
                }
                else
                    alphaPanel.Visible = false;
#endif

                Application.AddMessageFilter(m_filter);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x003");
            }
        }
        /// <summary>
        /// Sets up initial dock pages
        /// </summary>
        private void SetUpInitDocks()
        {
            try
            {
                // Homepage
                homePage = new HomePage();
                homePage.Show(dockPanel);

            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x004");
            }
        }
        #endregion

        #region Menu
        #region View
        private void homepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (homePage.IsDisposed)
                    homePage = new HomePage();
                homePage.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x005");
            }
        }
        
        private void materialExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    materialExplorer.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x006");
            }
        }

        private void tutorialExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    tutorialExplorer.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x007");
            }
        }
        
        private void fontBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    fontEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x007");
            }
        }

        private void itemsEditorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    itemEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x008");
            }
        }

        private void skillsEditorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    skillsEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x009");
            }
        }

        private void statesEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    statesEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x010");
            }
        }

        private void equipmentsEditorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    equipmentEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x011");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    heroEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x012");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    enemyEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x013");
            }
        }
        
        private void soundBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    audioEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x014");
            }
        }
        
        private void projectileEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    projectileEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x015");
            }
        }
        
        private void comboEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    comboEdtor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x016");
            }
        }
        
        private void sceneBtn_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    mapEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x018");
            }
        }
        
        private void tileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    tilesetEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x019");
            }
        }
        
        private void animeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    animationEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x020");
            }
        }
        
        private void textBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    textEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x021");
            }
        }

        private void databaseExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null && !alphaPanel.Visible)
                databaseExplorer.Show(dockPanel);
        }

        private void databaseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                    databaseEditor.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x022");
            }
        }
        
        private void databaseBtn_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    databaseBtn.DropDownItems.Clear();
                    // List All Databases
                    foreach (Data d in GameData.Databases.Values)
                    {
                        ToolStripMenuItem ctrl = new ToolStripMenuItem(d.Name);
                        ctrl.Tag = d;
                        ctrl.Click += new EventHandler(databaseItems_Click);
                        databaseBtn.DropDownItems.Add(ctrl);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x023");
            }
        }
        
        private void databaseItems_Click(object sender, EventArgs e)
        {
            try
            {
                Data data = (Data)((ToolStripMenuItem)sender).Tag;
                if (!CMD.CheckIfDataEditorShown(data))
                {   // Display 
                    DataEditor editor = new DataEditor();
                    editor.TabText = data.Name;
                    editor.Text = data.Name;
                    editor.ParentData = data;
                    editor.FormClosed += new FormClosedEventHandler(databaseEditorClosed);
                    editor.Show(dockPanel);
                    dataEditors.Add(editor);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x024");
            }
        }

        internal void databaseShow(Data data)
        {
            try
            {
                if (!CMD.CheckIfDataEditorShown(data))
                {   // Display 
                    DataEditor editor = new DataEditor();
                    editor.TabText = data.Name;
                    editor.Text = data.Name;
                    editor.ParentData = data;
                    editor.FormClosed += new FormClosedEventHandler(databaseEditorClosed);
                    editor.Show(dockPanel);
                    dataEditors.Add(editor);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x025");
            }
        }

        public void databaseItemOpen(Data data, int id)
        {
            try
            {
                if (!CMD.CheckIfDataEditorShown(data))
                {   // Display 
                    DataEditor editor = new DataEditor();
                    editor.TabText = data.Name;
                    editor.Text = data.Name;
                    editor.ParentData = data;
                    editor.FormClosed += new FormClosedEventHandler(databaseEditorClosed);
                    editor.Show(dockPanel);
                    editor.Select(id);
                    dataEditors.Add(editor);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x026");
            }
        }

        public void databaseItemOpen(Data data)
        {
            try
            {
                if (!CMD.CheckIfDataEditorShown(data))
                {   // Display 
                    DataEditor editor = new DataEditor();
                    editor.TabText = data.Name;
                    editor.Text = data.Name;
                    editor.ParentData = data;
                    editor.FormClosed += new FormClosedEventHandler(databaseEditorClosed);
                    editor.Show(dockPanel);
                    dataEditors.Add(editor);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x027");
            }
        }

        private void databaseEditorClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                dataEditors.Remove((DataEditor)sender);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x029");
            }
        }

        private void eventBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    eventEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x030");
            }
        }

        private void playerEditorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    playerEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x031");
            }
        }

        private void globalEventBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    globalEventEditor.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x032");
            }
        }

        private void variablesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                    variablesEditor.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x033");
            }
        }

        private void switchesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                    switchesEditor.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x034");
            }
        }

        private void listEditorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                    listEditor.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x035");
            }
        }

        private void particleEditorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                    particleEditor.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x036");
            }
        }
        
        private void skinEditorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                    skinEditor.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x037");
            }
        }
        
        private void stringEditorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                    stringEditor.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x038");
            }
        }
        
        private void menuEditorBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                    menuEditor.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x039");
            }
        }
        
        private void settingsBtn_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                settingsForm.ShowDialog();
            }
        }
        
        private void tilesExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                tilesExplorer.Show(dockPanel);
            }
        }
        
        private void materialPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                materialPreview.Show(dockPanel);
            }
        }

        private void sourceEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                sourceEditor.Show(dockPanel);
            }
        }

        private void itemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                itemSettings.Show(dockPanel);
            }
        }
        
        private void historyExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                HistoryExplorer.Show(dockPanel);
            }
        }
        
        private void errorExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                errorExplorer.Show(dockPanel);
            }
        }
        
        private void menuPartsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
                menuPartsExplorer.Show(this.dockPanel);
        }

        private void menuBattlePropertyExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
                menuPropertyExplorer.Show(this.dockPanel);
        }

        private void mapsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
                mapsExplorer.Show(this.dockPanel);
        }

        private void layersExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
                layersExplorer.Show(this.dockPanel);
        }

        private void mapEventsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
                mapEventsExplorer.Show(this.dockPanel);
        }

        private void templateEventsExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null)
                eventsExplorer.Show(this.dockPanel);
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                    sourceEditor.Show(dockPanel);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x061");
            }
        }

        #endregion

        #region Help
        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    feedbackPanel.Show(dockPanel);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x017");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            dialog.ShowDialog();
        }
        #endregion

        #region File
        /// <summary>
        /// Called when new project button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if need save
                if (NeedSave)
                    CallNeedSave();
                else
                {
                    CallWizard();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x040");
            }
        }
        /// <summary>
        /// Call project wizard.
        /// </summary>
        private void CallWizard()
        {
            try
            {
                NewProjectWiz wiz = new NewProjectWiz();
                Project old = CurrentProject;
                if (wiz.ShowDialog() == DialogResult.OK)
                {
                    IsLoadingProject = true;
                    loadDialogWorker.RunWorkerAsync();

                    if (!wiz.IsTemplate)
                        GameData.Reset();

                    if (old != null)
                        MaterialExplorer.contentBuilder.Clear();

                    saveToolStripButton.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;


                    editorsToolStrip.Enabled = true;
                    viewToolStripMenuItem.Enabled = true;


                    EnableRibbon();

                    editToolStripMenuItem.Enabled = true;
                    gameToolStripMenuItem.Enabled = true;
                    settingsBtn.Enabled = true;
                    playBtn.Enabled = true;
                    // Reset Everything
                    if (old != null)
                    {
                        mapsExplorer.CloseAllMaps();
                        mapsExplorer.cache.Clear();
                    }

                    CurrentProject = wiz.project;
                    TemplateContent = wiz.TemplateContent;

                    SetupCategories();
                    CurrentProject.Name = wiz.nameTxt.Text;

                    if (!wiz.IsTemplate)
                    {
                        SetupDatabases();
                        CreateProjectDirectory(wiz.locationTxt.Text, wiz.directoryChk.Checked);

                    }
                    else
                    {
                        if (Directory.Exists(CurrentProject.Location + @"\Temp"))
                            Directory.Delete(CurrentProject.Location + @"\Temp", true);
                        Directory.CreateDirectory(CurrentProject.Location + @"\Temp");
                    }

                    // Project Details
                    CurrentProject.Description = wiz.descBox.Text;
                    CurrentProject.Platform = (EGMGame.Library.TargetPlatform)wiz.defaultPlatform.SelectedIndex;
                    CurrentProject.ScreenRatio = new Microsoft.Xna.Framework.Vector2((float)wiz.screenWidth.Value, (float)wiz.screenHeight.Value);
                    CurrentProject.DefaultPixel = (int)wiz.defaultPixel.Value;

                    Global.Project.DefaultGridSize = new Microsoft.Xna.Framework.Vector2((float)wiz.gridWidth.Value, (float)wiz.gridHeight.Value);
                    // Delete Old Icon
                    if (wiz.project == null)
                    {
                        if (Path.Combine(CurrentProject.Location, CurrentProject.Icon) != wiz.iconBox.Text)
                        {
                            if (File.Exists(Path.Combine(CurrentProject.Location, CurrentProject.Icon)))
                            {
                                if ((File.GetAttributes(Path.Combine(CurrentProject.Location, CurrentProject.Icon)) & FileAttributes.ReadOnly)
                                    == FileAttributes.ReadOnly)
                                    File.SetAttributes(Path.Combine(CurrentProject.Location, CurrentProject.Icon), FileAttributes.Normal);
                                File.Delete(Path.Combine(CurrentProject.Location, CurrentProject.Icon));
                            }
                            FileInfo iFile = new FileInfo(wiz.iconBox.Text);
                            CurrentProject.Icon = iFile.Name;
                            // Import Icon if necessary
                            iFile.CopyTo(Path.Combine(CurrentProject.Location, iFile.Name));
                        }
                    }
                    // 
                    // Create version file
                    using (StreamWriter versionFile = new StreamWriter(CurrentProject.Location + @"\version.xml"))
                    {
                        versionFile.WriteLine("<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "utf-8" + '"' + "?>");
                        versionFile.WriteLine("<config>");
                        versionFile.WriteLine("  <source>" + Global.EngineVersion + "</source>");
                        versionFile.WriteLine("  <data>" + Global.DataVersion + "</data>");
                        versionFile.WriteLine("</config>");
                        versionFile.Close();
                    }

                    CurrentProject.Version = Global.EngineVersion.Split('.')[0];

                    MaterialExplorer.contentBuilder = new ContentBuilder();


                    // Reset Everything
                    if (old == null)
                    {
                        if (File.Exists(Path.Combine(CurrentProject.Location, CurrentProject.LayoutConfig)))
                        {
                            // Init Controls
                            LoadControls(); LoadLayout();
                        }
                        else
                            InitControls();
                    }
                    else
                    {
                        //mapsExplorer.CloseAllMaps();
                        //mapsExplorer.cache.Clear();
                        CloseOldControls();
                        if (File.Exists(Path.Combine(CurrentProject.Location, CurrentProject.LayoutConfig)))
                        {
                            //LoadControls(); 
                            LoadLayout();
                        }
                        //else 
                        //    InitControls();
                    }
                    AddRecentProject();

                    IsLoadingProject = false;

                    if (wiz.IsTemplate)
                    {
                        mapsExplorer.SelectMap(Global.Project.SelectedMap);
                        layersExplorer.SelecteLayer(Global.Project.SelectedLayer);
                        tilesExplorer.Zoom(Global.Project.TilesetZoom);
                        FillDatabases();
                        // Check Materials
                        CheckMaterials();
                    }
                    else
                    {
                        materialExplorer.AddMaterial(Application.StartupPath + @"\Content\ParticleEffect.fx");
                        materialExplorer.AddMaterial(Application.StartupPath + @"\Content\SystemFont.spritefont");
                    }
                    XboxManager.CreateXboxProject(CurrentProject);

                    if (IsHigherThenXP)
                    {
                        MainForm._tabMapContext.ContextAvailable = ContextAvailability.Available;
                    }

                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x041");
            }
        }

        private void EnableRibbon()
        {
            if (IsHigherThenXP)
            {
                _buttonExport.Enabled = true;
                _ribbonButton["undo"].Enabled = true;
                _ribbonButton["redo"].Enabled = true;
                _ribbonButton["play"].Enabled = true;
                _ribbonButton["animation"].Enabled = true;
                _ribbonButton["audio"].Enabled = true;
                _ribbonButton["font"].Enabled = true;
                _ribbonButton["map"].Enabled = true;
                _ribbonButton["particle"].Enabled = true;
                _ribbonButton["skin"].Enabled = true;
                _ribbonButton["tileset"].Enabled = true;
                _ribbonButton["combo"].Enabled = true;
                _ribbonButton["globalEvent"].Enabled = true;
                _ribbonButton["list"].Enabled = true;
                _ribbonButton["menu"].Enabled = true;
                _ribbonButton["player"].Enabled = true;
                _ribbonButton["string"].Enabled = true;
                _ribbonButton["switches"].Enabled = true;
                _ribbonButton["text"].Enabled = true;
                _ribbonButton["variable"].Enabled = true;
                _ribbonButton["enemies"].Enabled = true;
                _ribbonButton["equipment"].Enabled = true;
                _ribbonButton["hero"].Enabled = true;
                _ribbonButton["items"].Enabled = true;
                _ribbonButton["projectile"].Enabled = true;
                _ribbonButton["skills"].Enabled = true;
                _ribbonButton["states"].Enabled = true;
                _ribbonButton["templateEvents"].Enabled = true;
                _ribbonButton["projectsettings"].Enabled = true;
                _ribbonButton["egmsettings"].Enabled = true;
                _ribbonButton["materialexplorer"].Enabled = true;

                _ribbonButton["mapsexplorer"].Enabled = true;
                _ribbonButton["eventsexplorer"].Enabled = true;
                _ribbonButton["menuparts"].Enabled = true;
                _ribbonButton["menuproperty"].Enabled = true;
                _ribbonButton["history"].Enabled = true;
                _ribbonButton["mapevents"].Enabled = true;
                _ribbonButton["tilesexplorer"].Enabled = true;
                _ribbonButton["layersexplorer"].Enabled = true;
                _ribbonButton["itemsettings"].Enabled = true;
                _ribbonButton["database"].Enabled = true;
                _ribbonButton["databases"].Enabled = true;
                _ribbonButton["tutorials"].Enabled = true;
                _ribbonToggleButton["btnDrawEraser"].Enabled = true;
                _ribbonToggleButton["btnDrawPencil"].Enabled = true;
                _ribbonToggleButton["btnDrawRectangle"].Enabled = true;
                _ribbonToggleButton["btnDrawFill"].Enabled = true;
                _ribbonToggleButton["btnSelectionPointer"].Enabled = true;
                _ribbonToggleButton["btnSelectionRect"].Enabled = true;
                _ribbonToggleButton["btnSelectionRectAll"].Enabled = true;
                _ribbonButton["btnLayerUp"].Enabled = true;
                _ribbonButton["btnLayerDown"].Enabled = true;
                _ribbonButton["btnMapSize"].Enabled = true;
                _ribbonButton["btnGridSize"].Enabled = true;
                _ribbonButton["btnMapGravity"].Enabled = true;
                _ribbonButton["btnMapEffects"].Enabled = true;
                _ribbonToggleButton["btnMapDimLayer"].Enabled = true;
                _ribbonToggleButton["btnMapShowGrid"].Enabled = true;
                _ribbonToggleButton["btnMapSnapToGrid"].Enabled = true;
                _ribbonToggleButton["btnMapShowCollision"].Enabled = true;
                _ribbonButton["btnAddMap"].Enabled = true;
                _ribbonToggleButton["btnMapEvents"].Enabled = true;
                _ribbonButton["btnSource"].Enabled = true;
                _ribbonButton["btnReset"].Enabled = true;
                _ribbonButton["btnError"].Enabled = true;
                _ribbonToggleButton["btnDrawEraseRect"].Enabled = true;
                _ribbonToggleButton["btnDrawEraseFill"].Enabled = true;
                _ribbonToggleButton["btnMapEnableLayer"].Enabled = true;
            }
        }

        private void SetupDatabases()
        {
            Data dataBase = new Data();
            dataBase.Name = "Heroes";
            dataBase.ID = 0;
            AddNumber(dataBase, "HP");
            AddNumber(dataBase, "SP");
            AddNumber(dataBase, "MP");
            AddList(dataBase, "Max HP");
            AddList(dataBase, "Max SP");
            AddList(dataBase, "Max MP");
            AddList(dataBase, "Strength");
            AddList(dataBase, "Defense");
            AddList(dataBase, "Magic STR");
            AddList(dataBase, "Magic DEF");
            AddList(dataBase, "Agility");
            AddList(dataBase, "Luck");
            AddNumber(dataBase, "Level");
            AddNumber(dataBase, "Max Level");
            AddList(dataBase, "Experience");
            GameData.Databases.Add(0, dataBase);
            dataBase = new Data();
            dataBase.Name = "Enemies";
            AddNumber(dataBase, "HP");
            AddNumber(dataBase, "SP");
            AddNumber(dataBase, "MP");
            AddNumber(dataBase, "Max HP");
            AddNumber(dataBase, "Max SP");
            AddNumber(dataBase, "Max MP");
            AddNumber(dataBase, "Strength");
            AddNumber(dataBase, "Defense");
            AddNumber(dataBase, "Magic STR");
            AddNumber(dataBase, "Magic DEF");
            AddNumber(dataBase, "Agility");
            AddNumber(dataBase, "Luck");
            dataBase.ID = 1;
            GameData.Databases.Add(1, dataBase);
        }

        private void AddList(Data data, string p)
        {
            DataProperty a = new DataProperty();
            a.Name = p;
            a.ID = Global.GetID(data.Properties);
            a.ValueType = DataType.List;
            data.Properties.Add(a);
        }

        private void AddNumber(Data data, string p)
        {
            DataProperty a = new DataProperty();
            a.Name = p;
            a.ID = Global.GetID(data.Properties);
            if (p == "Level")
                a.Value = 1;
            if (p == "Max Level")
                a.Value = 99;
            a.ValueType = DataType.Number;
            data.Properties.Add(a);
        }
        /// <summary>
        /// Adds to the recent project list
        /// </summary>
        private void AddRecentProject()
        {
            try
            {
                RecentProject p = new RecentProject();
                p.Name = CurrentProject.Name;
                p.Location = CurrentProject.FullLocation;
                p.Description = CurrentProject.Description;
                RecentProject contains = null;
                foreach (RecentProject rp in Configuration.RecentProjects)
                {
                    if (rp.Location == p.Location)
                        contains = rp;
                }
                if (contains != null)
                    Configuration.RecentProjects.Remove(contains);
                Configuration.RecentProjects.Insert(0, p);
                if (Configuration.RecentProjects.Count > 12)
                    Configuration.RecentProjects.RemoveAt(12);

                Config.Save();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x042");
            }
        }
        /// <summary>
        /// Sets up categories for organizing data
        /// </summary>
        private void SetupCategories()
        {
            if (CurrentProject.Categories.Count == 0)
            {
                CurrentProject.Categories[typeof(AnimationData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(AudioData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(EventData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(FontData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(ItemData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(EquipmentData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(SkillData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(StateData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(MenuData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(IMenuParts).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(MapData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(SwitchData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(TextData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(TilesetData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(VariableData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(Data).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(GlobalEventData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(ListData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(MaterialData).ToString()] = new List<NodeCategory>() { new NodeCategory("Materials") };
                CurrentProject.Categories[typeof(MapData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(ParticleSystemData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(SkinData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(StringData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(HeroData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(EnemyData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(ComboData).ToString()] = new List<NodeCategory>() { new NodeCategory() };
                CurrentProject.Categories[typeof(ProjectileGroupData).ToString()] = new List<NodeCategory>() { new NodeCategory() };

            }
        }
        /// <summary>
        /// Load Project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (!Global.ImportingAudio)
            {
                try
                {
                    if (NeedSave)
                    {
                        DialogResult d = MessageBox.Show("Save changes to the project?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                        if (d == DialogResult.Yes)
                        {
                            SaveProject(true, true);
                        }
                        else if (d == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "1x043");
                }
                try
                {
                    openFileDialog.InitialDirectory = MainForm.Configuration.LastProjectDirectory;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        bool old = (CurrentProject != null);
                        LoadProject(openFileDialog.FileName, old);
                    }
                }
                catch (Exception ex)
                {
                    Error.ShowLogError(ex, "1x044");
                }
            }
        }

        internal void RecentProjectLoad(string path)
        {
            try
            {
                if (NeedSave && CurrentProject != null)
                {
                    DialogResult d = MessageBox.Show("Save changes to the project?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                    if (d == DialogResult.Yes)
                    {
                        SaveProject(true, true);
                    }
                    else if (d == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x045");
            }
            try
            {
                bool old = (CurrentProject != null);
                LoadProject(path, old);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x046");
            }
        }
        /// <summary>
        /// Set the docking
        /// </summary>
        /// <param name="old"></param>
        internal void SetDocking(bool old)
        {
            if (old)
                CloseOldControls();
            if (File.Exists(CurrentProject.LayoutConfig))
            {
                // Init Controls
                if (!old)
                    LoadControls();
                // Load Layout
                LoadLayout();
            }
            else if (!old)
                InitControls();
        }
        /// <summary>
        /// Create Project directory from location and create directory if needed.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="checkBox"></param>
        private void CreateProjectDirectory(string location, bool createDir)
        {
            try
            {
                CurrentProject.Location = (createDir ? location + CurrentProject.Name : location);
                // Create Folders
                if (createDir)
                {
                    Directory.CreateDirectory(CurrentProject.Location);
                }
                Directory.CreateDirectory(CurrentProject.Location + @"\Content");
                Directory.CreateDirectory(CurrentProject.Location + @"\Data");
                Directory.CreateDirectory(CurrentProject.Location + @"\Source");
                Directory.CreateDirectory(CurrentProject.Location + @"\Materials");
                Directory.CreateDirectory(CurrentProject.Location + @"\Maps");
                if (Directory.Exists(CurrentProject.Location + @"\Temp"))
                    Directory.Delete(CurrentProject.Location + @"\Temp", true);
                Directory.CreateDirectory(CurrentProject.Location + @"\Temp");

                if (CurrentProject.LayoutConfig == null)
                {
                    CurrentProject.LayoutConfig = "LayoutConfig.cfg";
                    if (File.Exists(Application.StartupPath + @"/LayoutConfig.cfg"))
                    {
                        string path = Path.Combine(Application.StartupPath, CurrentProject.LayoutConfig);
                        string npath = Path.Combine(Global.Project.Location, CurrentProject.LayoutConfig);
                        FileStream fs;
                        using (fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            FileStream nfile;
                            using (nfile = new FileStream(npath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                            {
                                Copy(fs, nfile);
                            }
                            fs.Flush();
                            fs.Close();
                        }
                    }
                }

                if (CurrentProject.SourceFiles.Count == 0)
                {
#if DEBUG
                    // Source Directory
                    DirectoryInfo sourceDir = new DirectoryInfo(Application.StartupPath + @"/Source");
                    // Empty Source Directory
                    foreach (FileInfo file in sourceDir.GetFiles())
                    {
                        if ((File.GetAttributes(file.FullName) & FileAttributes.ReadOnly)
                            == FileAttributes.ReadOnly)
                            File.SetAttributes(file.FullName, FileAttributes.Normal);
                        file.Delete();
                    }
                    // Update Source Directory
                    LoopSourceDirectories(EnginePath + @"\EGMGame");
                    LoopSourceDirectories(EnginePath + @"\GameLibrary");
#endif
                    CopySourceFilesToProject();

                }

                if (String.IsNullOrEmpty(CurrentProject.DataPath))
                    CurrentProject.DataPath = @"\Data";
                // Execute Project
                ExecuteProject();
                // Save Project
                SaveProject(false, true);
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x047");
            }
        }
        /// <summary>
        /// Copy files to project
        /// </summary>
        private void CopySourceFilesToProject()
        {
            try
            {
                // Source Directory
                DirectoryInfo sourceDir = new DirectoryInfo(CurrentProject.Location + @"/Source");

                foreach (string path in Directory.GetDirectories(CurrentProject.Location + @"/Source"))
                {
                    DisableReadOnlyFolder(path);
                    Directory.Delete(path, true);
                }
                foreach (string path in Directory.GetFiles(CurrentProject.Location + @"/Source"))
                {
                    if ((File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        File.SetAttributes(path, FileAttributes.Normal);
                    File.Delete(path);
                }
                // Empty Source Directory
                foreach (FileInfo file in sourceDir.GetFiles())
                {
                    if ((File.GetAttributes(file.FullName) & FileAttributes.ReadOnly)
                        == FileAttributes.ReadOnly)
                        File.SetAttributes(file.FullName, FileAttributes.Normal);
                    file.Delete();
                }
                if (File.Exists(CurrentProject.Location + @"\Game.ico"))
                {
                    if ((File.GetAttributes(CurrentProject.Location + @"\Game.ico") & FileAttributes.ReadOnly)
                        == FileAttributes.ReadOnly)
                        File.SetAttributes(CurrentProject.Location + @"\Game.ico", FileAttributes.Normal);
                    File.Delete(CurrentProject.Location + @"\Game.ico");
                }
                CopySourceDirectories(Application.StartupPath + @"\Source");

                File.Copy(Application.StartupPath + @"\Source\Game.ico", CurrentProject.Location + @"\Game.ico", true);
            }
            catch
            {
            }
        }
        /// <summary>
        /// Loops the source directories and adds all files that end with .cs
        /// </summary>
        /// <param name="p"></param>
        private void CopySourceDirectories(string p)
        {
            string newPath = "";
            FileInfo temp;
            foreach (string path in Directory.GetFiles(p))
            {
                FileInfo file = new FileInfo(path);
                newPath = file.FullName;
                if (newPath.Contains(Application.StartupPath + @"\Source"))
                    newPath = file.FullName.Replace(Application.StartupPath + @"\Source", "");
                if (file.Exists && !File.Exists(CurrentProject.Location + @"\Source" + newPath))
                {
                    if (file.Extension.ToLower() == ".cs")
                    {
                        temp = new FileInfo(CurrentProject.Location + @"\Source" + newPath);
                        if (!temp.Directory.Exists)
                            temp.Directory.Create();
                        File.Copy(path, CurrentProject.Location + @"\Source" + newPath, true);
                    }
                }
                if (file.Extension.ToLower() == ".cs")
                {
                    CurrentProject.SourceFiles.Add(new SourceFile(@"\Source" + newPath));
                }
            }
            foreach (string dir in Directory.GetDirectories(p))
                CopySourceDirectories(dir);
        }
        /// <summary>
        /// Loops the source directories and adds all files that end with .cs
        /// </summary>
        /// <param name="p"></param>
        private void LoopSourceDirectories(string p)
        {
            string newPath = "";
            FileInfo temp;
            foreach (string path in Directory.GetFiles(p))
            {
                FileInfo file = new FileInfo(path);
                newPath = file.FullName;
                if (newPath.Contains(EnginePath + @"\EGMGame"))
                    newPath = file.FullName.Replace(EnginePath + @"\EGMGame", "");
                if (newPath.Contains(EnginePath + @"\GameLibrary"))
                    newPath = file.FullName.Replace(EnginePath + @"\GameLibrary", "");
                if (file.Exists && !File.Exists(Application.StartupPath + @"\Source" + newPath))
                {
                    if (file.Extension.ToLower() == ".cs" || file.Extension.ToLower() == ".ico")
                    {
                        temp = new FileInfo(Application.StartupPath + @"\Source" + newPath);
                        if (!temp.Directory.Exists)
                            temp.Directory.Create();
                        if ((File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                            File.SetAttributes(path, FileAttributes.Normal);
                        File.Copy(path, Application.StartupPath + @"\Source" + newPath, true);
                    }
                }
            }
            foreach (string dir in Directory.GetDirectories(p))
                LoopSourceDirectories(dir);
        }
        /// <summary>
        /// Copt
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public void Copy(Stream source, Stream target)
        {
            byte[] buffer = new byte[0x10000];
            int bytes;
            try
            {
                while ((bytes = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    target.Write(buffer, 0, bytes);
                }
            }
            finally
            {
                target.Flush();
                target.Close();
            }
        }

        /// <summary>
        /// If main form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (alphaPanel.Visible || Global.ImportingAudio)
                {
                    e.Cancel = true;
                    return;
                }
                e.Cancel = false;
                if (NeedSave && !e.Cancel)
                {
                    DialogResult d = MessageBox.Show("Save changes to the project?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                    if (d == DialogResult.Yes)
                    {
                        SaveProject(true, false);
                    }
                    else if (d == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
                // Dispose Audio
                if (!e.Cancel)
                {
                    //if (audioEngine != null)
                    //    audioEngine.Dispose();
                    //foreach (SoundBank sound in MainForm.soundBanks.Values)
                    //{
                    //    sound.Dispose();
                    //}
                    //MainForm.soundBanks.Clear();
                    //foreach (WaveBank wave in MainForm.waveBanks.Values)
                    //{
                    //    wave.Dispose();
                    //}
                    //MainForm.waveBanks.Clear();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x048");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Resets controls to the new project
        /// </summary>
        private void CloseOldControls()
        {
            try
            {
                NeedSave = false;

                Loader.Clear(true);
                MainForm.SelectedMap = null;
                // Close All Data
                foreach (DataEditor e in dataEditors)
                {
                    e.Close();
                    e.Dispose();
                }
                // Reset List
                dataEditorIDs = new List<int>();
                dataEditors = new List<DataEditor>();
                feedbackPanel.Hide();
                materialExplorer.Hide();
                materialExplorer.ResetProject();
                sourceEditor.Hide();
                sourceEditor.ResetProject();
                mapEventsExplorer.Hide();
                mapEventsExplorer.ResetProject();
                mapsExplorer.Hide();
                mapsExplorer.ResetProject();
                databaseExplorer.Hide();
                databaseExplorer.ResetProject();
                HistoryExplorer.Hide();
                HistoryExplorer.ResetProject();
                materialPreview.Hide();
                materialPreview.ResetProject();
                itemSettings.Hide();
                itemSettings.ResetProject();
                layersExplorer.Hide();
                layersExplorer.ResetProject();
                tilesExplorer.Hide();
                tilesExplorer.ResetProject();
                menuPartsExplorer.Hide();
                menuPartsExplorer.ResetProject();
                menuPropertyExplorer.Hide();
                menuPropertyExplorer.ResetProject();
                eventsExplorer.Hide();
                eventsExplorer.ResetProject();
                errorExplorer.Hide();
                tutorialExplorer.Hide();
                mapEditor.Hide();
                mapEditor.ResetProject();
                animationEditor.Hide();
                animationEditor.ResetProject();
                settingsForm.Hide();
                settingsForm.ResetProject();
                tilesetEditor.Hide();
                tilesetEditor.ResetProject();
                audioEditor.Hide();
                audioEditor.ResetProject();
                projectileEditor.Hide();
                projectileEditor.ResetProject();
                comboEdtor.Hide();
                comboEdtor.ResetProject();
                textEditor.Hide();
                textEditor.ResetProject();
                fontEditor.Hide();
                fontEditor.ResetProject();
                eventEditor.Hide();
                eventEditor.ResetProject();
                playerEditor.Hide();
                playerEditor.ResetProject();
                databaseEditor.Hide();
                databaseEditor.ResetProject();
                stringsEditor.Hide();
                stringsEditor.ResetProject();
                variablesEditor.Hide();
                variablesEditor.ResetProject();
                switchesEditor.Hide();
                switchesEditor.ResetProject();
                listEditor.Hide();
                listEditor.ResetProject();
                menuEditor.Hide();
                menuEditor.ResetProject();
                particleEditor.Hide();
                particleEditor.ResetProject();
                skinEditor.Hide();
                skinEditor.ResetProject();
                stringEditor.Hide();
                stringEditor.ResetProject();
                globalEventEditor.Hide();
                globalEventEditor.ResetProject();
                itemEditor.Hide();
                itemEditor.ResetProject();
                equipmentEditor.Hide();
                equipmentEditor.ResetProject();
                skillsEditor.Hide();
                skillsEditor.ResetProject();
                statesEditor.Hide();
                statesEditor.ResetProject();
                heroEditor.Hide();
                heroEditor.ResetProject();
                enemyEditor.Hide();
                enemyEditor.ResetProject();

                // Close and Dispose All
                //materialExplorer.Close();
                //materialExplorer.Dispose();
                //mapEventsExplorer.Close();
                //mapEventsExplorer.Dispose();
                //mapsExplorer.Close();
                //mapsExplorer.Dispose();
                //HistoryExplorer.Close();
                //HistoryExplorer.Dispose();
                //materialPreview.Close();
                //materialPreview.Dispose();
                //itemSettings.Close();
                //itemSettings.Dispose();
                //layersExplorer.Close();
                //layersExplorer.Dispose();
                //tilesExplorer.Close();
                //tilesExplorer.Dispose();
                //menuPartsExplorer.Close();
                //menuPartsExplorer.Dispose();
                //menuPropertyExplorer.Close();
                //menuPropertyExplorer.Dispose();
                //eventsExplorer.Close();
                //eventsExplorer.Dispose();
                //errorList.Close();
                //errorList.Dispose();
                //mapEditor.Close();
                //mapEditor.Dispose();
                //animationEditor.Close();
                //animationEditor.Dispose();
                //settingsForm.Close();
                //settingsForm.Dispose();
                //tilesetEditor.Close();
                //tilesetEditor.Dispose();
                //audioEditor.Close();
                //audioEditor.Dispose();
                //projectileEditor.Close();
                //projectileEditor.Dispose();
                //comboEdtor.Close();
                //comboEdtor.Dispose();
                //textEditor.Close();
                //textEditor.Dispose();
                //fontEditor.Close();
                //fontEditor.Dispose();
                //eventEditor.Close();
                //eventEditor.Dispose();
                //playerEditor.Close();
                //playerEditor.Dispose();
                //databaseEditor.Close();
                //databaseEditor.Dispose();
                //stringsEditor.Close();
                //stringsEditor.Dispose();
                //variablesEditor.Close();
                //variablesEditor.Dispose();
                //switchesEditor.Close();
                //switchesEditor.Dispose();
                //listEditor.Close();
                //listEditor.Dispose();
                //menuEditor.Close();
                //menuEditor.Dispose();
                //particleEditor.Close();
                //particleEditor.Dispose();
                //skinEditor.Close();
                //skinEditor.Dispose();
                //stringEditor.Close();
                //stringEditor.Dispose();
                //globalEventEditor.Close();
                //globalEventEditor.Dispose();
                //itemEditor.Close();
                //itemEditor.Dispose();
                //equipmentEditor.Close();
                //equipmentEditor.Dispose();
                //skillsEditor.Close();
                //skillsEditor.Dispose();
                //statesEditor.Close();
                //statesEditor.Dispose();
                //heroEditor.Close();
                //heroEditor.Dispose();
                //enemyEditor.Close();
                //enemyEditor.Dispose();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x049");
            }
        }
        /// <summary>
        /// Initializes controls.
        /// </summary>
        private void InitControls()
        {
            try
            {
                sourceEditor = new SourceEditor();
                feedbackPanel = new FeedbackPanel();
                feedbackPanel.Show(dockPanel);
                // Material Explorer
                materialExplorer = new MaterialExplorer();
                materialExplorer.Show(dockPanel);
                // Map Events Explorer
                mapEventsExplorer = new MapEventsExplorer();
                mapEventsExplorer.Show(dockPanel);
                // Map Events Explorer
                mapsExplorer = new MapsExplorer();
                mapsExplorer.Show(dockPanel);
                // Database explorer 
                databaseExplorer = new DatabaseExplorer();
                databaseExplorer.Show(dockPanel);
                // History Explorer
                HistoryExplorer = new HistoryExplorer();
                HistoryExplorer.Show(dockPanel);
                // Material Preview
                materialPreview = new MaterialPreviewDock();
                materialPreview.Show(dockPanel);
                // Item Settings
                itemSettings = new ItemSettingsForm();
                itemSettings.Show(dockPanel);
                // Layers Explorer
                layersExplorer = new LayersExplorer();
                layersExplorer.Show(dockPanel);
                // Tiles Explorer
                tilesExplorer = new TilesExplorer();
                tilesExplorer.Show(dockPanel);
                // Menu Parts Explorer
                menuPartsExplorer = new MenuPartsExplorer();
                menuPartsExplorer.Show(dockPanel);

                menuPropertyExplorer = new ObjectPropertyExplorer();
                menuPropertyExplorer.Show(dockPanel);
                // Material Preview
                materialPreview = new MaterialPreviewDock();
                materialExplorer.Show(dockPanel);


                itemSettings = new ItemSettingsForm();
                itemSettings.Show(dockPanel);
                // Event Explorer
                eventsExplorer = new EventExplorer();
                eventsExplorer.Show(dockPanel);
                // Error Explorer
                errorExplorer = new ErrorExplorer();
                tutorialExplorer = new TutorialExplorer();
                // Scene Editor
                MapEditorHistory = new Dictionary<MapViewer, UndoRedoHistory<IHistory>>();
                mapEditor = new MapEditor();
                mapEditor.Show(dockPanel);
                // Settings Form
                settingsForm = new SettingsForm();
                // Animation Editor
                AnimationHistory = new Dictionary<AnimationEditor, UndoRedoHistory<IHistory>>();
                animationEditor = new AnimationEditor();
                // Tileset Editor
                TilesetHistory = new Dictionary<TilesetEditor, UndoRedoHistory<IHistory>>();
                tilesetEditor = new TilesetEditor();
                // Audio Editor
                AudioHistory = new Dictionary<AudioEditor, UndoRedoHistory<IHistory>>();
                audioEditor = new AudioEditor();
                // Projectile Editor
                ProjectileHistory = new Dictionary<ProjectileEditor, UndoRedoHistory<IHistory>>();
                projectileEditor = new ProjectileEditor();
                // Combo Editor
                CombosHistory = new Dictionary<ComboEditor, UndoRedoHistory<IHistory>>();
                comboEdtor = new ComboEditor();
                // Item Editor
                ItemHistory = new Dictionary<ItemEditor, UndoRedoHistory<IHistory>>();
                itemEditor = new ItemEditor();
                EquipmentHistory = new Dictionary<EquipmentEditor, UndoRedoHistory<IHistory>>();
                equipmentEditor = new EquipmentEditor();
                SkillsHistory = new Dictionary<SkillsEditor, UndoRedoHistory<IHistory>>();
                skillsEditor = new SkillsEditor();
                StatesHistory = new Dictionary<StatesEditor, UndoRedoHistory<IHistory>>();
                statesEditor = new StatesEditor();
                // Hero Editor
                HeroHistory = new Dictionary<HeroEditor, UndoRedoHistory<IHistory>>();
                heroEditor = new HeroEditor();
                EnemyHistory = new Dictionary<EnemiesEditor, UndoRedoHistory<IHistory>>();
                enemyEditor = new EnemiesEditor();
                // List Editor
                ListHistory = new Dictionary<ListEditor, UndoRedoHistory<IHistory>>();
                listEditor = new ListEditor();
                // Text Editor
                TextHistory = new Dictionary<TextEditor, UndoRedoHistory<IHistory>>();
                textEditor = new TextEditor();
                // Font Editor
                FontHistory = new Dictionary<FontEditor, UndoRedoHistory<IHistory>>();
                fontEditor = new FontEditor();
                // Event Editor
                EventHistory = new Dictionary<EventEditor, UndoRedoHistory<IHistory>>();
                eventEditor = new EventEditor();
                // Player Editor
                PlayerHistory = new Dictionary<PlayerEditor, UndoRedoHistory<IHistory>>();
                playerEditor = new PlayerEditor();
                // Event Editor
                GlobalEventHistory = new Dictionary<GlobalEventEditor, UndoRedoHistory<IHistory>>();
                globalEventEditor = new GlobalEventEditor();
                // Database Editor
                DatabaseHistory = new Dictionary<DatabaseEditor, UndoRedoHistory<IHistory>>();
                DataHistory = new Dictionary<DataEditor, UndoRedoHistory<IHistory>>();
                databaseEditor = new DatabaseEditor();
                // Variable Editor
                VariablesHistory = new Dictionary<VariablesEditor, UndoRedoHistory<IHistory>>();
                variablesEditor = new VariablesEditor();
                // String Editor
                StringsHistory = new Dictionary<StringEditor, UndoRedoHistory<IHistory>>();
                stringsEditor = new StringEditor();
                // Switches Editor         
                SwitchesHistory = new Dictionary<SwitchesEditor, UndoRedoHistory<IHistory>>();
                switchesEditor = new SwitchesEditor();
                // Menu Editor
                MenuEditorHistory = new Dictionary<MenuViewer, UndoRedoHistory<IHistory>>();
                menuEditor = new MenuEditor();
                // Particle Editor
                ParticleHistory = new Dictionary<ParticleEditor, UndoRedoHistory<IHistory>>();
                particleEditor = new ParticleEditor();
                // Skin Editor
                SkinHistory = new Dictionary<SkinEditor, UndoRedoHistory<IHistory>>();
                skinEditor = new SkinEditor();
                // String Editor
                StringHistory = new Dictionary<StringEditor, UndoRedoHistory<IHistory>>();
                stringEditor = new StringEditor();
                //
                HistoryExplorer.SelectedHistory = null;
                //
                materialExplorer.SetProject();
                sourceEditor.SetProject();

                CommandDialog = new BehaviorListDialog();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x050");
            }
        }
        /// <summary>
        /// Load Controls
        /// </summary>
        private void LoadControls()
        {
            try
            {
                LoadProgress = 150;

                sourceEditor = new SourceEditor();

                LoadProgress = 160;

                // Tt

                // Material Explorer
                materialExplorer = new MaterialExplorer();

                LoadProgress = 165;
                // Tt

                // Map Events Explorer
                mapEventsExplorer = new MapEventsExplorer();

                LoadProgress = 170;
                // Tt

                // Maps Explorer
                mapsExplorer = new MapsExplorer();

                LoadProgress = 175;
                // Tt

                databaseExplorer = new DatabaseExplorer();
                // History Explorer
                HistoryExplorer = new HistoryExplorer();

                LoadProgress = 180;
                // Tt

                // Material Preview
                materialPreview = new MaterialPreviewDock();
                // Item settings
                itemSettings = new ItemSettingsForm();

                LoadProgress = 185;
                // Tt

                // Layers Explorer
                layersExplorer = new LayersExplorer();
                // Tiles Explorer
                tilesExplorer = new TilesExplorer();

                LoadProgress = 190;
                // Tt

                // Menu Parts Explorer
                menuPartsExplorer = new MenuPartsExplorer();
                menuPropertyExplorer = new ObjectPropertyExplorer();

                LoadProgress = 195;
                // Tt

                // Event Explorer
                eventsExplorer = new EventExplorer();
                // Error Explorer
                errorExplorer = new ErrorExplorer();

                LoadProgress = 200;
                // Tt

                // Scene Editor
                MapEditorHistory = new Dictionary<MapViewer, UndoRedoHistory<IHistory>>();
                // Settings Form
                settingsForm = new SettingsForm();
                // Animation Editor
                AnimationHistory = new Dictionary<AnimationEditor, UndoRedoHistory<IHistory>>();
                animationEditor = new AnimationEditor();

                LoadProgress = 205;
                // Tt

                // Tileset Editor
                TilesetHistory = new Dictionary<TilesetEditor, UndoRedoHistory<IHistory>>();
                tilesetEditor = new TilesetEditor();
                // Audio Editor
                AudioHistory = new Dictionary<AudioEditor, UndoRedoHistory<IHistory>>();
                audioEditor = new AudioEditor();

                LoadProgress = 210;

                // Projectile Editor
                ProjectileHistory = new Dictionary<ProjectileEditor, UndoRedoHistory<IHistory>>();
                projectileEditor = new ProjectileEditor();
                // Combo Editor
                CombosHistory = new Dictionary<ComboEditor, UndoRedoHistory<IHistory>>();
                comboEdtor = new ComboEditor();

                LoadProgress = 215;
                // Tt

                // Item Editor
                ItemHistory = new Dictionary<ItemEditor, UndoRedoHistory<IHistory>>();
                itemEditor = new ItemEditor();
                EquipmentHistory = new Dictionary<EquipmentEditor, UndoRedoHistory<IHistory>>();
                equipmentEditor = new EquipmentEditor();

                LoadProgress = 220;
                // Tt

                SkillsHistory = new Dictionary<SkillsEditor, UndoRedoHistory<IHistory>>();
                skillsEditor = new SkillsEditor();
                StatesHistory = new Dictionary<StatesEditor, UndoRedoHistory<IHistory>>();
                statesEditor = new StatesEditor();

                LoadProgress = 225;
                // Tt

                // Hero Editor
                HeroHistory = new Dictionary<HeroEditor, UndoRedoHistory<IHistory>>();
                heroEditor = new HeroEditor();
                EnemyHistory = new Dictionary<EnemiesEditor, UndoRedoHistory<IHistory>>();
                enemyEditor = new EnemiesEditor();

                LoadProgress = 230;
                // Tt

                // Array
                ListHistory = new Dictionary<ListEditor, UndoRedoHistory<IHistory>>();
                listEditor = new ListEditor();
                // Text Editor
                TextHistory = new Dictionary<TextEditor, UndoRedoHistory<IHistory>>();
                textEditor = new TextEditor();

                LoadProgress = 235;
                // Tt

                // Font Editor
                FontHistory = new Dictionary<FontEditor, UndoRedoHistory<IHistory>>();
                fontEditor = new FontEditor();
                // Event Editor
                EventHistory = new Dictionary<EventEditor, UndoRedoHistory<IHistory>>();
                eventEditor = new EventEditor();

                LoadProgress = 240;
                // Tt

                GlobalEventHistory = new Dictionary<GlobalEventEditor, UndoRedoHistory<IHistory>>();
                globalEventEditor = new GlobalEventEditor();
                // Player Editor
                PlayerHistory = new Dictionary<PlayerEditor, UndoRedoHistory<IHistory>>();
                playerEditor = new PlayerEditor();

                LoadProgress = 245;
                // Tt

                // Database Editor
                DatabaseHistory = new Dictionary<DatabaseEditor, UndoRedoHistory<IHistory>>();
                DataHistory = new Dictionary<DataEditor, UndoRedoHistory<IHistory>>();
                databaseEditor = new DatabaseEditor();
                // Variable Editor
                VariablesHistory = new Dictionary<VariablesEditor, UndoRedoHistory<IHistory>>();
                variablesEditor = new VariablesEditor();

                LoadProgress = 250;
                // Tt

                // String Editor
                StringsHistory = new Dictionary<StringEditor, UndoRedoHistory<IHistory>>();
                stringsEditor = new StringEditor();
                // Particle Editor
                ParticleHistory = new Dictionary<ParticleEditor, UndoRedoHistory<IHistory>>();
                particleEditor = new ParticleEditor();

                LoadProgress = 255;
                // Tt

                // Switches Editor         
                SwitchesHistory = new Dictionary<SwitchesEditor, UndoRedoHistory<IHistory>>();
                switchesEditor = new SwitchesEditor();
                // Skin Editor
                SkinHistory = new Dictionary<SkinEditor, UndoRedoHistory<IHistory>>();
                skinEditor = new SkinEditor();

                LoadProgress = 260;
                // Tt

                // Menu Editor
                MenuEditorHistory = new Dictionary<MenuViewer, UndoRedoHistory<IHistory>>();
                menuEditor = new MenuEditor();
                // Skin Editor
                StringHistory = new Dictionary<StringEditor, UndoRedoHistory<IHistory>>();
                stringEditor = new StringEditor();

                LoadProgress = 265;
                // Tt

                //
                HistoryExplorer.SelectedHistory = null;
                //
                materialExplorer.SetProject();
                sourceEditor.SetProject();

                feedbackPanel = new FeedbackPanel();
                tutorialExplorer = new TutorialExplorer();
                mapEditor = new MapEditor();

                LoadProgress = 270;
                // Tt


                CommandDialog = new BehaviorListDialog();

                LoadProgress = 275;
                // Tt

            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x051");
            }
        }
        /// <summary>
        /// Execute Creation
        /// </summary>
        private void ExecuteProject()
        {
        }
        /// <summary>
        /// Is called if save is needed and hasn't been made.
        /// </summary>
        private void CallNeedSave()
        {
            try
            {
                if (NeedSave)
                {
                    DialogResult d = MessageBox.Show("Save changes to the project?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

                    if (d == DialogResult.Yes)
                    {
                        SaveProject(true, false);
                        CallWizard();
                    }
                    else if (d == DialogResult.No)
                    {
                        CallWizard();
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x052");
            }
        }
        #endregion

        #region Tools

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (alphaPanel.Visible)
                return;
            if (Global.ImportingAudio)
            {
                MessageBox.Show("You can't testplay while audio is compiling. Please wait until the imported audio has compiled.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (CurrentProject != null) // && CurrentProject.SourceFiles.Count > 0)
            {
                // Save Project
                SaveTemp();
#if DEBUG
                CurrentProject.SourceFiles.Clear();
                // Source Directory
                DirectoryInfo sourceDir = new DirectoryInfo(Application.StartupPath + @"/Source");
                // Empty Source Directory
                foreach (FileInfo file in sourceDir.GetFiles())
                {
                    if ((File.GetAttributes(file.FullName) & FileAttributes.ReadOnly)
                        == FileAttributes.ReadOnly)
                        File.SetAttributes(file.FullName, FileAttributes.Normal);

                    file.Delete();
                }
                // Update Source Directory
                foreach (string path in Directory.GetDirectories(Application.StartupPath + @"\Source"))
                {
                    DisableReadOnlyFolder(path);
                    Directory.Delete(path, true);
                }
                foreach (string path in Directory.GetFiles(Application.StartupPath + @"\Source"))
                {
                    if (File.GetAttributes(path) == FileAttributes.ReadOnly) File.SetAttributes(path, FileAttributes.Normal);
                    File.Delete(path);
                }
                LoopSourceDirectories(EnginePath + @"\EGMGame");
                LoopSourceDirectories(EnginePath + @"\GameLibrary");

                sourceDir = new DirectoryInfo(CurrentProject.Location + @"/Source");
                // Empty Source Directory
                foreach (FileInfo file in sourceDir.GetFiles())
                {
                    if ((File.GetAttributes(file.FullName) & FileAttributes.ReadOnly)
                        == FileAttributes.ReadOnly)
                        File.SetAttributes(file.FullName, FileAttributes.Normal);
                    file.Delete();
                }
                CopySourceFilesToProject();
#endif
#if BETA
                //CurrentProject.SourceFiles.Clear();
                // CopySourceFilesToProject();
#endif
                // Debug
                if (CurrentProject.Platform == TargetPlatform.Windows)
                {
                    DebugWindowsProject();
                }
                else if (CurrentProject.Platform == TargetPlatform.Xbox)
                {
                    DebugXboxProject();
                }
                else if (CurrentProject.Platform == TargetPlatform.Silverlight)
                {
                    DebugSilverlightProject();
                }
            }
        }

        static public void DisableReadOnlyFolder(string sourceFolder)
        {
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                if ((File.GetAttributes(file) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) File.SetAttributes(file, FileAttributes.Normal);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                DisableReadOnlyFolder(folder);
            }
        }

        private void SaveTemp()
        {
            if (!Directory.Exists(Global.Project.Location + @"\Temp"))
                Directory.CreateDirectory(Global.Project.Location + @"\Temp");
            if (!Directory.Exists(Global.Project.Location + @"\Temp\Maps"))
                Directory.CreateDirectory(Global.Project.Location + @"\Temp\Maps");
            if (!Directory.Exists(Global.Project.Location + @"\Temp\Data")) Directory.CreateDirectory(Global.Project.Location + @"\Temp\Data");
            Save(Global.Project.Location + @"\Temp", false);
        }

        private void DebugWindowsProject()
        {
            alphaPanel.Visible = true;
            testPlayDialog = new TestPlayDialog();

            testPlayWorker.WorkerReportsProgress = true;
            testPlayWorker.RunWorkerAsync();

            testPlayDialog.ShowDialog();
        }

        private void testPlayWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int tt = 0;
            testPlayWorker.ReportProgress(++tt);

            Dictionary<string, string> provider_options = new Dictionary<string, string>

                         {

                             {"CompilerVersion","v4.0"}

                         };
            CodeDomProvider provider = new CSharpCodeProvider(provider_options);

            CompilerParameters cp = new CompilerParameters();

            // Generate a class library.
            cp.GenerateExecutable = true;

            testPlayWorker.ReportProgress(++tt);
            cp.OutputAssembly = CurrentProject.Location + @"\" + CurrentProject.Name + ".exe";

            // Add an XNA assembly references
            cp.ReferencedAssemblies.Add(Assembly.GetAssembly(
                        typeof(Microsoft.Xna.Framework.BoundingBox)).Location);
            cp.ReferencedAssemblies.Add(Assembly.GetAssembly(
                       typeof(Microsoft.Xna.Framework.Content.Pipeline.ContentBuildLogger)).Location);
            cp.ReferencedAssemblies.Add(Assembly.GetAssembly(
                       typeof(Microsoft.Xna.Framework.GamerServices.Achievement)).Location);
            cp.ReferencedAssemblies.Add(Assembly.GetAssembly(
                        typeof(Microsoft.Xna.Framework.Game)).Location);
            cp.ReferencedAssemblies.Add(Assembly.GetAssembly(
                        typeof(Microsoft.Xna.Framework.Graphics.AlphaTestEffect)).Location);
            cp.ReferencedAssemblies.Add(Assembly.GetAssembly(
                        typeof(Microsoft.Xna.Framework.Net.AvailableNetworkSession)).Location);
            cp.ReferencedAssemblies.Add(Assembly.GetAssembly(
                        typeof(Microsoft.Xna.Framework.Storage.StorageContainer)).Location);
            cp.ReferencedAssemblies.Add(Assembly.GetAssembly(
                        typeof(Microsoft.Xna.Framework.Media.Video)).Location);

            testPlayWorker.ReportProgress(++tt);
            // Add Regular References
            cp.ReferencedAssemblies.Add("mscorlib.dll");
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Security.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            cp.ReferencedAssemblies.Add("System.Data.dll");
            cp.ReferencedAssemblies.Add("System.Xml.dll");
            cp.ReferencedAssemblies.Add("System.Xml.Linq.dll");
            // Set the level at which the compiler 
            // should start displaying warnings.
            cp.WarningLevel = 0;

            testPlayWorker.ReportProgress(++tt);
            // Set compiler argument to optimize output.
            cp.CompilerOptions = "/win32icon:\"" + CurrentProject.Location + @"\" + CurrentProject.Icon + "\"";
            foreach (string path in Directory.GetFiles(CurrentProject.Location + @"\Temp\Data"))
            {
                FileInfo file = new FileInfo(path);
                if (file.Extension.Contains(".egm"))
                    cp.CompilerOptions += " /resource:\"" + path + "\"" + "," + file.Name;
            }
            List<string> _maps = new List<string>();
            testPlayWorker.ReportProgress(++tt);
            foreach (string path2 in Directory.GetFiles(CurrentProject.Location + @"\Temp\Maps"))
            {
                FileInfo file = new FileInfo(path2);
                if (file.Extension.Contains(".egm"))
                {
                    cp.CompilerOptions += " /resource:\"" + path2 + "\"" + "," + "\"" + file.Name + "\"";
                    _maps.Add(file.Name);
                }
            }
            testPlayWorker.ReportProgress(++tt);
            foreach (string path3 in Directory.GetFiles(CurrentProject.Location + @"\Maps"))
            {
                if (!_maps.Contains(Path.GetFileName(path3)))
                {
                    FileInfo file2 = new FileInfo(path3);
                    if (file2.Extension.Contains(".egm"))
                    {
                        cp.CompilerOptions += " /resource:\"" + path3 + "\"" + "," + "\"" + file2.Name + "\"";
                    }
                }
            }
            testPlayWorker.ReportProgress(++tt);
            FileInfo project = new FileInfo(CurrentProject.Location + @"\Temp\Project.egmproj");
            cp.CompilerOptions += " /resource:\"" + project.FullName + "\"" + "," + project.Name;
            cp.CompilerOptions += @" /platform:x86";
            cp.CompilerOptions += @" /define:DEBUG";
            cp.CompilerOptions += @" /define:WINDOWS";
            cp.CompilerOptions += @" /define:XNA";
            testPlayWorker.ReportProgress(++tt);
            // Invoke compilation.
            string[] files = new string[CurrentProject.SourceFiles.Count];
            int i = 0;
            foreach (SourceFile file in CurrentProject.SourceFiles)
            {
                files[i] = CurrentProject.Location + file.Path;
                i++;
            }
            CompilerResults cr = provider.CompileAssemblyFromFile(
                                        cp, files);

            testPlayWorker.ReportProgress(++tt);
            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < cr.Errors.Count && j < 5; j++)
                {
                    sb.Append(cr.Errors[j].ToString());
                    sb.Append("\n");

                }
                errorExplorer.SetSourceError(sb.ToString());
                // errorExplorer.Show(dockPanel);
            }
            else
            {
                MainForm.errorExplorer.ClearSourceError();
                ProcessStartInfo p = new ProcessStartInfo(CurrentProject.Location + @"\" + CurrentProject.Name + ".exe");
                //p.UseShellExecute = false;
                //p.CreateNoWindow = true;
                testPlayWorker.ReportProgress(++tt);
                // Execute
                System.Diagnostics.Process.Start(p);
            }
        }

        private void testPlayWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            testPlayDialog.Bar.Value = e.ProgressPercentage;
        }

        private void testPlayWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            alphaPanel.Visible = false;
            testPlayDialog.Close();

            if (errorExplorer.ErrorCount > 0) errorExplorer.Show();
        }
        
        private void DebugXboxProject()
        {
            XboxManager.CreateXboxProject(CurrentProject);
            Process.Start(CurrentProject.Location + @"\Xbox\" + CurrentProject.Name + ".sln");
        }
        
        private void DebugSilverlightProject()
        {
        }
        
        private void redoBtn_Click(object sender, EventArgs e)
        {
            if (alphaPanel.Visible)
                return;
            HistoryExplorer.Redo();
        }
        
        private void undoBtn_Click(object sender, EventArgs e)
        {
            if (alphaPanel.Visible)
                return;
            HistoryExplorer.Undo();
        }
        
        public void addNewMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentProject != null)
                {
                    mapsExplorer.addRemoveList_AddItem(null, null);
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x053");
            }
        }
        
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (CurrentProject != null) SaveProject(true, true);
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playBtn_Click(null, null);
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void silverlightToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xbox360ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void windowsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void xbox360ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void silverlightToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion

        #region Save/Load Background Workers
        private void SaveProject(bool layout, bool thread)
        {
            if (alphaPanel.Visible)
                return;
            progressBar.Enabled = progressBar.Visible = true;
            progressBar.Maximum = 100;
            statusLbl.Enabled = statusLbl.Visible = true;
            statusLbl.Text = "Saving...";
            alphaPanel.BringToFront();
            alphaPanel.Visible = true;
            alphaPanel.Location = new Point(0, 0);
            alphaPanel.Size = this.Size;

            if (thread && !saveWorker.IsBusy)
                saveWorker.RunWorkerAsync(layout);
            else
            {
                NeedSave = false;
                Save(Global.Project.Location, layout);
                saveWorker_RunWorkerCompleted(null, new RunWorkerCompletedEventArgs(layout, null, false));
            }
        }
        private void Save(string path, bool layout)
        {
            Marshal.SaveObj(CurrentProject, path + @"\Project.egmproj", path);
            // Save Animations
            Marshal.SaveObj(GameData.Animations, path + CurrentProject.DataPath + Extensions.Animations, path + CurrentProject.DataPath);
            // Save Audios
            Marshal.SaveObj(GameData.Audios, path + CurrentProject.DataPath + Extensions.Audios, path + CurrentProject.DataPath);
            // Save Tilesets
            Marshal.SaveObj(GameData.Tilesets, path + CurrentProject.DataPath + Extensions.Tilesets, path + CurrentProject.DataPath);
            // Save Texts
            foreach (string lang in CurrentProject.Languages)
            {
                Marshal.SaveObj(GameData.Texts[lang], path + CurrentProject.DataPath + CMD.TextCode(lang) + Extensions.Texts, path + CurrentProject.DataPath);
            }
            // Save Fonts
            Marshal.SaveObj(GameData.Fonts, path + CurrentProject.DataPath + Extensions.Fonts, path + CurrentProject.DataPath);
            // Save Databases
            Marshal.SaveObj(GameData.Databases, path + CurrentProject.DataPath + Extensions.Databases, path + CurrentProject.DataPath);
            // Save Events
            Marshal.SaveObj(GameData.Events, path + CurrentProject.DataPath + Extensions.Events, path + CurrentProject.DataPath);
            // Save Events
            Marshal.SaveObj(GameData.GlobalEvents, path + CurrentProject.DataPath + Extensions.GlobalEvents, path + CurrentProject.DataPath);
            // Save Variables
            Marshal.SaveObj(GameData.Variables, path + CurrentProject.DataPath + Extensions.Variables, path + CurrentProject.DataPath);
            // Save Switches
            Marshal.SaveObj(GameData.Switches, path + CurrentProject.DataPath + Extensions.Switches, path + CurrentProject.DataPath);
            // Save Switches
            Marshal.SaveObj(GameData.Lists, path + CurrentProject.DataPath + Extensions.Arrays, path + CurrentProject.DataPath);
            // Save Menus
            Marshal.SaveObj(GameData.Menus, path + CurrentProject.DataPath + Extensions.Menus, path + CurrentProject.DataPath);
            // Save Switches
            Marshal.SaveObj(GameData.Items, path + CurrentProject.DataPath + Extensions.Items, path + CurrentProject.DataPath);
            // Save Materials
            Marshal.SaveObj(GameData.Materials, path + CurrentProject.DataPath + Extensions.Materials, path + CurrentProject.DataPath);
            // Save Player
            Marshal.SaveObj(GameData.Player, path + CurrentProject.DataPath + Extensions.Player, path + CurrentProject.DataPath);
            // Save Particles
            Marshal.SaveObj(GameData.ParticleSystems, path + CurrentProject.DataPath + Extensions.ParticleSystems, path + CurrentProject.DataPath);
            // Save Skins
            Marshal.SaveObj(GameData.Skins, path + CurrentProject.DataPath + Extensions.Skins, path + CurrentProject.DataPath);
            // Save Strings
            Marshal.SaveObj(GameData.Strings, path + CurrentProject.DataPath + Extensions.Strings, path + CurrentProject.DataPath);
            // Save Projectiles
            Marshal.SaveObj(GameData.Projectiles, path + CurrentProject.DataPath + Extensions.Projectiles, path + CurrentProject.DataPath);
            // Save Combos
            Marshal.SaveObj(GameData.Combos, path + CurrentProject.DataPath + Extensions.Combos, path + CurrentProject.DataPath);
            // Phys Quickset
            Marshal.SaveObj(GameData.PhysQuicksets, CurrentProject.Location + CurrentProject.DataPath + Extensions.PhysQuickset, CurrentProject.Location + CurrentProject.DataPath);
            // Save Heros
            Marshal.SaveObj(GameData.Heroes, path + CurrentProject.DataPath + Extensions.Heroes, path + CurrentProject.DataPath);
            // Save Enemies
            Marshal.SaveObj(GameData.Enemies, path + CurrentProject.DataPath + Extensions.Enemies, path + CurrentProject.DataPath);
            // Save Equipment
            Marshal.SaveObj(GameData.Equipments, path + CurrentProject.DataPath + Extensions.Equipments, path + CurrentProject.DataPath);
            // Save Skills
            Marshal.SaveObj(GameData.Skills, path + CurrentProject.DataPath + Extensions.Skills, path + CurrentProject.DataPath);
            // Save States
            Marshal.SaveObj(CurrentProject.SourceFiles, path + CurrentProject.DataPath + Extensions.Source, path + CurrentProject.DataPath);
            // Save States
            Marshal.SaveObj(GameData.States, path + CurrentProject.DataPath + Extensions.States, path + CurrentProject.DataPath);
            // Save Scenes
            foreach (MapData scene in GameData.Maps.Values)
            {
                Marshal.SaveObj(scene, path + CurrentProject.MapsInfo[scene.ID].Path + @"\" + CurrentProject.MapsInfo[scene.ID].Name + Extensions.Scene, path + CurrentProject.MapsInfo[scene.ID].Path);
            }
            // Get Scenes from Cache
            if (mapsExplorer != null)
            {
                foreach (KeyValuePair<int, string> pair in mapsExplorer.cache)
                {
                    FileInfo file = new FileInfo(pair.Value);
                    file.CopyTo(path + CurrentProject.MapsInfo[pair.Key].Path + @"\" + CurrentProject.MapsInfo[pair.Key].Name + Extensions.Scene, true);
                }
                mapsExplorer.cache.Clear();
            }

            if (sourceEditor != null)
            {
                sourceEditor.Save();
            }

            if (layout)
                SaveLayout();
            // Add to recent project
            AddRecentProject();
            Marshal.Clear();
            txtStatus2.Text = "";
        }
        private void saveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool layout = (bool)e.Argument;
            try
            {
                if (saveWorker.IsBusy)
                {
                    saveWorker.ReportProgress(0, "Saving Project..");
                    NeedSave = false;
                    Marshal.SaveObj(CurrentProject, CurrentProject.FullLocation, CurrentProject.Location);
                    saveWorker.ReportProgress(5, "Saving Animations");
                    // Save Animations
                    Marshal.SaveObj(GameData.Animations, CurrentProject.Location + CurrentProject.DataPath + Extensions.Animations, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(10, "Saving Audios");
                    // Save Audios
                    Marshal.SaveObj(GameData.Audios, CurrentProject.Location + CurrentProject.DataPath + Extensions.Audios, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(15, "Saving Tilesets");
                    // Save Tilesets
                    Marshal.SaveObj(GameData.Tilesets, CurrentProject.Location + CurrentProject.DataPath + Extensions.Tilesets, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(20, "Saving Text");
                    // Save Texts
                    foreach (string lang in CurrentProject.Languages)
                    {
                        Marshal.SaveObj(GameData.Texts[lang], CurrentProject.Location + CurrentProject.DataPath + CMD.TextCode(lang) + Extensions.Texts, CurrentProject.Location + CurrentProject.DataPath);
                    }
                    saveWorker.ReportProgress(25, "Saving Fonts");
                    // Save Fonts
                    Marshal.SaveObj(GameData.Fonts, CurrentProject.Location + CurrentProject.DataPath + Extensions.Fonts, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(30, "Saving Databases");
                    // Save Databases
                    Marshal.SaveObj(GameData.Databases, CurrentProject.Location + CurrentProject.DataPath + Extensions.Databases, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(35, "Saving Template Events");
                    // Save Events
                    Marshal.SaveObj(GameData.Events, CurrentProject.Location + CurrentProject.DataPath + Extensions.Events, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(40, "Saving Global Events");
                    // Save Events
                    Marshal.SaveObj(GameData.GlobalEvents, CurrentProject.Location + CurrentProject.DataPath + Extensions.GlobalEvents, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(45, "Saving Variables");
                    // Save Variables
                    Marshal.SaveObj(GameData.Variables, CurrentProject.Location + CurrentProject.DataPath + Extensions.Variables, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(50, "Saving Switches");
                    // Save Switches
                    Marshal.SaveObj(GameData.Switches, CurrentProject.Location + CurrentProject.DataPath + Extensions.Switches, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(55, "Saving Lists");
                    // Save Switches
                    Marshal.SaveObj(GameData.Lists, CurrentProject.Location + CurrentProject.DataPath + Extensions.Arrays, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(60, "Saving Menus");
                    // Save Menus
                    Marshal.SaveObj(GameData.Menus, CurrentProject.Location + CurrentProject.DataPath + Extensions.Menus, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(65, "Saving Items");
                    // Save Switches
                    Marshal.SaveObj(GameData.Items, CurrentProject.Location + CurrentProject.DataPath + Extensions.Items, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(70, "Saving Materials");
                    // Save Materials
                    Marshal.SaveObj(GameData.Materials, CurrentProject.Location + CurrentProject.DataPath + Extensions.Materials, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(75, "Saving Player");
                    // Save Player
                    Marshal.SaveObj(GameData.Player, CurrentProject.Location + CurrentProject.DataPath + Extensions.Player, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(80, "Saving Particles");
                    // Save Particles
                    Marshal.SaveObj(GameData.ParticleSystems, CurrentProject.Location + CurrentProject.DataPath + Extensions.ParticleSystems, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(85, "Saving Skins");
                    // Save Skins
                    Marshal.SaveObj(GameData.Skins, CurrentProject.Location + CurrentProject.DataPath + Extensions.Skins, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Strings");
                    // Save Strings
                    Marshal.SaveObj(GameData.Strings, CurrentProject.Location + CurrentProject.DataPath + Extensions.Strings, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Projectiles");
                    // Save Projectiles
                    Marshal.SaveObj(GameData.Projectiles, CurrentProject.Location + CurrentProject.DataPath + Extensions.Projectiles, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Combos");
                    // Save Combos
                    Marshal.SaveObj(GameData.Combos, CurrentProject.Location + CurrentProject.DataPath + Extensions.Combos, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Physics Quickset");
                    Marshal.SaveObj(GameData.PhysQuicksets, CurrentProject.Location + CurrentProject.DataPath + Extensions.PhysQuickset, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Heroes");
                    // Save Heros
                    Marshal.SaveObj(GameData.Heroes, CurrentProject.Location + CurrentProject.DataPath + Extensions.Heroes, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Enemies");
                    // Save Enemies
                    Marshal.SaveObj(GameData.Enemies, CurrentProject.Location + CurrentProject.DataPath + Extensions.Enemies, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Equipments");
                    // Save Equipment
                    Marshal.SaveObj(GameData.Equipments, CurrentProject.Location + CurrentProject.DataPath + Extensions.Equipments, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Skills");
                    // Save Skills
                    Marshal.SaveObj(GameData.Skills, CurrentProject.Location + CurrentProject.DataPath + Extensions.Skills, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving States");
                    // Save States
                    Marshal.SaveObj(GameData.States, CurrentProject.Location + CurrentProject.DataPath + Extensions.States, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Source");
                    // Save States
                    Marshal.SaveObj(CurrentProject.SourceFiles, CurrentProject.Location + CurrentProject.DataPath + Extensions.Source, CurrentProject.Location + CurrentProject.DataPath);
                    saveWorker.ReportProgress(90, "Saving Maps");

                    // Save Scenes
                    foreach (MapData scene in GameData.Maps.Values)
                    {
                        Marshal.SaveObj(scene, CurrentProject.Location + CurrentProject.MapsInfo[scene.ID].Path + @"\" + CurrentProject.MapsInfo[scene.ID].Name + Extensions.Scene, CurrentProject.Location + CurrentProject.MapsInfo[scene.ID].Path);
                    }

                    // Get Scenes from Cache
                    if (mapsExplorer != null)
                    {
                        foreach (KeyValuePair<int, string> pair in mapsExplorer.cache)
                        {
                            if (!GameData.Maps.ContainsKey(pair.Key))
                            {
                                FileInfo file = new FileInfo(pair.Value);
                                file.CopyTo(CurrentProject.Location + CurrentProject.MapsInfo[pair.Key].Path + @"\" + CurrentProject.MapsInfo[pair.Key].Name + Extensions.Scene, true);
                            }
                        }

                        if (Global.Project.Version != Global.EngineVersion.Split('.')[0])
                        {
                            foreach (MapInfo info in Global.Project.MapsInfo.Values)
                            {
                                string path;
                                if (!mapsExplorer.cache.TryGetValue(info.ID, out path) && !GameData.Maps.ContainsKey(info.ID))
                                {
                                    MapData scene = (MapData)Marshal.LoadData<MapData>(Global.Project.Location + info.Path + @"\" + info.Name + Extensions.Scene);
                                    Marshal.SaveObj(scene, CurrentProject.Location + CurrentProject.MapsInfo[scene.ID].Path + @"\" + CurrentProject.MapsInfo[scene.ID].Name + Extensions.Scene, CurrentProject.Location + CurrentProject.MapsInfo[scene.ID].Path);
                                }
                            }
                        }
                        mapsExplorer.cache.Clear();
                    }
                    if (sourceEditor != null)
                    {
                        sourceEditor.Save();
                    }

                    saveWorker.ReportProgress(95);
                    if (layout)
                        SaveLayout();
                    saveWorker.ReportProgress(97);
                    // Add to recent project
                    AddRecentProject();
                    Marshal.Clear();
                    saveWorker.ReportProgress(100);



                    using (StreamWriter versionFile = new StreamWriter(CurrentProject.Location + @"\version.xml"))
                    {
                        versionFile.WriteLine("<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "utf-8" + '"' + "?>");
                        versionFile.WriteLine("<config>");
                        versionFile.WriteLine("  <source>" + Global.EngineVersion + "</source>");
                        versionFile.WriteLine("</config>");
                        versionFile.Close();
                    }

                    Global.Project.Version = Global.EngineVersion.Split('.')[0];
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x054");
            }
        }
        private void saveWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            if (e.UserState != null)
                txtStatus2.Text = e.UserState.ToString();
        }
        private void saveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtStatus2.Text = "";
            progressBar.Enabled = progressBar.Visible = false;
            statusLbl.Text = "";
            statusLbl.Visible = false;
            saveToolStripButton.Checked = false;
            alphaPanel.Visible = false;
            XboxManager.CreateXboxProject(CurrentProject);

            if (Global.ImportingAudio)
            {
                statusLbl.Text = "Importing Audio... Some audio features are disabled during this process.";
            }
        }

        internal void LoadProject(string path, bool old)
        {
            if (CurrentProject != null)
                mapsExplorer.CloseAllMaps();


            saveToolStripButton.Enabled = true;
            saveToolStripMenuItem.Enabled = true;

            editorsToolStrip.Enabled = true;
            viewToolStripMenuItem.Enabled = true;

            EnableRibbon();

            editToolStripMenuItem.Enabled = true;
            gameToolStripMenuItem.Enabled = true;
            settingsBtn.Enabled = true;
            playBtn.Enabled = true;

            alphaPanel.BringToFront();
            alphaPanel.Location = new Point(0, 0);
            alphaPanel.Size = this.Size;
            alphaPanel.Visible = true;

            IsLoadingProject = true;

            loadDialogWorker.RunWorkerAsync();

            LoadProjectOnThisThread(old, path);
            FillDatabases();
            // Check Materials
            XboxManager.CreateXboxProject(CurrentProject);
            IsLoadingProject = false;
            LoadProgress = 0;

            CheckMaterials();

            ///loadWorker.RunWorkerAsync(new object[] { old, path });


        }
        private void loadDialogWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            loadDialog = new LoadDialog();
            LoadProgress = 0;
            loadDialog.Setup(0, 280);

            loadDialog.ShowDialog();
        }
        private void loadDialogWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        private void LoadProjectOnThisThread(bool old, string path)
        {
            try
            {
                LoadProgress = (0);
                bool updated = false;
                CurrentProject = new Project();
                CurrentProject.Version = GetDataVersion(path);
                SetupCategories();
                CurrentProject = Marshal.LoadData<Project>(path);
                CurrentProject.Version = GetDataVersion(path);

                if (!CheckSourceVersion(path))
                {
                    if (!updated)
                    {
                        ShowSourceUpdateFound();
                        BackUpProject(path);
                    }
                    UpdateProjectSource(path);
                }
                FileInfo file = new FileInfo(path);
                CurrentProject.Location = file.DirectoryName;
                LoadProgress = (5);
                // Load Animations
                GameData.Animations = Marshal.LoadData<Dictionary<int, AnimationData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Animations);
                LoadProgress = (10);
                // Load Audios
                GameData.Audios = Marshal.LoadData<Dictionary<int, AudioData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Audios);
                LoadProgress = (15);
                // Load Tilesets
                GameData.Tilesets = Marshal.LoadData<Dictionary<int, TilesetData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Tilesets);
                LoadProgress = (20);
                // Load Texts
                foreach (string lang in CurrentProject.Languages)
                {
                    GameData.Texts[lang] = Marshal.LoadData<Dictionary<int, TextData>>(CurrentProject.Location + CurrentProject.DataPath + CMD.TextCode(lang) + Extensions.Texts);
                }
                LoadProgress = (25);
                // Load Fonts
                GameData.Fonts = Marshal.LoadData<Dictionary<int, FontData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Fonts);
                LoadProgress = (30);
                // Load Databases
                GameData.Databases = Marshal.LoadData<Dictionary<int, Data>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Databases);
                LoadProgress = (35);
                // Load Events
                GameData.Events = Marshal.LoadData<Dictionary<int, EventData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Events);
                LoadProgress = (40);
                // Load Events
                GameData.GlobalEvents = Marshal.LoadData<Dictionary<int, GlobalEventData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.GlobalEvents);
                LoadProgress = (45);
                // Load Variables
                GameData.Variables = Marshal.LoadData<Dictionary<int, VariableData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Variables);
                LoadProgress = (50);
                // Load Switches
                GameData.Switches = Marshal.LoadData<Dictionary<int, SwitchData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Switches);
                LoadProgress = (55);
                // Load Arrays
                GameData.Lists = Marshal.LoadData<Dictionary<int, ListData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Arrays);
                LoadProgress = (60);
                // Load Items
                GameData.Items = Marshal.LoadData<Dictionary<int, ItemData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Items);
                LoadProgress = (75);
                // Load Items
                GameData.Materials = Marshal.LoadData<Dictionary<int, MaterialData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Materials);
                LoadProgress = (80);
                // Load Skins
                GameData.Skins = Marshal.LoadData<Dictionary<int, SkinData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Skins);
                LoadProgress = (85);
                // Load String
                GameData.Strings = Marshal.LoadData<Dictionary<int, StringData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Strings);
                LoadProgress = (90);
                // Load String
                GameData.Projectiles = Marshal.LoadData<Dictionary<int, ProjectileGroupData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Projectiles);
                LoadProgress = (95);
                // Load Combo
                GameData.Combos = Marshal.LoadData<Dictionary<int, ComboData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Combos);
                GameData.PhysQuicksets = Marshal.LoadData<List<PhysQuicksetData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.PhysQuickset);
                LoadProgress = (100);
                // Save Heros
                GameData.Heroes = Marshal.LoadData<Dictionary<int, HeroData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Heroes);
                LoadProgress = (105);
                // Save Enemies
                GameData.Enemies = Marshal.LoadData<Dictionary<int, EnemyData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Enemies);
                LoadProgress = (110);
                // Save Equipment
                GameData.Equipments = Marshal.LoadData<Dictionary<int, EquipmentData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Equipments);
                LoadProgress = (115);
                // Save Skills
                GameData.Skills = Marshal.LoadData<Dictionary<int, SkillData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Skills);
                LoadProgress = (120);
                // Load Particles
                GameData.ParticleSystems = Marshal.LoadData<Dictionary<int, ParticleSystemData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.ParticleSystems);
                LoadProgress = (125);
                // Save States
                GameData.States = Marshal.LoadData<Dictionary<int, StateData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.States);
                LoadProgress = (130);
                // Player
                GameData.Player = Marshal.LoadData<PlayerData>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Player);

                Global.Project.SourceFiles = Marshal.LoadData<List<SourceFile>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Source);
                // Load Menus
                GameData.Menus = Marshal.LoadData<Dictionary<int, MenuData>>(CurrentProject.Location + CurrentProject.DataPath + Extensions.Menus);

                LoadProgress = (135);

                // Beta
                CurrentProject.SourceFiles.Clear();

                CopySourceFilesToProject();

                MaterialExplorer.contentBuilder = new ContentBuilder();

                LoadProgress = (140);

                SetDockingThread(old);

                LoadProgress = 280;


                Marshal.Clear();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x055");
            }
        }
        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ((object[])e.Argument)[0];
            string path = (string)((object[])e.Argument)[1];
            LoadProjectOnThisThread((bool)e.Result, path);
        }
        private void SetDockingThread(bool old)
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { SetDockingThread(old); })));
            }
            else
            {
                SetDocking(old);

                saveToolStripButton.Checked = false;
                AddRecentProject();
                mapsExplorer.Clear();
                GameData.Maps.Clear();
                mapsExplorer.SelectMap(Global.Project.SelectedMap);
                layersExplorer.SelecteLayer(Global.Project.SelectedLayer);
                tilesExplorer.Zoom(Global.Project.TilesetZoom);
                alphaPanel.Visible = false;
                mapEditor.mapEditor2.ResetSettings();
            }
        }
        private void loadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool old = (bool)e.Result;
            FillDatabases();
            // Check Materials
            XboxManager.CreateXboxProject(CurrentProject);
            IsLoadingProject = false;
            LoadProgress = 0;

            CheckMaterials();
        }
        public static void CheckMaterials()
        {
            DirectoryInfo dir = new DirectoryInfo(CurrentProject.Location + @"\Content");
            List<MaterialData> materials = new List<MaterialData>();

            foreach (MaterialData data in GameData.Materials.Values)
            {
                if (File.Exists(Path.Combine(Global.Project.Location, data.FileName)))
                {
                    string name = MaterialExplorer.GetAssetName(new FileInfo(Path.Combine(Global.Project.Location, data.FileName)), data);

                    if (!File.Exists(Path.Combine(Global.Project.Location + @"\Content", name + ".xnb")))
                    {
                        materials.Add(data);
                    }
                }
            }
            if (materials.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("This project must be rebuild to function correctly. The build may take a few minutes. Build now?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
                {
                    foreach (MaterialData data in materials)
                    {
                        materialExplorer.contentToImport.Add(data);
                    }
                    materialExplorer.ImportContent();
                }
                else
                {
                    TemplateContent = "";
                }
            }
            else
                TemplateContent = "";
        }
        #endregion

        #region Backup Project
        /// <summary>
        /// Back up project
        /// </summary>
        /// <param name="path"></param>
        private void BackUpProject(string path)
        {
            path = path.Replace("Project.egmproj", "");
            string m_sErrorTime = DateTime.Now.ToString();
            m_sErrorTime = m_sErrorTime.Replace(@"/", "_");
            m_sErrorTime = m_sErrorTime.Replace(@":", "_");
            m_sErrorTime = m_sErrorTime.Replace(" ", "_");
            if (!Directory.Exists(path + @"Backups"))
                Directory.CreateDirectory(path + @"Backups");
            // Back up just data
            ArrayList ar = GenerateFileList(path);
            ar.AddRange(GenerateFileListRecrusive(path + "Source"));
            ar.AddRange(GenerateFileList(path + "Data"));
            ar.AddRange(GenerateFileList(path + "Maps"));
            ZipFiles(ar, path, path + @"Backups\Backup" + m_sErrorTime + ".zip", "");
        }
        public static void ZipFiles(ArrayList ar, string inputFolderPath, string outputPathAndFile, string password)
        {
            int TrimLength = (Directory.GetParent(inputFolderPath)).ToString().Length;
            // find number of chars to remove     // from orginal file path
            TrimLength += 1; //remove '\'
            FileStream ostream;
            byte[] obuffer;
            string outPath = outputPathAndFile;
            ZipOutputStream oZipStream = new ZipOutputStream(File.Create(outPath)); // create zip stream
            if (password != null && password != String.Empty)
                oZipStream.Password = password;
            oZipStream.SetLevel(9); // maximum compression
            ZipEntry oZipEntry;
            foreach (string Fil in ar) // for each file, generate a zipentry
            {
                oZipEntry = new ZipEntry(Fil.Remove(0, TrimLength));
                oZipStream.PutNextEntry(oZipEntry);

                if (!Fil.EndsWith(@"/")) // if a file ends with '/' its a directory
                {
                    ostream = File.OpenRead(Fil);
                    obuffer = new byte[ostream.Length];
                    ostream.Read(obuffer, 0, obuffer.Length);
                    oZipStream.Write(obuffer, 0, obuffer.Length);
                }
            }
            oZipStream.Finish();
            oZipStream.Close();
        }

        private static ArrayList GenerateFileList(string Dir)
        {
            ArrayList fils = new ArrayList();
            bool Empty = true;
            foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
            {
                fils.Add(file);
                Empty = false;
            }

            if (Empty)
            {
                if (Directory.GetDirectories(Dir).Length == 0)
                // if directory is completely empty, add it
                {
                    fils.Add(Dir + @"/");
                }
            }

            //foreach (string dirs in Directory.GetDirectories(Dir)) // recursive
            //{
            //    foreach (object obj in GenerateFileList(dirs))
            //    {
            //        fils.Add(obj);
            //    }
            //}
            return fils; // return file list
        }

        private static ArrayList GenerateFileListRecrusive(string Dir)
        {
            ArrayList fils = new ArrayList();
            bool Empty = true;
            foreach (string file in Directory.GetFiles(Dir)) // add each file in directory
            {
                fils.Add(file);
                Empty = false;
            }

            if (Empty)
            {
                if (Directory.GetDirectories(Dir).Length == 0)
                // if directory is completely empty, add it
                {
                    fils.Add(Dir + @"/");
                }
            }

            foreach (string dirs in Directory.GetDirectories(Dir)) // recursive
            {
                foreach (object obj in GenerateFileList(dirs))
                {
                    fils.Add(obj);
                }
            }
            return fils; // return file list
        }
        #endregion

        #region Engine Updater
        private bool CheckDataVersion(string path)
        {
            path = path.Replace("Project.egmproj", "");
            if (!File.Exists(path + @"\version.xml"))
            {
                using (StreamWriter versionFile = new StreamWriter(path + @"\version.xml"))
                {
                    versionFile.WriteLine("<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "utf-8" + '"' + "?>");
                    versionFile.WriteLine("<config>");
                    versionFile.WriteLine("  <source>" + Global.EngineVersion + "</source>");
                    versionFile.WriteLine("</config>");
                    versionFile.Close();
                }
                return true;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path + @"\version.xml");
            string[] version = doc.SelectSingleNode("config/source").InnerText.Split('.');
            if (version[0] != Global.EngineVersion.Split('.')[0])
                return false;

            return true;
        }

        private string GetDataVersion(string path)
        {
            path = path.Replace("Project.egmproj", "");
            if (!File.Exists(path + @"\version.xml"))
            {
                using (StreamWriter versionFile = new StreamWriter(path + @"\version.xml"))
                {
                    versionFile.WriteLine("<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "utf-8" + '"' + "?>");
                    versionFile.WriteLine("<config>");
                    versionFile.WriteLine("  <source>" + Global.EngineVersion + "</source>");
                    versionFile.WriteLine("</config>");
                    versionFile.Close();
                }
                return Global.EngineVersion.Split('.')[0];
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path + @"\version.xml");
            string[] version = doc.SelectSingleNode("config/source").InnerText.Split('.');
            return version[0];
        }

        private void UpdateProjectData(string path)
        {
            path = path.Replace("Project.egmproj", "");
            XmlDocument doc = new XmlDocument();
            doc.Load(path + @"\version.xml");

            // Engine updater
            string[] version = Global.EngineVersion.Split('.');
            string[] oldversion = doc.SelectSingleNode("config/source").InnerText.Split('.');

            EngineUpdater.Update(path, int.Parse(oldversion[0]), int.Parse(version[0]));

            doc.SelectSingleNode("config/source").InnerText = version[0] + "." + oldversion[1];
            doc.Save(path + @"\version.xml");
        }

        #endregion

        #region Source Updater
        private void UpdateProjectSource(string path)
        {
            path = path.Replace("Project.egmproj", "");

            XmlDocument doc = new XmlDocument();
            doc.Load(path + @"\version.xml");

            ArrayList deleteList = new ArrayList();
            ArrayList moveList = new ArrayList();
            ArrayList moveTo = new ArrayList();
            string[] oldversion = doc.SelectSingleNode("config/source").InnerText.Split('.');

            switch (oldversion[1])
            {
                #region v1
                case "1":
                    // To DO Record moved or deleted files.

                    break;
                #endregion
            }
            if (moveList.Count > 0)
            {
                ShowSourceMovedFound(moveList, moveTo, path);
            }
            if (deleteList.Count > 0)
            {
                ShowSourceDeletedFound(deleteList, path);
            }

            ArrayList createList = new ArrayList();
            ArrayList modified = new ArrayList();

            CheckSourceDirectory(createList, modified, path, Application.StartupPath + @"\Source");


            if (createList.Count > 0)
            {
                ShowSourceCreatedFound(createList, path);
            }

            if (modified.Count > 0)
            {
                ShowSourceModifiedFound(modified, path);
            }


            string[] version = Global.EngineVersion.Split('.');
            doc.SelectSingleNode("config/source").InnerText = oldversion[0] + "." + version[1];
            doc.Save(path + @"\version.xml");
        }

        private void CheckSourceDirectory(ArrayList createList, ArrayList modified, string path, string directory)
        {
            FileInfo file;
            foreach (string sourceFile in Directory.GetFiles(directory))
            {
                file = new FileInfo(sourceFile);

                if (file.Extension == ".cs")
                {
                    ModificationType type = FileCompare.CompareFiles(file.FullName, file.FullName.Replace(Application.StartupPath, path));

                    switch (type)
                    {
                        case ModificationType.Created:
                            createList.Add(file.FullName);
                            break;
                        case ModificationType.Modified:
                            modified.Add(file.FullName);
                            break;
                    }
                }
            }

            foreach (string nextDirectory in Directory.GetDirectories(directory))
            {
                CheckSourceDirectory(createList, modified, path, nextDirectory);
            }
        }

        private bool CheckSourceVersion(string path)
        {
            path = path.Replace("Project.egmproj", "");
            if (!File.Exists(path + @"\version.xml"))
            {
                using (StreamWriter versionFile = new StreamWriter(path + @"\version.xml"))
                {
                    versionFile.WriteLine("<?xml version=" + '"' + "1.0" + '"' + " encoding=" + '"' + "utf-8" + '"' + "?>");
                    versionFile.WriteLine("<config>");
                    versionFile.WriteLine("  <source>" + Global.EngineVersion + "</source>");
                    versionFile.WriteLine("</config>");
                    versionFile.Close();
                }
                return true;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(path + @"\version.xml");
            string[] version = doc.SelectSingleNode("config/source").InnerText.Split('.');
            if (version[1] != Global.EngineVersion.Split('.')[1])
                return false;
            return true;
        }
        private void ShowDataUpdateFound()
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { ShowSourceUpdateFound(); })));
            }
            else
            {
                MessageBox.Show("This project needs to be updated to work with the the current version of Express Game Maker.\nA backup is available in the project's folder.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ShowSourceUpdateFound()
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { ShowSourceUpdateFound(); })));
            }
            else
            {
                MessageBox.Show("The engine source has been updated! Please update this project's source.\nA backup is available in the project's folder.", "Express Game Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ShowSourceCreatedFound(ArrayList createList, string path)
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { ShowSourceCreatedFound(createList, path); })));
            }
            else
            {
                SourceCreated dialog = new SourceCreated();
                dialog.Setup(createList, path, CurrentProject);
                dialog.ShowDialog();
            }
        }
        private void ShowSourceMovedFound(ArrayList moveList, ArrayList moveTo, string path)
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { ShowSourceMovedFound(moveList, moveTo, path); })));
            }
            else
            {
                SourceMoved dialog = new SourceMoved();
                dialog.Setup(moveList, moveTo, path, CurrentProject);
                dialog.ShowDialog();
            }
        }

        private void ShowSourceDeletedFound(ArrayList deleteList, string path)
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { ShowSourceDeletedFound(deleteList, path); })));
            }
            else
            {
                SourceDeleted dialog = new SourceDeleted();
                dialog.Setup(deleteList, path, CurrentProject);
                dialog.ShowDialog();
            }
        }

        private void ShowSourceModifiedFound(ArrayList modified, string path)
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { ShowSourceModifiedFound(modified, path); })));
            }
            else
            {

                SourceModified dialog = new SourceModified();
                dialog.Setup(modified, path, CurrentProject);
                dialog.ShowDialog();
            }
        }
        #endregion

        #region Layout Settings
        /// <summary>
        /// Save docking layout
        /// </summary>
        private void SaveLayout()
        {
            try
            {
                if (!mapEditor.IsActivated)
                    mapEditor.ShowFloatingWindows();
                if (CurrentProject != null)
                    dockPanel.SaveAsXml(Path.Combine(CurrentProject.Location, CurrentProject.LayoutConfig));
                if (!mapEditor.IsActivated)
                    mapEditor.HideFloatingWindows();

            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x056");
            }
        }
        /// <summary>
        /// Load docking layout
        /// </summary>
        public static bool loadingLayout = false;
        private void LoadLayout()
        {
            try
            {
                if (CurrentProject != null)
                {

                    dockPanel.SuspendLayout(true);

                    // In order to load layout from XML, we need to close all the DockContents
                    CloseAllContents();

                    if (homePage == null || homePage.IsDisposed)
                        homePage = new HomePage();
                    loadingLayout = true;

                    try
                    {
                        if (!File.Exists(Path.Combine(CurrentProject.Location, CurrentProject.LayoutConfig)))
                        {
                            File.Copy(CurrentProject.LayoutConfig, Path.Combine(CurrentProject.Location, CurrentProject.LayoutConfig));
                        }
                    }
                    catch { }

                    try
                    {
                        dockPanel.LoadFromXml(Path.Combine(CurrentProject.Location, CurrentProject.LayoutConfig), m_deserializeDockContent);
                    }
                    catch
                    {

                    }
                    dockPanel.ResumeLayout(true, true);
                    loadingLayout = false;

                    if (!mapEditor.IsActivated)
                        mapEditor.HideFloatingWindows();
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x057");
            }
        }
        private void CloseAllContents()
        {
            try
            {
                // we don't want to create another instance of tool window, set DockPanel to null
                if (materialExplorer != null)
                {
                    feedbackPanel.DockPanel = null;
                    sourceEditor.DockPanel = null;
                    materialExplorer.DockPanel = null;
                    mapEventsExplorer.DockPanel = null;
                    mapsExplorer.DockPanel = null;
                    databaseExplorer.DockPanel = null;
                    errorExplorer.DockPanel = null;
                    tutorialExplorer.DockPanel = null;
                    materialExplorer.DockPanel = null;
                    HistoryExplorer.DockPanel = null;
                    materialPreview.DockPanel = null;
                    itemSettings.DockPanel = null;
                    layersExplorer.DockPanel = null;
                    tilesExplorer.DockPanel = null;
                    menuPartsExplorer.DockPanel = null;
                    menuPropertyExplorer.DockPanel = null;
                    eventsExplorer.DockPanel = null;
                    mapEditor.DockPanel = null;
                    animationEditor.DockPanel = null;
                    settingsForm.DockPanel = null;
                    tilesetEditor.DockPanel = null;
                    audioEditor.DockPanel = null;
                    projectileEditor.DockPanel = null;
                    comboEdtor.DockPanel = null;
                    itemEditor.DockPanel = null;
                    equipmentEditor.DockPanel = null;
                    skillsEditor.DockPanel = null;
                    statesEditor.DockPanel = null;
                    heroEditor.DockPanel = null;
                    enemyEditor.DockPanel = null;
                    textEditor.DockPanel = null;
                    fontEditor.DockPanel = null;
                    eventEditor.DockPanel = null;
                    playerEditor.DockPanel = null;
                    databaseEditor.DockPanel = null;
                    variablesEditor.DockPanel = null;
                    stringsEditor.DockPanel = null;
                    switchesEditor.DockPanel = null;
                    menuEditor.DockPanel = null;
                    globalEventEditor.DockPanel = null;
                    listEditor.DockPanel = null;
                    particleEditor.DockPanel = null;
                    skinEditor.DockPanel = null;
                    stringEditor.DockPanel = null;
                }
                // Close all other document windows
                CloseAllDocuments();
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x058");
            }
        }
        private void CloseAllDocuments()
        {
            try
            {
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    foreach (Form form in MdiChildren)
                        form.Close();
                }
                else
                {
                    for (int index = dockPanel.Contents.Count - 1; index >= 0; index--)
                    {
                        if (dockPanel.Contents[index] is IDockContent)
                        {
                            IDockContent content = (IDockContent)dockPanel.Contents[index];
                            content.DockHandler.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x059");
            }
        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            try
            {
                IDockContent content;
                if (persistString == typeof(AnimationEditor).ToString())
                    content = animationEditor;
                else if (persistString == typeof(MaterialPreviewDock).ToString())
                    content = materialPreview;
                else if (persistString == typeof(ItemSettingsForm).ToString())
                    content = itemSettings;
                else if (persistString == typeof(HomePage).ToString())
                    content = homePage;
                else if (persistString == typeof(AudioEditor).ToString())
                    content = audioEditor;
                else if (persistString == typeof(ProjectileEditor).ToString())
                    content = projectileEditor;
                else if (persistString == typeof(ComboEditor).ToString())
                    content = comboEdtor;
                // else if (persistString == typeof(HomePage).ToString())
                //return homePage;
                else if (persistString == typeof(ParticleEditor).ToString())
                    content = particleEditor;
                else if (persistString == typeof(SkinEditor).ToString())
                    content = skinEditor;
                else if (persistString == typeof(StringEditor).ToString())
                    content = stringEditor;
                else if (persistString == typeof(ListEditor).ToString())
                    content = listEditor;
                else if (persistString == typeof(EventEditor).ToString())
                    content = eventEditor;
                else if (persistString == typeof(GlobalEventEditor).ToString())
                    content = globalEventEditor;
                else if (persistString == typeof(PlayerEditor).ToString())
                    content = playerEditor;
                else if (persistString == typeof(FontEditor).ToString())
                    content = fontEditor;
                else if (persistString == typeof(ItemEditor).ToString())
                    content = itemEditor;
                else if (persistString == typeof(EquipmentEditor).ToString())
                    content = equipmentEditor;
                else if (persistString == typeof(SkillsEditor).ToString())
                    content = skillsEditor;
                else if (persistString == typeof(StatesEditor).ToString())
                    content = statesEditor;
                else if (persistString == typeof(EnemiesEditor).ToString())
                    content = enemyEditor;
                else if (persistString == typeof(HeroEditor).ToString())
                    content = heroEditor;
                else if (persistString == typeof(MenuEditor).ToString())
                    content = menuEditor;
                else if (persistString == typeof(MapEditor).ToString())
                    content = mapEditor;
                else if (persistString == typeof(SwitchesEditor).ToString())
                    content = switchesEditor;
                else if (persistString == typeof(TextEditor).ToString())
                    content = textEditor;
                else if (persistString == typeof(TilesetEditor).ToString())
                    content = tilesetEditor;
                else if (persistString == typeof(SettingsForm).ToString())
                    content = settingsForm;
                else if (persistString == typeof(VariablesEditor).ToString())
                    content = variablesEditor;
                else if (persistString == typeof(StringEditor).ToString())
                    content = stringsEditor;
                else if (persistString == typeof(DatabaseEditor).ToString())
                    content = databaseEditor;
                else if (persistString == typeof(ErrorExplorer).ToString())
                    content = errorExplorer;
                else if (persistString == typeof(TutorialExplorer).ToString())
                    content = tutorialExplorer;
                else if (persistString == typeof(EventExplorer).ToString())
                    content = eventsExplorer;
                else if (persistString == typeof(HistoryExplorer).ToString())
                    content = HistoryExplorer;
                else if (persistString == typeof(SourceEditor).ToString())
                    content = sourceEditor;
                else if (persistString == typeof(LayersExplorer).ToString())
                    content = layersExplorer;
                else if (persistString == typeof(TilesExplorer).ToString())
                    content = tilesExplorer;
                else if (persistString == typeof(MaterialExplorer).ToString())
                    content = materialExplorer;
                else if (persistString == typeof(MenuPartsExplorer).ToString())
                    content = menuPartsExplorer;
                else if (persistString == typeof(MapEventsExplorer).ToString())
                    content = mapEventsExplorer;
                else if (persistString == typeof(ObjectPropertyExplorer).ToString())
                    content = menuPropertyExplorer;
                else if (persistString == typeof(MapsExplorer).ToString())
                    content = mapsExplorer;
                else if (persistString == typeof(DatabaseExplorer).ToString())
                    content = databaseExplorer;
                else if (persistString == typeof(FeedbackPanel).ToString())
                    content = feedbackPanel;
                else
                    content = null;
                return content;
                if (content != null && ((DockContent)content).Visible)
                    return content;
            }
            catch (Exception ex)
            {
                Error.ShowLogError(ex, "1x060");
            }
            return null;
        }
        #endregion

        #region DockPanel and Document Events
        private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (CurrentProject != null)
            {
                if (dockPanel.ActiveDocument is MapEditor)
                {
                    // Show map editor floats
                    //if (layersExplorer.IsFloat)
                    //{
                    //    layersExplorer.Visible = true;
                    //}
                }
                else
                {
                    //// Hide map editor floats
                    //if (layersExplorer.IsFloat)
                    //{
                    //    layersExplorer.Visible = false;
                    //}
                }
            }
        }

        private void resetWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Project != null)
            {
                ResetControls(); LoadLayout();
            }
        }
    
        private void ResetControls()
        {
            // Close All Data
            foreach (DataEditor e in dataEditors)
            {
                e.Close();
                e.Dispose();
            }
            // Reset List
            dataEditorIDs = new List<int>();
            dataEditors = new List<DataEditor>();
            feedbackPanel.Hide();
            materialExplorer.Hide();
            sourceEditor.Hide();
            mapEventsExplorer.Hide();
            mapsExplorer.Hide();
            databaseExplorer.Hide();
            HistoryExplorer.Hide();
            materialPreview.Hide();
            itemSettings.Hide();
            layersExplorer.Hide();
            tilesExplorer.Hide();
            menuPartsExplorer.Hide();
            menuPropertyExplorer.Hide();
            eventsExplorer.Hide();
            errorExplorer.Hide();
            tutorialExplorer.Hide();
            mapEditor.Hide();
            animationEditor.Hide();
            settingsForm.Hide();
            tilesetEditor.Hide();
            audioEditor.Hide();
            projectileEditor.Hide();
            comboEdtor.Hide();
            textEditor.Hide();
            fontEditor.Hide();
            eventEditor.Hide();
            playerEditor.Hide();
            databaseEditor.Hide();
            stringsEditor.Hide();
            variablesEditor.Hide();
            switchesEditor.Hide();
            listEditor.Hide();
            menuEditor.Hide();
            particleEditor.Hide();
            skinEditor.Hide();
            stringEditor.Hide();
            globalEventEditor.Hide();
            itemEditor.Hide();
            equipmentEditor.Hide();
            skillsEditor.Hide();
            statesEditor.Hide();
            heroEditor.Hide();
            enemyEditor.Hide();
        }
        #endregion

        #region Debug Events

        #endregion

        #region Export
        private void exportAsTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Project == null)
                return;


            progressBar.Enabled = progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            statusLbl.Enabled = statusLbl.Visible = true;
            statusLbl.Text = "Exporting...";
            alphaPanel.BringToFront();
            alphaPanel.Visible = true;
            alphaPanel.Location = new System.Drawing.Point(0, 0);
            alphaPanel.Size = Size;

            exportWorker.RunWorkerAsync();
        }

        private void exportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (NeedSave)
            {
                if (DialogResult.No == MessageBox.Show("The project must be saved before exporting. Save?", "Express Game Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                {
                    return;
                }
                SaveProject(true, false);
            }
            // Path
            string path = Global.Project.Location;
            // Copy To Templates Directory
            DirectoryInfo dir = Directory.CreateDirectory(Path.Combine(Application.StartupPath, @"Express Templates\" + Global.Project.Name));
            File.Copy(Path.Combine(path, "Project.egmproj"), Path.Combine(dir.FullName, "Project.egmproj"));
            File.Copy(Path.Combine(path, Global.Project.Icon), Path.Combine(dir.FullName, Global.Project.Icon));
            File.Copy(Path.Combine(path, Global.Project.LayoutConfig), Path.Combine(dir.FullName, Global.Project.LayoutConfig));
            CMD.CopyFolder(path + @"\Materials", Path.Combine(Application.StartupPath, @"Express Templates\" + Global.Project.Name + @"\Materials"));
            CMD.CopyFolder(path + @"\Content", Path.Combine(Application.StartupPath, @"Express Templates\" + Global.Project.Name + @"\Content"));
            CMD.CopyFolder(path + @"\Data", Path.Combine(Application.StartupPath, @"Express Templates\" + Global.Project.Name + @"\Data"));
            CMD.CopyFolder(path + @"\Maps", Path.Combine(Application.StartupPath, @"Express Templates\" + Global.Project.Name + @"\Maps"));
            CMD.CopyFolder(path + @"\Source", Path.Combine(Application.StartupPath, @"Express Templates\" + Global.Project.Name + @"\Source"));
        }

        private void exportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Enabled = progressBar.Visible = false;
            progressBar.Style = ProgressBarStyle.Blocks;
            statusLbl.Text = "";
            statusLbl.Visible = false;
            alphaPanel.Visible = false;
        }
        #endregion

        #region Splash Dialog Background
        private void splashWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Splash splash = new Splash();
            try
            {
                if (splash.ShowDialog(null) == System.Windows.Forms.DialogResult.OK)
                {
                    Thread.Sleep(100);
                    if (this.InvokeRequired)
                        this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { this.TopMost = false; })));

                }
                else
                {
                    if (this.InvokeRequired)
                        this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { Application.Exit(); })));
                }
            }
            catch
            {
            }
        }
        #endregion

        #region Global Key Activity Cheker
        private KeyMessageFilter m_filter = new KeyMessageFilter();

        private void keyTimer_Tick(object sender, EventArgs e)
        {
            if (Global.Project != null && GameData.Maps != null && !alphaPanel.Visible)
            {
                if (m_filter.IsKeyPressed(Keys.F5))
                {
                    this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate() { playBtn_Click(this, EventArgs.Empty); })));
                }
                if (m_filter.IsKeyPressed(Keys.Left))
                    MainForm.animationEditor.animationComp.graphicsControl_KeyDown(this, new KeyEventArgs(Keys.Left));
                if (m_filter.IsKeyPressed(Keys.Right))
                    MainForm.animationEditor.animationComp.graphicsControl_KeyDown(this, new KeyEventArgs(Keys.Right));
                if (m_filter.IsKeyPressed(Keys.Up))
                    MainForm.animationEditor.animationComp.graphicsControl_KeyDown(this, new KeyEventArgs(Keys.Up));
                if (m_filter.IsKeyPressed(Keys.Down))
                    MainForm.animationEditor.animationComp.graphicsControl_KeyDown(this, new KeyEventArgs(Keys.Down));


                if (m_filter.IsKeyPressed(Keys.Escape))
                {
                    if (mapEditor.mapEditor2.mapViewer.eventDialog.Visible)
                        mapEditor.mapEditor2.mapViewer.eventDialog.Hide();
                }
            }
        }
        #endregion

        #region Crash Recovery
        internal void MainForm_Crashed()
        {

        }
        private void bgBackupSave_DoWork(object sender, DoWorkEventArgs e)
        {
        }
        private void bgBackupSave_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        private void bgBackupSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        /// <summary>
        /// This is where you try and persist your data in the event of a crash.  
        /// </summary>
        public void ApplicationRecovery_OnApplicationCrash()
        {
            try
            {
                if (Global.Project != null)
                {
                    string date = DateTime.Now.ToString();
                    date = date.Replace(@"/", "-");
                    date = date.Replace(@":", "-");
                    // Create Recovery Folder
                    DirectoryInfo dir = new DirectoryInfo(Path.Combine(Path.Combine(Application.StartupPath, "Crash Recovery"), Global.Project.Name + " " + date));
                    dir.Create();
                    Configuration.CrashedProjects.Add(Global.Project.Name + " " + date + "*" + Global.Project.Location);
                    Config.Save();
                    DirectoryInfo mapdir = new DirectoryInfo(dir.FullName + @"\Maps");
                    mapdir.Create();
                    Save(dir.FullName, false);
                    //Let the application recovery know that you finished successfully.
                    ApplicationRecovery.ApplicationRecoveryFinished(true);
                }
            }
            catch
            {
                //Or let it know that recovery failed.
                ApplicationRecovery.ApplicationRecoveryFinished(false);
            }
        }
        /// <summary>
        /// Recovery
        /// </summary>
        /// <returns></returns>
        private bool RecoverData()
        {
            bool result;

            try
            {
                if (Configuration.CrashedProjects.Count > 0)
                {
                    CrashRecoveryDialog dialog = new CrashRecoveryDialog();
                    dialog.ShowDialog();
                    Config.Save();
                }
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
        #endregion

        /// <summary>
        /// Reset EGM in the case of an UnexpectedDeviceError.
        /// </summary>
        internal static void ResetEGM()
        {
            MessageBox.Show("If you see this message, please email contact@expressgamemaker.com.\nSubject:Error Code: UnexpectedDeviceError");
        }

    }

    /// <summary>
    /// KeyMessageFilter - Use to capture keyboard actions.
    /// </summary>
    public class KeyMessageFilter : IMessageFilter
    {
        private Dictionary<Keys, bool> m_keyTable = new Dictionary<Keys, bool>();

        public Dictionary<Keys, bool> KeyTable
        {
            get { return m_keyTable; }
            private set { m_keyTable = value; }
        }

        public bool IsKeyPressed()
        {
            return m_keyPressed;
        }

        public bool IsKeyPressed(Keys k)
        {
            bool pressed = false;

            if (KeyTable.TryGetValue(k, out pressed))
            {
                KeyTable.Remove(k);
                return pressed;
            }

            return false;
        }

        private const int WM_KEYDOWN = 0x0100;

        private const int WM_KEYUP = 0x0101;

        private bool m_keyPressed = false;


        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                KeyTable[(Keys)m.WParam] = true;

                m_keyPressed = true;
            }

            if (m.Msg == WM_KEYUP)
            {
                KeyTable[(Keys)m.WParam] = false;

                m_keyPressed = false;
            }

            return false;
        }
    }
}
