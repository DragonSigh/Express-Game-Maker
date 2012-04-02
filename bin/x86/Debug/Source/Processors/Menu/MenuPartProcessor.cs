//* Copyright (c) 2010, Virtual Impact Studios LLC www.expressgamemaker.com
//* All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EGMGame.Library;
using EGMGame.Components;
using EGMGame.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework.GamerServices;

namespace EGMGame.Processors
{

    public class MenuPartProcessor : Interpreter
    {
        public IMenuParts Data
        {
            get { return data; }
            set { data = value; }
        }
        IMenuParts data;
        public List<MenuPartProcessor> MenuParts = new List<MenuPartProcessor>();
        [XmlIgnore, DoNotSerialize]
        public MenuProcessor ParentMenu;
        [XmlIgnore, DoNotSerialize]
        public MenuPartProcessor Parent;

        #region Field: Settings
        public int Padding = 5;
        int HighlighterIndex = 1;
        byte HighlighterCount = 50;
        public int PartyIndex;
        public bool Visible;
        public bool Enabled;
        public int SelectedIndex = 0; // Used in option based parts.
        public string Text;
        public bool IsParentAutoFit;
        public AnimationProcessor Animation;
        public List<int> Options;
        public Point IndexLocation = Point.Zero;
        private Keys? PressedKey = null;
        private int KeyTimer = 0;
        private Vector2 TextSize;
        private List<AnimationFrame> PointerFrames = null;
        private int PointerFrameIndex = 0;
        private bool PointerLoop = false;
        private int PointerLoopCount = 0;
        private int PointerLoopMax = 0;
        private int animationCounter = 0;
        private Vector2 MoveToPosition = Vector2.Zero;
        private Vector2 MoveToDifference = Vector2.Zero;
        private bool? isMouseOn;
        private bool? wasMouseOn;
        #endregion

        #region Properties: Framework
        public override Vector2 Position
        {
            get { return data.Position; }
            set { data.Position = value; }
        }
        public Vector2 Size
        {
            get { return data.Size; }
            set { data.Size = value; }
        }
        #endregion

        #region Constructor and Setup
        public MenuPartProcessor() { }
        /// <summary>
        /// Create a menu part from data.
        /// </summary>
        /// <param name="menuPart"></param>
        /// <param name="parent"></param>
        /// <param name="menu"></param>
        public MenuPartProcessor(IMenuParts menuPart, MenuPartProcessor parent, MenuProcessor menu)
        {
            Parent = parent;
            ParentMenu = menu;
            data = menuPart;
            Enabled = data.Enabled;
            Visible = data.Visible;
            ID = data.ID;
            Setup(data.MenuParts);

            if (data is TextPartStatic)
                Text = ((TextPartStatic)data).Text;
            else if (data is AnimationPartStatic)
            {
                Animation = new AnimationProcessor();
                Animation.Setup(((AnimationPartStatic)data).Animation, ((AnimationPartStatic)data).Action);
                Animation.Direction = ((AnimationPartStatic)data).Direction;
                Animation.Position = data.RealPosition;
                if (((AnimationPartStatic)data).Animate)
                    Animation.Start();
            }
            else if (data is AnimationPartParty)
            {
                Animation = new AnimationProcessor();
                int partyIndex = (int)Global.Variable(((AnimationPartParty)data).PartyIndex);
                if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count && Global.Instance.Party.Heroes[partyIndex] != null)
                    Animation.Setup(Global.Instance.Party.Heroes[partyIndex].AnimationID, ((AnimationPartParty)data).Action);
                Animation.Direction = ((AnimationPartParty)data).Direction;
                Animation.Position = data.RealPosition;
                if (((AnimationPartParty)data).Animate)
                    Animation.Start();
                PartyIndex = partyIndex;
            }
            else if (data is AnimationPartPartyFromList)
            {
                Animation = new AnimationProcessor();
                ListData list = GameData.Lists.GetData(((AnimationPartPartyFromList)data).List);
                if (list != null)
                {
                    int partyIndex = (int)Global.Variable(((AnimationPartPartyFromList)data).PartyIndex);
                    if (partyIndex > -1 && partyIndex < list.Values.Count && list.Values[partyIndex] != null)
                    {
                        HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                        if (hero != null)
                            Animation.Setup(hero.AnimationID, ((AnimationPartPartyFromList)data).Action);
                    }
                    Animation.Direction = ((AnimationPartPartyFromList)data).Direction;
                    Animation.Position = data.RealPosition;
                    if (((AnimationPartPartyFromList)data).Animate)
                        Animation.Start();
                    PartyIndex = partyIndex;
                }
            }
            else if (data is ListStatic)
            {
                // Set Variable To Index
                if (((ListStatic)data).Variable > -1)
                {
                    VariableData v = Global.Instance.Variables.GetData(((ListStatic)data).Variable);
                    if (v != null)
                        v.Value = SelectedIndex;
                }
            }
            else if (data is ListPartyFromList)
            {
                Options = new List<int>();
                ListData list = GameData.Lists.GetData(((ListPartyFromList)data).List);
                if (list != null)
                {
                    for (int i = 0; i < list.Values.Count; i++)
                    {
                        Options.Add(list.Values[i]);
                    }
                    // Set Variable To Index
                    if (((ListPartyFromList)data).Variable > -1)
                    {
                        VariableData v = Global.Instance.Variables.GetData(((ListPartyFromList)data).Variable);
                        if (v != null)
                            v.Value = SelectedIndex;
                    }
                }
            }
            else if (data is ListParty)
            {
                Options = new List<int>();
                for (int i = 0; i < Global.Instance.Party.Heroes.Count; i++)
                {
                    Options.Add(Global.Instance.Party.Heroes[i].ID);
                }
                // Set Variable To Index
                if (((ListParty)data).Variable > -1)
                {
                    VariableData v = Global.Instance.Variables.GetData(((ListParty)data).Variable);
                    if (v != null)
                        v.Value = SelectedIndex;
                }
            }
            else if (data is ListItemPartyFromList)
            {
                // Set Variable To Index
                if (((ListItemPartyFromList)data).Variable > -1)
                {
                    ListData list = GameData.Lists.GetData(((ListItemPartyFromList)data).List);
                    if (list != null)
                    {
                        int partyIndex = (int)Global.Variable(((ListItemPartyFromList)data).PartyIndex);
                        if (partyIndex > -1 && partyIndex < list.Values.Count && list.Values[partyIndex] != null)
                        {
                            HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                            if (hero != null)
                            {
                                Options = hero.GetItems().Values;

                                List<int> items = new List<int>();
                                for (int id = 0; id < Options.Count; id++)
                                    if (!items.Contains(Options[id]))
                                        items.Add(Options[id]);

                                Options = items;
                                VariableData v = Global.Instance.Variables.GetData(((ListItemPartyFromList)data).Variable);
                                if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                                    v.Value = Options[SelectedIndex];
                            }
                        }
                    }
                }
            }
            else if (data is ListSkillPartyFromList)
            {
                // Set Variable To Index
                if (((ListSkillPartyFromList)data).Variable > -1)
                {
                    ListData list = GameData.Lists.GetData(((ListSkillPartyFromList)data).List);
                    if (list != null)
                    {
                        int partyIndex = (int)Global.Variable(((ListSkillPartyFromList)data).PartyIndex);
                        if (partyIndex > -1 && partyIndex < list.Values.Count && list.Values[partyIndex] != null)
                        {
                            HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                            if (hero != null)
                            {
                                if (((ListSkillPartyFromList)data).Show == SkillType.Skill)
                                    Options = hero.GetSkills().Values;
                                else if (((ListSkillPartyFromList)data).Show == SkillType.Magic)
                                    Options = hero.GetMagics().Values;
                                else // Both
                                {
                                    Options = new List<int>(hero.GetSkills().Values);
                                    Options.AddRange(hero.GetMagics().Values);
                                }
                                List<int> items = new List<int>();
                                for (int id = 0; id < Options.Count; id++)
                                    if (!items.Contains(Options[id]))
                                        items.Add(Options[id]);

                                Options = items;
                                VariableData v = Global.Instance.Variables.GetData(((ListSkillPartyFromList)data).Variable);
                                if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                                    v.Value = Options[SelectedIndex];
                            }
                        }
                    }
                }
            }
            else if (data is ListEquipmentPartyFromList)
            {
                // Set Variable To Index
                if (((ListEquipmentPartyFromList)data).Variable > -1)
                {
                    ListData list = GameData.Lists.GetData(((ListEquipmentPartyFromList)data).List);
                    if (list != null)
                    {
                        int partyIndex = (int)Global.Variable(((ListEquipmentPartyFromList)data).PartyIndex);
                        if (partyIndex > -1 && partyIndex < list.Values.Count && list.Values[partyIndex] != null)
                        {
                            HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                            if (hero != null)
                            {
                                Options = hero.GetEquipments().Values;

                                List<int> items = new List<int>();
                                for (int id = 0; id < Options.Count; id++)
                                {
                                    EquipmentData eq;
                                    if (!items.Contains(Options[id]))
                                    {
                                        eq = GameData.Equipments.GetData(Options[id]);

                                        if (eq.UsableBy.Contains(hero.ID))
                                            if (!((ListEquipmentPartyFromList)data).DisableSlots || eq.EquipmentSlots.Contains((int)Global.Variable(((ListEquipmentPartyFromList)data).SelectedSlot)))
                                                items.Add(Options[id]);
                                    }
                                }
                                items.Add(-1);
                                Options = items;
                                VariableData v = Global.Instance.Variables.GetData(((ListEquipmentPartyFromList)data).Variable);
                                if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                                    v.Value = Options[SelectedIndex];
                            }
                        }
                    }
                }
            }
            else if (data is ListEquippedPartyFromList)
            {
                // Set Variable To Index
                if (((ListEquippedPartyFromList)data).SelectedSlot > -1)
                {
                    ListData list = GameData.Lists.GetData(((ListEquippedPartyFromList)data).List);
                    if (list != null)
                    {
                        int partyIndex = (int)Global.Variable(((ListEquippedPartyFromList)data).PartyIndex);
                        if (partyIndex > -1 && partyIndex < list.Values.Count && list.Values[partyIndex] != null)
                        {
                            HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                            if (hero != null)
                            {
                                Options = hero.GetSlots();

                                VariableData v = Global.Instance.Variables.GetData(((ListEquippedPartyFromList)data).SelectedSlot);
                                if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                                    v.Value = Options[SelectedIndex];
                            }
                        }
                    }
                }
            }
            else if (data is ListItemParty)
            {
                // Set Variable To Index
                if (((ListItemParty)data).Variable > -1)
                {
                    int partyIndex = (int)Global.Variable(((ListItemParty)data).PartyIndex);
                    if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
                    {
                        Options = Global.Instance.Party.Heroes[partyIndex].GetItems().Values;

                        List<int> items = new List<int>();
                        for (int id = 0; id < Options.Count; id++)
                            if (!items.Contains(Options[id]))
                                items.Add(Options[id]);

                        Options = items;
                        VariableData v = Global.Instance.Variables.GetData(((ListItemParty)data).Variable);
                        if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                            v.Value = Options[SelectedIndex];
                    }
                }
            }
            else if (data is ListSkillParty)
            {
                // Set Variable To Index
                if (((ListSkillParty)data).Variable > -1)
                {
                    int partyIndex = (int)Global.Variable(((ListSkillParty)data).PartyIndex);
                    if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
                    {
                        if (((ListSkillParty)data).Show == SkillType.Skill)
                            Options = Global.Instance.Party.Heroes[partyIndex].GetSkills().Values;
                        else if (((ListSkillParty)data).Show == SkillType.Magic)
                            Options = Global.Instance.Party.Heroes[partyIndex].GetMagics().Values;
                        else // Both
                        {
                            Options = new List<int>(Global.Instance.Party.Heroes[partyIndex].GetSkills().Values);
                            Options.AddRange(Global.Instance.Party.Heroes[partyIndex].GetMagics().Values);
                        }
                        List<int> items = new List<int>();
                        for (int id = 0; id < Options.Count; id++)
                            if (!items.Contains(Options[id]))
                                items.Add(Options[id]);

                        Options = items;
                        VariableData v = Global.Instance.Variables.GetData(((ListSkillParty)data).Variable);
                        if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                            v.Value = Options[SelectedIndex];
                    }
                }
            }
            else if (data is ListEquipmentParty)
            {
                // Set Variable To Index
                if (((ListEquipmentParty)data).Variable > -1)
                {
                    int partyIndex = (int)Global.Variable(((ListEquipmentParty)data).PartyIndex);
                    if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
                    {
                        Options = Global.Instance.Party.Heroes[partyIndex].GetEquipments().Values;

                        List<int> items = new List<int>();
                        for (int id = 0; id < Options.Count; id++)
                        {
                            EquipmentData eq;
                            if (!items.Contains(Options[id]))
                            {
                                eq = GameData.Equipments.GetData(Options[id]);

                                if (eq.UsableBy.Contains(Global.Instance.Party.Heroes[partyIndex].ID))
                                    if (!((ListEquipmentParty)data).DisableSlots || eq.EquipmentSlots.Contains((int)Global.Variable(((ListEquipmentParty)data).SelectedSlot)))
                                        items.Add(Options[id]);
                            }
                        }
                        items.Add(-1);
                        Options = items;
                        VariableData v = Global.Instance.Variables.GetData(((ListEquipmentParty)data).Variable);
                        if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                            v.Value = Options[SelectedIndex];
                    }
                }
            }
            else if (data is ListEquippedParty)
            {
                // Set Variable To Index
                if (((ListEquippedParty)data).SelectedSlot > -1)
                {
                    int partyIndex = (int)Global.Variable(((ListEquippedParty)data).PartyIndex);
                    if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
                    {
                        Options = Global.Instance.Party.Heroes[partyIndex].GetSlots();

                        VariableData v = Global.Instance.Variables.GetData(((ListEquippedParty)data).SelectedSlot);
                        if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                            v.Value = Options[SelectedIndex];
                    }
                }
            }
            else if (data is ListItemSource)
            {
                // Set Variable To Index
                if (((ListItemSource)data).Variable > -1)
                {
                    ListData list = Global.Instance.Lists.GetData(((ListItemSource)data).List);

                    if (list != null)
                    {
                        Options = list.Values;

                        List<int> items = new List<int>();
                        for (int id = 0; id < Options.Count; id++)
                            if (!items.Contains(Options[id]))
                                items.Add(Options[id]);

                        Options = items;
                        VariableData v = Global.Instance.Variables.GetData(((ListItemSource)data).Variable);
                        if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                            v.Value = Options[SelectedIndex];
                    }
                }
            }
            else if (data is ListEquipmentSource)
            {
                // Set Variable To Index
                if (((ListEquipmentSource)data).Variable > -1)
                {
                    ListData list = Global.Instance.Lists.GetData(((ListEquipmentSource)data).List);

                    if (list != null)
                    {
                        Options = list.Values;

                        List<int> items = new List<int>();
                        for (int id = 0; id < Options.Count; id++)
                        {
                            EquipmentData eq;
                            if (!items.Contains(Options[id]))
                            {
                                eq = GameData.Equipments.GetData(Options[id]);

                                if (!((ListEquipmentSource)data).DisableSlots || eq.EquipmentSlots.Contains((int)Global.Variable(((ListEquipmentSource)data).SelectedSlot)))
                                    items.Add(Options[id]);
                            }
                        }
                        items.Add(-1);
                        Options = items;
                        VariableData v = Global.Instance.Variables.GetData(((ListEquipmentSource)data).Variable);
                        if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                            v.Value = Options[SelectedIndex];
                    }
                }
            }
            else if (data is ListEquipmentShop)
            {
                // Set Variable To Index
                if (((ListEquipmentShop)data).Variable > -1)
                {
                    Options = Global.ShopEquipments;

                    VariableData v = Global.Instance.Variables.GetData(((ListEquipmentShop)data).Variable);
                    if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                        v.Value = Options[SelectedIndex];
                }
            }
            else if (data is ListItemShop)
            {
                // Set Variable To Index
                if (((ListItemShop)data).Variable > -1)
                {
                    Options = Global.ShopItems;
                    VariableData v = Global.Instance.Variables.GetData(((ListItemShop)data).Variable);
                    if (v != null && SelectedIndex > -1 && SelectedIndex < Options.Count)
                        v.Value = Options[SelectedIndex];
                }
            }
            else if (data is MenuOptions)
            {
                // Set Variable To Index
                if (((MenuOptions)data).Variable > -1)
                {
                    VariableData v = Global.Instance.Variables.GetData(((MenuOptions)data).Variable);
                    if (v != null)
                        v.Value = SelectedIndex;
                }
            }
            else if (data is ListSaveLoad)
            {
                Options = new List<int>();
                for (int i = 0; i < ((ListSaveLoad)data).MaxFiles; i++)
                    Options.Add(i);
                // Set Variable To Index
                if (((ListSaveLoad)data).Variable > -1)
                {
                    VariableData v = Global.Instance.Variables.GetData(((ListSaveLoad)data).Variable);
                    if (v != null)
                        v.Value = SelectedIndex;
                }
            }
            else if (data is TextBoxPart)
            {
                StringData str = Global.Instance.Strings.GetData(((TextBoxPart)data).String);
                if (str != null && str.Value != null)
                    IndexLocation.X = str.Value.Length;
            }
            else if (data is BackgroundProcessPart)
            {
                if (((BackgroundProcessPart)data).BackgroundEvent != null)
                {
                    ActivateEvent(((BackgroundProcessPart)data).BackgroundEvent);
                }
            }
        }
        /// <summary>
        /// Setup the menu
        /// </summary>
        private void Setup(List<IMenuParts> parts)
        {
            for (int index = 0; index < parts.Count; index++)
            {
                parts[index].Parent = data;
                MenuParts.Add(new MenuPartProcessor(parts[index], this, ParentMenu));
            }
        }
        /// <summary>
        /// Activate Event
        /// </summary>
        /// <param name="list"></param>
        public void ActivateEvent(List<EventProgramData> list)
        {
            if (!isProgramActive && Enabled && Visible)
            {
                // Save Branch if empty
                labels.Clear();
                LastBranch.Clear();
                EventProgramData parent = new EventProgramData();
                parent.Programs = list;
                CurrentBranch = parent;
                // Start processing program
                isProgramActive = true;
                // Process Program
                ProcessPrograms();
            }
        }
        #endregion

        #region Update: Process Menupart and Child parts
        public override void Update(GameTime gameTime)
        {
            // Update only if  data exists
            if (data != null)
            {
                if (ParentMenu == null || !ParentMenu.Erase)
                {
                    if (waitFrames > 0)
                    {
                        waitFrames--;
                        return;
                    }
                    if (!isProgramActive)
                    {
                        // Update Menupart
                        UpdateMenuPart(data, gameTime);
                        // Update Menuparts
                        UpdateMenuParts(gameTime);
                    }
                    else
                    {
                        // If Program is active
                        // Return if there is an action taking place and must be completed
                        if (!(actionTakingPlace != ActionType.None && waitActionCompelition))
                        {
                            // Reset wait
                            waitActionCompelition = false;

                            ProcessPrograms();
                        }
                    }
                }

                if (MoveToPosition.X > 0 && MoveToPosition.Y > 0)
                {
                    Vector2 pos = Position;
                    pos.X += MoveToDifference.X;
                    pos.Y += MoveToDifference.Y;
                }
            }
        }

        private void UpdateMenuParts(GameTime gameTime)
        {
            if (Enabled && Visible)
            {
                for (int index = 0; index < MenuParts.Count; index++)
                {
                    if (MenuParts[index].Enabled && MenuParts[index].Visible)
                    {
                        // Update Self
                        MenuParts[index].Update(gameTime);
                    }
                }
            }
        }

        private void UpdateMenuPart(IMenuParts menuPart, GameTime gameTime)
        {
            if (Data is MenuWindow)
            {
                UpdatePart((MenuWindow)Data);
            }
            else if (Data is MenuButton)
            {
                UpdatePart((MenuButton)Data);
            }
            else if (Data is ListStatic)
            {
                UpdatePart((ListStatic)Data);
            }
            else if (Data is ListParty)
            {
                UpdatePart((ListParty)Data);
            }
            else if (Data is ListPartyFromList)
            {
                UpdatePart((ListPartyFromList)Data);
            }
            else if (Data is AnimationPartStatic)
            {
                UpdatePart((AnimationPartStatic)Data, gameTime);
            }
            else if (Data is AnimationPartParty)
            {
                UpdatePart((AnimationPartParty)Data, gameTime);
            }
            else if (Data is AnimationPartPartyFromList)
            {
                UpdatePart((AnimationPartPartyFromList)Data, gameTime);
            }
            else if (Data is MenuOptions)
            {
                UpdatePart((MenuOptions)Data);
            }
            else if (Data is ListItemParty)
            {
                UpdatePart((ListItemParty)Data);
            }
            else if (Data is ListSkillParty)
            {
                UpdatePart((ListSkillParty)Data);
            }
            else if (Data is ListEquipmentParty)
            {
                UpdatePart((ListEquipmentParty)Data);
            }
            else if (Data is ListEquippedParty)
            {
                UpdatePart((ListEquippedParty)Data);
            }
            else if (Data is ListItemPartyFromList)
            {
                UpdatePart((ListItemPartyFromList)Data);
            }
            else if (Data is ListSkillPartyFromList)
            {
                UpdatePart((ListSkillPartyFromList)Data);
            }
            else if (Data is ListEquipmentPartyFromList)
            {
                UpdatePart((ListEquipmentPartyFromList)Data);
            }
            else if (Data is ListEquippedPartyFromList)
            {
                UpdatePart((ListEquippedPartyFromList)Data);
            }
            else if (Data is ListItemSource)
            {
                UpdatePart((ListItemSource)Data);
            }
            else if (Data is ListEquipmentSource)
            {
                UpdatePart((ListEquipmentSource)Data);
            }
            else if (Data is ListItemShop)
            {
                UpdatePart((ListItemShop)Data);
            }
            else if (Data is ListEquipmentShop)
            {
                UpdatePart((ListEquipmentShop)Data);
            }
            else if (Data is TextBoxPart)
            {
                UpdatePart((TextBoxPart)Data);
            }
            else if (Data is ListSaveLoad)
            {
                UpdatePart((ListSaveLoad)Data);
            }

            if (Enabled && Visible)
            {
                isMouseOn = null; wasMouseOn = null;
                // Events
                if (data.OnConfirm.Count > 0 && (InputState.IsNewKeyPress(InputState.KeysList[GameData.Player.Keys["Action"]], InputState.LastPlayer) || InputState.IsNewButtonPress(InputState.ButtonsList[GameData.Player.Buttons["Action"]], InputState.LastPlayer)))
                {
                    ActivateEvent(data.OnConfirm);
                }
                else if (data.OnCancel.Count > 0 && (InputState.IsNewKeyPress(InputState.KeysList[GameData.Player.Keys["Cancel"]], InputState.LastPlayer) || InputState.IsNewButtonPress(InputState.ButtonsList[GameData.Player.Buttons["Cancel"]], InputState.LastPlayer)))
                {
                    ActivateEvent(data.OnCancel);
                }
                else if (data.OnKeyPress.Count > 0 && (InputState.AnyKeyIsPressed(InputState.LastPlayer) || InputState.AnyButtonIsPressed(InputState.LastPlayer)))
                {
                    ActivateEvent(data.OnKeyPress);
                }
                else if (data.OnKeyRelease.Count > 0 && (InputState.AnyKeyIsReleased(InputState.LastPlayer) || InputState.AnyButtonIsReleased(InputState.LastPlayer)))
                {
                    ActivateEvent(data.OnKeyRelease);
                }
                else if (data.OnKeyDown.Count > 0 && (InputState.AnyKeyIsDown(InputState.LastPlayer) || InputState.AnyButtonIsDown(InputState.LastPlayer)))
                {
                    ActivateEvent(data.OnKeyDown);
                }
                else if (data.OnMouseDown.Count > 0 && (IsMouseOn() && InputState.IsMouseDown()))
                {
                    ActivateEvent(data.OnMouseDown);
                }
                else if (data.OnMouseUp.Count > 0 && (IsMouseOn() && InputState.IsMouseUp()))
                {
                    ActivateEvent(data.OnMouseUp);
                }
                else if (data.OnMouseMove.Count > 0 && (IsMouseOn() && WasMouseOn() && InputState.IsMouseMove()))
                {
                    ActivateEvent(data.OnMouseMove);
                }
                else if (data.OnMouseLeave.Count > 0 && (!IsMouseOn() && WasMouseOn() && InputState.IsMouseMove()))
                {
                    ActivateEvent(data.OnMouseLeave);
                }
                else if (data.OnMouseEnter.Count > 0 && (IsMouseOn() && !WasMouseOn() && InputState.IsMouseMove()))
                {
                    ActivateEvent(data.OnMouseEnter);
                }
                else if (data.OnMouseHover.Count > 0 && (IsMouseOn() && WasMouseOn() && !InputState.IsMouseMove()))
                {
                    ActivateEvent(data.OnMouseHover);
                }
            }
        }
        /// <summary>
        /// Checks if the mouse was on the menu part
        /// </summary>
        /// <returns></returns>
        private bool WasMouseOn()
        {
            if (!wasMouseOn.HasValue)
                wasMouseOn = ((((data.Bounds.X <= InputState.LastMouseState.X) && (InputState.LastMouseState.X < (data.Bounds.X + data.Bounds.Width))) && (data.Bounds.Y <= InputState.LastMouseState.Y)) && (InputState.LastMouseState.Y < (data.Bounds.Y + data.Bounds.Height)));
            return wasMouseOn.Value;
        }
        /// <summary>
        /// Is Mouse On
        /// </summary>
        /// <returns></returns>
        private bool IsMouseOn()
        {
            if (!isMouseOn.HasValue)
                isMouseOn = ((((data.Bounds.X <= Mouse.GetState().X) && (Mouse.GetState().X < (data.Bounds.X + data.Bounds.Width))) && (data.Bounds.Y <= Mouse.GetState().Y)) && (Mouse.GetState().Y < (data.Bounds.Y + data.Bounds.Height)));
            return isMouseOn.Value;
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
                    case ActionType.PictureTint:
                        actionTakingPlace = ActionType.None;
                        break;
                }
            }
        }
        #endregion

        #region Update: Find and Update self
        private void UpdatePart(ListItemParty part)
        {
            int partyIndex = (int)Global.Variable(part.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                int increment = part.Columns;
                Options = Global.Instance.Party.Heroes[partyIndex].GetItems().Values;

                List<int> items = new List<int>();
                for (int id = 0; id < Options.Count; id++)
                    if (!items.Contains(Options[id]))
                        items.Add(Options[id]);

                Options = items;

                if (Options.Count == 0) SelectedIndex = -1;

                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }

                if (!Enabled || !Visible)
                    return;
                // Check if the list index changes
                if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex++;
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
            }
        }

        private void UpdatePart(ListSkillParty part)
        {
            int partyIndex = (int)Global.Variable(part.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                int increment = part.Columns;
                if (part.Show == SkillType.Skill)
                    Options = Global.Instance.Party.Heroes[partyIndex].GetSkills().Values;
                else if (part.Show == SkillType.Magic)
                    Options = Global.Instance.Party.Heroes[partyIndex].GetMagics().Values;
                else // Both
                {
                    Options = new List<int>(Global.Instance.Party.Heroes[partyIndex].GetSkills().Values);
                    Options.AddRange(Global.Instance.Party.Heroes[partyIndex].GetMagics().Values);
                }
                List<int> items = new List<int>();
                for (int id = 0; id < Options.Count; id++)
                    if (!items.Contains(Options[id]))
                        items.Add(Options[id]);

                Options = items;

                if (Options.Count == 0) SelectedIndex = -1;

                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                if (!Enabled || !Visible)
                    return;
                // Check if the list index changes
                if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex++;
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
            }
        }

        private void UpdatePart(ListEquipmentParty part)
        {
            int partyIndex = (int)Global.Variable(part.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                int increment = part.Columns;

                Options = Global.Instance.Party.Heroes[partyIndex].GetEquipments().Values;

                List<int> items = new List<int>();
                for (int id = 0; id < Options.Count; id++)
                {
                    EquipmentData eq;
                    if (!items.Contains(Options[id]))
                    {
                        eq = GameData.Equipments.GetData(Options[id]);

                        if (eq.UsableBy.Contains(Global.Instance.Party.Heroes[partyIndex].ID))
                            if (!part.DisableSlots || eq.EquipmentSlots.Contains((int)Global.Variable(part.SelectedSlot)))
                                items.Add(Options[id]);
                    }
                }
                items.Add(-1);
                Options = items;

                if (Options.Count == 0) SelectedIndex = -1;

                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);                    if (data != null)                        data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                if (!Enabled || !Visible)
                    return;
                // Check if the list index changes
                if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex++;
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
            }
        }

        private void UpdatePart(ListEquippedParty part)
        {
            int partyIndex = (int)Global.Variable(part.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                int increment = part.Columns;

                Options = Global.Instance.Party.Heroes[partyIndex].GetSlots();
                // Set Variable To Index
                if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot);                    if (data != null)                        data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                if (!Enabled || !Visible)
                    return;
                // Check if the list index changes
                if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex++;
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
            }
        }

        private void UpdatePart(ListItemPartyFromList part)
        {
            ListData list = GameData.Lists.GetData(part.List);
            if (list == null) return;

            int partyIndex = (int)Global.Variable(part.PartyIndex);
            if (partyIndex > -1 && partyIndex < list.Values.Count)
            {
                HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]); if (hero == null) return;
                int increment = part.Columns;
                Options = hero.GetItems().Values;

                List<int> items = new List<int>();
                for (int id = 0; id < Options.Count; id++)
                    if (!items.Contains(Options[id]))
                        items.Add(Options[id]);

                Options = items;

                if (Options.Count == 0) SelectedIndex = -1;

                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);                    if (data != null)                        data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }

                if (!Enabled || !Visible)
                    return;
                // Check if the list index changes
                if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }

                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }

                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex++;
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }

                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }

                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
            }
        }

        private void UpdatePart(ListSkillPartyFromList part)
        {
            ListData list = GameData.Lists.GetData(part.List);
            if (list == null) return;

            int partyIndex = (int)Global.Variable(part.PartyIndex);
            if (partyIndex > -1 && partyIndex < list.Values.Count)
            {
                HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]); if (hero == null) return;
                int increment = part.Columns;
                if (part.Show == SkillType.Skill)
                    Options = hero.GetSkills().Values;
                else if (part.Show == SkillType.Magic)
                    Options = hero.GetMagics().Values;
                else // Both
                {
                    Options = new List<int>(hero.GetSkills().Values);
                    Options.AddRange(hero.GetMagics().Values);
                }
                List<int> items = new List<int>();
                for (int id = 0; id < Options.Count; id++)
                    if (!items.Contains(Options[id]))
                        items.Add(Options[id]);

                Options = items;

                if (Options.Count == 0) SelectedIndex = -1;

                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);                    if (data != null)                        data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                if (!Enabled || !Visible)
                    return;
                // Check if the list index changes
                if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex++;
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
            }
        }

        private void UpdatePart(ListEquipmentPartyFromList part)
        {
            ListData list = GameData.Lists.GetData(part.List);
            if (list == null) return;

            int partyIndex = (int)Global.Variable(part.PartyIndex);
            if (partyIndex > -1 && partyIndex < list.Values.Count)
            {
                HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]); if (hero == null) return;
                int increment = part.Columns;

                Options = hero.GetEquipments().Values;

                List<int> items = new List<int>();
                for (int id = 0; id < Options.Count; id++)
                {
                    EquipmentData eq;
                    if (!items.Contains(Options[id]))
                    {
                        eq = GameData.Equipments.GetData(Options[id]);

                        if (eq.UsableBy.Contains(Global.Instance.Party.Heroes[partyIndex].ID))
                            if (!part.DisableSlots || eq.EquipmentSlots.Contains((int)Global.Variable(part.SelectedSlot)))
                                items.Add(Options[id]);
                    }
                }
                items.Add(-1);
                Options = items;

                if (Options.Count == 0) SelectedIndex = -1;

                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);                    if (data != null)                        data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                if (!Enabled || !Visible)
                    return;
                // Check if the list index changes
                if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex++;
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
            }
        }

        private void UpdatePart(ListEquippedPartyFromList part)
        {
            ListData list = GameData.Lists.GetData(part.List);
            if (list == null) return;

            int partyIndex = (int)Global.Variable(part.PartyIndex);
            if (partyIndex > -1 && partyIndex < list.Values.Count)
            {
                HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]); if (hero == null) return;
                int increment = part.Columns;

                Options = hero.GetSlots();
                // Set Variable To Index
                if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot);                    if (data != null)                        data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                if (!Enabled || !Visible)
                    return;
                // Check if the list index changes
                if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex++;
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.SelectedSlot > -1 && SelectedIndex > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.SelectedSlot); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
            }
        }

        private void UpdatePart(ListItemSource part)
        {
            if (part.List > -1)
            {
                ListData list = Global.Instance.Lists.GetData(part.List);
                int increment = part.Columns;
                Options = list.Values;

                List<int> items = new List<int>();
                for (int id = 0; id < Options.Count; id++)
                    if (!items.Contains(Options[id]))
                        items.Add(Options[id]);

                Options = items;

                if (Options.Count == 0) SelectedIndex = -1;

                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)       
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);                    if (data != null)                        data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }

                if (!Enabled || !Visible)
                    return;
                // Check if the list index changes
                if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex--;
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                {
                    if (SelectedIndex > 0)
                        SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                    else
                        SelectedIndex = Options.Count - 1;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex++;
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
                else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                {
                    if (SelectedIndex < Options.Count - 1)
                        SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                    else
                        SelectedIndex = 0;
                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);
                        if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    // Activate Event
                    if (part.OnSelectedIndex.Count > 0)
                        ActivateEvent(part.OnSelectedIndex);
                }
            }
        }

        private void UpdatePart(ListEquipmentSource part)
        {
            if (part.List > -1)
            {
                ListData list = Global.Instance.Lists.GetData(part.List);
                {
                    int increment = part.Columns;

                    Options = list.Values;

                    List<int> items = new List<int>();
                    for (int id = 0; id < Options.Count; id++)
                    {
                        EquipmentData eq;
                        if (!items.Contains(Options[id]))
                        {
                            eq = GameData.Equipments.GetData(Options[id]);
                            if (!part.DisableSlots || eq.EquipmentSlots.Contains((int)Global.Variable(part.SelectedSlot)))
                                items.Add(Options[id]);
                        }
                    }
                    items.Add(-1);
                    Options = items;

                    if (Options.Count == 0) SelectedIndex = -1;

                    // Set Variable To Index
                    if (part.Variable > -1 && SelectedIndex < Options.Count)
                    {   
                        VariableData data = Global.Instance.Variables.GetData(part.Variable);                        if (data != null)                            data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                    }
                    if (!Enabled || !Visible)
                        return;
                    // Check if the list index changes
                    if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
                    {
                        if (SelectedIndex > 0)
                            SelectedIndex--;
                        else
                            SelectedIndex = Options.Count - 1;
                        // Set Variable To Index
                        if (part.Variable > -1 && SelectedIndex < Options.Count)
                        {
                            VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                        }
                        // Activate Event
                        if (part.OnSelectedIndex.Count > 0)
                            ActivateEvent(part.OnSelectedIndex);
                    }
                    else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
                    {
                        if (SelectedIndex > 0)
                            SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                        else
                            SelectedIndex = Options.Count - 1;
                        // Set Variable To Index
                        if (part.Variable > -1 && SelectedIndex < Options.Count)
                        {
                            VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                        }
                        // Activate Event
                        if (part.OnSelectedIndex.Count > 0)
                            ActivateEvent(part.OnSelectedIndex);
                    }
                    else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
                    {
                        if (SelectedIndex < Options.Count - 1)
                            SelectedIndex++;
                        else
                            SelectedIndex = 0;
                        // Set Variable To Index
                        if (part.Variable > -1 && SelectedIndex < Options.Count)
                        {
                            VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                        }
                        // Activate Event
                        if (part.OnSelectedIndex.Count > 0)
                            ActivateEvent(part.OnSelectedIndex);
                    }
                    else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
                    {
                        if (SelectedIndex < Options.Count - 1)
                            SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                        else
                            SelectedIndex = 0;
                        // Set Variable To Index
                        if (part.Variable > -1 && SelectedIndex < Options.Count)
                        {
                            VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                        }
                        // Activate Event
                        if (part.OnSelectedIndex.Count > 0)
                            ActivateEvent(part.OnSelectedIndex);
                    }
                }
            }
        }

        private void UpdatePart(ListItemShop part)
        {
            int increment = part.Columns;
            Options = Global.ShopItems;

            List<int> items = new List<int>();
            for (int id = 0; id < Options.Count; id++)
                if (!items.Contains(Options[id]))
                    items.Add(Options[id]);

            Options = items;

            if (Options.Count == 0) SelectedIndex = -1;

            // Set Variable To Index
            if (part.Variable > -1 && SelectedIndex < Options.Count)
            {
                VariableData data = Global.Instance.Variables.GetData(part.Variable);                if (data != null)                    data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
            }

            if (!Enabled || !Visible)
                return;
            // Check if the list index changes
            if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
            {
                if (SelectedIndex > 0)
                    SelectedIndex--;
                else
                    SelectedIndex = Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
            {
                if (SelectedIndex > 0)
                    SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                else
                    SelectedIndex = Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
            {
                if (SelectedIndex < Options.Count - 1)
                    SelectedIndex++;
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
            {
                if (SelectedIndex < Options.Count - 1)
                    SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
        }

        private void UpdatePart(ListEquipmentShop part)
        {
            int increment = part.Columns;

            Options = Global.ShopEquipments;

            List<int> items = new List<int>();
            for (int id = 0; id < Options.Count; id++)
            {
                if (!items.Contains(Options[id]))
                    items.Add(Options[id]);
            }
            Options = items;

            if (Options.Count == 0) SelectedIndex = -1;

            // Set Variable To Index
            if (part.Variable > -1 && SelectedIndex < Options.Count)
            {
                VariableData data = Global.Instance.Variables.GetData(part.Variable);                if (data != null)                    data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
            }
            if (!Enabled || !Visible)
                return;
            // Check if the list index changes
            if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
            {
                if (SelectedIndex > 0)
                    SelectedIndex--;
                else
                    SelectedIndex = Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
            {
                if (SelectedIndex > 0)
                    SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                else
                    SelectedIndex = Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
            {
                if (SelectedIndex < Options.Count - 1)
                    SelectedIndex++;
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
            {
                if (SelectedIndex < Options.Count - 1)
                    SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1 && SelectedIndex < Options.Count)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable); if (data != null) data.Value = (SelectedIndex == -1 ? -1 : Options[SelectedIndex]);
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
        }

        private void UpdatePart(MenuOptions part)
        {
            int count = part.Options.Count;
            part.Options.Clear();
            ListItem item;
            for (int i = 0; i < Global.Instance.MenuOptions.Count; i++)
            {
                if (Global.Instance.MenuOptions[i] is int) // Text
                {
                    item = new ListItem();


                    item.Font = part.Font;
                    item.Style = part.Style;
                    item.TextColor = part.TextColor;
                    part.Options.Add(item);
                }
                else // Message
                {
                    item = new ListItem();
                    item.Text = Global.Instance.MenuOptions[i].ToString();
                    item.Font = part.Font;
                    item.Style = part.Style;
                    item.TextColor = part.TextColor;
                    part.Options.Add(item);
                }
            }

            if (count != part.Options.Count)
                SelectedIndex = 0;

            if (!Enabled || !Visible)
                return;
            int increment = part.Columns;
            // Check if the list index changes
            if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
            {
                if (SelectedIndex > 0)
                    SelectedIndex--;
                else
                    SelectedIndex = part.Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
            {
                if (SelectedIndex > 0)
                    SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                else
                    SelectedIndex = part.Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
            {
                if (SelectedIndex < part.Options.Count - 1)
                    SelectedIndex++;
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
            {
                if (SelectedIndex < part.Options.Count - 1)
                    SelectedIndex = Math.Min(SelectedIndex + increment, part.Options.Count - 1);
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
        }

        private void UpdatePart(MenuWindow part)
        {

        }

        private void UpdatePart(MenuButton part)
        {

        }

        private void UpdatePart(ListStatic part)
        {
            if (!Enabled || !Visible)
                return;
            int increment = part.Columns;
            // Check if the list index changes
            if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
            {
                if (SelectedIndex > 0)
                    SelectedIndex--;
                else
                    SelectedIndex = part.Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
            {
                if (SelectedIndex > 0)
                    SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                else
                    SelectedIndex = part.Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
            {
                if (SelectedIndex < part.Options.Count - 1)
                    SelectedIndex++;
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
            {
                if (SelectedIndex < part.Options.Count - 1)
                    SelectedIndex = Math.Min(SelectedIndex + increment, part.Options.Count - 1);
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
        }

        private void UpdatePart(ListParty part)
        {
            int increment = part.Columns;
            Options.Clear();
            for (int i = 0; i < Global.Instance.Party.Heroes.Count; i++)
            {
                Options.Add(Global.Instance.Party.Heroes[i].ID);
            }
            if (!Enabled || !Visible)
                return;
            // Check if the list index changes
            if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
            {
                if (SelectedIndex > 0)
                    SelectedIndex--;
                else
                    SelectedIndex = Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
            {
                if (SelectedIndex > 0)
                    SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                else
                    SelectedIndex = Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
            {
                if (SelectedIndex < Options.Count - 1)
                    SelectedIndex++;
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
            {
                if (SelectedIndex < Options.Count - 1)
                    SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
        }

        private void UpdatePart(ListPartyFromList part)
        {
            int increment = part.Columns;
            Options.Clear();

            List<int> IDs = GameData.Lists.GetData(part.List).Values;

            for (int i = 0; i < IDs.Count; i++)
            {
                Options.Add(IDs[i]);
            }

            if (!Enabled || !Visible)
                return;
            // Check if the list index changes
            if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
            {
                if (SelectedIndex > 0)
                    SelectedIndex--;
                else
                    SelectedIndex = Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
            {
                if (SelectedIndex > 0)
                    SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                else
                    SelectedIndex = Options.Count - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
            {
                if (SelectedIndex < Options.Count - 1)
                    SelectedIndex++;
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
            {
                if (SelectedIndex < Options.Count - 1)
                    SelectedIndex = Math.Min(SelectedIndex + increment, Options.Count - 1);
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
        }

        private void UpdatePart(ListSaveLoad part)
        {
            int increment = part.Columns;

            if (!Enabled || !Visible)
                return;
            // Check if the list index changes
            if (InputState.IsNewKeyPress(Keys.Left, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadLeft, InputState.LastPlayer) || InputState.LeftStickLeft())
            {
                if (SelectedIndex > 0)
                    SelectedIndex--;
                else
                    SelectedIndex = part.MaxFiles - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Up, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadUp, InputState.LastPlayer) || InputState.LeftStickUp())
            {
                if (SelectedIndex > 0)
                    SelectedIndex = Math.Max(SelectedIndex - increment, 0);
                else
                    SelectedIndex = part.MaxFiles - 1;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Right, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadRight, InputState.LastPlayer) || InputState.LeftStickRight())
            {
                if (SelectedIndex < part.MaxFiles - 1)
                    SelectedIndex++;
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
            else if (InputState.IsNewKeyPress(Keys.Down, InputState.LastPlayer) || InputState.IsNewButtonPress(Buttons.DPadDown, InputState.LastPlayer) || InputState.LeftStickDown())
            {
                if (SelectedIndex < part.MaxFiles - 1)
                    SelectedIndex = Math.Min(SelectedIndex + increment, part.MaxFiles - 1);
                else
                    SelectedIndex = 0;
                // Set Variable To Index
                if (part.Variable > -1)
                {
                    VariableData data = Global.Instance.Variables.GetData(part.Variable);
                    if (data != null)
                        data.Value = SelectedIndex;
                }
                // Activate Event
                if (part.OnSelectedIndex.Count > 0)
                    ActivateEvent(part.OnSelectedIndex);
            }
        }

        private void UpdatePart(TextBoxPart part)
        {
            if (!Enabled || !Visible)
                return;

#if !SILVERLIGHT
            Keys[] keys = Keyboard.GetState(0).GetPressedKeys();
#else
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
#endif
            if (part.String > -1)
                Text = Global.Instance.Strings.GetData(part.String).Value;
            bool ShiftDown = (InputState.IsKeyPress(Keys.RightShift, 0) || InputState.IsKeyPress(Keys.LeftShift, 0));
            bool CapsLock = InputState.IsCapsLockOn();
            char[] dontAllow = part.DoNotAllow.ToCharArray();

            KeyTimer++;
            if (Text != null)
            {
                if (keys.Length > 0)
                {
                    Keys key = keys[keys.Length - 1];
                    // Get Last Pressed Key
                    if (ShiftDown)
                    {
                        for (int i = keys.Length - 1; i > -1; i--)
                        {
                            if (keys[i] != Keys.RightShift && keys[i] != Keys.LeftShift)
                            {
                                key = keys[i]; break;
                            }
                        }
                    }
                    // If this key is pressed, check timer
                    if (PressedKey.HasValue && PressedKey.Value == key)
                    {
                        if (KeyTimer >= 10) { PressedKey = null; KeyTimer = 0; } else return;
                    }

                    KeyTimer = 0; PressedKey = key;

                    switch (key)
                    {
                        case Keys.Left:
                            #region Move Cursor Left
                            if (IndexLocation.X > 0) IndexLocation.X--;
                            #endregion
                            break;
                        case Keys.Right:
                            #region Move Cursor Right
                            if (IndexLocation.X < Text.Length)
                                IndexLocation.X++;
                            #endregion
                            break;
                        case Keys.Up:

                            break;
                        case Keys.Down:

                            break;
                        case Keys.Back:
                            #region Backspace
                            if (Text.Length > 0)
                            {
                                List<char> chr = Text.ToCharArray().ToList();
                                chr.RemoveAt(IndexLocation.X - 1);
                                Text = new String(chr.ToArray());
                                IndexLocation.X--;
                            }
                            #endregion
                            break;
                        case Keys.Delete:
                            #region Delete
                            if (Text.Length > 0 && IndexLocation.X < Text.Length - 1)
                            {
                                List<char> chr = Text.ToCharArray().ToList();
                                chr.RemoveAt(IndexLocation.X);
                                Text = new String(chr.ToArray());
                                IndexLocation.X--;
                            }
                            #endregion
                            break;
                        case Keys.Home:
                            IndexLocation.X = 0;
                            break;
                        case Keys.End:
                            break;
                        case Keys.Enter:
                            break;
                        case Keys.Space:
                            if (part.AllowSpaces)
                            {
                                Add(" ", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.Decimal:
                            if (part.AllowSpecialChar)
                            {
                                Add(".", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.Divide:
                            if (part.AllowSpecialChar)
                            {
                                Add("/", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemBackslash:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("|", dontAllow, part.MaxNumberOfChars); else Add("\\", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemCloseBrackets:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("}", dontAllow, part.MaxNumberOfChars); else Add("]", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemComma:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("<", dontAllow, part.MaxNumberOfChars); else Add(",", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemMinus:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("_", dontAllow, part.MaxNumberOfChars); else Add("-", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemOpenBrackets:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("{", dontAllow, part.MaxNumberOfChars); else Add("[", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemPeriod:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add(">", dontAllow, part.MaxNumberOfChars); else Add(".", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemPipe:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("|", dontAllow, part.MaxNumberOfChars); else Add("\\", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemPlus:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("+", dontAllow, part.MaxNumberOfChars); else Add("=", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemQuestion:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("?", dontAllow, part.MaxNumberOfChars); else Add("/", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemQuotes:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("\"", dontAllow, part.MaxNumberOfChars); else Add("'", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemSemicolon:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add(":", dontAllow, part.MaxNumberOfChars); else Add(";", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.OemTilde:
                            if (part.AllowSpecialChar)
                            {
                                if (ShiftDown) Add("~", dontAllow, part.MaxNumberOfChars); else Add("`", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.Subtract:
                            if (part.AllowSpecialChar)
                            {
                                Add("-", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.Multiply:
                            if (part.AllowSpecialChar)
                            {
                                Add("*", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        case Keys.Tab:
                            if (part.AllowSpaces)
                            {
                                Add("      ", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 6;
                            }
                            break;
                        case Keys.Add:
                            if (part.AllowSpecialChar)
                            {
                                Add("+", dontAllow, part.MaxNumberOfChars);
                                IndexLocation.X += 1;
                            }
                            break;
                        default:
                            string k = key.ToString();
                            if (k.Length == 1)
                            {
                                if (CapsLock || ShiftDown)
                                    Add(k.ToUpper(), dontAllow, part.MaxNumberOfChars);
                                else
                                    Add(k.ToLower(), dontAllow, part.MaxNumberOfChars);

                                IndexLocation.X += 1;
                            }
                            else if (k.Length == 2 && k.StartsWith("D"))
                            {
                                if (ShiftDown)
                                {

                                    if (part.AllowSpecialChar)
                                    {
                                        switch (int.Parse(k.Substring(1, 1)))
                                        {
                                            case 0:
                                                Add(")", dontAllow, part.MaxNumberOfChars);
                                                break;
                                            case 1:
                                                Add("!", dontAllow, part.MaxNumberOfChars);
                                                break;
                                            case 2:
                                                Add("@", dontAllow, part.MaxNumberOfChars);
                                                break;
                                            case 3:
                                                Add("#", dontAllow, part.MaxNumberOfChars);
                                                break;
                                            case 4:
                                                Add("$", dontAllow, part.MaxNumberOfChars);
                                                break;
                                            case 5:
                                                Add("%", dontAllow, part.MaxNumberOfChars);
                                                break;
                                            case 6:
                                                Add("^", dontAllow, part.MaxNumberOfChars);
                                                break;
                                            case 7:
                                                Add("&", dontAllow, part.MaxNumberOfChars);
                                                break;
                                            case 8:
                                                Add("*", dontAllow, part.MaxNumberOfChars);
                                                break;
                                            case 9:
                                                Add("(", dontAllow, part.MaxNumberOfChars);
                                                break;
                                        }
                                    }
                                }
                                else
                                    Add(k.Substring(1, 1), dontAllow, part.MaxNumberOfChars);

                                IndexLocation.X += 1;
                            }
                            break;
                    }

                }
                if (part.String > -1)
                    Global.Instance.Strings.GetData(part.String).Value = Text;
            }
        }
        private void Add(string chr, char[] dontAllow, int max)
        {
            if (dontAllow.Contains(chr[0]) || Text.Length >= max)
            { IndexLocation.X--; return; }
            if (IndexLocation.X < Text.Length)
            {
                List<char> chrs = Text.ToCharArray().ToList();
                chrs.Insert(IndexLocation.X, chr[0]);
                Text = new String(chrs.ToArray());
            }
            else
                Text += chr;
        }

        private void UpdatePart(AnimationPartStatic part, GameTime gameTime)
        {
            if (!Enabled || !Visible)
                return;
            if (!Animation.IsAnimating && part.Animate)
                Animation.Start();
            Animation.Position = part.RealPosition;
            Animation.Update(gameTime);
        }

        private void UpdatePart(AnimationPartParty part, GameTime gameTime)
        {
            if (!Enabled || !Visible)
                return;
            int partyIndex = (int)Global.Variable(((AnimationPartParty)data).PartyIndex);
            if (partyIndex != PartyIndex && partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count && Global.Instance.Party.Heroes[partyIndex] != null)
            {
                PartyIndex = partyIndex;
                Animation.Setup(Global.Instance.Party.Heroes[partyIndex].AnimationID, ((AnimationPartParty)data).Action);
            }
            else if (partyIndex < 0 || partyIndex >= Global.Instance.Party.Heroes.Count || Global.Instance.Party.Heroes[partyIndex] == null)
                Animation.Clear();
            PartyIndex = partyIndex;
            if (!Animation.IsAnimating && part.Animate)
                Animation.Start();
            Animation.Position = part.RealPosition;
            Animation.Update(gameTime);
        }

        private void UpdatePart(AnimationPartPartyFromList part, GameTime gameTime)
        {
            if (!Enabled || !Visible)
                return;
            ListData list = GameData.Lists.GetData(part.List);
            if (list == null) return;

            int partyIndex = (int)Global.Variable(((AnimationPartPartyFromList)data).PartyIndex);
            if (partyIndex != PartyIndex && partyIndex > -1 && partyIndex < list.Values.Count && list.Values[partyIndex] != null)
            {
                PartyIndex = partyIndex;
                HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                Animation.Setup(hero.AnimationID, ((AnimationPartParty)data).Action);
            }
            else if (partyIndex < 0 || partyIndex >= Global.Instance.Party.Heroes.Count || Global.Instance.Party.Heroes[partyIndex] == null)
                Animation.Clear();
            PartyIndex = partyIndex;
            if (!Animation.IsAnimating && part.Animate)
                Animation.Start();
            Animation.Position = part.RealPosition;
            Animation.Update(gameTime);
        }
        #endregion

        #region Method: Process Program
        /// <summary>
        /// Process Program
        /// </summary>
        private void ProcessPrograms()
        {
            if (CurrentBranch != null)
            {
                if (!(actionTakingPlace != ActionType.None && waitActionCompelition) && waitFrames <= 0)
                {
                    if (programIndex > -1 && programIndex < CurrentBranch.Programs.Count)
                    {
                        if (CurrentBranch.Enabled)
                        {
                            switch (CurrentBranch.Programs[programIndex].ProgramCategory)
                            {
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
                                case ProgramCategory.Menu: // Menu
                                    ProcessCategoryMenu(CurrentBranch.Programs[programIndex], ref programIndex);
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
                            if (data is BackgroundProcessPart)
                                isProgramActive = true;
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
                        NextProgram();
                    }
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
            {
                ProcessPrograms();
            }
        }
        /// <summary>
        /// Setup branch
        /// </summary>
        /// <param name="eventProgramData"></param>
        public override void SetupBranch(EventProgramData eventProgramData)
        {
            LastBranch.Add(CurrentBranch);
            LastProgramIndex.Add(programIndex + 1);
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
            LastProgramIndex.Add(programIndex + 1);
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
            {
                return;
            }
            // Go to last branch
            CurrentBranch = LastBranch.Last();
            index = LastProgramIndex.Last();
            LastBranch.Remove(LastBranch.Last());
            LastProgramIndex.RemoveAt(LastProgramIndex.Count - 1);
        }
        /// <summary>
        /// Process Category Menu
        /// </summary>
        /// <param name="eventProgramData"></param>
        /// <param name="programIndex"></param>
        private void ProcessCategoryMenu(EventProgramData eventProgramData, ref int programIndex)
        {
            MenuPartProcessor part;
            switch (eventProgramData.Code)
            {
                case 0: // Close Menu
                    ParentMenu.Close();
                    programIndex++; NextProgram();
                    break;
                case 1: // Toggle Enable
                    if ((int)eventProgramData.Value[0] == -1)
                    {
                        if ((int)eventProgramData.Value[1] == 0) // Enable
                            Enable();
                        else if ((int)eventProgramData.Value[1] == 1)// Disable
                            Disable();
                    }
                    else
                        ParentMenu.ToggleEnable((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                    programIndex++; NextProgram();
                    break;
                case 2: // Toggle Visible
                    if ((int)eventProgramData.Value[0] == -1)
                    {
                        if ((int)eventProgramData.Value[1] == 0) // Show
                            Show();
                        else if ((int)eventProgramData.Value[1] == 1)// Hide
                            Hide();
                    }
                    else
                        ParentMenu.ToggleVisible((int)eventProgramData.Value[0], (int)eventProgramData.Value[1]);
                    programIndex++; NextProgram();
                    break;
                case 3: // Select
                    if ((int)eventProgramData.Value[0] == -1)
                        ParentMenu.Select(this);
                    else
                        ParentMenu.Select((int)eventProgramData.Value[0]);
                    programIndex++; NextProgram();
                    break;
                case 4: // Conditions
                    bool result = false;
                    if ((int)eventProgramData.Value[0] == -1)
                        part = this;
                    else
                        part = ParentMenu.GetMenuPart((int)eventProgramData.Value[0]);

                    switch ((int)eventProgramData.Value[2])
                    {
                        case 0: // Enabled
                            result = (part.Enabled);
                            break;
                        case 1: // Visible
                            result = (part.Visible);
                            break;
                        case 2: // Selected
                            result = (ParentMenu.SelectedPart == part);
                            break;
                    }
                    if ((int)eventProgramData.Value[1] == 1)
                        result = !result;
                    if (result)
                        SetupBranch(eventProgramData);
                    else if (eventProgramData.Else)
                        SetupElseBranch(eventProgramData);
                    programIndex++; NextProgram();
                    break;
                case 5: // Move Menu To
                    if ((int)eventProgramData.Value[0] == -1)
                        part = this;
                    else
                        part = ParentMenu.GetMenuPart((int)eventProgramData.Value[0]);

                    part.MoveTo((int)GetValue((int)eventProgramData.Value[1], (int)eventProgramData.Value[2]), (int)GetValue((int)eventProgramData.Value[1], (int)eventProgramData.Value[3]), (int)eventProgramData.Value[4]);
                    break;
            }
        }
        #region Helper: Get Value Constant or Variable
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
            }
            return 0;
        }
        #endregion
        #endregion

        #region Method: Show, Hide, Enable, Disable, Move TO
        /// <summary>
        /// Show 
        /// </summary>
        public void Show()
        {
            Visible = true;
        }
        /// <summary>
        /// Hide
        /// </summary>
        public void Hide()
        {
            Visible = false;
        }
        /// <summary>
        /// Enable
        /// </summary>
        public void Enable()
        {
            ParentMenu.AddToEnable(this);
        }
        /// <summary>
        /// Disable
        /// </summary>
        public void Disable()
        {
            ParentMenu.AddToDisable(this);
        }
        /// <summary>
        /// Move To
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="frames"></param>
        internal void MoveTo(int x, int y, int frames)
        {
            if (frames <= 0)
            {
                Position = new Vector2(x, y);
            }
            else
            {
                MoveToPosition.X = x;
                MoveToPosition.Y = y;
                MoveToDifference.X = (Position.X - x) / frames;
                MoveToDifference.Y = (Position.X - y) / frames;
            }
        }
        #endregion

        #region Draw: Find and Draw Self
        /// <summary>
        /// Draw Event
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, IMenuParts selected, Vector2 offset)
        {
            base.Draw(gameTime);
            // Draw only if  data exists and page exists
            if (data != null)
            {
                if (Data is MenuWindow)
                {
                    DrawWindow(offset);
                }
                else if (Data is MenuButton)
                {
                    DrawButton(offset);
                }
                else if (Data is TextPartStatic)
                {
                    DrawTextPartStatic(offset);
                }
                else if (Data is TextPartSource)
                {
                    DrawTextPartSource(offset);
                }
                else if (Data is TextPartData)
                {
                    DrawTextPartData(offset);
                }
                else if (Data is TextPartString)
                {
                    DrawTextPartString(offset);
                }
                else if (Data is TextPartVariable)
                {
                    DrawTextPartVariable(offset);
                }
                else if (Data is TextPartParty)
                {
                    DrawTextPartParty(offset);
                }
                else if (Data is TextPartPartyFromList)
                {
                    DrawTextPartPartyFromList(offset);
                }
                else if (Data is ListStatic)
                {
                    DrawStaticList(offset);
                }
                else if (Data is DynamicBarParty)
                {
                    DrawDynamicBarParty(offset);
                }
                else if (Data is DynamicBarPartyFromList)
                {
                    DrawDynamicBarPartyFromList(offset);
                }
                else if (Data is DynamicBarVariable)
                {
                    DrawDynamicBarVariable(offset);
                }
                else if (Data is AnimationPartStatic)
                {
                    DrawAnimationPartStatic(offset, gameTime);
                }
                else if (Data is AnimationPartParty)
                {
                    DrawAnimationPartParty(offset, gameTime);
                }
                else if (Data is AnimationPartPartyFromList)
                {
                    DrawAnimationPartPartyFromList(offset, gameTime);
                }
                else if (Data is ImagePart)
                {
                    DrawImagePart(offset);
                }
                else if (Data is MenuOptions)
                {
                    DrawMenuOptions(offset);
                }
                else if (Data is ListItemParty)
                {
                    DrawListItemParty(offset);
                }
                else if (Data is ListItemPartyFromList)
                {
                    DrawListItemPartyFromList(offset);
                }
                else if (Data is ListEquipmentParty)
                {
                    DrawListEquipmentParty(offset);
                }
                else if (Data is ListEquipmentPartyFromList)
                {
                    DrawListEquipmentPartyFromList(offset);
                }
                else if (Data is ListSkillParty)
                {
                    DrawListSkillParty(offset);
                }
                else if (Data is ListSkillPartyFromList)
                {
                    DrawListSkillPartyFromList(offset);
                }
                else if (Data is ListEquippedParty)
                {
                    DrawListEquippedParty(offset);
                }
                else if (Data is ListEquippedPartyFromList)
                {
                    DrawListEquippedPartyFromList(offset);
                }
                else if (Data is TextPartItem)
                {
                    DrawTextPartItem(offset);
                }
                else if (Data is ListItemSource)
                {
                    DrawListItemSource(offset);
                }
                else if (Data is ListEquipmentSource)
                {
                    DrawListEquipmentSource(offset);
                }
                else if (Data is ListSkillSource)
                {
                    DrawListSkillSource(offset);
                }
                else if (Data is TextPartEquipment)
                {
                    DrawTextPartEquipment(offset);
                }
                else if (Data is TextPartSkill)
                {
                    DrawTextPartSkill(offset);
                }
                else if (Data is ListParty)
                {
                    DrawPartyList(offset);
                }
                else if (Data is ListPartyFromList)
                {
                    DrawPartyListFromList(offset);
                }
                else if (Data is ListItemShop)
                {
                    DrawListItemShop(offset);
                }
                else if (Data is ListEquipmentShop)
                {
                    DrawListEquipmentShop(offset);
                }
                else if (Data is ListSaveLoad)
                {
                    DrawListSaveLoad(offset);
                }
                else if (Data is TextPartSaveLoad)
                {
                    DrawTextSaveLoad(offset);
                }
                else if (Data is TextBoxPart)
                {
                    DrawTextbox(offset);
                }
                else if (Data is TextPartNameParty)
                {
                    DrawTextPartNameParty(offset);
                }
                else if (Data is TextPartNamePartyFromList)
                {
                    DrawTextPartNamePartyFromList(offset);
                }
                else if (Data is TextPartEquipStat)
                {
                    DrawTextPartEquipStat(offset);
                }
                else if (Data is TextPartEquippedStat)
                {
                    DrawTextPartEquippedStat(offset);
                }
                else if (Data is TextPartEquippedStatFromList)
                {
                    DrawTextPartEquippedStatFromList(offset);
                }
                else if (Data is TextPartEquipped)
                {
                    DrawTextPartEquipped(offset);
                }
                else if (Data is TextPartEquipped2)
                {
                    DrawTextPartEquipped2(offset);
                }
                else if (Data is TextPartEquipped)
                {
                    DrawTextPartEquipped(offset);
                }
                else if (Data is TextPartCount)
                {
                    DrawTextPartCount(offset);
                }
                else if (Data is HighlighterStatic)
                {
                    DrawHighlighterStatic(offset);
                }
                // Draw child parts
                for (int index = 0; index < MenuParts.Count; index++)
                {
                    if (MenuParts[index].Visible)
                    {
                        // Draw part
                        MenuParts[index].Draw(gameTime, selected, offset);
                    }
                }
            }
        }

        #region Text
        private void DrawTextPartStatic(Vector2 offset)
        {
            TextPartStatic menuPart = (TextPartStatic)data;
            FontData font = GameData.Fonts.GetData(menuPart.Font);

            if (font != null && Text != null)
            {
                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
            }
        }

        private void DrawTextPartSource(Vector2 offset)
        {
            throw new NotImplementedException();
        }

        private void DrawTextPartData(Vector2 offset)
        {
            throw new NotImplementedException();
        }

        private void DrawTextPartString(Vector2 offset)
        {
            TextPartString menuPart = (TextPartString)data;

            if (menuPart.String > -1)
            {
                Text = Global.String(menuPart.String);

                FontData font = GameData.Fonts.GetData(menuPart.Font);

                if (font != null && Text != null)
                {
                    FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                    GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                }
            }
        }

        private void DrawTextPartVariable(Vector2 offset)
        {
            TextPartVariable menuPart = (TextPartVariable)data;

            if (menuPart.Variable > -1)
            {
                string[] tex = Global.Variable(menuPart.Variable).ToString().Split('.');

                if (tex.Length > 1 && menuPart.Decimals > 0)
                    tex[0] += "." + tex[1].Remove((tex[1].Length > menuPart.Decimals ? menuPart.Decimals : tex[1].Length - 1));
                Text = tex[0];

                FontData font = GameData.Fonts.GetData(menuPart.Font);

                if (font != null && Text != null)
                {
                    FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                    GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                }
            }
        }

        private void DrawTextPartParty(Vector2 offset)
        {
            TextPartParty menuPart = (TextPartParty)data;
            FontData font = GameData.Fonts.GetData(menuPart.Font);

            if (font != null)
            {
                int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
                if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
                {
                    switch (menuPart.PropertyType)
                    {
                        case PartyPropertyType.Modified:
                            Text = Global.Instance.Party.Heroes[partyIndex].GetModifiedPropertyValue(menuPart.Property, menuPart.LevelPlus).ToString();
                            break;
                        case PartyPropertyType.Unmodified:
                            Text = Global.Instance.Party.Heroes[partyIndex].GetPropertyValue(menuPart.Property, menuPart.LevelPlus).ToString();
                            break;
                        default:
                            Text = (Global.Instance.Party.Heroes[partyIndex].GetModifiedPropertyValue(menuPart.Property, menuPart.LevelPlus) - Global.Instance.Party.Heroes[partyIndex].GetPropertyValue(menuPart.Property, menuPart.LevelPlus)).ToString();
                            break;
                    }
                    FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                    GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                }
            }
        }

        private void DrawTextPartPartyFromList(Vector2 offset)
        {
            TextPartPartyFromList menuPart = (TextPartPartyFromList)data;
            FontData font = GameData.Fonts.GetData(menuPart.Font);

            if (font != null)
            {

                ListData list = GameData.Lists.GetData(menuPart.List);
                if (list != null)
                {
                    int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
                    if (partyIndex > -1 && partyIndex < list.Values.Count)
                    {
                        HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);

                        if (hero != null)
                        {
                            switch (menuPart.PropertyType)
                            {
                                case PartyPropertyType.Modified:
                                    Text = hero.GetModifiedPropertyValue(menuPart.Property, menuPart.LevelPlus).ToString();
                                    break;
                                case PartyPropertyType.Unmodified:
                                    Text = hero.GetPropertyValue(menuPart.Property, menuPart.LevelPlus).ToString();
                                    break;
                                default:
                                    Text = (hero.GetModifiedPropertyValue(menuPart.Property, menuPart.LevelPlus) - hero.GetPropertyValue(menuPart.Property, menuPart.LevelPlus)).ToString();
                                    break;
                            }
                            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                            GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                        }
                    }
                }
            }
        }

        private void DrawTextPartEquipment(Vector2 offset)
        {
            TextPartEquipment menuPart = (TextPartEquipment)Data;

            int id = (int)Global.Variable(menuPart.ItemID);

            if (id > -1)
            {
                EquipmentData item = GameData.Equipments.GetData(id);

                if (item != null)
                {
                    // Get Text
                    switch (menuPart.Show)
                    {
                        case ShowItemType.Name:
                            Text = item.Name;
                            break;
                        case ShowItemType.Description:
                            Text = item.Description;
                            break;
                        case ShowItemType.Cost:
                            Text = item.Price.ToString();
                            break;
                        case ShowItemType.Value:
                            Text = item.Value.ToString();
                            break;
                        case ShowItemType.Icon:
                            Texture2D icon = GetTexture(item.Icon);

                            if (icon != null && icon.Name != "BLANK")
                            {
                                Global.SpriteBatch.Draw(icon, menuPart.RealPosition + offset, Color.White);
                            }
                            return;
                        default:
                            Text = "";
                            break;
                    }

                    FontData font = GameData.Fonts.GetData(menuPart.Font);

                    if (font != null && Text != null)
                    {
                        FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                        GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                    }
                }
            }
        }

        private void DrawTextPartSkill(Vector2 offset)
        {
            TextPartSkill menuPart = (TextPartSkill)Data;

            int id = (int)Global.Variable(menuPart.SkillID);

            if (id > -1)
            {
                SkillData item = GameData.Skills.GetData(id);

                if (item != null)
                {
                    // Get Text
                    switch (menuPart.Show)
                    {
                        case ShowItemType.Name:
                            Text = item.Name;
                            break;
                        case ShowItemType.Description:
                            Text = item.Description;
                            break;
                        case ShowItemType.Cost:
                            Text = item.Cost.ToString();
                            break;
                        case ShowItemType.Icon:
                            Texture2D icon = GetTexture(item.Icon);

                            if (icon != null && icon.Name != "BLANK")
                            {
                                Global.SpriteBatch.Draw(icon, menuPart.RealPosition + offset, Color.White);
                            }
                            return;
                        default:
                            Text = "";
                            break;
                    }

                    FontData font = GameData.Fonts.GetData(menuPart.Font);

                    if (font != null && Text != null)
                    {
                        FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                        GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                    }
                }
            }
        }

        private void DrawTextPartItem(Vector2 offset)
        {
            TextPartItem menuPart = (TextPartItem)Data;

            int id = (int)Global.Variable(menuPart.ItemID);

            if (id > -1)
            {
                ItemData item = GameData.Items.GetData(id);

                if (item != null)
                {
                    // Get Text
                    switch (menuPart.Show)
                    {
                        case ShowItemType.Name:
                            Text = item.Name;
                            break;
                        case ShowItemType.Description:
                            Text = item.Description;
                            break;
                        case ShowItemType.Cost:
                            Text = item.Price.ToString();
                            break;
                        case ShowItemType.Icon:
                            Texture2D icon = GetTexture(item.Icon);

                            if (icon != null && icon.Name != "BLANK")
                            {
                                Global.SpriteBatch.Draw(icon, menuPart.RealPosition + offset, Color.White);
                            }
                            return;
                        default:
                            Text = "";
                            break;
                    }

                    FontData font = GameData.Fonts.GetData(menuPart.Font);

                    if (font != null && Text != null)
                    {
                        FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                        GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                    }
                }
            }
        }

        private void DrawTextPartCount(Vector2 offset)
        {
            TextPartCount menuPart = (TextPartCount)Data;

            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                int id = (int)Global.Variable(menuPart.ItemID);

                if (id > -1)
                {
                    // Get Text
                    switch (menuPart.Show)
                    {
                        case ShowCountType.Item:
                            Text = Global.Instance.Party.Heroes[partyIndex].GetItems().Values.Count(id).ToString();
                            break;
                        case ShowCountType.Equipment:
                            Text = Global.Instance.Party.Heroes[partyIndex].GetEquipments().Values.Count(id).ToString();
                            break;
                    }

                    FontData font = GameData.Fonts.GetData(menuPart.Font);

                    if (font != null && Text != null)
                    {
                        FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                        GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                    }
                }
            }
        }

        private void DrawTextPartEquipped(Vector2 offset)
        {
            TextPartEquipped menuPart = (TextPartEquipped)Data;

            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                int id = (int)Global.Variable(menuPart.SlotID);

                if (id > -1)
                {
                    EquipmentData item = GameData.Equipments.GetData(Global.Instance.Party.Heroes[partyIndex].GetEquipment(id));

                    if (item != null)
                    {
                        // Get Text
                        switch (menuPart.Show)
                        {
                            case ShowItemType.Name:
                                Text = item.Name;
                                break;
                            case ShowItemType.Description:
                                Text = item.Description;
                                break;
                            case ShowItemType.Cost:
                                Text = item.Price.ToString();
                                break;
                            case ShowItemType.Icon:
                                Texture2D icon = GetTexture(item.Icon);

                                if (icon != null && icon.Name != "BLANK")
                                {
                                    Global.SpriteBatch.Draw(icon, menuPart.RealPosition + offset, Color.White);
                                }
                                return;
                            default:
                                Text = "";
                                break;
                        }

                        FontData font = GameData.Fonts.GetData(menuPart.Font);

                        if (font != null && Text != null)
                        {
                            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                            GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                        }
                    }
                }
            }
        }

        private void DrawTextPartEquipped2(Vector2 offset)
        {
            TextPartEquipped2 menuPart = (TextPartEquipped2)Data;


            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                int id = (int)Global.Variable(menuPart.EquipmentID);

                if (id > -1)
                {
                    EquipmentData equip = GameData.Equipments.GetData(id);

                    if (equip != null)
                    {
                        EquipmentData heroEquip = null;
                        for (int i = 0; i < equip.EquipmentSlots.Count; i++)
                        {
                            id = Global.Instance.Party.Heroes[partyIndex].GetEquipment(equip.EquipmentSlots[i]);
                            if (id > -1)
                                heroEquip = GameData.Equipments.GetData(id);
                            if (heroEquip != null)
                                break;
                        }

                        if (heroEquip != null)
                        {
                            // Get Text
                            switch (menuPart.Show)
                            {
                                case ShowItemType.Name:
                                    Text = heroEquip.Name;
                                    break;
                                case ShowItemType.Description:
                                    Text = heroEquip.Description;
                                    break;
                                case ShowItemType.Cost:
                                    Text = heroEquip.Price.ToString();
                                    break;
                                case ShowItemType.Icon:
                                    Texture2D icon = GetTexture(heroEquip.Icon);

                                    if (icon != null && icon.Name != "BLANK")
                                    {
                                        Global.SpriteBatch.Draw(icon, menuPart.RealPosition + offset, Color.White);
                                    }
                                    return;
                                default:
                                    Text = "";
                                    break;
                            }

                            FontData font = GameData.Fonts.GetData(menuPart.Font);

                            if (font != null && Text != null)
                            {
                                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                                GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                            }
                        }
                    }
                }
            }
        }

        private void DrawTextPartEquipStat(Vector2 offset)
        {
            TextPartEquipStat menuPart = (TextPartEquipStat)Data;

            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                int id = (int)Global.Variable(menuPart.EquipmentID);

                if (id > -1)
                {
                    EquipmentData equip = GameData.Equipments.GetData(id);

                    if (equip != null)
                    {
                        EquipmentData heroEquip = null;
                        for (int i = 0; i < equip.EquipmentSlots.Count; i++)
                        {
                            id = Global.Instance.Party.Heroes[partyIndex].GetEquipment(equip.EquipmentSlots[i]);
                            if (id > -1)
                                heroEquip = GameData.Equipments.GetData(id);
                            if (heroEquip != null)
                                break;
                        }

                        if (heroEquip != null)
                        {
                            id = equip.Value - heroEquip.Value;
                            if (id > 0)
                                Text = "+ " + (id).ToString();
                            else
                                Text = id.ToString();

                            FontData font = GameData.Fonts.GetData(menuPart.Font);

                            if (font != null && Text != null)
                            {
                                FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                                GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                            }
                        }
                    }
                }
            }
        }

        private void DrawTextPartEquippedStatFromList(Vector2 offset)
        {
            TextPartEquippedStatFromList menuPart = (TextPartEquippedStatFromList)Data;
            Text = "";
            ListData list = GameData.Lists.GetData(menuPart.List);
            if (list != null)
            {
                int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
                if (partyIndex > -1 && partyIndex < list.Values.Count)
                {
                    HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);

                    if (hero != null)
                    {
                        int value1 = 0, value2 = 0;
                        int id = (int)Global.Variable(menuPart.SlotID);

                        if (id > -1)
                        {
                            EquipmentData equipped = GameData.Equipments.GetData(hero.GetEquipment(id));

                            if (equipped != null && equipped.Property == menuPart.Property)
                            {
                                value1 = equipped.Value;
                            }
                        }

                        id = (int)Global.Variable(menuPart.EquipmentID);
                        if (id > -1)
                        {
                            EquipmentData item = GameData.Equipments.GetData(id);

                            if (item != null && item.Property == menuPart.Property)
                            {
                                value2 = item.Value;
                            }
                        }
                        else if (id == -1 && value1 > 0)
                        {
                            value1 = -value1;
                            Text = value1.ToString();
                        }

                        if (value2 > 0 && value1 > 0)
                        {
                            value2 -= value1;
                            if (value2 > 0)
                                Text = "+ " + (value2).ToString();
                            else
                                Text = value2.ToString();
                        }
                        else if (value2 > 0)
                        {
                            if (value2 > 0)
                                Text = "+ " + (value2).ToString();
                            else
                                Text = value2.ToString();
                        }


                        FontData font = GameData.Fonts.GetData(menuPart.Font);

                        if (font != null && Text != null)
                        {
                            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                            GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                        }
                    }
                }
            }
        }

        private void DrawTextPartEquippedStat(Vector2 offset)
        {
            TextPartEquippedStat menuPart = (TextPartEquippedStat)Data;
            Text = "";
            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                int value1 = 0, value2 = 0;
                int id = (int)Global.Variable(menuPart.SlotID);

                if (id > -1)
                {
                    EquipmentData equipped = GameData.Equipments.GetData(Global.Instance.Party.Heroes[partyIndex].GetEquipment(id));

                    if (equipped != null && equipped.Property == menuPart.Property)
                    {
                        value1 = equipped.Value;
                    }
                }

                id = (int)Global.Variable(menuPart.EquipmentID);
                if (id > -1)
                {
                    EquipmentData item = GameData.Equipments.GetData(id);

                    if (item != null && item.Property == menuPart.Property)
                    {
                        value2 = item.Value;
                    }
                }
                else if (id == -1 && value1 > 0)
                {
                    value1 = -value1;
                    Text = value1.ToString();
                }

                if (value2 > 0 && value1 > 0)
                {
                    value2 -= value1;
                    if (value2 > 0)
                        Text = "+ " + (value2).ToString();
                    else
                        Text = value2.ToString();
                }
                else if (value2 > 0)
                {
                    if (value2 > 0)
                        Text = "+ " + (value2).ToString();
                    else
                        Text = value2.ToString();
                }


                FontData font = GameData.Fonts.GetData(menuPart.Font);

                if (font != null && Text != null)
                {
                    FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                    GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                }
            }
        }

        private void DrawTextPartNameParty(Vector2 offset)
        {
            TextPartNameParty menuPart = (TextPartNameParty)data;
            FontData font = GameData.Fonts.GetData(menuPart.Font);

            if (font != null)
            {
                int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
                if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
                {
                    Text = Global.Instance.Party.Heroes[partyIndex].Name;
                    FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                    GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                }
            }
        }

        private void DrawTextPartNamePartyFromList(Vector2 offset)
        {
            TextPartNamePartyFromList menuPart = (TextPartNamePartyFromList)data;
            FontData font = GameData.Fonts.GetData(menuPart.Font);

            if (font != null)
            {
                ListData list = GameData.Lists.GetData(menuPart.List);
                if (list != null)
                {
                    int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
                    if (partyIndex > -1 && partyIndex < list.Values.Count)
                    {
                        HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                        if (hero != null)
                        {
                            Text = Global.Instance.Party.Heroes[partyIndex].Name;
                            FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                            GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                        }
                    }
                }
            }
        }

        private void DrawTextSaveLoad(Vector2 offset)
        {
            TextPartSaveLoad menuPart = (TextPartSaveLoad)data;
            FontData font = GameData.Fonts.GetData(menuPart.Font);

            if (font != null)
            {
                int index = (int)Global.Variable(menuPart.Index) + 1;
                if (index > 0 && index < 10)
                {
                    FileInfo file = new FileInfo("saved" + index.ToString() + ".svdat");
                    if (file.Exists)
                    {
                        switch (menuPart.Display)
                        {
                            case FileDisplayType.Name:
                                Text = "Save " + index.ToString();
                                break;
                            case FileDisplayType.Date:
                                Text = file.LastWriteTime.Date.ToShortDateString();
                                break;
                            case FileDisplayType.Time:
                                Text = file.LastWriteTime.Date.ToShortTimeString();
                                break;
                        }
                        FontStyleData style = GameData.Fonts[menuPart.Font].Styles[menuPart.Style];
                        GraphicsHelper.DrawText(GameData.Fonts[menuPart.Font], style, Text, menuPart.RealPosition + offset, menuPart.TextColor);
                    }
                }
            }
        }
        #endregion

        #region Dynamic Bar
        private void DrawDynamicBarVariable(Vector2 offset)
        {
            DynamicBarVariable menuPart = (DynamicBarVariable)data;
            float PropertyMin;
            float PropertyMax;
            float PropertyValue;

            PropertyMax = Global.Variable(menuPart.VariableMax);
            PropertyValue = Global.Variable(menuPart.VariableValue);
            PropertyMin = Global.Variable(menuPart.VariableMin);

            if (menuPart.VariableValue == menuPart.VariableMin)
                PropertyMin = 0;

            if (PropertyMin < PropertyMax)
            {
                PropertyValue = Math.Max(PropertyMin, Math.Min(PropertyMax, PropertyValue));

                DrawBar((int)PropertyMax, (int)PropertyMin, (int)PropertyValue, menuPart);
            }
        }

        private void DrawDynamicBarParty(Vector2 offset)
        {
            DynamicBarParty menuPart = (DynamicBarParty)data;
            int PropertyMin;
            int PropertyMax;
            int PropertyValue;

            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count)
            {
                switch (menuPart.PropertyType)
                {
                    case PartyPropertyType.Modified:
                        PropertyMax = Global.Instance.Party.Heroes[partyIndex].GetModifiedPropertyValue(menuPart.MaxProperty, menuPart.LevelPlus);
                        PropertyValue = Global.Instance.Party.Heroes[partyIndex].GetModifiedPropertyValue(menuPart.Value, menuPart.LevelPlus);
                        PropertyMin = Global.Instance.Party.Heroes[partyIndex].GetModifiedPropertyValue(menuPart.MinProperty, menuPart.LevelPlus);
                        break;
                    case PartyPropertyType.Unmodified:
                        PropertyMax = Global.Instance.Party.Heroes[partyIndex].GetPropertyValue(menuPart.MaxProperty, menuPart.LevelPlus);
                        PropertyValue = Global.Instance.Party.Heroes[partyIndex].GetPropertyValue(menuPart.Value, menuPart.LevelPlus);
                        PropertyMin = Global.Instance.Party.Heroes[partyIndex].GetPropertyValue(menuPart.MinProperty, menuPart.LevelPlus);
                        break;
                    default:
                        PropertyMax = Global.Instance.Party.Heroes[partyIndex].GetModifiedPropertyValue(menuPart.MaxProperty, menuPart.LevelPlus) - Global.Instance.Party.Heroes[partyIndex].GetPropertyValue(menuPart.MaxProperty, menuPart.LevelPlus);
                        PropertyValue = Global.Instance.Party.Heroes[partyIndex].GetModifiedPropertyValue(menuPart.Value, menuPart.LevelPlus) - Global.Instance.Party.Heroes[partyIndex].GetPropertyValue(menuPart.Value, menuPart.LevelPlus);
                        PropertyMin = Global.Instance.Party.Heroes[partyIndex].GetModifiedPropertyValue(menuPart.MinProperty, menuPart.LevelPlus) - Global.Instance.Party.Heroes[partyIndex].GetPropertyValue(menuPart.MinProperty, menuPart.LevelPlus);
                        break;
                }
                if (PropertyValue == PropertyMin)
                    PropertyMin = 0;

                if (PropertyMin < PropertyMax)
                {
                    PropertyValue = Math.Max(PropertyMin, Math.Min(PropertyMax, PropertyValue));

                    DrawBar(PropertyMax, PropertyMin, PropertyValue, menuPart);
                }
            }
        }

        private void DrawDynamicBarPartyFromList(Vector2 offset)
        {
            DynamicBarPartyFromList menuPart = (DynamicBarPartyFromList)data;
            int PropertyMin;
            int PropertyMax;
            int PropertyValue;

            ListData list = GameData.Lists.GetData(menuPart.List);

            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < list.Values.Count)
            {
                HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                if (hero != null)
                {
                    switch (menuPart.PropertyType)
                    {
                        case PartyPropertyType.Modified:
                            PropertyMax = hero.GetModifiedPropertyValue(menuPart.MaxProperty, menuPart.LevelPlus);
                            PropertyValue = hero.GetModifiedPropertyValue(menuPart.Value, menuPart.LevelPlus);
                            PropertyMin = hero.GetModifiedPropertyValue(menuPart.MinProperty, menuPart.LevelPlus);
                            break;
                        case PartyPropertyType.Unmodified:
                            PropertyMax = hero.GetPropertyValue(menuPart.MaxProperty, menuPart.LevelPlus);
                            PropertyValue = hero.GetPropertyValue(menuPart.Value, menuPart.LevelPlus);
                            PropertyMin = hero.GetPropertyValue(menuPart.MinProperty, menuPart.LevelPlus);
                            break;
                        default:
                            PropertyMax = hero.GetModifiedPropertyValue(menuPart.MaxProperty, menuPart.LevelPlus) - hero.GetPropertyValue(menuPart.MaxProperty, menuPart.LevelPlus);
                            PropertyValue = hero.GetModifiedPropertyValue(menuPart.Value, menuPart.LevelPlus) - hero.GetPropertyValue(menuPart.Value, menuPart.LevelPlus);
                            PropertyMin = hero.GetModifiedPropertyValue(menuPart.MinProperty, menuPart.LevelPlus) - hero.GetPropertyValue(menuPart.MinProperty, menuPart.LevelPlus);
                            break;
                    }
                    if (PropertyValue == PropertyMin)
                        PropertyMin = 0;

                    if (PropertyMin < PropertyMax)
                    {
                        PropertyValue = Math.Max(PropertyMin, Math.Min(PropertyMax, PropertyValue));
                        DrawBar(PropertyMax, PropertyMin, PropertyValue, menuPart);
                    }
                }
            }
        }

        private void DrawBar(int PropertyMax, int PropertyMin, int PropertyValue, IMenuParts menuPart)
        {
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                if (skin != null)
                {
                    if (skin.DynamicBar.Rounded)
                    {
                        // Load Textures
                        Texture2D left = GetTexture(skin.DynamicBar.LeftID);
                        Texture2D center = GetTexture(skin.DynamicBar.BackgroundID);
                        Texture2D right = GetTexture(skin.DynamicBar.RightID);

                        // Load bar Textures
                        Texture2D barleft = GetTexture(skin.DynamicBar.BarLeftID);
                        Texture2D barcenter = GetTexture(skin.DynamicBar.BarBackgroundID);
                        Texture2D barright = GetTexture(skin.DynamicBar.BarRightID);

                        // Calculate areas
                        int centerStart = left.Width;
                        int rightStart = (int)menuPart.Width - right.Width;

                        int centerWidth = (int)menuPart.Width - right.Width - left.Width;
                        int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / center.Width));
                        int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);


                        // Draw Left
                        Global.SpriteBatch.Draw(left, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, left.Width, (int)menuPart.Height), Color.White);

                        // Draw Repeated Center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            Global.SpriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                        }
                        // Draw Leftover Center
                        if (finalCenterTexels > 0)
                        {
                            Global.SpriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + centerStart + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height),
                                new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                        }

                        // Draw Right
                        Global.SpriteBatch.Draw(right, new Rectangle((int)(menuPart.RealPosition.X + rightStart), (int)menuPart.RealPosition.Y, (int)right.Width, (int)menuPart.Height), Color.White);

                        ///// BAR
                        // calculate areas
                        int barcenterStart = barleft.Width;
                        int barrightStart = (int)menuPart.Width - barright.Width;

                        // calucate bar width based on the current value and its min and max
                        int min = PropertyMin;
                        int max = PropertyMax;
                        int val = PropertyValue;
                        int maxval = max - min;
                        int valinmax = val - min;
                        double percentofvalinmax = (double)valinmax / (double)maxval;

                        int barWidth = (int)((double)menuPart.Width * percentofvalinmax);

                        if (barWidth < barleft.Width)
                        {
                            // Draw Left
                            Global.SpriteBatch.Draw(barleft, new Rectangle((int)(menuPart.RealPosition.X), (int)menuPart.RealPosition.Y, (int)barWidth, (int)menuPart.Height), new Rectangle(0, 0, barWidth, (int)barleft.Height), Color.White);
                        }
                        else
                        {
                            int barcenterWidth = (int)barWidth - barleft.Width; //- barright.Width;
                            if (barcenterWidth > 0)
                            {
                                if (barcenterWidth > (menuPart.Width - barleft.Width - barright.Width))
                                    barcenterWidth = (int)(menuPart.Width - barleft.Width - barright.Width);

                                int barfullCenterRepeats = (int)Math.Floor((double)(barcenterWidth / barcenter.Width));
                                int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                                // Draw Left
                                Global.SpriteBatch.Draw(barleft, new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, barleft.Width, (int)menuPart.Height), Color.White);

                                // Draw Repeated Center
                                for (int i = 0; i < barfullCenterRepeats; i++)
                                {
                                    Global.SpriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                                }
                                // Draw Leftover Center
                                if (barfinalCenterTexels > 0)
                                {
                                    Global.SpriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + barcenterStart + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                        new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                                }
                                if (barWidth >= barrightStart)
                                {
                                    // Draw Right
                                    Global.SpriteBatch.Draw(barright, new Rectangle((int)(menuPart.RealPosition.X + barrightStart), (int)menuPart.RealPosition.Y, (int)(barWidth - barrightStart), (int)menuPart.Height), new Rectangle(0, 0, barWidth - barrightStart, (int)barright.Height), Color.White);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Load Textures
                        Texture2D center = GetTexture(skin.DynamicBar.BackgroundID);
                        Texture2D barcenter = GetTexture(skin.DynamicBar.BarBackgroundID);

                        if (center.Name != "BLANK")
                        {
                            // Calculate areas
                            int centerWidth = (int)menuPart.Width;
                            int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (i * center.Width)), (int)menuPart.RealPosition.Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(menuPart.RealPosition.X + (fullCenterRepeats * center.Width)), (int)menuPart.RealPosition.Y, (int)finalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else if (skin.DynamicBar.BackgroundID > -1)
                        {
                            GraphicsHelper.FillGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                        }

                        if (barcenter.Name != "BLANK")
                        {
                            // calucate bar width based on the current value and its min and max
                            int min = PropertyMin;
                            int max = PropertyMax;
                            int val = PropertyValue;
                            int maxval = max - min;
                            int valinmax = val - min;
                            double percentofvalinmax = (double)valinmax / (double)maxval;
                            int barWidth = (int)((double)menuPart.Width * percentofvalinmax);

                            int barcenterWidth = (int)barWidth;
                            int barfullCenterRepeats = (int)Math.Floor((double)(barcenterWidth / barcenter.Width));
                            int barfinalCenterTexels = barcenterWidth - (barcenter.Width * barfullCenterRepeats);

                            // Draw Repeated Center
                            for (int i = 0; i < barfullCenterRepeats; i++)
                            {
                                Global.SpriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (i * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barcenter.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (barfinalCenterTexels > 0)
                            {
                                Global.SpriteBatch.Draw(barcenter, new Rectangle((int)(menuPart.RealPosition.X + (barfullCenterRepeats * barcenter.Width)), (int)menuPart.RealPosition.Y, (int)barfinalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, barfinalCenterTexels, barcenter.Height), Color.White);
                            }
                        }
                        else
                        {
                            GraphicsHelper.FillGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.EndGradient, menuPart.StartGradient);
                        }
                    }
                }
                else
                {
                    GraphicsHelper.FillGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                GraphicsHelper.FillGradient(new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
        }


        #endregion

        #region Animation
        private void DrawAnimationPartStatic(Vector2 offset, GameTime gameTime)
        {
            Animation.Offset = offset;
            Animation.Draw(gameTime);
        }

        private void DrawAnimationPartParty(Vector2 offset, GameTime gameTime)
        {
            Animation.Offset = offset;
            Animation.Draw(gameTime);
        }

        private void DrawAnimationPartPartyFromList(Vector2 offset, GameTime gameTime)
        {
            Animation.Offset = offset;
            Animation.Draw(gameTime);
        }

        #endregion

        #region List
        private void DrawMenuOptions(Vector2 offset)
        {
            MenuOptions menuPart = (MenuOptions)data;
            DrawListBackground(menuPart, offset);
            // Draw each list menuPart.part.Options[i]
            // Calculate positions etc.            
            int currentColumn = 1;
            int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10;
            int currenty = 10;
            Vector2 index = new Vector2();
            int maxNumberOfRows = (int)((menuPart.Height - (Padding * menuPart.Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
            int startIndex = 0;
            if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
            for (int i = startIndex; (i < menuPart.Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
            {
                menuPart.Options[i].Parent = menuPart;
                menuPart.Options[i].Height = menuPart.ItemHeight;
                menuPart.Options[i].Width = width;
                menuPart.Options[i].Position = new Vector2(currentx, currenty);
                DrawListItem(menuPart.Options[i], 2, offset);

                if (i == SelectedIndex)
                {
                    index.X = currentx;
                    index.Y = currenty;
                }
                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + Padding;
                    currentx = 10;
                }
                else
                {
                    currentx += width + Padding;
                }
            }

            if (menuPart.Options.Count > 0)
            {
                index.X += (menuPart.RealPosition.X);
                index.Y += (menuPart.RealPosition.Y) + 4;
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                        DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawStaticList(Vector2 offset)
        {
            ListStatic menuPart = (ListStatic)data;
            DrawListBackground(menuPart, offset);
            // Draw each list menuPart.Options[i]
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10;
            int currenty = 10;
            Vector2 index = new Vector2();
            int maxNumberOfRows = (int)((menuPart.Height - (Padding * menuPart.Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (menuPart.Options.Count % (menuPart.Columns + 1));
            int startIndex = 0;
            if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
            for (int i = startIndex; (i < menuPart.Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
            {
                menuPart.Options[i].Parent = menuPart;
                menuPart.Options[i].Height = menuPart.ItemHeight;
                menuPart.Options[i].Width = width;
                menuPart.Options[i].Position = new Vector2(currentx, currenty);
                DrawListItem(menuPart.Options[i], 2, offset + menuPart.TextOffset);

                if (i == SelectedIndex)
                {
                    index.X = currentx;
                    index.Y = currenty;
                }
                currentColumn++;

                if (currentColumn > menuPart.Columns)
                {
                    currentColumn = 1;
                    currenty += menuPart.ItemHeight + Padding;
                    currentx = 10;
                }
                else
                {
                    currentx += width + Padding;
                }
            }

            if (menuPart.Options.Count > 0)
            {
                index.X += (menuPart.RealPosition.X);
                index.Y += (menuPart.RealPosition.Y) + 4;
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                        DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawListItem(ListItem item, int Padding, Vector2 offset)
        {
            int icontextPadding = 5;
            int height = (int)item.Height - (Padding * 2);
            int width = (int)item.Width - (Padding * 2);

            if (item.Height + item.Position.Y <= item.Parent.Height && item.Width + item.Position.X - 10 <= item.Parent.Width)
            {
                Texture2D icon = GetTexture(item.Icon);
                int iconPadding = 0;
                if (icon != null)
                {
                    iconPadding = icon.Width;
                    Global.SpriteBatch.Draw(icon, new Vector2(item.RealPosition.X + Padding, item.RealPosition.Y + Padding + (height - icon.Height) / 2) + offset, Color.White);
                }
                FontData font = GameData.Fonts.GetData(item.Font);
                if (font != null)
                {
                    FontStyleData style = font.Styles[item.Style];
                    GraphicsHelper.DrawText(GameData.Fonts[item.Font], style, item.Text, new Vector2(item.RealPosition.X + Padding + icontextPadding, item.RealPosition.Y + Padding + height / 4) + offset, item.TextColor);
                }
            }
        }
        /// <summary>
        /// Draw Pointer
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="pointer"></param>
        private void DrawPointer(Vector2 pos, SkinObjectPointer pointer)
        {
            if (PointerFrames == null)
            {
                AnimationData Animation = GameData.Animations.GetData(pointer.AnimationID);

                if (Animation != null)
                {
                    AnimationAction Action = Animation.Actions.GetData(pointer.ActionID);
                    if (Action != null)
                    {
                        PointerFrames = Action.Directions[pointer.Direction];
                        PointerLoopMax = Action.LoopCount;
                        PointerLoop = Action.InfiniteLoop;
                    }
                }
            }

            if (PointerFrames != null)
            {
                animationCounter++;
                // Get Frame
                if (PointerFrameIndex < PointerFrames.Count)
                {
                    int maxCount;
                    if (PointerFrameIndex > -1)
                        maxCount = PointerFrames[PointerFrameIndex].TimeElapse;
                    else
                        maxCount = 0;
                    if (animationCounter >= maxCount)
                    {
                        animationCounter = 0;

                        // Check if there enough frames for another increase
                        if (PointerFrameIndex + 1 < PointerFrames.Count)
                        {
                            PointerFrameIndex++;
                        }
                        else // The previous frame was the last frame
                        {
                            // Check if we loop
                            if (PointerLoop)
                            {
                                PointerFrameIndex = 0;
                                animationCounter = 0;
                            }
                            else if (PointerLoopCount < PointerLoopMax)
                            {
                                PointerFrameIndex = 0;
                                animationCounter = 0;
                                PointerLoopCount++;
                            }
                        }
                    }
                }
                // Loop all the frames in the direction.
                if (PointerFrameIndex < PointerFrames.Count)
                {
                    AnimationFrame frame = null;
                    Texture2D tex;
                    if (PointerFrameIndex == -1 && 0 < PointerFrames.Count)
                        frame = PointerFrames[0];
                    else if (PointerFrameIndex > -1)
                        frame = PointerFrames[PointerFrameIndex];
                    if (frame != null)
                    {
                        Color color = new Color();
                        // Loop and draw sprites
                        for (int spriteIndex = 0; spriteIndex < frame.Sprites.Count; spriteIndex++)
                        {
                            tex = Content.Texture2D(frame.Sprites[spriteIndex].MaterialId);
                            if (tex != null)
                            {
                                color = frame.Sprites[spriteIndex].Tint;

                                pos.X = (float)Math.Round(pos.X + (frame.Sprites[spriteIndex].Position.X));
                                pos.Y = (float)Math.Round(pos.Y + (frame.Sprites[spriteIndex].Position.Y));

                                Global.SpriteBatch.Draw(
                                    tex,
                                    pos,
                                    frame.Sprites[spriteIndex].DisplayRect,
                                    color,
                                    MathHelper.ToRadians(frame.Sprites[spriteIndex].Rotation),
                                    new Vector2(frame.Sprites[spriteIndex].DisplayRect.Width / 2, frame.Sprites[spriteIndex].DisplayRect.Height / 2) + frame.Sprites[spriteIndex].OriginOffset,
                                    frame.Sprites[spriteIndex].Scale,
                                    (frame.Sprites[spriteIndex].HorizontalFlip ? SpriteEffects.FlipHorizontally : frame.Sprites[spriteIndex].VerticalFlip ? SpriteEffects.FlipVertically : SpriteEffects.None),
                                    0
                                    );
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Draw List Item Party
        /// </summary>
        /// <param name="offset"></param>
        private void DrawListItemParty(Vector2 offset)
        {
            ListItemParty menuPart = (ListItemParty)Data;
            DrawListBackground(menuPart, offset);
            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count && Options != null)
            {
                ItemData item;
                // Calculate positions etc.

                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = 10;
                int currenty = 10;
                Vector2 index = new Vector2();
                Vector2 pos;
                int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
                int startIndex = 0;
                if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                {
                    item = GameData.Items.GetData(Options[i]);

                    if (item != null)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        if (menuPart.ShowIcon)
                        {
                            Texture2D icon = GetTexture(item.Icon);
                            int iconPadding = 0;
                            if (icon != null && icon.Name != "BLANK")
                            {
                                pos.X += 2;
                                pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                iconPadding = icon.Width;
                                Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                pos.X += 48;
                            }
                        }

                        if (menuPart.ShowName)
                        {
                            DrawItemText(item.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (menuPart.ShowCount)
                        {
                            pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                            DrawItemText("x" + Global.Instance.Party.Heroes[partyIndex].GetItems().Values.Count(Options[i]), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (menuPart.ShowPrice)
                        {
                            pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                            DrawItemText(item.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }

                if (Options.Count > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        private void DrawListItemPartyFromList(Vector2 offset)
        {
            ListItemPartyFromList menuPart = (ListItemPartyFromList)Data;
            DrawListBackground(menuPart, offset);

            ListData list = GameData.Lists.GetData(menuPart.List);
            if (list != null)
            {
                int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
                if (partyIndex > -1 && partyIndex < list.Values.Count && Options != null)
                {
                    HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                    if (hero != null)
                    {
                        ItemData item;
                        // Calculate positions etc.

                        int currentColumn = 1;
                        int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                        int currentx = 10;
                        int currenty = 10;
                        Vector2 index = new Vector2();
                        Vector2 pos;
                        int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
                        int startIndex = 0;
                        if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                        for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                        {
                            item = GameData.Items.GetData(Options[i]);

                            if (item != null)
                            {
                                pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                                if (menuPart.ShowIcon)
                                {
                                    Texture2D icon = GetTexture(item.Icon);
                                    int iconPadding = 0;
                                    if (icon != null && icon.Name != "BLANK")
                                    {
                                        pos.X += 2;
                                        pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                        iconPadding = icon.Width;
                                        Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                        pos.X += 48;
                                    }
                                }

                                if (menuPart.ShowName)
                                {
                                    DrawItemText(item.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                }

                                if (menuPart.ShowCount)
                                {
                                    pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                    DrawItemText("x" + hero.GetItems().Values.Count(Options[i]), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                }

                                if (menuPart.ShowPrice)
                                {
                                    pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                    DrawItemText(item.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                }

                                if (i == SelectedIndex)
                                {
                                    index.X = currentx;
                                    index.Y = currenty;
                                }
                                currentColumn++;

                                if (currentColumn > menuPart.Columns)
                                {
                                    currentColumn = 1;
                                    currenty += menuPart.ItemHeight + Padding;
                                    currentx = 10;
                                }
                                else
                                {
                                    currentx += width + Padding;
                                }
                            }
                        }

                        if (Options.Count > 0)
                        {
                            index.X += (menuPart.RealPosition.X);
                            index.Y += (menuPart.RealPosition.Y) + 4;
                            switch (menuPart.SelectionType)
                            {
                                case ListSelectionType.Rectangle:
                                    Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                                    DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                                    break;
                                case ListSelectionType.Cursor:
                                    if (menuPart.SkinID > -1)
                                    {
                                        SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                        if (skin != null)
                                            DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                                    }
                                    break;
                                case ListSelectionType.None:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void DrawListSkillParty(Vector2 offset)
        {
            ListSkillParty menuPart = (ListSkillParty)Data;
            DrawListBackground(menuPart, offset);
            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count && Options != null)
            {
                SkillData skill;
                // Calculate positions etc.
                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = Padding; int currenty = Padding;
                Vector2 index = new Vector2(), pos;
                int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
                int startIndex = 0;
                if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                {
                    skill = GameData.Skills.GetData(Options[i]);

                    if (skill != null)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        if (menuPart.ShowIcon)
                        {
                            Texture2D icon = GetTexture(skill.Icon);
                            int iconPadding = 0;
                            if (icon != null && icon.Name != "BLANK")
                            {
                                pos.X += 2;
                                pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                iconPadding = icon.Width;
                                Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                pos.X += 48;
                            }
                        }

                        if (menuPart.ShowName)
                        {
                            DrawItemText(skill.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (menuPart.ShowCost)
                        {
                            pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                            DrawItemText("x" + skill.Cost, pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }


                if (Options.Count > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        private void DrawListSkillPartyFromList(Vector2 offset)
        {
            ListSkillPartyFromList menuPart = (ListSkillPartyFromList)Data;
            DrawListBackground(menuPart, offset);
            ListData list = GameData.Lists.GetData(menuPart.List);
            if (list != null)
            {
                int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
                if (partyIndex > -1 && partyIndex < list.Values.Count && Options != null)
                {
                    HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                    if (hero != null)
                    {
                        SkillData skill;
                        // Calculate positions etc.
                        int currentColumn = 1;
                        int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                        int currentx = Padding; int currenty = Padding;
                        Vector2 index = new Vector2(), pos;
                        int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight) + (Options.Count % (menuPart.Columns + 1));
                        int startIndex = 0;
                        if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                        for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                        {
                            skill = GameData.Skills.GetData(Options[i]);

                            if (skill != null)
                            {
                                pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                                if (menuPart.ShowIcon)
                                {
                                    Texture2D icon = GetTexture(skill.Icon);
                                    int iconPadding = 0;
                                    if (icon != null && icon.Name != "BLANK")
                                    {
                                        pos.X += 2;
                                        pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                        iconPadding = icon.Width;
                                        Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                        pos.X += 48;
                                    }
                                }

                                if (menuPart.ShowName)
                                {
                                    DrawItemText(skill.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                }

                                if (menuPart.ShowCost)
                                {
                                    pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                    DrawItemText("x" + skill.Cost, pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                }

                                if (i == SelectedIndex)
                                {
                                    index.X = currentx;
                                    index.Y = currenty;
                                }
                                currentColumn++;

                                if (currentColumn > menuPart.Columns)
                                {
                                    currentColumn = 1;
                                    currenty += menuPart.ItemHeight + Padding;
                                    currentx = 10;
                                }
                                else
                                {
                                    currentx += width + Padding;
                                }
                            }
                        }


                        if (Options.Count > 0)
                        {
                            index.X += (menuPart.RealPosition.X);
                            index.Y += (menuPart.RealPosition.Y) + 4;
                            switch (menuPart.SelectionType)
                            {
                                case ListSelectionType.Rectangle:
                                    Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                                    DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                                    break;
                                case ListSelectionType.Cursor:
                                    if (menuPart.SkinID > -1)
                                    {
                                        SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                        if (skin != null)
                                            DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                                    }
                                    break;
                                case ListSelectionType.None:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void DrawListEquipmentParty(Vector2 offset)
        {
            ListEquipmentParty menuPart = (ListEquipmentParty)Data;
            DrawListBackground(menuPart, offset);
            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count && Options != null)
            {
                EquipmentData equipment;
                // Calculate positions etc.

                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = 10;
                int currenty = 10;
                Vector2 index = new Vector2();
                Vector2 pos;
                int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
                int startIndex = 0;
                if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                {
                    equipment = GameData.Equipments.GetData(Options[i]);

                    if (equipment != null || Options[i] == -1)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        if (equipment != null)
                        {
                            if (menuPart.ShowIcon)
                            {
                                Texture2D icon = GetTexture(equipment.Icon);
                                int iconPadding = 0;
                                if (icon != null && icon.Name != "BLANK")
                                {
                                    pos.X += 2;
                                    pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                    iconPadding = icon.Width;
                                    Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                    pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                    pos.X += 48;
                                }
                            }

                            if (menuPart.ShowName)
                            {
                                DrawItemText(equipment.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }


                            if (menuPart.ShowCount)
                            {
                                pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                DrawItemText("x" + Global.Instance.Party.Heroes[partyIndex].GetEquipments().Values.Count(Options[i]), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }

                            if (menuPart.ShowPrice)
                            {
                                pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                DrawItemText(equipment.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }

                if (Options.Count > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        private void DrawListEquipmentPartyFromList(Vector2 offset)
        {
            ListEquipmentPartyFromList menuPart = (ListEquipmentPartyFromList)Data;
            DrawListBackground(menuPart, offset);
            ListData list = GameData.Lists.GetData(menuPart.List);
            if (list != null)
            {
                int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
                if (partyIndex > -1 && partyIndex < list.Values.Count && Options != null)
                {
                    HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                    if (hero != null)
                    {
                        EquipmentData equipment;
                        // Calculate positions etc.

                        int currentColumn = 1;
                        int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                        int currentx = 10;
                        int currenty = 10;
                        Vector2 index = new Vector2();
                        Vector2 pos;
                        int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
                        int startIndex = 0;
                        if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                        for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                        {
                            equipment = GameData.Equipments.GetData(Options[i]);

                            if (equipment != null || Options[i] == -1)
                            {
                                pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                                if (equipment != null)
                                {
                                    if (menuPart.ShowIcon)
                                    {
                                        Texture2D icon = GetTexture(equipment.Icon);
                                        int iconPadding = 0;
                                        if (icon != null && icon.Name != "BLANK")
                                        {
                                            pos.X += 2;
                                            pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                            iconPadding = icon.Width;
                                            Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                            pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                            pos.X += 48;
                                        }
                                    }

                                    if (menuPart.ShowName)
                                    {
                                        DrawItemText(equipment.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                    }


                                    if (menuPart.ShowCount)
                                    {
                                        pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                        DrawItemText("x" + hero.GetEquipments().Values.Count(Options[i]), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                    }

                                    if (menuPart.ShowPrice)
                                    {
                                        pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                        DrawItemText(equipment.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                    }
                                }

                                if (i == SelectedIndex)
                                {
                                    index.X = currentx;
                                    index.Y = currenty;
                                }
                                currentColumn++;

                                if (currentColumn > menuPart.Columns)
                                {
                                    currentColumn = 1;
                                    currenty += menuPart.ItemHeight + Padding;
                                    currentx = 10;
                                }
                                else
                                {
                                    currentx += width + Padding;
                                }
                            }
                        }

                        if (Options.Count > 0)
                        {
                            index.X += (menuPart.RealPosition.X);
                            index.Y += (menuPart.RealPosition.Y) + 4;
                            switch (menuPart.SelectionType)
                            {
                                case ListSelectionType.Rectangle:
                                    Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                                    DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                                    break;
                                case ListSelectionType.Cursor:
                                    if (menuPart.SkinID > -1)
                                    {
                                        SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                        if (skin != null)
                                            DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                                    }
                                    break;
                                case ListSelectionType.None:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void DrawListEquippedParty(Vector2 offset)
        {
            ListEquippedParty menuPart = (ListEquippedParty)Data;
            DrawListBackground(menuPart, offset);
            int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
            if (partyIndex > -1 && partyIndex < Global.Instance.Party.Heroes.Count && Options != null)
            {
                EquipmentData equipped;
                // Calculate positions etc.

                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = 10;
                int currenty = 10;
                Vector2 index = new Vector2();
                Vector2 pos;
                int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
                int startIndex = 0;
                if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                {
                    equipped = GameData.Equipments.GetData(Global.Instance.Party.Heroes[partyIndex].GetEquipment(Options[i]));

                    if (equipped != null || Global.Instance.Party.Heroes[partyIndex].GetEquipment(Options[i]) == -1)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        if (equipped != null)
                        {
                            if (menuPart.ShowIcon)
                            {
                                Texture2D icon = GetTexture(equipped.Icon);
                                int iconPadding = 0;
                                if (icon != null && icon.Name != "BLANK")
                                {
                                    pos.X += 2;
                                    pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                    iconPadding = icon.Width;
                                    Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                    pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                    pos.X += 48;
                                }
                            }

                            if (menuPart.ShowName)
                            {
                                DrawItemText(equipped.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }

                            if (menuPart.ShowCount)
                            {
                                pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                DrawItemText("x" + Global.Instance.Party.Heroes[partyIndex].GetEquipments().Values.Count(Options[i]), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }

                            if (menuPart.ShowPrice)
                            {
                                pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                DrawItemText(equipped.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }

                if (Options.Count > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        private void DrawListEquippedPartyFromList(Vector2 offset)
        {
            ListEquippedPartyFromList menuPart = (ListEquippedPartyFromList)Data;
            DrawListBackground(menuPart, offset); ListData list = GameData.Lists.GetData(menuPart.List);
            if (list != null)
            {
                int partyIndex = (int)Global.Variable(menuPart.PartyIndex);
                if (partyIndex > -1 && partyIndex < list.Values.Count && Options != null)
                {
                    HeroProcessor hero = Global.Instance.Party.GetHero(list.Values[partyIndex]);
                    if (hero != null)
                    {
                        EquipmentData equipped;
                        // Calculate positions etc.

                        int currentColumn = 1;
                        int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                        int currentx = 10;
                        int currenty = 10;
                        Vector2 index = new Vector2();
                        Vector2 pos;
                        int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
                        int startIndex = 0;
                        if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                        for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                        {
                            equipped = GameData.Equipments.GetData(hero.GetEquipment(Options[i]));

                            if (equipped != null || hero.GetEquipment(Options[i]) == -1)
                            {
                                pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                                if (equipped != null)
                                {
                                    if (menuPart.ShowIcon)
                                    {
                                        Texture2D icon = GetTexture(equipped.Icon);
                                        int iconPadding = 0;
                                        if (icon != null && icon.Name != "BLANK")
                                        {
                                            pos.X += 2;
                                            pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                            iconPadding = icon.Width;
                                            Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                            pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                            pos.X += 48;
                                        }
                                    }

                                    if (menuPart.ShowName)
                                    {
                                        DrawItemText(equipped.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                    }

                                    if (menuPart.ShowCount)
                                    {
                                        pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                        DrawItemText("x" + hero.GetEquipments().Values.Count(Options[i]), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                    }

                                    if (menuPart.ShowPrice)
                                    {
                                        pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                        DrawItemText(equipped.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                                    }
                                }

                                if (i == SelectedIndex)
                                {
                                    index.X = currentx;
                                    index.Y = currenty;
                                }
                                currentColumn++;

                                if (currentColumn > menuPart.Columns)
                                {
                                    currentColumn = 1;
                                    currenty += menuPart.ItemHeight + Padding;
                                    currentx = 10;
                                }
                                else
                                {
                                    currentx += width + Padding;
                                }
                            }
                        }

                        if (Options.Count > 0)
                        {
                            index.X += (menuPart.RealPosition.X);
                            index.Y += (menuPart.RealPosition.Y) + 4;
                            switch (menuPart.SelectionType)
                            {
                                case ListSelectionType.Rectangle:
                                    Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                                    DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                                    break;
                                case ListSelectionType.Cursor:
                                    if (menuPart.SkinID > -1)
                                    {
                                        SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                        if (skin != null)
                                            DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                                    }
                                    break;
                                case ListSelectionType.None:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void DrawItemText(string txt, Vector2 position, Vector2 size, int Padding, int font, int style, Color textColor, Vector2 offset)
        {
            int height = (int)size.Y - (Padding * 2);
            int width = (int)size.X - (Padding * 2);

            FontData _font = GameData.Fonts.GetData(font);
            if (_font != null)
            {
                FontStyleData _style = _font.Styles[style];
                GraphicsHelper.DrawText(_font, _style, txt, new Vector2(position.X + Padding, position.Y + Padding + height / 4) + offset, textColor);
            }
        }

        private void DrawPartyList(Vector2 offset)
        {
            ListParty menuPart = (ListParty)data;
            DrawListBackground(menuPart, offset);
            // Draw each list menuPart.Options[i]
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10;
            int currenty = 10;
            Vector2 index = new Vector2();
            HeroProcessor hero;
            int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
            int startIndex = 0;
            if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
            for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
            {
                hero = Global.Instance.Party.GetHero(Options[i]);
                if (hero != null)
                {
                    DrawItemText(hero.Name, new Vector2(currentx, currenty) + menuPart.RealPosition + offset, new Vector2(width, menuPart.ItemHeight), 5, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);

                    if (i == SelectedIndex)
                    {
                        index.X = currentx;
                        index.Y = currenty;
                    }
                    currentColumn++;

                    if (currentColumn > menuPart.Columns)
                    {
                        currentColumn = 1;
                        currenty += menuPart.ItemHeight + Padding;
                        currentx = 10;
                    }
                    else
                    {
                        currentx += width + Padding;
                    }
                }
            }

            if (Options.Count > 0)
            {
                index.X += (menuPart.RealPosition.X);
                index.Y += (menuPart.RealPosition.Y) + 4;
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                        DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawPartyListFromList(Vector2 offset)
        {
            ListPartyFromList menuPart = (ListPartyFromList)data;
            DrawListBackground(menuPart, offset);
            // Draw each list menuPart.Options[i]
            // Calculate positions etc.

            int currentColumn = 1;
            int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
            int currentx = 10;
            int currenty = 10;
            Vector2 index = new Vector2();
            HeroProcessor hero;
            int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
            int startIndex = 0;
            if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
            for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
            {
                hero = Global.Instance.Party.GetHero(Options[i]);
                if (hero != null)
                {
                    DrawItemText(hero.Name, new Vector2(currentx, currenty) + menuPart.RealPosition + offset, new Vector2(width, menuPart.ItemHeight), 5, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);

                    if (i == SelectedIndex)
                    {
                        index.X = currentx;
                        index.Y = currenty;
                    }
                    currentColumn++;

                    if (currentColumn > menuPart.Columns)
                    {
                        currentColumn = 1;
                        currenty += menuPart.ItemHeight + Padding;
                        currentx = 10;
                    }
                    else
                    {
                        currentx += width + Padding;
                    }
                }
            }

            if (Options.Count > 0)
            {
                index.X += (menuPart.RealPosition.X);
                index.Y += (menuPart.RealPosition.Y) + 4;
                switch (menuPart.SelectionType)
                {
                    case ListSelectionType.Rectangle:
                        Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                        DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                        break;
                    case ListSelectionType.Cursor:
                        if (menuPart.SkinID > -1)
                        {
                            SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                            if (skin != null)
                                DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                        }
                        break;
                    case ListSelectionType.None:
                        break;
                }
            }
        }

        private void DrawListItemSource(Vector2 offset)
        {
            ListItemSource menuPart = (ListItemSource)data;
            ListData list = Global.Instance.Lists.GetData(menuPart.List);
            DrawListBackground(menuPart, offset);
            if (list != null && Options != null)
            {
                ItemData item;
                // Calculate positions etc.

                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = 10;
                int currenty = 10;
                Vector2 index = new Vector2();
                Vector2 pos;
                int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
                int startIndex = 0;
                if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                {
                    item = GameData.Items.GetData(Options[i]);

                    if (item != null)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        if (menuPart.ShowIcon)
                        {
                            Texture2D icon = GetTexture(item.Icon);
                            int iconPadding = 0;
                            if (icon != null && icon.Name != "BLANK")
                            {
                                pos.X += 2;
                                pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                iconPadding = icon.Width;
                                Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                pos.X += 48;
                            }
                        }

                        if (menuPart.ShowName)
                        {
                            DrawItemText(item.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (menuPart.ShowCount)
                        {
                            pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                            DrawItemText("x" + list.Values.Count(Options[i]), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (menuPart.ShowPrice)
                        {
                            pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                            DrawItemText(item.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }

                if (Options.Count > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        private void DrawListEquipmentSource(Vector2 offset)
        {
            ListEquipmentSource menuPart = (ListEquipmentSource)Data;
            DrawListBackground(menuPart, offset);
            ListData list = Global.Instance.Lists.GetData(menuPart.List);
            if (list != null && Options != null)
            {
                EquipmentData equipment;
                // Calculate positions etc.

                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = 10;
                int currenty = 10;
                Vector2 index = new Vector2();
                Vector2 pos;
                int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
                int startIndex = 0;
                if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                {
                    equipment = GameData.Equipments.GetData(Options[i]);

                    if (equipment != null || Options[i] == -1)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        if (equipment != null)
                        {
                            if (menuPart.ShowIcon)
                            {
                                Texture2D icon = GetTexture(equipment.Icon);
                                int iconPadding = 0;
                                if (icon != null && icon.Name != "BLANK")
                                {
                                    pos.X += 2;
                                    pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                    iconPadding = icon.Width;
                                    Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                    pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                    pos.X += 48;
                                }
                            }

                            if (menuPart.ShowName)
                            {
                                DrawItemText(equipment.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }


                            if (menuPart.ShowCount)
                            {
                                pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                DrawItemText("x" + list.Values.Count(Options[i]), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }

                            if (menuPart.ShowPrice)
                            {
                                pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                DrawItemText(equipment.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }

                if (Options.Count > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        private void DrawListSkillSource(Vector2 offset)
        {
            ListSkillSource menuPart = (ListSkillSource)Data;
            DrawListBackground(menuPart, offset);
            if (Options != null)
            {
                SkillData skill;
                // Calculate positions etc.

                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = 10;
                int currenty = 10;
                Vector2 index = new Vector2();
                Vector2 pos;
                int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
                int startIndex = 0;
                if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                {
                    skill = GameData.Skills.GetData(Options[i]);

                    if (skill != null)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        if (menuPart.ShowIcon)
                        {
                            Texture2D icon = GetTexture(skill.Icon);
                            int iconPadding = 0;
                            if (icon != null && icon.Name != "BLANK")
                            {
                                pos.X += 2;
                                pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                iconPadding = icon.Width;
                                Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                pos.X += 48;
                            }
                        }

                        if (menuPart.ShowName)
                        {
                            DrawItemText(skill.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (menuPart.ShowCost)
                        {
                            pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                            DrawItemText("x" + skill.Cost, pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }

                if (Options.Count > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        private void DrawListItemShop(Vector2 offset)
        {
            ListItemShop menuPart = (ListItemShop)Data;
            DrawListBackground(menuPart, offset);
            if (Options != null)
            {
                ItemData item;
                // Calculate positions etc.

                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = 10;
                int currenty = 10;
                Vector2 index = new Vector2();
                Vector2 pos;
                int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
                int startIndex = 0;
                if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                {
                    item = GameData.Items.GetData(Options[i]);

                    if (item != null)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        if (menuPart.ShowIcon)
                        {
                            Texture2D icon = GetTexture(item.Icon);
                            int iconPadding = 0;
                            if (icon != null && icon.Name != "BLANK")
                            {
                                pos.X += 2;
                                pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                iconPadding = icon.Width;
                                Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                pos.X += 48;
                            }
                        }

                        if (menuPart.ShowName)
                        {
                            DrawItemText(item.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (menuPart.ShowPrice)
                        {
                            pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                            DrawItemText(item.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }


                if (Options.Count > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        private void DrawListEquipmentShop(Vector2 offset)
        {
            ListEquipmentShop menuPart = (ListEquipmentShop)Data;
            DrawListBackground(menuPart, offset);
            if (Options != null)
            {
                EquipmentData equipment;
                // Calculate positions etc.

                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = 10;
                int currenty = 10;
                Vector2 index = new Vector2();
                Vector2 pos;
                int maxNumberOfRows = (int)((menuPart.Height - (Padding * Options.Count / menuPart.Columns)) / menuPart.ItemHeight);
                int startIndex = 0;
                if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                for (int i = startIndex; (i < Options.Count && i <= maxNumberOfRows + startIndex + 1); i++)
                {
                    equipment = GameData.Equipments.GetData(Options[i]);

                    if (equipment != null || Options[i] == -1)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        if (equipment != null)
                        {
                            if (menuPart.ShowIcon)
                            {
                                Texture2D icon = GetTexture(equipment.Icon);
                                int iconPadding = 0;
                                if (icon != null && icon.Name != "BLANK")
                                {
                                    pos.X += 2;
                                    pos.Y += 10 + ((menuPart.ItemHeight - icon.Height) / 2);
                                    iconPadding = icon.Width;
                                    Global.SpriteBatch.Draw(icon, pos + menuPart.TextOffset, Color.White);

                                    pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;
                                    pos.X += 48;
                                }
                            }

                            if (menuPart.ShowName)
                            {
                                DrawItemText(equipment.Name, pos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }

                            if (menuPart.ShowPrice)
                            {
                                pos.X = currentx + width - 60 + menuPart.RealPosition.X;
                                DrawItemText(equipment.Price.ToString(), pos, new Vector2(width, menuPart.ItemHeight), 2, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }

                if (Options.Count > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        private void DrawListSaveLoad(Vector2 offset)
        {
            ListSaveLoad menuPart = (ListSaveLoad)Data;

            DrawListBackground(menuPart, offset);

            if (Options != null)
            {
                int currentColumn = 1;
                int width = ((int)menuPart.Width - (Padding * (menuPart.Columns - 1))) / menuPart.Columns;
                int currentx = 10;
                int currenty = 10;
                Vector2 index = new Vector2();
                Vector2 pos;
                FileInfo file;
                try
                {
                    int maxNumberOfRows = (int)((menuPart.Height - (Padding * menuPart.MaxFiles / menuPart.Columns)) / menuPart.ItemHeight) + (menuPart.MaxFiles % (menuPart.Columns + 1));
                    int startIndex = 0;
                    if (SelectedIndex / menuPart.Columns > maxNumberOfRows / menuPart.Columns) startIndex = SelectedIndex - maxNumberOfRows - (SelectedIndex % menuPart.Columns);
                    for (int i = startIndex; (i < menuPart.MaxFiles && i <= maxNumberOfRows + startIndex + 1); i++)
                    {
                        pos = new Vector2(currentx, currenty) + menuPart.RealPosition + offset;

                        file = new FileInfo("saved" + (i + 1).ToString() + ".svdat");
                        if (file.Exists)
                        {
                            Vector2 sub = new Vector2(0, 0);
                            if (menuPart.ShowName)
                            {
                                DrawItemText("Save " + (i + 1).ToString(), pos + menuPart.NamePos, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }

                            if (menuPart.ShowDate)
                            {
                                DrawItemText("Date: " + file.LastWriteTime.Date.ToShortDateString(), pos + menuPart.DatePos - sub, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }

                            if (menuPart.ShowTime)
                            {
                                DrawItemText("Time: " + file.LastWriteTime.ToLocalTime().ToShortTimeString(), pos + menuPart.TimePos - sub, new Vector2(width, menuPart.ItemHeight), 7, menuPart.Font, menuPart.Style, menuPart.TextColor, offset + menuPart.TextOffset);
                            }
                        }

                        if (i == SelectedIndex)
                        {
                            index.X = currentx;
                            index.Y = currenty;
                        }
                        currentColumn++;

                        if (currentColumn > menuPart.Columns)
                        {
                            currentColumn = 1;
                            currenty += menuPart.ItemHeight + Padding;
                            currentx = 10;
                        }
                        else
                        {
                            currentx += width + Padding;
                        }
                    }
                }
                catch
                { }

                if (menuPart.MaxFiles > 0)
                {
                    index.X += (menuPart.RealPosition.X);
                    index.Y += (menuPart.RealPosition.Y) + 4;
                    switch (menuPart.SelectionType)
                    {
                        case ListSelectionType.Rectangle:
                            Rectangle rect = new Rectangle((int)(index.X + offset.X), (int)(index.Y + offset.Y) - 2, width - 20, menuPart.ItemHeight + 9);
                            DrawSelectionRectangle(rect, menuPart.SelectionType, menuPart.HighlightBorderColor, menuPart.HighlightStartGradient, menuPart.HighlightEndGradient, menuPart.DisabledBorderColor, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
                            break;
                        case ListSelectionType.Cursor:
                            if (menuPart.SkinID > -1)
                            {
                                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                                if (skin != null)
                                    DrawPointer(index + offset + menuPart.CursorOffset, skin.Pointer);
                            }
                            break;
                        case ListSelectionType.None:
                            break;
                    }
                }
            }
        }

        #region List: Helpers
        /// <summary>
        /// Draw List Background
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="menuPart"></param>
        /// <param name="offset"></param>
        private void DrawListBackground(IMenuParts menuPart, Vector2 offset)
        {
            #region Draw Background
            // Calculate Areas
            int X = (int)menuPart.RealPosition.X + (int)offset.X;
            int Y = (int)menuPart.RealPosition.Y + (int)offset.Y;
            // Draw the containing list
            if (menuPart.SkinID > -1)
            {
                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTexture(skin.List.TopLeftID);
                    Texture2D topCenter = GetTexture(skin.List.TopID);
                    Texture2D topRight = GetTexture(skin.List.TopRightID);

                    Texture2D left = GetTexture(skin.List.LeftID);
                    Texture2D right = GetTexture(skin.List.RightID);

                    Texture2D bottomLeft = GetTexture(skin.List.BottomLeftID);
                    Texture2D bottomCenter = GetTexture(skin.List.BottomID);
                    Texture2D bottomRight = GetTexture(skin.List.BottomRightID);

                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((double)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((double)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((double)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((double)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    Global.SpriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        Global.SpriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        Global.SpriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    Global.SpriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    Global.SpriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    Global.SpriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    Global.SpriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        Global.SpriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        Global.SpriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    Global.SpriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTexture(skin.List.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            Global.SpriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            Global.SpriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        GraphicsHelper.FillGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion
        }

        /// <summary>
        /// Draw Selection Rectangle
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="rect"></param>
        /// <param name="SelectionType"></param>
        /// <param name="HighlightBorderColor"></param>
        /// <param name="HighlightStartGradient"></param>
        /// <param name="HighlightEndGradient"></param>
        /// <param name="DisabledBorderColor"></param>
        /// <param name="DisabledStartGradient"></param>
        /// <param name="DisabledEndGradient"></param>
        private void DrawSelectionRectangle(Rectangle rect, ListSelectionType SelectionType, Color HighlightBorderColor, Color HighlightStartGradient, Color HighlightEndGradient, Color DisabledBorderColor, Color DisabledStartGradient, Color DisabledEndGradient)
        {
            switch (SelectionType)
            {
                case ListSelectionType.Rectangle:
                    if (Enabled)
                    {
                        GraphicsHelper.DrawRectangle(GraphicsHelper.Texture, rect, HighlightBorderColor);
                        Color c1, c2;
                        if (HighlighterIndex == 0)
                        {
                            HighlighterCount--;
                            c1 = HighlightStartGradient;
                            c2 = HighlightEndGradient;
                            c1.A -= HighlighterCount;
                            c2.A -= HighlighterCount;

                            if (HighlighterCount <= (HighlightStartGradient.A > HighlightEndGradient.A ? HighlightEndGradient.A : HighlightStartGradient.A) - 50)
                            {
                                HighlighterIndex = 1;
                                HighlighterCount = (byte)((HighlightStartGradient.A > HighlightEndGradient.A ? HighlightEndGradient.A : HighlightStartGradient.A) - 50);
                            }
                        }
                        else
                        {
                            HighlighterCount++;
                            c1 = HighlightStartGradient;
                            c2 = HighlightEndGradient;
                            c1.A -= HighlighterCount;
                            c2.A -= HighlighterCount;
                            if (HighlighterCount >= HighlightStartGradient.A)
                            {
                                HighlighterIndex = 0; HighlighterCount = (HighlightStartGradient.A > HighlightEndGradient.A ? HighlightEndGradient.A : HighlightStartGradient.A);
                            }
                        }
                        GraphicsHelper.FillGradient(rect, c1, c2);
                    }
                    else
                    {
                        GraphicsHelper.FillGradient(rect, DisabledStartGradient, DisabledEndGradient);
                        GraphicsHelper.DrawRectangle(GraphicsHelper.Texture, rect, DisabledBorderColor);
                    }
                    break;
            }
        }
        #endregion

        #endregion

        #region Window
        private void DrawWindow(Vector2 offset)
        {
            MenuWindow menuPart = (MenuWindow)data;
            // Calculate Areas
            int X = (int)(menuPart.RealPosition.X + offset.X);
            int Y = (int)(menuPart.RealPosition.Y + offset.Y);

            if (menuPart.SkinID > -1)
            {
                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                if (skin != null)
                {
                    // ------- Border  ---------
                    // Load Textures
                    Texture2D topLeft = GetTexture(skin.Window.TopLeftID);
                    Texture2D topCenter = GetTexture(skin.Window.TopID);
                    Texture2D topRight = GetTexture(skin.Window.TopRightID);

                    Texture2D left = GetTexture(skin.Window.LeftID);
                    Texture2D right = GetTexture(skin.Window.RightID);

                    Texture2D bottomLeft = GetTexture(skin.Window.BottomLeftID);
                    Texture2D bottomCenter = GetTexture(skin.Window.BottomID);
                    Texture2D bottomRight = GetTexture(skin.Window.BottomRightID);


                    Vector2 Pos = new Vector2(X, Y);

                    int topStart = topLeft.Width;
                    int topRightStart = (int)menuPart.Width - (int)topRight.Width;

                    int leftStart = topLeft.Height;
                    int bottomLeftStart = (int)menuPart.Height - (int)bottomLeft.Height;

                    int rightX = (int)menuPart.Width - right.Width;
                    int rightStart = topRight.Height;

                    int bottomRightX = (int)menuPart.Width - bottomRight.Width;
                    int bottomRightStart = (int)menuPart.Height - bottomRight.Height;

                    int bottomY = (int)menuPart.Height - bottomCenter.Height;
                    int bottomStart = bottomLeft.Width;

                    int topWidth = (int)menuPart.Width - topLeft.Width - topRight.Width;
                    int fullTopRepeats = (int)Math.Floor((double)(topWidth / topCenter.Width));
                    int remainderTopTexels = topWidth - (topCenter.Width * fullTopRepeats);

                    int leftHeight = (int)menuPart.Height - topLeft.Height - bottomLeft.Height;
                    int fullLeftRepeats = (int)Math.Floor((double)(leftHeight / left.Height)); ;
                    int remainderLeftTexels = leftHeight - (left.Height * fullLeftRepeats);

                    int rightHeight = (int)menuPart.Height - topRight.Height - bottomRight.Height;
                    int fullRightRepeats = (int)Math.Floor((double)(rightHeight / right.Height)); ;
                    int remainderRightTexels = rightHeight - (right.Height * fullRightRepeats);

                    int bottomWidth = (int)menuPart.Width - bottomLeft.Width - bottomRight.Width;
                    int fullBottomRepeat = (int)Math.Floor((double)(bottomWidth / bottomCenter.Width));
                    int remainderBottomTexels = bottomWidth - (bottomCenter.Width * fullBottomRepeat);

                    // Draw Top Left at (0,0) relative
                    Global.SpriteBatch.Draw(topLeft, Pos, Color.White);

                    // Draw Top Repeat after topLeft and repeat until topRight
                    for (int i = 0; i < fullTopRepeats; i++)
                    {
                        Global.SpriteBatch.Draw(topCenter, new Vector2(X + topStart + (i * topCenter.Width), Y), Color.White);
                    }
                    if (remainderTopTexels > 0)
                    {
                        Global.SpriteBatch.Draw(topCenter, new Vector2(X + topStart + (fullTopRepeats * topCenter.Width), Y),
                            new Rectangle(0, 0, remainderTopTexels, topCenter.Height), Color.White);
                    }

                    // Drop Top Right
                    Global.SpriteBatch.Draw(topRight, new Vector2(X + topRightStart, Y), Color.White);

                    // Draw Left Repeat
                    Global.SpriteBatch.Draw(left, new Rectangle(X, Y + leftStart, left.Width, (int)leftHeight), Color.White);

                    // Draw Right Repeat
                    Global.SpriteBatch.Draw(right, new Rectangle(X + rightX, Y + rightStart, right.Width, (int)rightHeight), Color.White);


                    // Draw Bottom Left
                    Global.SpriteBatch.Draw(bottomLeft, new Vector2(X, Y + bottomLeftStart), Color.White);

                    // Draw Bottom Repeat
                    for (int i = 0; i < fullBottomRepeat; i++)
                    {
                        Global.SpriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (i * bottomCenter.Width), Y + bottomY), Color.White);
                    }
                    if (remainderBottomTexels > 0)
                    {
                        Global.SpriteBatch.Draw(bottomCenter, new Vector2(X + bottomStart + (fullBottomRepeat * bottomCenter.Width), Y + bottomY),
                            new Rectangle(0, 0, remainderBottomTexels, bottomCenter.Height), Color.White);
                    }

                    // Draw Bottom Right
                    Global.SpriteBatch.Draw(bottomRight, new Vector2(X + bottomRightX, Y + bottomRightStart), Color.White);


                    // ------- Window ---------
                    // Load Textures
                    Texture2D windowBack = GetTexture(skin.Window.BackgroundID);

                    // Calculate areas

                    int centerX = left.Width;
                    int centerY = topCenter.Height;
                    int centerWidth = (int)menuPart.Width - left.Width - right.Width;
                    int centerHeight = (int)menuPart.Height - topCenter.Height - bottomCenter.Height;

                    int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / windowBack.Width));
                    int remainderCenterTexels = centerWidth - (windowBack.Width * fullCenterRepeats);

                    if (windowBack.Name != "BLANK")
                    {
                        // Draw center
                        for (int i = 0; i < fullCenterRepeats; i++)
                        {
                            Global.SpriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (i * windowBack.Width)), (int)Y + centerY, windowBack.Width, (int)centerHeight), Color.White);
                        }
                        if (remainderCenterTexels > 0)
                        {
                            Global.SpriteBatch.Draw(windowBack, new Rectangle((int)(X + centerX + (fullCenterRepeats * windowBack.Width)), (int)(Y + centerY), remainderCenterTexels, (int)centerHeight),
                                new Rectangle(0, 0, remainderCenterTexels, windowBack.Height), Color.White);
                        }
                    }
                    else
                    {
                        // Draw Gradient
                        GraphicsHelper.FillGradient(new Rectangle(X + centerX, Y + centerY, centerWidth, centerHeight), menuPart.StartGradient, menuPart.EndGradient);
                    }
                }
                else
                {
                    GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
        }

        private void DrawButton(Vector2 offset)
        {
            MenuButton menuPart = (MenuButton)data;
            // Calculate Areas
            int X = (int)(menuPart.RealPosition.X + offset.X);
            int Y = (int)(menuPart.RealPosition.Y + offset.Y);

            if (menuPart.SkinID > -1)
            {
                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                if (skin != null)
                {
                    if (skin.Button.Rounded)
                    {
                        // Load Textures
                        Texture2D left = GetTexture(skin.Button.LeftID);
                        Texture2D center = GetTexture(skin.Button.BackgroundID);
                        Texture2D right = GetTexture(skin.Button.RightID);

                        // Calculate areas
                        int centerStart = left.Width;
                        int rightStart = (int)menuPart.Width - right.Width;

                        int centerWidth = (int)menuPart.Width - right.Width - left.Width;
                        int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / center.Width));
                        int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                        // Draw Left
                        Global.SpriteBatch.Draw(left, new Rectangle((int)X, (int)Y, left.Width, (int)menuPart.Height), Color.White);

                        if (center.Name != "BLANK")
                        {
                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(X + centerStart + (i * center.Width)), (int)Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(X + centerStart + (fullCenterRepeats * center.Width)), (int)Y, (int)finalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            GraphicsHelper.FillGradient(new Rectangle((int)X + centerStart, (int)Y, (int)centerWidth, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                        }

                        // Draw Right
                        Global.SpriteBatch.Draw(right, new Rectangle((int)(X + rightStart), (int)Y, (int)right.Width, (int)menuPart.Height), Color.White);
                    }
                    else
                    {

                        // Load Textures
                        Texture2D center = GetTexture(skin.Button.BackgroundID);

                        if (center.Name != "BLANK")
                        {
                            // Calculate areas
                            int centerWidth = (int)menuPart.Width;
                            int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(X + (i * center.Width)), (int)Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(X + (fullCenterRepeats * center.Width)), (int)Y, (int)finalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                        }
                    }
                }
                else
                {
                    GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
        }
        #endregion

        #region Other
        private void DrawTextbox(Vector2 offset)
        {
            TextBoxPart menuPart = (TextBoxPart)data;
            // Calculate Areas
            int X = (int)(menuPart.RealPosition.X + offset.X);
            int Y = (int)(menuPart.RealPosition.Y + offset.Y);
            int textOffset = 0;

            #region Background

            if (menuPart.SkinID > -1)
            {
                SkinData skin = GameData.Skins.GetData(menuPart.SkinID);
                if (skin != null)
                {
                    textOffset = skin.Text.TextOffset;
                    if (skin.Text.Rounded)
                    {
                        // Load Textures
                        Texture2D left = GetTexture(skin.Text.LeftID);
                        Texture2D center = GetTexture(skin.Text.BackgroundID);
                        Texture2D right = GetTexture(skin.Text.RightID);

                        // Calculate areas
                        int centerStart = left.Width;
                        int rightStart = (int)menuPart.Width - right.Width;

                        int centerWidth = (int)menuPart.Width - right.Width - left.Width;
                        int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / center.Width));
                        int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                        // Draw Left
                        Global.SpriteBatch.Draw(left, new Rectangle((int)X, (int)Y, left.Width, (int)menuPart.Height), Color.White);

                        if (center.Name != "BLANK")
                        {
                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(X + centerStart + (i * center.Width)), (int)Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(X + centerStart + (fullCenterRepeats * center.Width)), (int)Y, (int)finalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            GraphicsHelper.FillGradient(new Rectangle((int)X + centerStart, (int)Y, (int)centerWidth, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                        }

                        // Draw Right
                        Global.SpriteBatch.Draw(right, new Rectangle((int)(X + rightStart), (int)Y, (int)right.Width, (int)menuPart.Height), Color.White);
                    }
                    else
                    {

                        // Load Textures
                        Texture2D center = GetTexture(skin.Text.BackgroundID);

                        if (center.Name != "BLANK")
                        {
                            // Calculate areas
                            int centerWidth = (int)menuPart.Width;
                            int fullCenterRepeats = (int)Math.Floor((double)(centerWidth / center.Width));
                            int finalCenterTexels = centerWidth - (center.Width * fullCenterRepeats);

                            // Draw Repeated Center
                            for (int i = 0; i < fullCenterRepeats; i++)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(X + (i * center.Width)), (int)Y, (int)center.Width, (int)menuPart.Height), Color.White);
                            }
                            // Draw Leftover Center
                            if (finalCenterTexels > 0)
                            {
                                Global.SpriteBatch.Draw(center, new Rectangle((int)(X + (fullCenterRepeats * center.Width)), (int)Y, (int)finalCenterTexels, (int)menuPart.Height),
                                    new Rectangle(0, 0, finalCenterTexels, center.Height), Color.White);
                            }
                        }
                        else
                        {
                            GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                        }
                    }
                }
                else
                {
                    GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
                }
            }
            else
            {
                GraphicsHelper.FillGradient(new Rectangle((int)X, (int)Y, (int)menuPart.Width, (int)menuPart.Height), menuPart.StartGradient, menuPart.EndGradient);
            }
            #endregion

            if (menuPart.String > -1)
                Text = Global.String(menuPart.String);
            string _text = Text;
            // If Password
            if (menuPart.PasswordChars)
            {
                int c = _text.Length; _text = "";
                for (int i = 0; i < c; i++) _text += "*";
            }
            // Draw Text
            FontData font;
            if (menuPart.Style > -1 && GameData.Fonts.TryGetValue(menuPart.Font, out font) && menuPart.Style < font.Styles.Count)
            {
                offset.X += 5 + textOffset;
                offset.Y += textOffset;
                SelectedIndex--;
                // Center Text
                offset.Y += menuPart.Height / 2 - TextSize.Y / 2;

                if (!string.IsNullOrEmpty(Text))
                {
                    TextSize = GraphicsHelper.DrawText(font, font.Styles[menuPart.Style], Text, menuPart.RealPosition + offset, menuPart.TextColor);
                    TextSize.X -= (menuPart.RealPosition.X + offset.X);
                }
                if (SelectedIndex > 0)
                {
                    Vector2 marker = new Vector2();
                    if (IndexLocation.X < _text.Length)
                    {
                        List<char> chrs = _text.ToCharArray().ToList();
                        if (IndexLocation.X > 0)
                            chrs.RemoveRange(IndexLocation.X - 1, chrs.Count - IndexLocation.X);
                        else
                            chrs.Clear();
                        string rt = new String(chrs.ToArray());

                        marker.X = GraphicsHelper.GetTextSize(font, font.Styles[menuPart.Style], rt).X - 1;
                        Global.SpriteBatch.DrawString(Content.SpriteFont(font.Styles[menuPart.Style].MaterialID), "|", menuPart.RealPosition + offset + marker, menuPart.TextColor);
                    }
                    else
                    {
                        marker.X = TextSize.X - 1;
                        Global.SpriteBatch.DrawString(Content.SpriteFont(font.Styles[menuPart.Style].MaterialID), "|", menuPart.RealPosition + offset + marker, menuPart.TextColor);
                    }
                }
                else if (SelectedIndex < -30)
                {
                    SelectedIndex = 30;
                }
            }
        }

        private void DrawImagePart(Vector2 offset)
        {
            ImagePart menuPart = (ImagePart)data;
            Texture2D icon = GetTexture(menuPart.Image);

            if (icon != null && icon.Name != "BLANK")
            {
                Global.SpriteBatch.Draw(icon, new Rectangle((int)menuPart.RealPosition.X + (int)offset.X, (int)menuPart.RealPosition.Y + (int)offset.Y, (int)menuPart.Width, (int)menuPart.Height), new Rectangle(0, 0, icon.Width, icon.Height), Color.White, 0, Vector2.Zero, (menuPart.VerticalFlip ? SpriteEffects.FlipVertically : menuPart.HorizontalFlip ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0f);
            }
        }

        private void DrawHighlighterStatic(Vector2 offset)
        {
            HighlighterStatic menuPart = (HighlighterStatic)data;
            Rectangle rect = new Rectangle((int)menuPart.RealPosition.X, (int)menuPart.RealPosition.Y, (int)menuPart.Size.X, (int)menuPart.Size.Y);
            Color c1;
            Color c2;
            if (!Enabled)
            {
                GraphicsHelper.DrawRectangle(GraphicsHelper.Texture, rect, menuPart.DisabledBorderColor);
                GraphicsHelper.FillGradient(rect, menuPart.DisabledStartGradient, menuPart.DisabledEndGradient);
            }
            else
            {
                GraphicsHelper.DrawRectangle(GraphicsHelper.Texture, rect, menuPart.HighlightBorderColor);
                if (HighlighterIndex == 0)
                {
                    HighlighterCount--;
                    c1 = menuPart.HighlightStartGradient;
                    c2 = menuPart.HighlightEndGradient;
                    c1.A -= HighlighterCount;
                    c2.A -= HighlighterCount;

                    if (HighlighterCount <= (menuPart.HighlightStartGradient.A > menuPart.HighlightEndGradient.A ? menuPart.HighlightEndGradient.A : menuPart.HighlightStartGradient.A) - 50)
                    {
                        HighlighterIndex = 1;
                        HighlighterCount = (byte)((menuPart.HighlightStartGradient.A > menuPart.HighlightEndGradient.A ? menuPart.HighlightEndGradient.A : menuPart.HighlightStartGradient.A) - 50);
                    }
                }
                else
                {
                    HighlighterCount++;
                    c1 = menuPart.HighlightStartGradient;
                    c2 = menuPart.HighlightEndGradient;
                    c1.A -= HighlighterCount;
                    c2.A -= HighlighterCount;
                    if (HighlighterCount >= menuPart.HighlightStartGradient.A)
                    {
                        HighlighterIndex = 0; HighlighterCount = (menuPart.HighlightStartGradient.A > menuPart.HighlightEndGradient.A ? menuPart.HighlightEndGradient.A : menuPart.HighlightStartGradient.A);
                    }
                }
                GraphicsHelper.FillGradient(rect, c1, c2);
            }
        }
        #endregion

        /// <summary>
        /// Returns the material's texture
        /// </summary>
        /// <param name="animationSprite"></param>
        /// <returns></returns>
        private Texture2D GetTexture(int materialId)
        {
            Texture2D tex = Content.Texture2D(materialId);
            if (tex == null) return BlankTexture;
            return tex;
        }
        Texture2D BlankTexture = new Texture2D(Global.Game.GraphicsDevice, 2, 2) { Name = "Blank" };
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

        /// <summary>
        /// Load Game
        /// </summary>
        public override void Load()
        {
            for (int i = 0; i < MenuParts.Count; i++)
            {
                MenuParts[i].ParentMenu = ParentMenu;
                MenuParts[i].Parent = this;
                MenuParts[i].data.Parent = data;
                MenuParts[i].Load();
            }
        }
    }
}