//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using FarseerPhysics.Collision;
using Microsoft.Xna.Framework;
using EGMGame.Components;

namespace EGMGame.Processors
{

    public class MovementProcessor
    {
        #region Field: Settings
        EventProcessor Event
        {
            get
            {
                if (ev == null)
                    if (IsThisTarget)
                        return (EventProcessor)Owner;
                    else
                        ev = Global.Instance.CurrentMap.GetEvent(ID);
                return ev;
            }
            set { ev = value; }
        }
        EventProcessor ev;
        public Drawable Owner;
        public int ID;
        public List<EventProgramData> Programs;
        public bool Repeat;
        public bool Ignore;
        public int programIndex = 0;
        public bool UseImpulse;
        public bool ActionComplete;
        // Is the Owner Target
        public bool IsThisTarget;
        // Wait Counter
        public int waitFrames = 0;
        // If true, this movement processor is done.
        public bool IsDone = false;
        // Number of tries
        int numberOfTries = 0;
        #endregion

        #region Field: Movement
        public bool IsMoving
        {
            get
            {

                if (Event.Body != null && !Event.Body.IsStatic)
                {
                    return Event.Body.Moves;
                }
                else
                    return _IsMoving || Path.IsUsingPath;
            }
            set
            {
                _IsMoving = value;
            }
        }
        bool _IsMoving;
        public int prgmIgnoreCounter;
        public Vector2 newPosition = new Vector2();
        // Pathfinding 
        public PathfindingPath Path = new PathfindingPath();
        // Action Taking Place
        public ActionType actionTakingPlace = ActionType.None;
        // Wait action to be complete?
        public bool waitActionCompelition = false;
        #endregion

        #region Constructor And Setup
        public MovementProcessor() { }
        /// <summary>
        /// Setup
        /// </summary>
        /// <param name="targetEvent">The event this processor will control</param>
        /// <param name="isThisTarget">Is Target The Owner?</param>
        /// <param name="list">The list of commands in the movement</param>
        /// <param name="repeat">Will this process repeat?</param>
        /// <param name="ignore">Will this process ignore impossible movements?</param>
        public void Setup(EventProcessor targetEvent, bool isThisTarget, List<EventProgramData> list, bool repeat, bool ignore, bool _actionComplete, Drawable owner)
        {
            Event = targetEvent;
            IsThisTarget = isThisTarget;
            ID = Event.ID;
            Programs = new List<EventProgramData>(list);
            Repeat = repeat;
            Ignore = ignore;
            programIndex = 0;
            UseImpulse = false;
            IsMoving = false;
            prgmIgnoreCounter = 0;
            newPosition = new Vector2();
            IsDone = false;
            actionTakingPlace = ActionType.None;
            waitActionCompelition = false;
            ActionComplete = _actionComplete;
            Owner = (isThisTarget ? targetEvent : owner);
        }
        #endregion

        #region Update: Update Movement Processing
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (IsDone) return;
            waitFrames--;

            if (waitFrames <= 0)
            {
                UpdateMovement();
                // Return if an action is taking place and must be complete
                if (actionTakingPlace != ActionType.None && waitActionCompelition)
                    return;
                if (programIndex > -1 && programIndex < Programs.Count)
                {
                    if (Programs[programIndex].Enabled)
                    {
                        switch (Programs[programIndex].ProgramCategory)
                        {
                            case ProgramCategory.Movement: // Movement Category
                                ProcessCategoryMovement(Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Settings: // Settings
                                ProcessCategorySettings(Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Audio: // Audio
                                ProcessCategoryAudio(Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Data: // Data
                                ProcessCategoryData(Programs[programIndex], ref programIndex);
                                break;
                            case ProgramCategory.Other: // Other
                                ProcessCategoryOther(Programs[programIndex], ref programIndex);
                                break;
                        }
                    }
                    else
                    {
                        programIndex++;
                    }
                }
                else
                {
                    if (Repeat)
                    {
                        programIndex = 0;
                    }
                    else
                    {
                        if (ActionComplete)
                        {
                            if (Owner is EventProcessor)
                                ((EventProcessor)Owner).ActionComplete(ActionType.MovementProgram);
                            else
                                ((GlobalEventProcessor)Owner).ActionComplete(ActionType.MovementProgram);
                        }
                        IsDone = true;
                        programIndex = -1;
                    }
                }
            }
        }
        /// <summary>
        /// Update movement
        /// </summary>
        private void UpdateMovement()
        {
            // Move to a position if necessarry
            if ((IsMoving || !Event.Static) && newPosition != Vector2.Zero && !Path.IsUsingPath)
            {
                Vector2 pos = Event.Position;
                if (Event.MoveTo(ref newPosition, (UseImpulse && actionTakingPlace == ActionType.Movement)))
                {
                    Event.Position = newPosition;
                    if (Event.Body != null)
                        Event.Body.ResetBaseDynamics();
                    IsMoving = false;
                    // Tell wait to end
                    if (actionTakingPlace == ActionType.Movement)
                    {
                        prgmIgnoreCounter = 0;
                        actionTakingPlace = ActionType.None;
                    }
                }
                else if (pos == Event.Position && Ignore)
                {
                    numberOfTries++;
                    if (numberOfTries > 40)
                    {
                        numberOfTries = 0;

                        newPosition = Event.Position;
                        if (Event.Body != null)
                            Event.Body.ResetBaseDynamics();
                        IsMoving = false;
                        // Tell wait to end
                        if (actionTakingPlace == ActionType.Movement)
                        {
                            prgmIgnoreCounter = 0;
                            actionTakingPlace = ActionType.None;
                        }
                    }
                }
                else
                {
                    numberOfTries = 0;
                }
            }
            // Update Path
            if (Path.IsUsingPath)
            {
                // Face New Point
                if (Path.Turn && (Event.Position - Path.CurrentVector).Length() > Event.MoveSpeed)
                    Event.TurnToward(Path.CurrentVector);
                if (Event.MoveTo(Path.CurrentVector, Path.UseImpulse))
                {
                    // Progress
                    Path.Progress();
                    // Check if path is done
                    if (Path.Done)
                    {
                        Event.Position = Path.CurrentVector;
                        if (Event.Body != null)
                            Event.Body.ResetBaseDynamics();
                        Path.IsUsingPath = false;
                        if (actionTakingPlace == ActionType.FindingPath)
                            actionTakingPlace = ActionType.None;
                        if (Event.Animation.IsAnimating)
                            Event.EndAnimation();
                    }
                    else
                    {
                        if (!Event.Animation.IsAnimating)
                            Event.StartAnimation();
                    }
                }
            }
            if (Event.ActionIndex == EventAction.Walk)
            {
            }
            // Update Animation if moving
            if (Event.Body != null)
            {
                // Update Animation
                if (IsMoving && !Event.Animation.IsAnimating)
                {
                    if (Event.ActionIndex == EventAction.Walk)
                        Event.StartAnimation();
                    prgmIgnoreCounter = 0;
                }
                else if (!IsMoving && Event.Body.Force == Vector2.Zero && Event.Animation.IsAnimating && !Path.IsUsingPath)
                {
                    if (Event.ActionIndex == EventAction.Walk && Event.Animation.ActionIndex == EventAction.Walk)
                        Event.EndAnimation();
                }
                // If Action taking place is movement
                // check impossible counter and decided if movement 
                // program should be stopped;
                if (actionTakingPlace == ActionType.Movement && !Event.Body.Moves && !Path.IsUsingPath)
                {
                    prgmIgnoreCounter++;
                    if (Event.Data.Pages[Event.pageIndex].SkipImpassable && prgmIgnoreCounter > 60)
                    {
                        prgmIgnoreCounter = 0;
                        newPosition = Event.Position;
                        if (Event.Body != null)
                            Event.Body.ClearForce();
                        IsMoving = false;
                        actionTakingPlace = ActionType.None;
                    }
                }

                if (Event.ActionIndex == EventAction.Jump && !Event.IsJumping)
                {
                    if (actionTakingPlace == ActionType.Jumping) actionTakingPlace = ActionType.None;
                    Event.ActionIndex = EventAction.Walk;
                    Event.SetAnimationAndAction();
                }
                if (actionTakingPlace == ActionType.Jumping && !Event.IsJumping) actionTakingPlace = ActionType.None;
            }
        }
        /// <summary>
        /// Go To Next Program
        /// </summary>
        private void NextProgram()
        {
            Update(null);
        }
        #endregion

        #region Method: Process Categories
        /// <summary>
        /// Process Category Others
        /// </summary>
        /// <param name="eventProgramData"></param>
        private void ProcessCategoryOther(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Wait
                    waitFrames = (int)eventProgramData.Value[0];
                    index++;
                    break;
            }
        }
        /// <summary>
        /// Process Data
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="movementPrgmIndex"></param>
        private void ProcessCategoryData(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Switch
                    Event.SetSwitch(eventProgramData, Global.Instance.Switches[(int)eventProgramData.Value[0]]);
                    index++;
                    NextProgram();
                    break;
                case 2: // Variable
                    Event.SetVariable(eventProgramData, Global.Instance.Variables[(int)eventProgramData.Value[0]]);
                    index++;
                    NextProgram();
                    break;
                case 3: // Local Switch
                    Event.SetSwitch(eventProgramData, Event.Switches[(int)eventProgramData.Value[0]]);
                    index++;
                    NextProgram();
                    break;
                case 4: // Local Variable
                    Event.SetVariable(eventProgramData, Event.Variables[(int)eventProgramData.Value[0]]);
                    index++;
                    NextProgram();
                    break;
                case 5: // List
                    Event.SetList(eventProgramData);
                    index++;
                    NextProgram();
                    break;
                case 6: // Database
                    Event.SetDataBase(eventProgramData);
                    index++; NextProgram();
                    break;
                case 7: // String
                    Event.SetString(eventProgramData);
                    index++; NextProgram();
                    break;
            }
        }
        /// <summary>
        /// Process Category Movement
        /// </summary>
        /// <param name="eventProgramData"></param>
        private void ProcessCategoryMovement(EventProgramData eventProgramData, ref int index)
        {
            Random rand; int angle;
            switch (eventProgramData.Code)
            {
                case 1:
                    index++; NextProgram();
                    break;
                case 2: // Move
                    angle = Event.Angle;
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0:// Custom
                            angle = (int)eventProgramData.Value[2];
                            break;
                        case 1: // Forward
                            angle = Event.Angle;
                            break;
                        case 2: // Backward
                            angle = Event.Angle - 180;
                            break;
                        case 3: // Leftward
                            angle = Event.Angle - 90;
                            break;
                        case 5: // Rightward
                            angle = Event.Angle + 90;
                            break;
                    }
                    MoveEvent(angle, (int)GetValue((int)eventProgramData.Value[3], (int)eventProgramData.Value[4]), (bool)eventProgramData.Value[5], true);
                    actionTakingPlace = ActionType.Movement;
                    waitActionCompelition = (bool)eventProgramData.Value[6];
                    UseImpulse = ((int)eventProgramData.Value[1] == 1);
                    index++; NextProgram();
                    break;
                case 4: // Move Toward Events
                    UseImpulse = (bool)eventProgramData.Value[5];
                    MoveTowardEvents((List<int>)eventProgramData.Value[0], (float)eventProgramData.Value[1], (bool)eventProgramData.Value[2], (List<int>)eventProgramData.Value[3], (int)eventProgramData.Value[6] == 0);
                    actionTakingPlace = ActionType.Movement;
                    waitActionCompelition = (bool)eventProgramData.Value[4];

                    index++; NextProgram();
                    break;
                case 5: // Move Away From Events
                    UseImpulse = (bool)eventProgramData.Value[5];
                    MoveAwayFromEvents((List<int>)eventProgramData.Value[0], (float)eventProgramData.Value[1], (bool)eventProgramData.Value[2], (List<int>)eventProgramData.Value[3], (int)eventProgramData.Value[6] == 0);
                    actionTakingPlace = ActionType.Movement;
                    waitActionCompelition = (bool)eventProgramData.Value[4];

                    index++; NextProgram();
                    break;
                case 6: // Turn
                    if ((int)eventProgramData.Value[0] < 3)
                        Event.SetAngle((int)GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]), true);
                    else
                    {
                        float x = GetValue((int)eventProgramData.Value[0] - 2, (int)eventProgramData.Value[1]), y = GetValue((int)eventProgramData.Value[0] - 2, (int)eventProgramData.Value[2]);
                        Event.TurnToward(x, y);
                    }
                    index++; NextProgram();
                    break;
                case 7: // Turn Toward Events
                    Event.TurnTowardEvents((List<int>)eventProgramData.Value[0], (List<int>)eventProgramData.Value[1]);
                    index++; NextProgram();
                    break;
                case 8: // Turn Away From Events
                    Event.TurnAwayFromEvents((List<int>)eventProgramData.Value[0], (List<int>)eventProgramData.Value[1]);
                    index++; NextProgram();
                    break;
                case 9: // Move to Position (Pathfinding)
                    Vector2 newPos = new Vector2((float)GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]), (float)GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[2]));

                    List<Vector2> path = Pathfinder.FindPath(Event, newPos, (List<int>)eventProgramData.Value[4], (int)eventProgramData.Value[6]);

                    if (path != null)
                    {
                        Path.IsUsingPath = true;
                        Path.AddVector(path, true);
                        Event.ActionIndex = EventAction.Walk;
                        Path.UseImpulse = (bool)eventProgramData.Value[7];
                        Event.StartAnimation();
                        Path.Turn = (bool)eventProgramData.Value[3];
                        actionTakingPlace = ActionType.FindingPath;
                        waitActionCompelition = (bool)eventProgramData.Value[5];
                        IsMoving = true;
                    }
                    index++; NextProgram();
                    break;
                case 11: // Jump
                    Jump((int)GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]), (int)GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[2]), (bool)eventProgramData.Value[3], true);
                    actionTakingPlace = ActionType.Jumping;
                    waitActionCompelition = (bool)eventProgramData.Value[4];
                    waitFrames = 5;
                    index++; NextProgram();
                    break;
                case 12: // Move Random
                    List<int> directions = (List<int>)eventProgramData.Value[2];

                    if (directions.Count > 0)
                    {
                        rand = new Random();
                        MoveEvent(Global.DirectionToAngle(directions[rand.Next(directions.Count)]), (int)eventProgramData.Value[0], (bool)eventProgramData.Value[1], true);
                        actionTakingPlace = ActionType.Movement;
                        waitActionCompelition = (bool)eventProgramData.Value[3];
                        UseImpulse = (bool)eventProgramData.Value[4];
                    }


                    index++; NextProgram();
                    break;
                case 13: // Turn Random
                    List<int> directions2 = (List<int>)eventProgramData.Value[0];
                    rand = new Random();
                    if (!Event.DirectionFix && directions2.Count > 0)
                        Event.SetAngle(Global.DirectionToAngle(directions2[rand.Next(0, directions2.Count - 1)]), true);
                    index++; NextProgram();
                    break;
                case 14: // Apply Force
                    angle = Event.Angle;
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0:// Custom
                            angle = (int)eventProgramData.Value[2];
                            break;
                        case 1: // Forward
                            angle = Event.Angle;
                            break;
                        case 2: // Backward
                            angle = Event.Angle - 180;
                            break;
                        case 3: // Leftward
                            angle = Event.Angle - 90;
                            break;
                        case 5: // Rightward
                            angle = Event.Angle + 90;
                            break;
                    }

                    if ((int)eventProgramData.Value[1] == 0)
                        ApplyForce(angle, GetValue((int)eventProgramData.Value[3], (float)eventProgramData.Value[4]), (bool)eventProgramData.Value[5], false);
                    else
                        ApplyLinearImpulse(angle, GetValue((int)eventProgramData.Value[3], (float)eventProgramData.Value[4]), (bool)eventProgramData.Value[5], false);

                    actionTakingPlace = ActionType.Movement;
                    waitActionCompelition = (bool)eventProgramData.Value[6];

                    index++; // NextProgram();
                    break;
                case 15: // Apply Rotation
                    if (Event.Body != null)
                    {
                        Event.Body.Rotation += GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) / 100;
                        Event.Body.ResetTorque();
                    }
                    else
                        Event.Animation.Rotation += GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) / 100;
                    index++; NextProgram();
                    break;
                case 16: // Move To Event
                    EventProcessor target = Event.GetEvent((int)eventProgramData.Value[0]);
                    if (target != null)
                    {
                        actionTakingPlace = ActionType.FindingPath;
                        waitActionCompelition = (bool)eventProgramData.Value[4];


                        List<Vector2> path2 = Pathfinder.FindPath(Event, target.Position, (List<int>)eventProgramData.Value[3], (int)eventProgramData.Value[1]);

                        if (path2 != null)
                        {
                            Path.IsUsingPath = true;
                            Path.AddVector(path2, true);
                            Path.UseImpulse = (bool)eventProgramData.Value[5];
                            Event.ActionIndex = EventAction.Walk;
                            Event.StartAnimation();
                            Path.Turn = (bool)eventProgramData.Value[2];
                            actionTakingPlace = ActionType.FindingPath;
                            waitActionCompelition = (bool)eventProgramData.Value[4];

                        }
                    }
                    index++; NextProgram();
                    break;
                case 17: // Torque
                    ApplyTorque(GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]));
                    index++; NextProgram();
                    break;
                case 18: // Torque
                    ApplyAngularImpulse(GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]), true);
                    index++; NextProgram();
                    break;
                case 19: // Clear Force/Impulse/Torque
                    if (Event.Body != null)
                        switch ((int)eventProgramData.Value[0])
                        {
                            case 0:
                                Event.Body.ClearForce();
                                break;
                            case 1:
                                Event.Body.ClearImpulse();
                                break;
                            case 2:
                                Event.Body.ClearTorque();
                                break;
                        }
                    index++; NextProgram();
                    break;
                case 20: // Animate
                    if (!Event.Animation.IsAnimating)
                    {
                        Event.Animation.Start();
                    }
                    if ((bool)eventProgramData.Value[0]) waitFrames = Event.Animation.GetDisplayTime() + 1;
                    index++; NextProgram();
                    break;
                case 21: // Next Frame
                    waitFrames = Event.Animation.NextFrame() + 1;
                    index++; NextProgram();
                    break;
                case 22: // Stop Animation
                    if (Event.Animation.IsAnimating)
                        Event.Animation.EndAnimation();
                    index++; NextProgram();
                    break;
            }
        }
        /// <summary>
        /// Process Audio
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="movementPrgmIndex"></param>
        private void ProcessCategoryAudio(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Play Audio
                    AudioSettings settings;
                    settings = new AudioSettings((int)eventProgramData.Value[2], (int)eventProgramData.Value[3], (bool)eventProgramData.Value[4], (float)eventProgramData.Value[5], (float)eventProgramData.Value[6], (float)eventProgramData.Value[7], (bool)eventProgramData.Value[8]);

                    Global.Instance.AudioManager.Play((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], settings);
                    break;
                case 2: // Control Audio Channel
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0: // Play
                            Global.Instance.AudioManager.Play((int)eventProgramData.Value[1]);
                            break;
                        case 1: // Pause
                            Global.Instance.AudioManager.Pause((int)eventProgramData.Value[1]);
                            break;
                        case 2: // Resume
                            Global.Instance.AudioManager.Resume((int)eventProgramData.Value[1]);
                            break;
                        case 3: // Stop
                            Global.Instance.AudioManager.Stop((int)eventProgramData.Value[1]);
                            break;
                        case 4: // Fade Out
                            Global.Instance.AudioManager.FadeOut((int)eventProgramData.Value[1]);
                            break;
                    }
                    break;
                case 3: // Create PlayList
                    Global.Instance.AudioManager.CreatePlaylist((List<int>)eventProgramData.Value[0], (int)eventProgramData.Value[1], (bool)eventProgramData.Value[2]);
                    break;
                case 4: // Control PlayList
                    switch ((int)eventProgramData.Value[0])
                    {
                        case 0: // Play
                            Global.Instance.AudioManager.PlayPlaylist((int)eventProgramData.Value[1]);
                            break;
                        case 1: // Pause
                            Global.Instance.AudioManager.PausePlaylist((int)eventProgramData.Value[1]);
                            break;
                        case 2: // Resume
                            Global.Instance.AudioManager.ResumePlaylist((int)eventProgramData.Value[1]);
                            break;
                        case 3: // Stop
                            Global.Instance.AudioManager.StopPlaylist((int)eventProgramData.Value[1]);
                            break;
                        case 4: // Fade Out
                            Global.Instance.AudioManager.FadeOutPlayList((int)eventProgramData.Value[1]);
                            break;
                    }
                    break;
            }
            index++; NextProgram();
        }
        /// <summary>
        /// Process Settings
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="movementPrgmIndex"></param>
        private void ProcessCategorySettings(EventProgramData eventProgramData, ref int index)
        {
            switch (eventProgramData.Code)
            {
                case 1: // Animation
                    Event.Animation.animationOn = (bool)eventProgramData.Value[0];
                    index++; NextProgram();
                    break;
                case 2: // Direction Fix
                    Event.DirectionFix = (bool)eventProgramData.Value[0];
                    index++; NextProgram();
                    break;
                case 3: // Collision
                    Event.CollisionOn = (bool)eventProgramData.Value[0];
                    index++; NextProgram();
                    break;
                case 4: // Change Animation
                    Event.Animation.Setup((int)eventProgramData.Value[0], (int)eventProgramData.Value[1], EventAction.Idle);
                    Event.SetupCollisionBody();
                    index++; NextProgram();
                    break;
                case 5: // Enable/Disable Frequency
                    Event.Animation.EnableFrequency = (bool)eventProgramData.Value[0];
                    index++; NextProgram();
                    break;
                case 6: // Change Frequency
                    Event.Animation.Frequency = (int)GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                    index++; NextProgram();
                    break;
                case 7: // Change Move Speed
                    Event.MoveSpeed = (int)GetValue((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                    index++; NextProgram();
                    break;
                case 8: // Set Force
                    Event.Force = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.Force);
                    index++; NextProgram();
                    break;
                case 10: // Linear Drag  
                    Event.LinearDrag = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.LinearDrag);
                    if (Event.Body != null)
                        Event.Body.LinearDamping = Event.LinearDrag;
                    index++; NextProgram();
                    break;
                case 11: // Rotational Drag
                    Event.RotationalDrag = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.RotationalDrag);
                    if (Event.Body != null)
                        Event.Body.AngularDamping = Event.RotationalDrag;
                    index++; NextProgram();
                    break;
                case 12: // Friction
                    Event.Friction = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.Friction);
                    if (Event.Body != null)
                        Event.Body.Friction = Event.Friction;
                    index++; NextProgram();
                    break;
                case 13: // Bounce
                    Event.Bounce = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.Bounce);

                    if (Event.Body != null)
                        Event.Body.Restitution = Event.Bounce;
                    index++; NextProgram();
                    break;
                case 14: // Mass
                    Event.Mass = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.Mass);
                    if (Event.Body != null)
                        Event.Body.Mass = Event.Mass;
                    index++; NextProgram();
                    break;
                case 15: // Impulse 
                    if (Event.Body != null)
                        Event.Impulse = ((bool)eventProgramData.Value[2] ? GetValue((int)eventProgramData.Value[0], (float)eventProgramData.Value[1]) : Global.Project.Impulse);
                    index++; NextProgram();
                    break;
                case 16: // Change Static
                    Event.Static = ((bool)eventProgramData.Value[0]);
                    if (ev.Body != null)
                    {
                        ev.Body.IsStatic = ev.Static;
                        ev.Body.Mass = ev.Mass;
                        if (ev.Data.Pages[ev.pageIndex].CustomMOI) ev.Body.Inertia = ev.MomentOfInertia;
                    }
                    index++; NextProgram();
                    break;
                case 17: // Change Passthrough
                    Event.PassThrough = (bool)eventProgramData.Value[0];
                    if (Event.Body != null)
                        Event.Body.IsSensor = Event.PassThrough;
                    index++; NextProgram();
                    break;
                case 18: // Change Fixed Rotation
                    Event.IsFixedRotation = ((bool)eventProgramData.Value[0]);
                    if (ev.Body != null) ev.Body.FixedRotation = Event.IsFixedRotation;
                    index++; NextProgram();
                    break;
                case 19: // Change Ignore Gravity
                    Event.IgnoreGravity = ((bool)eventProgramData.Value[0]);
                    if (ev.Body != null) ev.Body.IgnoreGravity = Event.IgnoreGravity;
                    index++; NextProgram();
                    break;
                case 20: // Change Custom Gravity
                    Event.CustomGravity = ((bool)eventProgramData.Value[0]);
                    Event.Gravity = new Vector2((float)eventProgramData.Value[1], (float)eventProgramData.Value[2]); ;
                    if (ev.Body != null)
                    {
                        ev.Body.Gravity = new Vector2((float)eventProgramData.Value[1], (float)eventProgramData.Value[2]);
                        ev.Body.CustomGravity = Event.CustomGravity;
                    }
                    index++; NextProgram();
                    break;
                case 21: // Sync Angle To Rotation
                    ev.SyncAngleToRotation = (bool)eventProgramData.Value[0];
                    if (ev.SyncAngleToRotation && ev.Body != null)
                    {
                        ev.Body.Rotation = MathHelper.ToRadians(ev.Angle + 90);
                        ev.Body.ResetTorque();
                    }
                    break;
            }

        }
        #endregion

        /// <summary>
        /// Gets a value from either constant, variable, or local variable.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public float GetValue(int type, float id)
        {
            if (Owner is EventProcessor)
                return ((EventProcessor)Owner).GetValue(type, id);
            else
                return ((GlobalEventProcessor)Owner).GetValue(type, id);
        }

        #region Method: Movement
        /// <summary>
        /// Move Event
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="pixels"></param>
        public void MoveEvent(int angle, int distance, bool turn, bool animate)
        {
            if (angle < 0) angle += 360;
            if (angle > 360) angle -= 360;

            newPosition.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * distance;
            newPosition.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * distance;

            // Moving Platform
            if (Event.IsMovingPlatform)
            {
                for (int i = 0; i < Event.collisionList.Count; i++)
                {
                    if (!Event.collisionList[i].IsStatic)
                    {
                        Event.collisionList[i].LinearVelocity = Vector2.Zero;
                    }
                }
            }

            newPosition += Event.Position;
            IsMoving = true;

            if (!Event.DirectionFix && turn)
            {
                Event.Angle = angle;
                Event.Animation.ApplyAngleToDirection(Event.Angle);
            }
            bool animateForced = (Event.ActionIndex != EventAction.Walk || !Event.Animation.IsAnimating);
            Event.ActionIndex = EventAction.Walk;

            if (Event.Animation.animationOn && animateForced && animate)
                Event.StartAnimation();
        }
        /// <summary>
        /// Apply Jump
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="force"></param>
        /// <param name="turn"></param>
        private void Jump(int angle, float force, bool turn, bool animate)
        {
            if (Event.Body != null)
            {
                if (turn && !Event.DirectionFix)
                {
                    //Event.Angle = angle;
                    //Event.Animation.ApplyAngleToDirection(Event.Angle);
                }
                Vector2 amount = new Vector2(0, 0);
                Event.ActionIndex = EventAction.Jump;
                Event.SetAnimationAndAction();
                amount.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * force;
                amount.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * force;
                Event.Body.ApplyLinearImpulse(ref amount);
                if (Event.Animation.animationOn && !Event.Animation.IsAnimating && animate)
                    Event.StartAnimationStill();
            }
        }
        /// <summary>
        /// Apply Impulse
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="force"></param>
        /// <param name="turn"></param>
        private void ApplyLinearImpulse(int angle, float force, bool turn, bool animate)
        {
            if (Event.Body != null)
            {
                if (turn && !Event.DirectionFix)
                {
                    Event.Angle = angle;
                    Event.Animation.ApplyAngleToDirection(Event.Angle);
                }
                Vector2 amount = new Vector2(0, 0);
                amount.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * force;
                amount.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * force;

                Event.Body.ApplyLinearImpulse(ref amount);
                if (!Event.IsJumping)
                {
                    Event.ActionIndex = EventAction.Walk;
                    if (Event.Animation.animationOn && !Event.Animation.IsAnimating && animate)
                        Event.StartAnimation();
                }
            }
        }
        /// <summary>
        /// Apply Angular Impulse
        /// </summary>
        /// <param name="force"></param>
        private void ApplyAngularImpulse(float force, bool animate)
        {
            if (Event.Body != null)
                Event.Body.ApplyAngularImpulse(force);
            if (!Event.IsJumping)
            {
                Event.ActionIndex = EventAction.Walk;
                if (Event.Animation.animationOn && !Event.Animation.IsAnimating && animate)
                    Event.StartAnimation();
            }
        }
        /// <summary>
        /// Apply Force
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="distance"></param>
        /// <param name="turn"></param>
        private void ApplyForce(int angle, float force, bool turn, bool animate)
        {
            if (Event.Body != null)
            {
                if (turn && !Event.DirectionFix)
                {
                    Event.Angle = angle;
                    Event.Animation.ApplyAngleToDirection(Event.Angle);
                }
                Vector2 amount = new Vector2(0, 0);
                amount.X = (float)Math.Round(Math.Cos(MathHelper.ToRadians(angle)), 2) * force;
                amount.Y = (float)Math.Round(Math.Sin(MathHelper.ToRadians(angle)), 2) * force;
                Event.Body.ApplyForce(ref amount);
                if (!Event.IsJumping)
                {
                    Event.ActionIndex = EventAction.Walk;
                    if (Event.Animation.animationOn && !Event.Animation.IsAnimating)
                        Event.StartAnimation();
                }
            }
        }
        /// <summary>
        /// Apply Torque
        /// </summary>
        /// <param name="p"></param>
        private void ApplyTorque(float amount)
        {
            if (Event.Body != null)
                Event.Body.ApplyTorque(amount);
        }
        /// <summary>
        /// Move Toward Events
        /// </summary>
        /// <param name="list"></param>
        /// <param name="p"></param>
        /// <param name="p_3"></param>
        /// <param name="list_4"></param>
        public void MoveTowardEvents(List<int> eventIDs, float pixel, bool turn, List<int> directions, bool useDistance)
        {
            EventProcessor closestEvent = null;
            EventProcessor currentEvent = null;
            // Get Closest Event
            foreach (int id in eventIDs)
            {
                if (closestEvent == null)
                {
                    closestEvent = Global.Instance.CurrentMap.GetEvent(id);

                    if (closestEvent.Body == null)
                        closestEvent = null;
                    continue;
                }
                currentEvent = Global.Instance.CurrentMap.GetEvent(id);
                if (currentEvent != null && currentEvent.Body != null)
                {
                    Vector2 pos = Event.Position;

                    float distance1 = closestEvent.Body.GetDistance(Event.Body);
                    float distance2 = currentEvent.Body.GetDistance(Event.Body);

                    if (distance2 < distance1)
                        closestEvent = currentEvent;
                }
            }

            if (closestEvent != null)
            {
                MoveTowardEvent(closestEvent, pixel, turn, directions, useDistance);
            }
        }
        /// <summary>
        /// Move Away Events
        /// </summary>
        /// <param name="list"></param>
        /// <param name="p"></param>
        /// <param name="p_3"></param>
        /// <param name="list_4"></param>
        public void MoveAwayFromEvents(List<int> eventIDs, float pixel, bool turn, List<int> directions, bool useDistance)
        {
            EventProcessor closestEvent = null;
            EventProcessor currentEvent = null;
            // Get Closest Event
            foreach (int id in eventIDs)
            {
                if (closestEvent == null)
                {
                    closestEvent = Global.Instance.CurrentMap.GetEvent(id);

                    if (closestEvent.Body == null)
                        closestEvent = null;
                    continue;
                }
                currentEvent = Global.Instance.CurrentMap.GetEvent(id);
                if (currentEvent != null && currentEvent.Body != null)
                {
                    Vector2 pos = Event.Position;
                    float distance1 = closestEvent.Body.GetDistance(Event.Body);
                    float distance2 = currentEvent.Body.GetDistance(Event.Body);

                    if (distance2 < distance1)
                        closestEvent = currentEvent;
                }
            }

            if (closestEvent != null)
            {
                MoveAwayFromEvent(closestEvent, pixel, turn, directions, useDistance);
            }
        }
        /// <summary>
        /// Move Toward Event
        /// </summary>
        /// <param name="closestEvent"></param>
        /// <param name="pixel"></param>
        /// <param name="turn"></param>
        /// <param name="directions"></param>
        private void MoveTowardEvent(EventProcessor ev, float pixel, bool turn, List<int> directions, bool useDistance)
        {
            Vector2 targetAngle = (ev.Position - Event.Position);

            CorrectTargetAngle(directions, (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0));
            // Calculate target To Move
            if (useDistance)
                MoveEvent((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), (int)pixel, turn, true);
            else if (!UseImpulse)
                ApplyForce((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), pixel, turn, true);
            else
                ApplyLinearImpulse((int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0), pixel, turn, true);
        }
        /// <summary>
        /// Move Away From Event
        /// </summary>
        /// <param name="closestEvent"></param>
        /// <param name="pixel"></param>
        /// <param name="turn"></param>
        /// <param name="directions"></param>
        private void MoveAwayFromEvent(EventProcessor ev, float pixel, bool turn, List<int> directions, bool useDistance)
        {
            Vector2 targetAngle = (ev.Position - Event.Position);
            int angle = (int)Math.Round(MathHelper.ToDegrees((float)Math.Atan2(targetAngle.Y, targetAngle.X)), 0);
            if (angle < 0) angle += 360;
            angle += 180;
            if (angle > 360) angle -= 360;
            CorrectTargetAngle(directions, angle);
            // Calculate target To Move
            if (useDistance)
                MoveEvent(angle, (int)pixel, turn, true);
            else if (!UseImpulse)
                ApplyForce(angle, pixel, turn, true);
            else
                ApplyLinearImpulse(angle, pixel, turn, true);
        }
        /// <summary>
        /// Correct Target Angle
        /// </summary>
        /// <param name="directions"></param>
        /// <param name="targetAngle"></param>
        private void CorrectTargetAngle(List<int> directions, int angle)
        {
            for (int i = 0; i < directions.Count; i++)
            {
                switch (directions[i])
                {
                    case 0: // Up

                        break;
                    case 1: // Down

                        break;
                    case 2: // Left

                        break;
                    case 3: // Right

                        break;
                    case 4: // Up Left

                        break;
                    case 5: // Up Right

                        break;
                    case 6: // Down Left

                        break;
                    case 7: // Down Right

                        break;
                }
            }
        }
        #endregion

        public void Clear()
        {
            Event = null; ;
            Repeat = false;
            Ignore = false;
            ActionComplete = false;
            programIndex = 0;
            UseImpulse = false;
            IsMoving = false;
            prgmIgnoreCounter = 0;
            newPosition = new Vector2();
            Path.Clear();
            IsDone = false;
            actionTakingPlace = ActionType.None;
            waitActionCompelition = false;
        }
        /// <summary>
        /// Set the Owner
        /// </summary>
        /// <param name="owner"></param>
        public void SetOwner(Drawable owner)
        {
            Owner = owner;
        }
    }
}
