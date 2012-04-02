//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using EGMGame.Extensions;
using EGMGame.Interfaces;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.GamerServices;
using System.IO;

namespace EGMGame.Processors
{

    public class GlobalEventProcessor : Interpreter
    {
        [XmlIgnore, DoNotSerialize]
        public GlobalEventData Data
        {
            get { return (data == null ? data = GameData.GlobalEvents[id] : data); }
            set { data = value; }
        } GlobalEventData data;
        // Unique ID Count
        public int UniqueIDCount = 0;

        #region Field: Event Program
        // Page Index
        public int pageIndex = -1;
        // Is Auto Run
        public bool IsAutoRun = false;
        // This Event's Movement Processor
        public MovementProcessor ActiveMovementProcessor;
        #endregion

        #region Constructor and Setuo
        /// <summary>
        /// Constructor
        /// </summary>
        public GlobalEventProcessor() { }
        /// <summary>
        /// Initialize Event
        /// </summary>
        /// <param name="eventData"></param>
        public GlobalEventProcessor(GlobalEventData eventData)
        {
            data = eventData;
            id = data.ID;
        }
        #endregion

        #region Update: Event
        /// <summary>
        /// Update the event
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Update only if  data exists
            if (data != null)
            {
                if (waitFrames > 0)
                    waitFrames--;

                if ((Global.Instance.GlobalAutorunID > -1 && ID == Global.Instance.GlobalAutorunID) || Global.Instance.GlobalAutorunID == -1)
                {
                    // Check if any messages are active
                    for (int i = 0; i < Global.Messages.Count; i++)
                        if (Global.Messages[i].WaitOnClose)
                            return;
                    // Check if any menus are active
                    for (int i = 0; i < Global.Menus.Count; i++)
                        if (Global.Menus[i].WaitOnClose)
                            return;
                    // Process Event Page
                    ProcessEventPage(gameTime);
                }
            }
        }
        /// <summary>
        /// Action Complete
        /// Called when an action is complete.
        /// </summary>
        /// <param name="type"></param>
        public void ActionComplete(ActionType type)
        {
            if (type == actionTakingPlace)
            {
                switch (actionTakingPlace)
                {
                    case ActionType.Tint:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.Flash:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.Shake:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.Video:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.FindingPath:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.PictureTint:
                        actionTakingPlace = ActionType.None;
                        break;
                    case ActionType.MovementProgram:
                        actionTakingPlace = ActionType.None;
                        break;
                }
            }
        }
        #endregion

        #region Method: Page Setup - Process, Clear, Setup Page
        /// <summary>
        /// Process Event Page
        /// </summary>
        /// <param name="gameTime"></param>
        private void ProcessEventPage(GameTime gameTime)
        {
            for (int index = data.Pages.Count - 1; index >= 0; index--)
            {
                if (PageActive(index))
                {
                    if (pageIndex != index)
                    {
                        SetupPage(ref index);
                    }
                    ProcessPage(index, gameTime);
                    break;
                }
                else if (pageIndex == index)
                {
                    ClearPage(ref pageIndex);
                }
            }
        }
        /// <summary>
        /// Clear Page
        /// </summary>
        /// <param name="pageIndex"></param>
        private void ClearPage(ref int pageIndex)
        {
            // Save Branch if empty
            labels.Clear();
            LastBranch.Clear();
            // Check Trigger
            isProgramActive = false;

            pageIndex = -1;

            UniqueIDCount = 0;
        }
        /// <summary>
        /// Setup the page
        /// </summary>
        /// <param name="index"></param>
        private void SetupPage(ref int index)
        {
            // Save Branch if empty
            labels.Clear();
            LastBranch.Clear();
            UniqueIDCount = 0;
            pageIndex = index;
            CurrentBranch = data.Pages[pageIndex];
            // Check Trigger
            if (data.Pages[index].TriggerConditions == TriggerConditions.AutorunOnce)
            {
                isProgramActive = true;
                Global.Instance.GlobalAutorunID = id;
            }
        }
        /// <summary>
        /// Returns whether if the page is active
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool PageActive(int index)
        {
            bool activate = true;
            // Check Switches
            if (data.Pages[index].SwitchCondition)
            {
                for (int csIndex = 0; csIndex < data.Pages[index].SwitchConditions.Count; csIndex++)
                {
                    if (Global.Instance.Switches[data.Pages[index].SwitchConditions[csIndex].SwitchID].State == data.Pages[index].SwitchConditions[csIndex].State)
                    {
                        activate = true;
                        if (data.Pages[index].SwitchConditions[csIndex].OR)
                            return activate;
                    }
                    else
                    {
                        activate = false;
                        if (!data.Pages[index].SwitchConditions[csIndex].OR)
                            return activate;
                    }
                }
            }
            // Check Variables
            if (data.Pages[index].VariableCondition)
            {
                for (int cvIndex = 0; cvIndex < data.Pages[index].VariableConditions.Count; cvIndex++)
                {
                    if (CheckVariableCondition(data.Pages[index].VariableConditions[cvIndex]))
                    {
                        activate = true;
                        if (data.Pages[index].VariableConditions[cvIndex].OR)
                            return activate;
                    }
                    else
                    {
                        activate = false;
                        if (!data.Pages[index].VariableConditions[cvIndex].OR)
                            return activate;
                    }
                }
            }
            // Check Local Switches
            if (data.Pages[index].LocalSwitchCondition)
            {
                for (int clsIndex = 0; clsIndex < data.Pages[index].LocalSwitchConditions.Count; clsIndex++)
                {
                    if (data.Switches[data.Pages[index].LocalSwitchConditions[clsIndex].SwitchID].State == data.Pages[index].LocalSwitchConditions[clsIndex].State)
                    {
                        activate = true;
                        if (data.Pages[index].LocalSwitchConditions[clsIndex].OR)
                            return activate;
                    }
                    else
                    {
                        activate = false;
                        if (!data.Pages[index].LocalSwitchConditions[clsIndex].OR)
                            return activate;
                    }
                }
            }
            // Check Local Variables
            if (data.Pages[index].LocalVariableCondition)
            {
                for (int cvIndex = 0; cvIndex < data.Pages[index].LocalVariableConditions.Count; cvIndex++)
                {
                    if (CheckVariableCondition(data.Pages[index].LocalVariableConditions[cvIndex]))
                    {
                        activate = true;
                        if (data.Pages[index].LocalVariableConditions[cvIndex].OR)
                            return activate;
                    }
                    else
                    {
                        activate = false;
                        if (!data.Pages[index].LocalVariableConditions[cvIndex].OR)
                            return activate;
                    }
                }
            }
            // Check Screen Location

            // Return result
            return activate;
        }
        /// <summary>
        /// Checks the variable condition
        /// </summary>
        /// <param name="variableCondition"></param>
        /// <returns></returns>
        private bool CheckVariableCondition(VariableCondition variableCondition)
        {
            float variable = Global.Instance.Variables[variableCondition.VariableID].Value;
            switch (variableCondition.Type)
            {
                case 0: // Number
                    switch (variableCondition.Condition)
                    {
                        case VariableConditions.Equals:
                            if (variableCondition.Value == variable)
                                return true;
                            break;
                        case VariableConditions.GreaterThan:
                            if (variable > variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.GreaterThanEquals:
                            if (variable >= variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.LessThan:
                            if (variable < variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.LessThanEquals:
                            if (variable <= variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.NotEquals:
                            if (variable != variableCondition.Value)
                                return true;
                            break;
                    }
                    break;
                case 1: // Variable
                    float compVariable = Global.Instance.Variables[variableCondition.CompVariableID].Value;
                    switch (variableCondition.Condition)
                    {
                        case VariableConditions.Equals:
                            if (variable == compVariable)
                                return true;
                            break;
                        case VariableConditions.GreaterThan:
                            if (variable > compVariable)
                                return true;
                            break;
                        case VariableConditions.GreaterThanEquals:
                            if (variable >= compVariable)
                                return true;
                            break;
                        case VariableConditions.LessThan:
                            if (variable < compVariable)
                                return true;
                            break;
                        case VariableConditions.LessThanEquals:
                            if (variable <= compVariable)
                                return true;
                            break;
                        case VariableConditions.NotEquals:
                            if (variable != compVariable)
                                return true;
                            break;
                    }
                    break;
            }
            return false;
        }
        /// <summary>
        /// Check the local variable's condition
        /// </summary>
        /// <param name="localVariableCondition"></param>
        /// <returns></returns>
        private bool CheckVariableCondition(LocalVariableCondition variableCondition)
        {
            float variable = data.Variables[variableCondition.VariableID].Value;
            switch (variableCondition.Type)
            {
                case 0: // Number
                    switch (variableCondition.Condition)
                    {
                        case VariableConditions.Equals:
                            if (variableCondition.Value == variable)
                                return true;
                            break;
                        case VariableConditions.GreaterThan:
                            if (variable > variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.GreaterThanEquals:
                            if (variable >= variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.LessThan:
                            if (variable < variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.LessThanEquals:
                            if (variable <= variableCondition.Value)
                                return true;
                            break;
                        case VariableConditions.NotEquals:
                            if (variable != variableCondition.Value)
                                return true;
                            break;
                    }
                    break;
                case 1: // Variable
                    float compVariable = Global.Instance.Variables[variableCondition.CompVariableID].Value;
                    switch (variableCondition.Condition)
                    {
                        case VariableConditions.Equals:
                            if (variable == compVariable)
                                return true;
                            break;
                        case VariableConditions.GreaterThan:
                            if (variable > compVariable)
                                return true;
                            break;
                        case VariableConditions.GreaterThanEquals:
                            if (variable >= compVariable)
                                return true;
                            break;
                        case VariableConditions.LessThan:
                            if (variable < compVariable)
                                return true;
                            break;
                        case VariableConditions.LessThanEquals:
                            if (variable <= compVariable)
                                return true;
                            break;
                        case VariableConditions.NotEquals:
                            if (variable != compVariable)
                                return true;
                            break;
                    }
                    break;
            }
            return false;
        }
        /// <summary>
        /// Processes the programs in the page
        /// </summary>
        /// <param name="index"></param>
        private void ProcessPage(int index, GameTime gameTime)
        {
            // Process trigger if not active
            if (!isProgramActive)
                ProcessProgramTriggers();
            // Check waiting time
            if (waitFrames <= 0)
            {
                if (ActiveMovementProcessor != null && actionTakingPlace == ActionType.MovementProgram)
                {
                    if (ActiveMovementProcessor.IsDone)
                    {
                        ActiveMovementProcessor = null;
                        actionTakingPlace = ActionType.None;
                        waitActionCompelition = false;
                    }
                }
                // Return if there is an action taking place and must be completed
                if (!(actionTakingPlace != ActionType.None && waitActionCompelition))
                {
                    // Reset wait
                    waitActionCompelition = false;
                    // Process Page Commands if active
                    if (isProgramActive)
                        ProcessPrograms();
                }
            }
        }
        /// <summary>
        /// Process Program Triggers
        /// Parallel Process
        /// AutoRun
        /// </summary>
        private void ProcessProgramTriggers()
        {
            // Auto-run or parallel process triggers
            if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.BackgroundProcess || data.Pages[pageIndex].TriggerConditions == TriggerConditions.AutorunLoop)
            {
                isProgramActive = true;
                if (data.Pages[pageIndex].TriggerConditions == TriggerConditions.AutorunLoop)
                {
                    IsAutoRun = true;
                }
            }
        }
        #endregion

        #region Method: Process Program
        /// <summary>
        /// Process Programs
        /// </summary>
        private void ProcessPrograms()
        {
            if (!(actionTakingPlace != ActionType.None && waitActionCompelition) && waitFrames <= 0)
            {
                if (programIndex > -1 && programIndex < CurrentBranch.Programs.Count)
                {
                    if (CurrentBranch.Enabled && CurrentBranch.Programs[programIndex].Enabled)
                    {
                        if (CurrentBranch.UniqueID == -1)
                            CurrentBranch.UniqueID = UniqueIDCount++;

                        switch (CurrentBranch.Programs[programIndex].ProgramCategory)
                        {
                            case ProgramCategory.Movement: // Movement
                                ProcessCategoryMovement(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Settings: // Settings
                                ProcessCategorySettings(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Display: // Display
                                ProcessCategoryDisplay(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Conditions: // Conditions
                                ProcessCategoryConditions(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Loops: // Loops
                                ProcessCategoryLoop(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Audio: // Audio
                                ProcessCategoryAudio(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Data: // Data
                                ProcessCategoryData(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Event: // Event
                                ProcessCategoryEvent(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Map: // Map
                                ProcessCategoryMap(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Screen: // Screen
                                ProcessCategoryScreen(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Guide: // Memory
                                ProcessCategoryGuide(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Other: // Other
                                ProcessCategoryOther(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Party: // Party
                                ProcessCategoryParty(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Hero: // Hero
                                ProcessCategoryHero(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Battle: // Battle
                                ProcessCategoryBattle(CurrentBranch.Programs[programIndex], ref programIndex, null);
                                break;
                            case ProgramCategory.Graphics: // Graphics
                                ProcessCategoryGraphics(CurrentBranch.Programs[programIndex], ref programIndex);
                                break;
                        }
                    }
                    else
                    {
                        programIndex++;
                    }
                }
                else if (programIndex >= CurrentBranch.Programs.Count)
                {
                    // If this is the top most branch, end
                    if (LastBranch.Count == 0)
                    {
                        isProgramActive = false;
                        programIndex = 0;
                        labels.Clear();
                        // If not loop
                        if (data.Pages[pageIndex].TriggerConditions != TriggerConditions.AutorunLoop)
                            Global.Instance.GlobalAutorunID = -1;
                        // Check if Player Locked
                        if (Global.Instance.LockPlayer[0] == 1 && Global.Instance.LockPlayer[1] == id)
                            Global.Instance.LockPlayer[1] = -1;
                        return;
                    }
                    // Check if its a loop
                    if (CurrentBranch.ProgramCategory == ProgramCategory.Loops)
                    {
                        // Loop Do
                        if (CurrentBranch.Code == 1)
                        {
                            programIndex = 0;
                            return;
                        }
                    }
                    // Go to last branch
                    CurrentBranch = LastBranch.Last();
                    programIndex = LastProgramIndex.Last();
                    LastBranch.Remove(LastBranch.Last());
                    LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);
                    // If in loop or background process
                    NextProgram();
                }
            }
        }
        /// <summary>
        /// Continues to the next program
        /// Called when the program data is simple and doesn't require more frames
        /// </summary>
        public override void NextProgram()
        {
            // Process Page Commands if active
            if (isProgramActive)
                ProcessPrograms();
        }
        /// <summary>
        /// Setup branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void SetupBranch(EventProgramData eventProgramData)
        {
            LastBranch.Add(CurrentBranch);
            LastProgramIndex.Add(++programIndex);
            CurrentBranch = eventProgramData;
            programIndex = -1;
        }
        /// <summary>
        /// Else Branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void SetupElseBranch(EventProgramData eventProgramData)
        {
            LastBranch.Add(CurrentBranch);
            LastProgramIndex.Add(++programIndex);
            EventProgramData programData = new EventProgramData();
            programData.Programs = eventProgramData.ElsePrograms;
            CurrentBranch = programData;
            programIndex = -1;
        }
        /// <summary>
        /// Break Current Branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void BreakBranch(ref int index, bool ignoreTop)
        {
            // If this is the top most branch
            if (LastBranch.Count == 0)
            {
                if (ignoreTop)
                {
                    index++; NextProgram();
                }
                else
                {
                    isProgramActive = false;
                    programIndex = 0;
                    labels.Clear();
                }
                return;
            }
            // Go to last branch
            CurrentBranch = LastBranch.Last();
            index = LastProgramIndex.Last();
            LastBranch.Remove(LastBranch.Last());
            LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);
            index++; NextProgram();
        }
        /// <summary>
        /// Break Current Branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void BreakBranch(ref int index)
        {
            // If this is the top most branch
            if (LastBranch.Count == 0)
                return;
            // Go to last branch
            CurrentBranch = LastBranch.Last();
            index = LastProgramIndex.Last();
            LastBranch.Remove(LastBranch.Last());
            LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);
        }
        /// <summary>
        /// Setup Program Movement 
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void SetupProgramMovement(EventProgramData eventProgramData)
        {
            EventProcessor targetEvent = GetEvent((int)eventProgramData.Value[0]);
            if (targetEvent != null)
            {
                MovementProcessor mp = Global.MovementProcessors.Fetch();
                mp = new MovementProcessor();
                mp.Setup(targetEvent, false, (List<EventProgramData>)eventProgramData.Value[4], (bool)eventProgramData.Value[2], (bool)eventProgramData.Value[3], (bool)eventProgramData.Value[1], this);
                targetEvent.MovementProcessors.Add(mp);

                mp.Update(null);
                actionTakingPlace = ActionType.MovementProgram;
                waitActionCompelition = (bool)eventProgramData.Value[1];

                if (waitActionCompelition)
                    ActiveMovementProcessor = mp;
            }
        }
        #endregion

        #region Helper: Get Event, Get Value from Constant or Variable
        /// <summary>
        /// Get Event
        /// </summary>
        /// <param name="p"></param>
        public override EventProcessor GetEvent(int id)
        {
            return Global.Instance.Player[0];
        }
        /// <summary>
        /// Gets a value from either constant, variable, or local variable.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override float GetValue(int type, int id)
        {
            switch (type)
            {
                case 0:
                    return id;
                case 1:
                    return Global.Variable(id);
                case 2:
                    return Global.Variable(id, this);
            }
            return 0;
        }
        /// <summary>
        /// Gets a value from either constant, variable, or local variable.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override float GetValue(int type, float id)
        {
            switch (type)
            {
                case 0:
                    return id;
                case 1:
                    return Global.Variable((int)id);
                case 2:
                    return Global.Variable((int)id, this);
            }
            return 0;
        }
        #endregion

        #region Helper: Delete Event
        /// <summary>
        /// Delete Event
        /// </summary>
        /// <param name="eventProgramData"></param>
        private bool DeleteEvent(EventProgramData eventProgramData)
        {
            int id = (int)eventProgramData.Value[0];
            Global.Instance.CurrentMap.RemoveProcessor(GetEvent(id));
            return (id != data.ID);
        }
        #endregion

        #region Method: Load Global Event
        public override void Load()
        {
            // Setup Branches
            if (pageIndex > -1 && pageIndex < Data.Pages.Count)
            {
                if (CurrentBranch is EventPageData)
                    CurrentBranch = data.Pages[pageIndex];
                else // Event Program Data
                    CurrentBranch = LoadProgramData(data.Pages[pageIndex], CurrentBranch);

                for (int j = 0; j < LastBranch.Count; j++)
                {
                    if (LastBranch[j] is EventPageData)
                        LastBranch[j] = data.Pages[pageIndex];
                    else // Event Program Data
                        LastBranch[j] = LoadProgramData(data.Pages[pageIndex], LastBranch[j]);
                }

                foreach (Bookmark bookmark in labels.Values)
                {
                    if (bookmark.CurrentBranch is EventPageData)
                        bookmark.CurrentBranch = data.Pages[pageIndex];
                    else // Event Program Data
                        bookmark.CurrentBranch = LoadProgramData(data.Pages[pageIndex], bookmark.CurrentBranch);

                    for (int j = 0; j < bookmark.LastBranch.Count; j++)
                    {
                        if (bookmark.LastBranch[j] is EventPageData)
                            bookmark.LastBranch[j] = data.Pages[pageIndex];
                        else // Event Program Data
                            bookmark.LastBranch[j] = LoadProgramData(data.Pages[pageIndex], bookmark.LastBranch[j]);
                    }

                }
                if (actionTakingPlace == ActionType.Menu || actionTakingPlace == ActionType.Message)
                    actionTakingPlace = ActionType.None;
            }
        }
        /// <summary>
        /// Load Program Data
        /// </summary>
        /// <param name="eventPageData"></param>
        private IEventProgram LoadProgramData(IEventProgram parent, IEventProgram branch)
        {
            IEventProgram temp;
            for (int i = 0; i < parent.Programs.Count; i++)
            {
                if (parent.Programs[i].UniqueID == branch.UniqueID)
                    return parent.Programs[i];
                temp = LoadProgramData(parent.Programs[i], branch);
                if (temp != null)
                    return temp;
            }
            return null;
        }
        #endregion

        /// <summary>
        /// Menu Closed
        /// </summary>
        public void MenuClosed()
        {
            if (actionTakingPlace == ActionType.Message || actionTakingPlace == ActionType.Menu)
            {
                actionTakingPlace = ActionType.None;
                waitActionCompelition = false;
            }
        }
    }
}
